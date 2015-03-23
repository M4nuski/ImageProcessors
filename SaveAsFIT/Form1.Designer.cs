namespace SaveAsFITS
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItem5 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripTextBox2 = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripTextBox1 = new System.Windows.Forms.ToolStripTextBox();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.RedCheckBox = new System.Windows.Forms.CheckBox();
            this.GreenCheckBox = new System.Windows.Forms.CheckBox();
            this.BlueCheckBox = new System.Windows.Forms.CheckBox();
            this.AlphaCheckBox = new System.Windows.Forms.CheckBox();
            this.GrayScaleCheckBox = new System.Windows.Forms.CheckBox();
            this.LuminanceButton = new System.Windows.Forms.Button();
            this.AverageButton = new System.Windows.Forms.Button();
            this.GrayAdjustBox = new System.Windows.Forms.PictureBox();
            this.imageControl1 = new SaveAsFITS.ImageControl();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GrayAdjustBox)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.toolStripTextBox2,
            this.toolStripTextBox1});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(924, 31);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem3,
            this.toolStripMenuItem4,
            this.toolStripSeparator1,
            this.toolStripMenuItem5});
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(44, 27);
            this.toolStripMenuItem1.Text = "File";
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(184, 24);
            this.toolStripMenuItem3.Text = "Load Image File";
            this.toolStripMenuItem3.Click += new System.EventHandler(this.toolStripLoadImage_Click);
            // 
            // toolStripMenuItem4
            // 
            this.toolStripMenuItem4.Name = "toolStripMenuItem4";
            this.toolStripMenuItem4.Size = new System.Drawing.Size(184, 24);
            this.toolStripMenuItem4.Text = "Save As FITS";
            this.toolStripMenuItem4.Click += new System.EventHandler(this.toolStripSaveAsFITS_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(181, 6);
            // 
            // toolStripMenuItem5
            // 
            this.toolStripMenuItem5.Name = "toolStripMenuItem5";
            this.toolStripMenuItem5.Size = new System.Drawing.Size(184, 24);
            this.toolStripMenuItem5.Text = "Quit";
            this.toolStripMenuItem5.Click += new System.EventHandler(this.toolStripQuit_Click);
            // 
            // toolStripTextBox2
            // 
            this.toolStripTextBox2.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripTextBox2.Enabled = false;
            this.toolStripTextBox2.Name = "toolStripTextBox2";
            this.toolStripTextBox2.ReadOnly = true;
            this.toolStripTextBox2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.toolStripTextBox2.Size = new System.Drawing.Size(200, 27);
            this.toolStripTextBox2.Text = "Emmanuel Charettte 2015";
            this.toolStripTextBox2.TextBoxTextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // toolStripTextBox1
            // 
            this.toolStripTextBox1.Name = "toolStripTextBox1";
            this.toolStripTextBox1.ReadOnly = true;
            this.toolStripTextBox1.Size = new System.Drawing.Size(100, 27);
            this.toolStripTextBox1.Text = "100%";
            this.toolStripTextBox1.TextBoxTextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.Filter = "Image Files|*.bmp;*.gif;*.exif;*.jpg;*.png;*.tiff;*.tif|All Files|*.*";
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.DefaultExt = "fit";
            this.saveFileDialog1.Filter = "FITS|*.fit;*.fits|All Files|*.*";
            // 
            // RedCheckBox
            // 
            this.RedCheckBox.AutoSize = true;
            this.RedCheckBox.Location = new System.Drawing.Point(8, 44);
            this.RedCheckBox.Name = "RedCheckBox";
            this.RedCheckBox.Size = new System.Drawing.Size(56, 21);
            this.RedCheckBox.TabIndex = 4;
            this.RedCheckBox.Text = "Red";
            this.RedCheckBox.UseVisualStyleBackColor = true;
            this.RedCheckBox.CheckedChanged += new System.EventHandler(this.toolStripGrayscale_CheckedChanged);
            // 
            // GreenCheckBox
            // 
            this.GreenCheckBox.AutoSize = true;
            this.GreenCheckBox.Location = new System.Drawing.Point(8, 71);
            this.GreenCheckBox.Name = "GreenCheckBox";
            this.GreenCheckBox.Size = new System.Drawing.Size(70, 21);
            this.GreenCheckBox.TabIndex = 5;
            this.GreenCheckBox.Text = "Green";
            this.GreenCheckBox.UseVisualStyleBackColor = true;
            this.GreenCheckBox.CheckedChanged += new System.EventHandler(this.toolStripGrayscale_CheckedChanged);
            // 
            // BlueCheckBox
            // 
            this.BlueCheckBox.AutoSize = true;
            this.BlueCheckBox.Location = new System.Drawing.Point(8, 98);
            this.BlueCheckBox.Name = "BlueCheckBox";
            this.BlueCheckBox.Size = new System.Drawing.Size(58, 21);
            this.BlueCheckBox.TabIndex = 6;
            this.BlueCheckBox.Text = "Blue";
            this.BlueCheckBox.UseVisualStyleBackColor = true;
            this.BlueCheckBox.CheckedChanged += new System.EventHandler(this.toolStripGrayscale_CheckedChanged);
            // 
            // AlphaCheckBox
            // 
            this.AlphaCheckBox.AutoSize = true;
            this.AlphaCheckBox.Location = new System.Drawing.Point(8, 125);
            this.AlphaCheckBox.Name = "AlphaCheckBox";
            this.AlphaCheckBox.Size = new System.Drawing.Size(66, 21);
            this.AlphaCheckBox.TabIndex = 7;
            this.AlphaCheckBox.Text = "Alpha";
            this.AlphaCheckBox.UseVisualStyleBackColor = true;
            this.AlphaCheckBox.CheckedChanged += new System.EventHandler(this.toolStripGrayscale_CheckedChanged);
            // 
            // GrayScaleCheckBox
            // 
            this.GrayScaleCheckBox.AutoSize = true;
            this.GrayScaleCheckBox.Location = new System.Drawing.Point(8, 152);
            this.GrayScaleCheckBox.Name = "GrayScaleCheckBox";
            this.GrayScaleCheckBox.Size = new System.Drawing.Size(100, 21);
            this.GrayScaleCheckBox.TabIndex = 8;
            this.GrayScaleCheckBox.Text = "Gray Scale";
            this.GrayScaleCheckBox.UseVisualStyleBackColor = true;
            this.GrayScaleCheckBox.CheckedChanged += new System.EventHandler(this.toolStripGrayscale_CheckedChanged);
            // 
            // LuminanceButton
            // 
            this.LuminanceButton.Location = new System.Drawing.Point(8, 272);
            this.LuminanceButton.Name = "LuminanceButton";
            this.LuminanceButton.Size = new System.Drawing.Size(100, 23);
            this.LuminanceButton.TabIndex = 9;
            this.LuminanceButton.Text = "Luminance";
            this.LuminanceButton.UseVisualStyleBackColor = true;
            this.LuminanceButton.Click += new System.EventHandler(this.LuminanceButton_Click);
            // 
            // AverageButton
            // 
            this.AverageButton.Location = new System.Drawing.Point(8, 301);
            this.AverageButton.Name = "AverageButton";
            this.AverageButton.Size = new System.Drawing.Size(100, 23);
            this.AverageButton.TabIndex = 10;
            this.AverageButton.Text = "Average";
            this.AverageButton.UseVisualStyleBackColor = true;
            this.AverageButton.Click += new System.EventHandler(this.AverageButton_Click);
            // 
            // GrayAdjustBox
            // 
            this.GrayAdjustBox.BackColor = System.Drawing.Color.Black;
            this.GrayAdjustBox.Cursor = System.Windows.Forms.Cursors.Cross;
            this.GrayAdjustBox.Location = new System.Drawing.Point(8, 179);
            this.GrayAdjustBox.Margin = new System.Windows.Forms.Padding(3, 3, 8, 3);
            this.GrayAdjustBox.Name = "GrayAdjustBox";
            this.GrayAdjustBox.Size = new System.Drawing.Size(100, 87);
            this.GrayAdjustBox.TabIndex = 11;
            this.GrayAdjustBox.TabStop = false;
            this.GrayAdjustBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.GrayAdjustBox_MouseDown);
            this.GrayAdjustBox.MouseMove += new System.Windows.Forms.MouseEventHandler(this.GrayAdjustBox_MouseMove);
            this.GrayAdjustBox.MouseUp += new System.Windows.Forms.MouseEventHandler(this.GrayAdjustBox_MouseUp);
            // 
            // imageControl1
            // 
            this.imageControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.imageControl1.BackColor = System.Drawing.Color.Gray;
            this.imageControl1.BackgroundImage = global::SaveAsFITS.Properties.Resources.checkeredBG22;
            this.imageControl1.Location = new System.Drawing.Point(119, 44);
            this.imageControl1.MaxZoomLevel = 10F;
            this.imageControl1.MinimumSize = new System.Drawing.Size(32, 18);
            this.imageControl1.Name = "imageControl1";
            this.imageControl1.Size = new System.Drawing.Size(791, 590);
            this.imageControl1.SourceImage = null;
            this.imageControl1.TabIndex = 3;
            this.imageControl1.ZoomLevel = 0F;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 338);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 17);
            this.label1.TabIndex = 12;
            this.label1.Text = "label1";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(11, 355);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 17);
            this.label2.TabIndex = 13;
            this.label2.Text = "label2";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(11, 372);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(46, 17);
            this.label3.TabIndex = 14;
            this.label3.Text = "label3";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(924, 646);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.GrayAdjustBox);
            this.Controls.Add(this.AverageButton);
            this.Controls.Add(this.LuminanceButton);
            this.Controls.Add(this.GrayScaleCheckBox);
            this.Controls.Add(this.AlphaCheckBox);
            this.Controls.Add(this.BlueCheckBox);
            this.Controls.Add(this.GreenCheckBox);
            this.Controls.Add(this.RedCheckBox);
            this.Controls.Add(this.imageControl1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "SaveAsFITS";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GrayAdjustBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private ImageControl imageControl1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.ToolStripTextBox toolStripTextBox1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.ToolStripTextBox toolStripTextBox2;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem4;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem5;
        private System.Windows.Forms.CheckBox RedCheckBox;
        private System.Windows.Forms.CheckBox GreenCheckBox;
        private System.Windows.Forms.CheckBox BlueCheckBox;
        private System.Windows.Forms.CheckBox AlphaCheckBox;
        private System.Windows.Forms.CheckBox GrayScaleCheckBox;
        private System.Windows.Forms.Button LuminanceButton;
        private System.Windows.Forms.Button AverageButton;
        private System.Windows.Forms.PictureBox GrayAdjustBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
    }
}

