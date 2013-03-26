using System;
using System.Drawing;

namespace SeatArranger
{
    /// <summary>
    /// 学生
    /// </summary>
    public class Student
    {
        
        public Student(int id, string name, Sex sex)
        {
            this._id = id;
            this._name = name;
            this._sex = sex;
            this.shape = MakeShape();
        }

        //图形大小
        public readonly int width = 28, height = 60;

        //定位
        public int X = 0;
        public int Y = 0;

        //是否被选中
        public bool isSelected = false;
        
        
        //学号
        int _id;
        public int id {
            get { return _id; }
        }
        
        
        //姓名
        string _name;
        public string name {
            get { return _name; }
        }
        
        
        //性别
        Sex _sex;
        public Sex sex {
            get { return _sex; }
        }
        
        
        //扩展：视力、性格、成绩
        
        
        //图形
        Image shape;
        
        public Image Shape {
            get { return shape; }
        }



        //性别类型
        public enum Sex
        {
            male,
            female
        }
        
        
        //根据学生信息制作图像
        public Image MakeShape()
        {
            Color stdColor = _sex == Sex.male ? Color.LightSkyBlue : Color.Pink;

            Image stdImg = new Bitmap(width, height);
            Graphics g = Graphics.FromImage(stdImg);
            g.Clear(stdColor);
            

            SolidBrush brush = new SolidBrush(Color.Black);
            Font font = new Font("宋体", 10);

            if (_name.Length == 2)
            {
                char[] cname = _name.ToCharArray();
                _name = string.Join(" ", new string[] { cname[0].ToString(), cname[1].ToString() });
            }

            if (_name.Length > 3)
            {
                _name = _name.Substring(0, 2) + "…";
            }

            for (int i = 0; i < _name.Length; i++)
            {
                g.DrawString(_name[i].ToString(), font, brush, 6, 8 + i*16);
            }
            

            return stdImg;

        }


        public Student Clone()
        {
            return new Student(_id, _name, _sex); 
        }
    }
}
