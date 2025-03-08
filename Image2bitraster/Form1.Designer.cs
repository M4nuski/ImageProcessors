
namespace Image2bitraster
{
    partial class Image2bitrasterForm
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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.button_load = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button_rasterize = new System.Windows.Forms.Button();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.button_saveTXT = new System.Windows.Forms.Button();
            this.button_saveBIN = new System.Windows.Forms.Button();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.trackBar1 = new System.Windows.Forms.TrackBar();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(12, 206);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(360, 360);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // button_load
            // 
            this.button_load.Location = new System.Drawing.Point(12, 12);
            this.button_load.Name = "button_load";
            this.button_load.Size = new System.Drawing.Size(75, 23);
            this.button_load.TabIndex = 1;
            this.button_load.Text = "Load";
            this.button_load.UseVisualStyleBackColor = true;
            this.button_load.Click += new System.EventHandler(this.button_load_Click);
            // 
            // textBox1
            // 
            this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox1.Location = new System.Drawing.Point(12, 41);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBox1.Size = new System.Drawing.Size(896, 159);
            this.textBox1.TabIndex = 2;
            this.textBox1.WordWrap = false;
            // 
            // button_rasterize
            // 
            this.button_rasterize.Location = new System.Drawing.Point(93, 12);
            this.button_rasterize.Name = "button_rasterize";
            this.button_rasterize.Size = new System.Drawing.Size(75, 23);
            this.button_rasterize.TabIndex = 3;
            this.button_rasterize.Text = "Rasterize";
            this.button_rasterize.UseVisualStyleBackColor = true;
            this.button_rasterize.Click += new System.EventHandler(this.button_rasterize_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Location = new System.Drawing.Point(445, 206);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(360, 360);
            this.pictureBox2.TabIndex = 4;
            this.pictureBox2.TabStop = false;
            // 
            // button_saveTXT
            // 
            this.button_saveTXT.Location = new System.Drawing.Point(174, 12);
            this.button_saveTXT.Name = "button_saveTXT";
            this.button_saveTXT.Size = new System.Drawing.Size(75, 23);
            this.button_saveTXT.TabIndex = 5;
            this.button_saveTXT.Text = "Save txt";
            this.button_saveTXT.UseVisualStyleBackColor = true;
            this.button_saveTXT.Click += new System.EventHandler(this.button_saveTXT_Click);
            // 
            // button_saveBIN
            // 
            this.button_saveBIN.Location = new System.Drawing.Point(255, 12);
            this.button_saveBIN.Name = "button_saveBIN";
            this.button_saveBIN.Size = new System.Drawing.Size(75, 23);
            this.button_saveBIN.TabIndex = 6;
            this.button_saveBIN.Text = "Save bin";
            this.button_saveBIN.UseVisualStyleBackColor = true;
            this.button_saveBIN.Click += new System.EventHandler(this.button2_Click);
            // 
            // trackBar1
            // 
            this.trackBar1.Location = new System.Drawing.Point(485, 563);
            this.trackBar1.Maximum = 255;
            this.trackBar1.Name = "trackBar1";
            this.trackBar1.Size = new System.Drawing.Size(320, 45);
            this.trackBar1.TabIndex = 7;
            this.trackBar1.Value = 128;
            this.trackBar1.Scroll += new System.EventHandler(this.trackBar1_Scroll);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // Image2bitrasterForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(920, 609);
            this.Controls.Add(this.trackBar1);
            this.Controls.Add(this.button_saveBIN);
            this.Controls.Add(this.button_saveTXT);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.button_rasterize);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.button_load);
            this.Controls.Add(this.pictureBox1);
            this.Name = "Image2bitrasterForm";
            this.Text = "Image To bit raster";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button button_load;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button button_rasterize;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Button button_saveTXT;
        private System.Windows.Forms.Button button_saveBIN;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.TrackBar trackBar1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
    }
}

