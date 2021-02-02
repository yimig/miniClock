using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using miniClockT2.Controls;

namespace miniClockT2.Windows
{
    public partial class TestForm : Form
    {
        public TestForm()
        {
            InitializeComponent();
            Graphics g = CreateGraphics();
            string strValue = "Hello World";
            StringFormat myformat = new StringFormat();
            myformat.Alignment = StringAlignment.Center;
            myformat.LineAlignment = StringAlignment.Center;
            myformat.FormatFlags = StringFormatFlags.FitBlackBox;

            Font fnt = new Font("宋体", 10f);
            Rectangle rect = new Rectangle(300, 300, 170, 30);

            SizeF size = g.MeasureString(strValue, fnt);
            Bitmap bit = new Bitmap((int)(size.Width), (int)(size.Height));
            Rectangle rectBase = new Rectangle(0, 0, bit.Width, bit.Height);
            Graphics gImage = Graphics.FromImage(bit);
            gImage.DrawString(strValue, fnt,
                Brushes.Black,
                rectBase, myformat);
            gImage.Save();

            //Stretch image to specific width
            rect.X = rect.Top + (rect.Height - rectBase.Height) / 2;
            rect.Height = rectBase.Height;
            g.DrawImage(bit, rect, rectBase, GraphicsUnit.Pixel);
            gImage.Dispose();
            bit.Dispose();
        }
    }
}
