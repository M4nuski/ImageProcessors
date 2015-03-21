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
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripRed = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripGreen = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripBlue = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripAlpha = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripGrayscale = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripTextBox2 = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripTextBox1 = new System.Windows.Forms.ToolStripTextBox();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.imageControl1 = new SaveAsFITS.ImageControl();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.toolStripMenuItem2,
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
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripRed,
            this.toolStripGreen,
            this.toolStripBlue,
            this.toolStripAlpha,
            this.toolStripSeparator2,
            this.toolStripGrayscale});
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(124, 27);
            this.toolStripMenuItem2.Text = "Select Channels";
            // 
            // toolStripRed
            // 
            this.toolStripRed.Checked = true;
            this.toolStripRed.CheckOnClick = true;
            this.toolStripRed.CheckState = System.Windows.Forms.CheckState.Checked;
            this.toolStripRed.Name = "toolStripRed";
            this.toolStripRed.Size = new System.Drawing.Size(199, 24);
            this.toolStripRed.Text = "Red";
            this.toolStripRed.CheckedChanged += new System.EventHandler(this.toolStripGrayscale_CheckedChanged);
            // 
            // toolStripGreen
            // 
            this.toolStripGreen.Checked = true;
            this.toolStripGreen.CheckOnClick = true;
            this.toolStripGreen.CheckState = System.Windows.Forms.CheckState.Checked;
            this.toolStripGreen.Name = "toolStripGreen";
            this.toolStripGreen.Size = new System.Drawing.Size(199, 24);
            this.toolStripGreen.Text = "Green";
            this.toolStripGreen.CheckedChanged += new System.EventHandler(this.toolStripGrayscale_CheckedChanged);
            // 
            // toolStripBlue
            // 
            this.toolStripBlue.Checked = true;
            this.toolStripBlue.CheckOnClick = true;
            this.toolStripBlue.CheckState = System.Windows.Forms.CheckState.Checked;
            this.toolStripBlue.Name = "toolStripBlue";
            this.toolStripBlue.Size = new System.Drawing.Size(199, 24);
            this.toolStripBlue.Text = "Blue";
            this.toolStripBlue.CheckedChanged += new System.EventHandler(this.toolStripGrayscale_CheckedChanged);
            // 
            // toolStripAlpha
            // 
            this.toolStripAlpha.Checked = true;
            this.toolStripAlpha.CheckOnClick = true;
            this.toolStripAlpha.CheckState = System.Windows.Forms.CheckState.Checked;
            this.toolStripAlpha.Name = "toolStripAlpha";
            this.toolStripAlpha.Size = new System.Drawing.Size(199, 24);
            this.toolStripAlpha.Text = "Alpha";
            this.toolStripAlpha.CheckedChanged += new System.EventHandler(this.toolStripGrayscale_CheckedChanged);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(196, 6);
            // 
            // toolStripGrayscale
            // 
            this.toolStripGrayscale.CheckOnClick = true;
            this.toolStripGrayscale.Name = "toolStripGrayscale";
            this.toolStripGrayscale.Size = new System.Drawing.Size(199, 24);
            this.toolStripGrayscale.Text = "View As GrayScale";
            this.toolStripGrayscale.CheckedChanged += new System.EventHandler(this.toolStripGrayscale_CheckedChanged);
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
            // imageControl1
            // 
            this.imageControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.imageControl1.BackColor = System.Drawing.Color.Gray;
            this.imageControl1.BackgroundImage = global::SaveAsFITS.Properties.Resources.checkeredBG22;
            this.imageControl1.Location = new System.Drawing.Point(138, 44);
            this.imageControl1.MaxZoomLevel = 10F;
            this.imageControl1.MinimumSize = new System.Drawing.Size(32, 18);
            this.imageControl1.Name = "imageControl1";
            this.imageControl1.Size = new System.Drawing.Size(772, 590);
            this.imageControl1.SourceImage = null;
            this.imageControl1.TabIndex = 3;
            this.imageControl1.ZoomLevel = 0F;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(924, 646);
            this.Controls.Add(this.imageControl1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "SaveAsFITS";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
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
        private System.Windows.Forms.ToolStripMenuItem toolStripRed;
        private System.Windows.Forms.ToolStripMenuItem toolStripGreen;
        private System.Windows.Forms.ToolStripMenuItem toolStripBlue;
        private System.Windows.Forms.ToolStripMenuItem toolStripAlpha;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem toolStripGrayscale;
    }
}

