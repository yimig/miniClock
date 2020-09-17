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
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tbpControl = new System.Windows.Forms.TabPage();
            this.label6 = new System.Windows.Forms.Label();
            this.trbOpacity = new System.Windows.Forms.TrackBar();
            this.label5 = new System.Windows.Forms.Label();
            this.btnSelectFont = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.trbFontSize = new System.Windows.Forms.TrackBar();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lbColor1 = new System.Windows.Forms.Label();
            this.lbColor5 = new System.Windows.Forms.Label();
            this.lbColor4 = new System.Windows.Forms.Label();
            this.lbColor3 = new System.Windows.Forms.Label();
            this.lbColor2 = new System.Windows.Forms.Label();
            this.lbNowColor = new System.Windows.Forms.Label();
            this.btnSelectColor = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tbpAbout = new System.Windows.Forms.TabPage();
            this.btnSave = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.trbHorizontal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trbVertical)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trbSize)).BeginInit();
            this.tabControl.SuspendLayout();
            this.tbpControl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trbOpacity)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trbFontSize)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // trbHorizontal
            // 
            this.trbHorizontal.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.trbHorizontal.Location = new System.Drawing.Point(51, 18);
            this.trbHorizontal.Maximum = 100;
            this.trbHorizontal.Name = "trbHorizontal";
            this.trbHorizontal.Size = new System.Drawing.Size(194, 45);
            this.trbHorizontal.TabIndex = 0;
            this.trbHorizontal.Value = 50;
            this.trbHorizontal.Scroll += new System.EventHandler(this.trbHorizontal_Scroll);
            // 
            // trbVertical
            // 
            this.trbVertical.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.trbVertical.Location = new System.Drawing.Point(51, 69);
            this.trbVertical.Maximum = 100;
            this.trbVertical.Name = "trbVertical";
            this.trbVertical.Size = new System.Drawing.Size(194, 45);
            this.trbVertical.TabIndex = 1;
            this.trbVertical.Value = 50;
            this.trbVertical.Scroll += new System.EventHandler(this.trbVertical_Scroll);
            // 
            // trbSize
            // 
            this.trbSize.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.trbSize.Location = new System.Drawing.Point(51, 120);
            this.trbSize.Maximum = 100;
            this.trbSize.Minimum = 1;
            this.trbSize.Name = "trbSize";
            this.trbSize.Size = new System.Drawing.Size(194, 45);
            this.trbSize.TabIndex = 2;
            this.trbSize.Value = 10;
            this.trbSize.Scroll += new System.EventHandler(this.trbSize_Scroll);
            this.trbSize.MouseUp += new System.Windows.Forms.MouseEventHandler(this.trbSize_MouseUp);
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tbpControl);
            this.tabControl.Controls.Add(this.tbpAbout);
            this.tabControl.Location = new System.Drawing.Point(12, 13);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(259, 528);
            this.tabControl.TabIndex = 3;
            // 
            // tbpControl
            // 
            this.tbpControl.Controls.Add(this.btnSave);
            this.tbpControl.Controls.Add(this.label6);
            this.tbpControl.Controls.Add(this.trbOpacity);
            this.tbpControl.Controls.Add(this.label5);
            this.tbpControl.Controls.Add(this.btnSelectFont);
            this.tbpControl.Controls.Add(this.label4);
            this.tbpControl.Controls.Add(this.trbFontSize);
            this.tbpControl.Controls.Add(this.groupBox1);
            this.tbpControl.Controls.Add(this.label3);
            this.tbpControl.Controls.Add(this.label2);
            this.tbpControl.Controls.Add(this.label1);
            this.tbpControl.Controls.Add(this.trbHorizontal);
            this.tbpControl.Controls.Add(this.trbSize);
            this.tbpControl.Controls.Add(this.trbVertical);
            this.tbpControl.Location = new System.Drawing.Point(4, 22);
            this.tbpControl.Name = "tbpControl";
            this.tbpControl.Padding = new System.Windows.Forms.Padding(3);
            this.tbpControl.Size = new System.Drawing.Size(251, 502);
            this.tbpControl.TabIndex = 0;
            this.tbpControl.Text = "控制";
            this.tbpControl.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(7, 222);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(41, 12);
            this.label6.TabIndex = 12;
            this.label6.Text = "透明度";
            // 
            // trbOpacity
            // 
            this.trbOpacity.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.trbOpacity.Location = new System.Drawing.Point(51, 222);
            this.trbOpacity.Maximum = 100;
            this.trbOpacity.Minimum = 1;
            this.trbOpacity.Name = "trbOpacity";
            this.trbOpacity.Size = new System.Drawing.Size(194, 45);
            this.trbOpacity.TabIndex = 11;
            this.trbOpacity.Value = 50;
            this.trbOpacity.Scroll += new System.EventHandler(this.trbOpacity_Scroll);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(16, 298);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(29, 12);
            this.label5.TabIndex = 10;
            this.label5.Text = "字体";
            // 
            // btnSelectFont
            // 
            this.btnSelectFont.Location = new System.Drawing.Point(60, 289);
            this.btnSelectFont.Name = "btnSelectFont";
            this.btnSelectFont.Size = new System.Drawing.Size(157, 30);
            this.btnSelectFont.TabIndex = 9;
            this.btnSelectFont.Text = "选择";
            this.btnSelectFont.UseVisualStyleBackColor = true;
            this.btnSelectFont.Click += new System.EventHandler(this.btnSelectFont_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 171);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 8;
            this.label4.Text = "字体大小";
            // 
            // trbFontSize
            // 
            this.trbFontSize.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.trbFontSize.Location = new System.Drawing.Point(51, 171);
            this.trbFontSize.Maximum = 100;
            this.trbFontSize.Minimum = 1;
            this.trbFontSize.Name = "trbFontSize";
            this.trbFontSize.Size = new System.Drawing.Size(194, 45);
            this.trbFontSize.TabIndex = 7;
            this.trbFontSize.Value = 24;
            this.trbFontSize.Scroll += new System.EventHandler(this.trbFontSize_Scroll);
            this.trbFontSize.MouseUp += new System.Windows.Forms.MouseEventHandler(this.trbFontSize_MouseUp);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lbColor1);
            this.groupBox1.Controls.Add(this.lbColor5);
            this.groupBox1.Controls.Add(this.lbColor4);
            this.groupBox1.Controls.Add(this.lbColor3);
            this.groupBox1.Controls.Add(this.lbColor2);
            this.groupBox1.Controls.Add(this.lbNowColor);
            this.groupBox1.Controls.Add(this.btnSelectColor);
            this.groupBox1.Location = new System.Drawing.Point(9, 339);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(239, 116);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "字体颜色";
            // 
            // lbColor1
            // 
            this.lbColor1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbColor1.Location = new System.Drawing.Point(6, 67);
            this.lbColor1.Name = "lbColor1";
            this.lbColor1.Size = new System.Drawing.Size(41, 30);
            this.lbColor1.TabIndex = 8;
            this.lbColor1.Text = " ";
            // 
            // lbColor5
            // 
            this.lbColor5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbColor5.Location = new System.Drawing.Point(192, 67);
            this.lbColor5.Name = "lbColor5";
            this.lbColor5.Size = new System.Drawing.Size(41, 30);
            this.lbColor5.TabIndex = 7;
            this.lbColor5.Text = " ";
            // 
            // lbColor4
            // 
            this.lbColor4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbColor4.Location = new System.Drawing.Point(145, 67);
            this.lbColor4.Name = "lbColor4";
            this.lbColor4.Size = new System.Drawing.Size(41, 30);
            this.lbColor4.TabIndex = 6;
            this.lbColor4.Text = " ";
            // 
            // lbColor3
            // 
            this.lbColor3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbColor3.Location = new System.Drawing.Point(98, 67);
            this.lbColor3.Name = "lbColor3";
            this.lbColor3.Size = new System.Drawing.Size(41, 30);
            this.lbColor3.TabIndex = 5;
            this.lbColor3.Text = " ";
            // 
            // lbColor2
            // 
            this.lbColor2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbColor2.Location = new System.Drawing.Point(51, 67);
            this.lbColor2.Name = "lbColor2";
            this.lbColor2.Size = new System.Drawing.Size(41, 30);
            this.lbColor2.TabIndex = 4;
            this.lbColor2.Text = " ";
            // 
            // lbNowColor
            // 
            this.lbNowColor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbNowColor.Location = new System.Drawing.Point(10, 20);
            this.lbNowColor.Name = "lbNowColor";
            this.lbNowColor.Size = new System.Drawing.Size(41, 30);
            this.lbNowColor.TabIndex = 1;
            this.lbNowColor.Text = " ";
            // 
            // btnSelectColor
            // 
            this.btnSelectColor.Location = new System.Drawing.Point(76, 20);
            this.btnSelectColor.Name = "btnSelectColor";
            this.btnSelectColor.Size = new System.Drawing.Size(157, 30);
            this.btnSelectColor.TabIndex = 0;
            this.btnSelectColor.Text = "选择";
            this.btnSelectColor.UseVisualStyleBackColor = true;
            this.btnSelectColor.Click += new System.EventHandler(this.btnSelectColor_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 120);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 5;
            this.label3.Text = "区域大小";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 69);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 12);
            this.label2.TabIndex = 4;
            this.label2.Text = "纵向";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 12);
            this.label1.TabIndex = 3;
            this.label1.Text = "横向";
            // 
            // tbpAbout
            // 
            this.tbpAbout.Location = new System.Drawing.Point(4, 22);
            this.tbpAbout.Name = "tbpAbout";
            this.tbpAbout.Padding = new System.Windows.Forms.Padding(3);
            this.tbpAbout.Size = new System.Drawing.Size(251, 461);
            this.tbpAbout.TabIndex = 1;
            this.tbpAbout.Text = "关于";
            this.tbpAbout.UseVisualStyleBackColor = true;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(15, 461);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(227, 34);
            this.btnSave.TabIndex = 13;
            this.btnSave.Text = "保存";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // WSetting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(283, 553);
            this.Controls.Add(this.tabControl);
            this.Name = "WSetting";
            this.Text = "Mini Clock";
            this.Load += new System.EventHandler(this.WSetting_Load);
            ((System.ComponentModel.ISupportInitialize)(this.trbHorizontal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trbVertical)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trbSize)).EndInit();
            this.tabControl.ResumeLayout(false);
            this.tbpControl.ResumeLayout(false);
            this.tbpControl.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trbOpacity)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trbFontSize)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TrackBar trbHorizontal;
        private System.Windows.Forms.TrackBar trbVertical;
        private System.Windows.Forms.TrackBar trbSize;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tbpControl;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabPage tbpAbout;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnSelectColor;
        private System.Windows.Forms.Label lbColor3;
        private System.Windows.Forms.Label lbColor2;
        private System.Windows.Forms.Label lbNowColor;
        private System.Windows.Forms.Label lbColor1;
        private System.Windows.Forms.Label lbColor5;
        private System.Windows.Forms.Label lbColor4;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TrackBar trbFontSize;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnSelectFont;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TrackBar trbOpacity;
        private System.Windows.Forms.Button btnSave;
    }
}