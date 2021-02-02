using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace miniClockT2.Controls
{
    public partial class SpacingEditableLabel : Label
    {
        public double WordSpacing { get; set; }

        public SpacingEditableLabel()
        {
            InitializeComponent();
        }

        public SpacingEditableLabel(double wordSpacing)
        {
            InitializeComponent();
            WordSpacing = wordSpacing;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            

        }
    }
}
