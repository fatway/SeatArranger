using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace SeatArranger
{
    /// <summary>
    /// 教室控件
    /// </summary>
    public partial class ClassRoom : UserControl
    {
        
        #region 全局变量
        
        
        //用于显示的数据源
        public List<Student> listStudent;
        private List<Student> listStudentBackup;

        private Dais dais;
        private List<Desk> listDesk;

        public int deskRow = 0;
        public int deskCol = 0;
        public string deskColFormat = "";
        
        //检测移动的位置点
        Point startPoint;
        
        //打印区
        public Rectangle printRange;
        
        
        //移动座位类型
        public enum SeatMoveType
        {
            Left,
            Right,
            Up,
            Down
        }

        #endregion
        
        
        
        #region 构造
        
        //构造
        public ClassRoom()
        {
            
            InitializeComponent();
 

            listStudent = new List<Student>();
            listStudentBackup = new List<Student>();
            dais = new Dais();
            listDesk = new List<Desk>();
            
            
            
            printRange = new Rectangle(0,0,0,0);
            
            

            //鼠标事件
            this.MouseDown += new MouseEventHandler(this.roomMouseDown);
            this.MouseMove += new MouseEventHandler(this.roomMouseMove);
            this.MouseUp += new MouseEventHandler(this.roomMouseUp);
            //this.MouseDoubleClick += new MouseEventHandler(this.roomMouseDoubleClick);
        }

        #endregion
        
        
        
        #region 控件绘图
        
        //重载背景绘制，在绘图前不擦除背景，避免绘图闪烁
        protected override void OnPaintBackground(PaintEventArgs e)
        {
            return;
        }

        
        //重载绘图方法
        protected override void OnPaint(PaintEventArgs pe)
        {
            //使用双缓冲绘图
            BufferedGraphicsContext currentContext = BufferedGraphicsManager.Current;
            BufferedGraphics bufg = currentContext.Allocate(pe.Graphics, this.ClientRectangle);
            Graphics g = bufg.Graphics;
            g.Clear(Color.White);


            //开启抗锯齿
            g.SmoothingMode = SmoothingMode.AntiAlias;


            int CandidateStartX = 242;  //候选区与教室分界线
            
            //绘制候选区与教室区
            g.DrawString("候选区", new Font("宋体", 14), new SolidBrush(Color.Black), 1, 1);
            g.DrawLine(new Pen(Color.Black, 5f), new Point(CandidateStartX, 0), new Point(CandidateStartX, this.Height));
            g.DrawString("课室", new Font("宋体", 14), new SolidBrush(Color.Black), CandidateStartX + 3, 1);

            
            //绘制学生卡
            if (listStudent != null || listStudent.Count > 0)
            {
                int stdCount = listStudent.Count;
                Hashtable hash = new Hashtable();

                
                for (int s = 0; s < stdCount; s++)
                {

                    g.DrawImage(listStudent[s].Shape, listStudent[s].X, listStudent[s].Y);
                    
                    
                    //重叠学生处理
                    try{
                        hash.Add(listStudent[s].X.ToString() + "," + listStudent[s].Y.ToString(), null);
                    }
                    catch(Exception)
                    {
                        g.FillRectangle(new SolidBrush(Color.FromArgb(150, 0, 220, 0)),
                                        listStudent[s].X,
                                        listStudent[s].Y,
                                        listStudent[s].width,
                                        listStudent[s].height
                                       );
                    }
                }
                
            }
            
            

            
            //绘制讲台与课桌
            InitDeskAndDais(ref g);
            


            //实际描绘到视图
            bufg.Render(pe.Graphics);
            g.Dispose();
            bufg.Dispose();

        }



        //绘制课桌与讲台
        private void InitDeskAndDais(ref Graphics gDesk)
        {
            
            string[] deskColGroup = deskColFormat.Split('/');
            
            if (deskColFormat.Trim() == "" || deskColGroup.Length == 0) {
                return;
            }
            
            int steps = deskColGroup.Length;
            int[] deskColSteps = new int[steps];
            deskCol = 0;
            
            try {
                
                for (int s = 0; s < steps; s++) {
                    deskColSteps[s] = int.Parse(deskColGroup[s]);
                    deskCol += deskColSteps[s];
                }
                
            } catch (Exception) {
                
                //MessageBox
                return;
            }
            
            
            
            if(deskRow * deskCol == 0)
                return;
            
            
            
            //根据行列数据初始课桌列表
            listDesk.Clear();
            for (int i = 0; i < deskRow * deskCol; i++)
            {
                Desk desk = new Desk();
                listDesk.Add(desk);
            }


            //起点位置
            int daisStartY = 30;
            
            int deskStartX = 290;
            int deskStartY = daisStartY + dais.Height + 25;
            
            //间距
            int deskDistX = 15;
            int deskDistY = 15;
            
            
            int colCenter = 0;  //讲台中心

            //分别绘制
            for (int row = 0; row < deskRow; row++)
            {
                int colPosition = 0;
                
                for (int col = 0; col < deskCol; col++)
                {
                    int order = row * deskCol + col;

                    if (!listDesk[order].isValued)
                        continue;
                    
                    
                    int px = deskStartX + colPosition;
                    int py = deskStartY + (listDesk[order].height + deskDistY) * row;

                    listDesk[order].X = px;
                    listDesk[order].Y = py;

                    gDesk.DrawImage(listDesk[order].Shape, px, py);
                    
                    
                    //移动X位置
                    colPosition += listDesk[order].width + deskDistX;
                    
                    //遇到分组时多进一个间距
                    int rDis = 0;
                    for (int r = 0; r < deskColSteps.Length - 1; r++) {
                        rDis += deskColSteps[r];
                        
                        if (col == rDis - 1) {
                            
                            colPosition += deskDistX;
                            break;
                        }
                    }
                }
                
                
                //确定讲桌中心
                colCenter = (colPosition - deskDistX) / 2;
            }
            
            
            
            //根据课桌中心位置绘制讲台
            //int colCenter = deskStartX + (deskDistX * (deskCol-1) + 30) / 2;
            int daisStartX = colCenter - dais.Width/2;
            daisStartX = daisStartX < 0? 0: daisStartX;
            dais.X = deskStartX + daisStartX;
            dais.Y = daisStartY;
            gDesk.DrawImage(dais.Shape, dais.X, dais.Y);
            
            
            //计算打印区域
            int printExtend = 20;       //扩边范围
            int printXmin = listDesk[0].X - printExtend;
            int printXmax = listDesk[listDesk.Count - 1].X + listDesk[0].width + printExtend;
            int printYmin = dais.Y - printExtend;
            int printYmax = listDesk[listDesk.Count - 1].Y + listDesk[0].height + printExtend;
            printRange = new Rectangle(printXmin, printYmin, printXmax - printXmin, printYmax - printYmin);

        }


        
        //在候选区绘制所有学生卡
        public void InitStudentInCandidate(bool inCandidate = true)
        {
            if(listStudent == null || listStudent.Count == 0)
                return;
            
            listStudentBackup.Clear();
            
            
            //创建备份学生表
            foreach (Student std in listStudent) {
                listStudentBackup.Add(std.Clone());
            }
            
            
            //设置【备份】的学生位置到候选区
            int startX = 1;
            int startY = 30;
            
            int stepX = 2;
            int stepY = 5;
            
            for (int i = 0; i < listStudentBackup.Count; i++)
            {
                
                listStudentBackup[i].X = startX;
                listStudentBackup[i].Y = startY;

                
                startX += listStudent[i].width + stepX;
                
                
                if ((i+1) % 8 == 0) {
                    
                    startX = 1;
                    startY += listStudent[i].height + stepY;
                    
                }
            }
            
            
            //将学生卡片绘制到候选区
            if(inCandidate)
            {
                for (int i = 0; i < listStudent.Count; i++) {
                    
                    listStudent[i].X = listStudentBackup[i].X;
                    listStudent[i].Y = listStudentBackup[i].Y;
                }
            }
        }
        
        #endregion
        
        

        #region 鼠标事件
        
        //鼠标按下事件
        private void roomMouseDown(object sender, MouseEventArgs e)
        {
            //屏蔽鼠标右键
            if (e.Button == MouseButtons.Right)
            {
                //将学生卡位置重置
                for (int i = 0; i < listStudent.Count; i++)
                {
                    if (e.X >= listStudent[i].X && e.X <= listStudent[i].X + listStudent[i].width &&
                        e.Y >= listStudent[i].Y && e.Y <= listStudent[i].Y + listStudent[i].height)
                    {
                        listStudent[i].X = listStudentBackup[i].X;
                        listStudent[i].Y = listStudentBackup[i].Y;
                    }
                }



                this.Invalidate();


                return;
            }

            foreach (Student std in listStudent)
            {
                if (e.X >= std.X && e.X <= std.X + std.width &&
                    e.Y >= std.Y && e.Y <= std.Y + std.height)

                    std.isSelected = true;
            }

            startPoint = new Point(e.X, e.Y);
        }

        
        //鼠标移动事件
        private void roomMouseMove(object sender, MouseEventArgs e)
        {
            foreach (Student std in listStudent)
            {
                if (std.isSelected)
                {
                    int dx = startPoint.X - std.X;
                    int dy = startPoint.Y - std.Y;

                    std.X = e.X - dx;
                    std.Y = e.Y - dy;
                }
            }

            startPoint = new Point(e.X, e.Y);

            this.Invalidate();
        }

        //鼠标抬起事件
        private void roomMouseUp(object sender, MouseEventArgs e)
        {
            foreach (Student std in listStudent)
            {
                if (std.isSelected == false)
                    continue;

                //停靠最近的课桌
                foreach (Desk desk in listDesk)
                {
                    if (e.X >= desk.X - 5 && e.X <= desk.X + desk.width - 5 &&
                        e.Y >= desk.Y - 5 && e.Y <= desk.Y + desk.height - 5)
                    {
                        std.X = desk.X + 1;
                        std.Y = desk.Y + 1;

                        break;
                    }

                }

                std.isSelected = false;
            }

            this.Invalidate();
        }


        //鼠标双击事件
        private void roomMouseDoubleClick(object sender, MouseEventArgs e)
        {
            //将学生卡位置重置
            for (int i = 0; i < listStudent.Count; i++)
            {
                if (e.X >= listStudent[i].X && e.X <= listStudent[i].X + listStudent[i].width &&
                    e.Y >= listStudent[i].Y && e.Y <= listStudent[i].Y + listStudent[i].height)
                {
                    listStudent[i].X = listStudentBackup[i].X;
                    listStudent[i].Y = listStudentBackup[i].Y;
                }
            }



            this.Invalidate();
        }

        #endregion



        #region 整体移动分配好的座位

        //获取移动座位后的课座号
        private int MoveedSeatIndex(int seatIndex, SeatMoveType moveType)
        {
            /**
             *   | 0   1   2   3   : col=4
             * --|---------------
             * 0 | 0   1   2   3
             * 1 | 4  [5]  6   7
             * 2 | 8   9   10  11
             * 
             * row=3
             */
            
            if (deskRow * deskCol == 0) {
                throw new Exception("座位数有误，无法移动");
            }
            
            
            int curRow = seatIndex / deskCol;
            int curCol = seatIndex % deskCol;
            
            
            switch (moveType) {
                case ClassRoom.SeatMoveType.Left:
                    
                    curCol -= 1;
                    curCol = (curCol < 0)? deskCol - 1: curCol;
                    
                    break;
                case ClassRoom.SeatMoveType.Right:
                    
                    curCol += 1;
                    curCol = (curCol >= deskCol)? 0: curCol;
                    
                    break;
                case ClassRoom.SeatMoveType.Up:
                    
                    curRow -= 1;
                    curRow = (curRow < 0)? deskRow - 1: curRow;
                    
                    break;
                case ClassRoom.SeatMoveType.Down:
                    
                    curRow += 1;
                    curRow = (curRow >= deskRow)? 0: curRow;
                    
                    break;
                default:
                    throw new Exception("无效的移动");
            }
            
            
            return curRow * deskCol + curCol;
        }
        
        
        //检查调皮学生（未就座 -1 / 正常 0 / 重复座 1）
        private int CheckStudentInClass()
        {
            //绘制学生卡
            if (listStudent == null || listStudent.Count <= 0)
                return -1;
            

            Hashtable hash = new Hashtable();
            
            foreach (Student std in listStudent) {
                
                bool inSeat = false;
                
                foreach (Desk desk in listDesk) {
                    
                    if (std.X == desk.X + 1  && std.Y == desk.Y + 1)
                    {
                        inSeat = true;
                        break;
                    }
                }
                
                if (!inSeat) {
                    return -1;
                }
                
                //重叠
                try
                {
                    hash.Add(std.X.ToString() + "," + std.Y.ToString(), null);
                }
                catch(Exception)
                {
                    return 1;
                }
            }
            
            
            return 0;
            
        }
        
        
        //移动座位
        public void MoveStudentSeatPosition(SeatMoveType moveType)
        {
            int valued = CheckStudentInClass();
            
            if (valued == -1) {
                MessageBox.Show("无法移动，有学生未就座");
                return;
            }
            
            if (valued == 1) {
                MessageBox.Show("无法移动，有座位被两人抢了");
                return;
            }
            

            foreach (Student std in listStudent) {
                
                int curSeat = 0;
                
                for (int i = 0; i < listDesk.Count; i++) {
                    
                    if (std.X == listDesk[i].X + 1 && std.Y == listDesk[i].Y + 1) {
                        
                        curSeat = i;
                        break;
                    }
                }
                
                int newSeat = MoveedSeatIndex(curSeat, moveType);
                
                std.X = listDesk[newSeat].X + 1;
                std.Y = listDesk[newSeat].Y + 1;
            }
            
            this.Invalidate();
        }

        #endregion

    }
}
