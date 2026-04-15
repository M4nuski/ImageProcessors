
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
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.POS_HDR_checkBox = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(16, 254);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(480, 443);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // button_load
            // 
            this.button_load.Location = new System.Drawing.Point(16, 15);
            this.button_load.Margin = new System.Windows.Forms.Padding(4);
            this.button_load.Name = "button_load";
            this.button_load.Size = new System.Drawing.Size(117, 28);
            this.button_load.TabIndex = 1;
            this.button_load.Text = "Load to Raster";
            this.button_load.UseVisualStyleBackColor = true;
            this.button_load.Click += new System.EventHandler(this.button_load_Click);
            // 
            // textBox1
            // 
            this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox1.Location = new System.Drawing.Point(16, 50);
            this.textBox1.Margin = new System.Windows.Forms.Padding(4);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBox1.Size = new System.Drawing.Size(1193, 195);
            this.textBox1.TabIndex = 2;
            this.textBox1.WordWrap = false;
            // 
            // button_rasterize
            // 
            this.button_rasterize.Location = new System.Drawing.Point(311, 14);
            this.button_rasterize.Margin = new System.Windows.Forms.Padding(4);
            this.button_rasterize.Name = "button_rasterize";
            this.button_rasterize.Size = new System.Drawing.Size(100, 28);
            this.button_rasterize.TabIndex = 3;
            this.button_rasterize.Text = "Rasterize";
            this.button_rasterize.UseVisualStyleBackColor = true;
            this.button_rasterize.Click += new System.EventHandler(this.button_rasterize_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Location = new System.Drawing.Point(593, 254);
            this.pictureBox2.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(480, 443);
            this.pictureBox2.TabIndex = 4;
            this.pictureBox2.TabStop = false;
            // 
            // button_saveTXT
            // 
            this.button_saveTXT.Location = new System.Drawing.Point(557, 15);
            this.button_saveTXT.Margin = new System.Windows.Forms.Padding(4);
            this.button_saveTXT.Name = "button_saveTXT";
            this.button_saveTXT.Size = new System.Drawing.Size(100, 28);
            this.button_saveTXT.TabIndex = 5;
            this.button_saveTXT.Text = "Save txt";
            this.button_saveTXT.UseVisualStyleBackColor = true;
            this.button_saveTXT.Click += new System.EventHandler(this.button_saveTXT_Click);
            // 
            // button_saveBIN
            // 
            this.button_saveBIN.Location = new System.Drawing.Point(665, 15);
            this.button_saveBIN.Margin = new System.Windows.Forms.Padding(4);
            this.button_saveBIN.Name = "button_saveBIN";
            this.button_saveBIN.Size = new System.Drawing.Size(100, 28);
            this.button_saveBIN.TabIndex = 6;
            this.button_saveBIN.Text = "Save bin";
            this.button_saveBIN.UseVisualStyleBackColor = true;
            this.button_saveBIN.Click += new System.EventHandler(this.button2_Click);
            // 
            // trackBar1
            // 
            this.trackBar1.Location = new System.Drawing.Point(647, 693);
            this.trackBar1.Margin = new System.Windows.Forms.Padding(4);
            this.trackBar1.Maximum = 255;
            this.trackBar1.Name = "trackBar1";
            this.trackBar1.Size = new System.Drawing.Size(427, 56);
            this.trackBar1.TabIndex = 7;
            this.trackBar1.Value = 128;
            this.trackBar1.Scroll += new System.EventHandler(this.trackBar1_Scroll);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(153, 14);
            this.button1.Margin = new System.Windows.Forms.Padding(4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(129, 28);
            this.button1.TabIndex = 8;
            this.button1.Text = "Load to VERA";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(773, 14);
            this.button2.Margin = new System.Windows.Forms.Padding(4);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(129, 28);
            this.button2.TabIndex = 9;
            this.button2.Text = "Load to 5-6-5";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click_1);
            // 
            // POS_HDR_checkBox
            // 
            this.POS_HDR_checkBox.AutoSize = true;
            this.POS_HDR_checkBox.Location = new System.Drawing.Point(418, 19);
            this.POS_HDR_checkBox.Name = "POS_HDR_checkBox";
            this.POS_HDR_checkBox.Size = new System.Drawing.Size(103, 20);
            this.POS_HDR_checkBox.TabIndex = 10;
            this.POS_HDR_checkBox.Text = "POS header";
            this.POS_HDR_checkBox.UseVisualStyleBackColor = true;
            // 
            // Image2bitrasterForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1227, 750);
            this.Controls.Add(this.POS_HDR_checkBox);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.trackBar1);
            this.Controls.Add(this.button_saveBIN);
            this.Controls.Add(this.button_saveTXT);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.button_rasterize);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.button_load);
            this.Controls.Add(this.pictureBox1);
            this.Margin = new System.Windows.Forms.Padding(4);
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
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.CheckBox POS_HDR_checkBox;
    }
}

