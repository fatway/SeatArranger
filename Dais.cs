using System;
using System.Drawing;

namespace SeatArranger
{
    /// <summary>
    /// 讲台
    /// </summary>
    public class Dais
    {
        public Dais()
        {
            this.Shape = MakeShape();
        }
        
        public Image Shape;

        //定位
        public int X = 0;
        public int Y = 0;
        
        public readonly int Width = 100, Height = 32;

        private Image MakeShape()
        {
            Image dais = new Bitmap(Width, Height);
            Graphics g = Graphics.FromImage(dais);
            g.Clear(Color.Wheat);

            g.DrawString("讲  台", new Font("宋体", 14), new SolidBrush(Color.Black), 18, 7);

            return dais;
        }
    }
}
