using System;
using System.Drawing;

namespace SeatArranger
{
    /// <summary>
    /// 座位
    /// </summary>
    public class Desk
    {
        public Desk()
        {
            isValued = true;
            Shape = MakeShape();
            
        }

        //定位
        public int X = 0;
        public int Y = 0;

        public readonly int width = 30, height = 62;
        
        public bool isValued;
        public Image Shape;


        private Image MakeShape()
        {
            Image img = new Bitmap(width, height);
            Graphics g = Graphics.FromImage(img);

            g.DrawRectangle(new Pen(Color.Wheat, 2f), new Rectangle(0, 0, width - 1, height - 1));

            return img;
        }
    }
}
