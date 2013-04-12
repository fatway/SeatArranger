using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace SeatArranger
{
    /// <summary>
    /// Description of MainForm.
    /// </summary>
    public partial class MainForm : Form
    {
        List<Student> listStudent = new List<Student>();
        private string studentSaved = "Students.db";
        
        
        #region 构造、加载&退出重载
        
        public MainForm()
        {
            InitializeComponent();

        }
        
        void MainFormLoad(object sender, EventArgs e)
        {
            studentSaved = Application.StartupPath + "\\Students.db";
            ReadSavedStudentList();
            
            ReadGridViewStudents();
            
            panel2.Visible = false;
            
        }
        
        
        //关闭系统前，提示未保存的学生名单
        void MainFormFormClosing(object sender, FormClosingEventArgs e)
        {
            bool needAbort = false;
            bool needConform = false;
            
      
            if (!File.Exists(studentSaved)) {
                
                needConform = true;
            }
            else {
                
                //文件行数
                StreamReader sr = new StreamReader(studentSaved);
                string strFile = sr.ReadToEnd();
                string[] arraFile = strFile.Split('\n'); //or '\r '，仅限于读取Windows下的文件
                int iLine = arraFile.Length - 1;
                sr.Close();
                
                
                if (iLine != dataGridView1.Rows.Count) {
                    
                    needConform = true;
                }
                else {
                    
                    for (int i = 0; i < iLine; i++) {
                        
                        string[] cells = arraFile[i].TrimEnd('\r').Split(';');
                        
                        if (cells[0] == dataGridView1.Rows[i].Cells[0].Value.ToString() &&
                            cells[1] == dataGridView1.Rows[i].Cells[1].Value.ToString() &&
                            cells[2] == dataGridView1.Rows[i].Cells[2].Value.ToString()
                           )
                        {
                            continue;
                        }
                        else {
                            
                            needConform = true;
                            break;
                        }
                    }
                }
            }
            
            
            
            if (needConform)
                if (MessageBox.Show("系统检测到未保存的学生名单，如果不保存，下次启动将丢失编辑的信息。\n\n确定直接退出吗？",
                                    "提示",
                                    MessageBoxButtons.YesNo,
                                    MessageBoxIcon.Question) == DialogResult.No)
                    needAbort = true;
            
            
            if (needAbort)
            {
                e.Cancel = true;
            }
            else
            {
                this.Dispose();
                Application.Exit();
            }
        }

        #endregion
        
        
        
        #region 从本地文件读取学生 & 学生列表绘制
        
        //读取本地学生清单文件到列表
        private void ReadSavedStudentList()
        {
            if(!File.Exists(studentSaved))
                return;
            
            
            StreamReader stdReader = new StreamReader(studentSaved);
            string line = "";
            
            dataGridView1.Rows.Clear();
            
            while ((line = stdReader.ReadLine()) != null) {
                string[] info = line.Split(';');
                
                dataGridView1.Rows.Add(info[0], info[1], info[2]);

            }
            
            stdReader.Close();
        }
        

        //读取学生列表中的信息到内存中
        public void ReadGridViewStudents()
        {
            foreach (DataGridViewRow data in dataGridView1.Rows) {
                
                if (data.Cells[0].Value == null ||
                    data.Cells[1].Value == null ||
                    data.Cells[2].Value == null ||
                    data.Cells[0].Value.ToString() == "" ||
                    data.Cells[1].Value.ToString() == "" ||
                    data.Cells[2].Value.ToString() == ""
                   ) {
                    
                    continue;
                }
                
                
                try{
                    Student.Sex stdSex = (data.Cells[2].Value.ToString() == "男")? Student.Sex.male: Student.Sex.female;
                    
                    listStudent.Add(new Student(
                        int.Parse(data.Cells[0].Value.ToString()),
                        data.Cells[1].Value.ToString(),
                        stdSex));
                }
                catch(Exception)
                {
                    //
                }
                
            }
            
        }
        
        #endregion
        
        
        
        #region 设置讲台课桌
        
        //设置课桌
        void BtnPaintDeskClick(object sender, EventArgs e)
        {
            try{
                
                int row = int.Parse(txtDeskRow.Text);
                string col = txtDeskCol.Text;
                
                if (!CheckDeskColInput(col))
                    throw new Exception();
                
                classRoom1.deskRow = row;
                classRoom1.deskColFormat = col;


                classRoom1.Invalidate();
            }
            catch(Exception)
            {
                MessageBox.Show("输入的“行 or 列”格式有误", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        
        //检查输入的课桌列格式
        bool CheckDeskColInput(string col)
        {
            return Regex.IsMatch(col, @"\d+(/\d)*");
        }
        
        #endregion
        
        
        
        #region 学生列表信息处理
        
        //添加学生信息
        void BtnStudentAddClick(object sender, EventArgs e)
        {
            int idx = dataGridView1.Rows.Add();
            dataGridView1.Rows[idx].Selected = true;
            dataGridView1.FirstDisplayedScrollingRowIndex = idx;
        }
        
        
        //删除学生信息
        void BtnStudentDelClick(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dataGridView1.SelectedRows) {
                dataGridView1.Rows.Remove(row);
            }
        }
        
        
        //保存学生清单
        void BtnSaveStudentListClick(object sender, EventArgs e)
        {
            StreamWriter stdWriter = new StreamWriter(studentSaved, false);
            
            foreach (DataGridViewRow data in dataGridView1.Rows) {
                
                if (data.Cells[0].Value == null ||
                    data.Cells[1].Value == null ||
                    data.Cells[2].Value == null ||
                    data.Cells[0].Value.ToString() == "" ||
                    data.Cells[1].Value.ToString() == "" ||
                    data.Cells[2].Value.ToString() == ""
                   ) {
                    
                    MessageBox.Show("无法保存，存在不完整的学生信息", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    
                    stdWriter.Close();
                    return;
                }
                
                stdWriter.WriteLine("{0};{1};{2}", data.Cells[0].Value.ToString(), data.Cells[1].Value.ToString(), data.Cells[2].Value.ToString());
            }
            
            stdWriter.Close();
            MessageBox.Show("保存成功", "提示");
        }
        
        
        
        //在候选区描绘学生卡
        void BtnPaintStudentClick(object sender, EventArgs e)
        {
            if(dataGridView1.Rows.Count > 0)
            {
                listStudent.Clear();
                //classRoom1.listStudent.Clear();
                
                ReadGridViewStudents();
                
                classRoom1.listStudent = listStudent;
                classRoom1.InitStudentInCandidate();
            }
            
            classRoom1.Invalidate();
        }
        
        #endregion
        
        
        
        #region 方案读取、保存、打印
        
        //加载新方案
        void BtnReadNewProjectClick(object sender, EventArgs e)
        {
            
            if(MessageBox.Show(
                "加载方案将会替换掉当前所有的学生及座位信息，确认执行该操作？",
                "提示",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Information
               ) == DialogResult.No)
                return;
            
            //
            OpenFileDialog prj = new OpenFileDialog();
            prj.Filter = "*.prj|*.prj";
            prj.Title = "指加需要加载的方案文件";
            
            if (prj.ShowDialog() == DialogResult.Cancel)
                return;
            
            
            int deskR = 0;
            string deskC = "";
            List<Student> listStd = new List<Student>();
            
            if (Project.Read(prj.FileName, out deskR, out deskC, out listStd)) {
                
                //设置课桌
                classRoom1.deskRow = deskR;
                txtDeskRow.Text = deskR.ToString();
                classRoom1.deskColFormat = txtDeskCol.Text = deskC;
                
                
                //显示学生名单
                dataGridView1.Rows.Clear();
                
                foreach (Student std in listStd) {
                    string sexstr = (std.sex == Student.Sex.male)? "男": "女";
                    
                    dataGridView1.Rows.Add(std.id, std.name, sexstr);
                }
                
                
                //绘制学生卡
                classRoom1.listStudent = listStd;
                classRoom1.InitStudentInCandidate(false);
                
                
                //刷新显示
                classRoom1.Invalidate();
            }
            else
                MessageBox.Show("加载方案失败", "提示");
        }
        
        
        
        //保存当前方案
        void BtnSaveProjectClick(object sender, EventArgs e)
        {

            if(MessageBox.Show(
                "方案保存时不会存储信息不完整的学生，确认执行该操作？",
                "提示",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Information
               ) == DialogResult.No)
                return;
            
            SaveFileDialog prj = new SaveFileDialog();
            prj.Filter = "*.prj|*.prj";
            prj.FileName = "排座方案" + DateTime.Now.ToShortDateString().Replace('/','-') + ".prj";
            prj.Title = "保存排座方案";
            
            if (prj.ShowDialog() == DialogResult.Cancel)
                return;
            
            
            Project.Save(prj.FileName, int.Parse(txtDeskRow.Text), txtDeskCol.Text, listStudent);
            
            MessageBox.Show("保存成功", "提示");
            
        }
        
        
        //打印当前布置
        void BtnPrintProjectClick(object sender, EventArgs e)
        {
            Image prt = classRoom1.GetSeatRangeImage4Print();
            if (prt == null)
                return;

            PrintForm printer = new PrintForm(prt);
            printer.ShowDialog();
        }
        
        #endregion



        #region 整体移动已设置好的座位

        void ButtonMoveUpClick(object sender, EventArgs e)
        {
            classRoom1.MoveStudentSeatPosition(ClassRoom.SeatMoveType.Up);
        }
        
        void ButtonMoveDownClick(object sender, EventArgs e)
        {
            classRoom1.MoveStudentSeatPosition(ClassRoom.SeatMoveType.Down);
        }
        
        void ButtonMoveLeftClick(object sender, EventArgs e)
        {
            classRoom1.MoveStudentSeatPosition(ClassRoom.SeatMoveType.Left);
        }
        
        void ButtonMoveRightClick(object sender, EventArgs e)
        {
            classRoom1.MoveStudentSeatPosition(ClassRoom.SeatMoveType.Right);
        }
        
        void LblShowMoveClick(object sender, EventArgs e)
        {
            if (lblShowMove.Text == "<<") {
                
                panel2.Visible = true;
                lblShowMove.Text = ">>";
            }
            else {
                
                panel2.Visible = false;
                lblShowMove.Text = "<<";
            }
        }

        #endregion

        
        
        #region 随机排座
        
        void BtnRandomArrangClick(object sender, EventArgs e)
        {
            
            if (MessageBox.Show("亲，随机排座会将之前的辛苦排列工作给打乱，确定执行该操作？", "提示",
                                MessageBoxButtons.YesNo, MessageBoxIcon.Information
               ) == DialogResult.No) {
                return;
            }
            
            classRoom1.RandomArrangerStudents();
        }
        
        #endregion
    }
}
