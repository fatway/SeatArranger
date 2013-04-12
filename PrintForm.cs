using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Printing;
using System.Windows.Forms;

namespace SeatArranger
{
    /// <summary>
    /// Description of PrintForm.
    /// </summary>
    public partial class PrintForm : Form
    {
        public PrintForm(Image prtImg)
        {
            InitializeComponent();
            this.prtImg = prtImg;
        }
        
        private Image prtImg;
        
        
        
        void PrintFormLoad(object sender, EventArgs e)
        {
            this.pictureBox1.Size = prtImg.Size;
            this.Size = new Size(prtImg.Size.Width + 40, prtImg.Size.Height + 140);
            
            
            this.pictureBox1.Image = prtImg;
        }
        
        
        void Button1Click(object sender, EventArgs e)
        {
            this.printDocument1.DefaultPageSettings.PaperSize = new PaperSize("A4", 794, 1123); //96dpi
            printDocument1.DocumentName = "座位表";
            printDocument1.PrintPage += new PrintPageEventHandler(PrintDocument1PrintPage);


            PrintDialog dialog = new PrintDialog();
            dialog.Document = printDocument1;

            if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                printDocument1.Print();
            }
        }
        
        
        void PrintDocument1PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            
            //设A4纸大小为800*1100，中间打印区域大小为740*1000
            int printWidth = e.MarginBounds.Width;
            int printHeight = e.MarginBounds.Height;

            Bitmap img = new Bitmap(printWidth, printHeight);
            Graphics g = Graphics.FromImage(img);
            g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.High;
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;


            //标题
            string title = textBox1.Text;
            //string title = "华业龙图员工座位表";
            Font font = new Font("黑体", 24f);

            Size sz = TextRenderer.MeasureText(title, font);
            g.DrawString(title, font, Brushes.Black, (printWidth - sz.Width) / 2, 0);
            

            //将课座位表图片prtImg调整大小，注意比例不变
            int titleSpace = 25;

            int x_start, y_start, x_width, y_height; 
            ReSizePrintImage(prtImg, printWidth, printHeight - titleSpace, 
                out x_start, out y_start, out x_width, out y_height);

            if (title != "")
                y_start += titleSpace;

            g.DrawImage(prtImg, x_start, y_start, x_width, y_height);


            //e.Graphics.DrawLine(Pens.Black, 0, 0, e.MarginBounds.Left, e.MarginBounds.Top);
            e.Graphics.DrawImage(img, e.MarginBounds.Left / 2, e.MarginBounds.Top);
        }


        //调整图片为打印区域大小（放大并居中）
        private void ReSizePrintImage(Image prtImg, int destWidth, int destHeight, 
            out int x_start, out int y_start, out int x_width, out int y_height)
        {
            //throw new NotImplementedException();

            x_start = 0;
            y_start = 0; 
            x_width = 0;
            y_height = 0;

            double xScale = destWidth / (double)prtImg.Width;
            double yScale = destHeight / (double)prtImg.Height;

            if (xScale <= yScale)  //上下留白
            {
                int yLength = Convert.ToInt32(prtImg.Height * xScale);

                x_start = 0;
                y_start = (destHeight - yLength) / 2;
                x_width = destWidth;
                y_height = yLength;
            }
            else   //左右留白
            {
                int xLength = Convert.ToInt32(prtImg.Width * yScale);

                x_start = (destWidth - xLength) / 2;
                y_start = 0;
                x_width = xLength;
                y_height = destHeight;
            }
        }
        
        
        


        //导出图片
        void btnSaveImg_Click(object sender, EventArgs e)
        {
            if (prtImg == null)
                return;
            
            Image savedImg = new Bitmap(prtImg.Width + 60, prtImg.Height + 60);
            Graphics sGraphics = Graphics.FromImage(savedImg);
            sGraphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.High;
            sGraphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            sGraphics.DrawImage(prtImg, 30, 30);
            

            SaveFileDialog save = new SaveFileDialog();
            save.Filter = "*.jpg|*.jpg";
            save.FileName = "座位表" + DateTime.Now.ToShortDateString().Replace('/', '-');
            

            if (save.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                //处理JPG质量的函数
                int level = 100; //图像质量 1-100的范围
                ImageCodecInfo[] codecs = ImageCodecInfo.GetImageEncoders();
                ImageCodecInfo ici = null;
                foreach (ImageCodecInfo codec in codecs)
                {
                    if (codec.MimeType == "image/jpeg")
                        ici = codec;
                }
                EncoderParameters ep = new EncoderParameters();
                ep.Param[0] = new EncoderParameter(System.Drawing.Imaging.Encoder.Quality, (long)level);
                

                savedImg.Save(save.FileName, ici, ep);
            }
            
            sGraphics.Dispose();
            savedImg.Dispose();
        }


        //关闭
        void Button2Click(object sender, EventArgs e)
        {
            this.Close();
        }
        
    }
}
