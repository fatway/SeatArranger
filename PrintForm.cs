using System;
using System.Drawing;
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
        
        Image prtImg;
        
        
        
        void PrintFormLoad(object sender, EventArgs e)
        {
            this.pictureBox1.Size = prtImg.Size;
            this.Size = new Size(prtImg.Size.Width + 40, prtImg.Size.Height + 100);
            
            
            this.pictureBox1.Image = prtImg;
            
        }
        
        
        void Button1Click(object sender, EventArgs e)
        {
            PrintDialog dialog = new PrintDialog();
            
            PrintDocument docToPrint = new PrintDocument();
            docToPrint.DocumentName = "座位表";
            docToPrint.PrintPage += new PrintPageEventHandler(PrintDocument1PrintPage);

            dialog.Document = docToPrint;
            
            dialog.ShowDialog();
        }
        
        
        void PrintDocument1PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            e.Graphics.DrawImage(prtImg, 20, 20);
        }
        
        
        void Button2Click(object sender, EventArgs e)
        {
            this.Close();
        }
        
        
    }
}
