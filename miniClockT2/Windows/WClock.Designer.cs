namespace miniClockT2
{
    partial class WClock
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.lbHour = new System.Windows.Forms.Label();
            this.lbColon1 = new System.Windows.Forms.Label();
            this.lbMinute = new System.Windows.Forms.Label();
            this.lbColon2 = new System.Windows.Forms.Label();
            this.lbSecond = new System.Windows.Forms.Label();
            this.tableLayoutPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel
            // 
            this.tableLayoutPanel.ColumnCount = 5;
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel.Controls.Add(this.lbSecond, 4, 0);
            this.tableLayoutPanel.Controls.Add(this.lbColon2, 3, 0);
            this.tableLayoutPanel.Controls.Add(this.lbMinute, 2, 0);
            this.tableLayoutPanel.Controls.Add(this.lbColon1, 1, 0);
            this.tableLayoutPanel.Controls.Add(this.lbHour, 0, 0);
            this.tableLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel.Name = "tableLayoutPanel";
            this.tableLayoutPanel.RowCount = 1;
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel.Size = new System.Drawing.Size(500, 100);
            this.tableLayoutPanel.TabIndex = 0;
            // 
            // lbHour
            // 
            this.lbHour.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbHour.BackColor = System.Drawing.SystemColors.Control;
            this.lbHour.Font = new System.Drawing.Font("宋体", 50F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(134)));
            this.lbHour.Location = new System.Drawing.Point(0, 0);
            this.lbHour.Margin = new System.Windows.Forms.Padding(0);
            this.lbHour.Name = "lbHour";
            this.lbHour.Size = new System.Drawing.Size(50, 100);
            this.lbHour.TabIndex = 5;
            this.lbHour.Text = "00";
            // 
            // lbColon1
            // 
            this.lbColon1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbColon1.BackColor = System.Drawing.SystemColors.Control;
            this.lbColon1.Font = new System.Drawing.Font("宋体", 50F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(134)));
            this.lbColon1.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.lbColon1.Location = new System.Drawing.Point(50, 0);
            this.lbColon1.Margin = new System.Windows.Forms.Padding(0);
            this.lbColon1.Name = "lbColon1";
            this.lbColon1.Size = new System.Drawing.Size(50, 100);
            this.lbColon1.TabIndex = 8;
            this.lbColon1.Text = ":";
            // 
            // lbMinute
            // 
            this.lbMinute.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbMinute.BackColor = System.Drawing.SystemColors.Control;
            this.lbMinute.Font = new System.Drawing.Font("宋体", 50F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(134)));
            this.lbMinute.Location = new System.Drawing.Point(100, 0);
            this.lbMinute.Margin = new System.Windows.Forms.Padding(0);
            this.lbMinute.Name = "lbMinute";
            this.lbMinute.Size = new System.Drawing.Size(50, 100);
            this.lbMinute.TabIndex = 6;
            this.lbMinute.Text = "00";
            // 
            // lbColon2
            // 
            this.lbColon2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbColon2.BackColor = System.Drawing.SystemColors.Control;
            this.lbColon2.Font = new System.Drawing.Font("宋体", 50F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(134)));
            this.lbColon2.Location = new System.Drawing.Point(150, 0);
            this.lbColon2.Margin = new System.Windows.Forms.Padding(0);
            this.lbColon2.Name = "lbColon2";
            this.lbColon2.Size = new System.Drawing.Size(50, 100);
            this.lbColon2.TabIndex = 9;
            this.lbColon2.Text = ":";
            // 
            // lbSecond
            // 
            this.lbSecond.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbSecond.BackColor = System.Drawing.SystemColors.Control;
            this.lbSecond.Font = new System.Drawing.Font("宋体", 50F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(134)));
            this.lbSecond.Location = new System.Drawing.Point(200, 0);
            this.lbSecond.Margin = new System.Windows.Forms.Padding(0);
            this.lbSecond.Name = "lbSecond";
            this.lbSecond.Size = new System.Drawing.Size(300, 100);
            this.lbSecond.TabIndex = 7;
            this.lbSecond.Text = "00";
            // 
            // WClock
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(500, 100);
            this.Controls.Add(this.tableLayoutPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "WClock";
            this.Opacity = 0.5D;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "WClock";
            this.TopMost = true;
            this.tableLayoutPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel;
        private System.Windows.Forms.Label lbSecond;
        private System.Windows.Forms.Label lbColon2;
        private System.Windows.Forms.Label lbMinute;
        private System.Windows.Forms.Label lbColon1;
        private System.Windows.Forms.Label lbHour;
    }
}