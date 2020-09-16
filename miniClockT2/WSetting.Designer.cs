namespace miniClockT2
{
    partial class WSetting
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
            this.trbHorizontal = new System.Windows.Forms.TrackBar();
            this.trbVertical = new System.Windows.Forms.TrackBar();
            this.trbSize = new System.Windows.Forms.TrackBar();
            ((System.ComponentModel.ISupportInitialize)(this.trbHorizontal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trbVertical)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trbSize)).BeginInit();
            this.SuspendLayout();
            // 
            // trbHorizontal
            // 
            this.trbHorizontal.Location = new System.Drawing.Point(12, 54);
            this.trbHorizontal.Maximum = 100;
            this.trbHorizontal.Name = "trbHorizontal";
            this.trbHorizontal.Size = new System.Drawing.Size(259, 45);
            this.trbHorizontal.TabIndex = 0;
            this.trbHorizontal.Value = 50;
            this.trbHorizontal.Scroll += new System.EventHandler(this.trbHorizontal_Scroll);
            // 
            // trbVertical
            // 
            this.trbVertical.Location = new System.Drawing.Point(12, 135);
            this.trbVertical.Maximum = 100;
            this.trbVertical.Name = "trbVertical";
            this.trbVertical.Size = new System.Drawing.Size(259, 45);
            this.trbVertical.TabIndex = 1;
            this.trbVertical.Value = 50;
            this.trbVertical.Scroll += new System.EventHandler(this.trbVertical_Scroll);
            // 
            // trbSize
            // 
            this.trbSize.Location = new System.Drawing.Point(12, 203);
            this.trbSize.Maximum = 100;
            this.trbSize.Minimum = 1;
            this.trbSize.Name = "trbSize";
            this.trbSize.Size = new System.Drawing.Size(259, 45);
            this.trbSize.TabIndex = 2;
            this.trbSize.Value = 10;
            this.trbSize.Scroll += new System.EventHandler(this.trbSize_Scroll);
            // 
            // WSetting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(283, 450);
            this.Controls.Add(this.trbSize);
            this.Controls.Add(this.trbVertical);
            this.Controls.Add(this.trbHorizontal);
            this.Name = "WSetting";
            this.Text = "WSetting";
            this.Load += new System.EventHandler(this.WSetting_Load);
            ((System.ComponentModel.ISupportInitialize)(this.trbHorizontal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trbVertical)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trbSize)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TrackBar trbHorizontal;
        private System.Windows.Forms.TrackBar trbVertical;
        private System.Windows.Forms.TrackBar trbSize;
    }
}