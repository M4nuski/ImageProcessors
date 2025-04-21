namespace SVG2PNG
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
            this.button_Open = new System.Windows.Forms.Button();
            this.textBox_DPI = new System.Windows.Forms.TextBox();
            this.checkBox_Invert = new System.Windows.Forms.CheckBox();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.button_Save = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.comboBox_alphaMode = new System.Windows.Forms.ComboBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // button_Open
            // 
            this.button_Open.Location = new System.Drawing.Point(12, 12);
            this.button_Open.Name = "button_Open";
            this.button_Open.Size = new System.Drawing.Size(99, 23);
            this.button_Open.TabIndex = 0;
            this.button_Open.Text = "Open SVG";
            this.button_Open.UseVisualStyleBackColor = true;
            this.button_Open.Click += new System.EventHandler(this.button_Open_Click);
            // 
            // textBox_DPI
            // 
            this.textBox_DPI.Location = new System.Drawing.Point(222, 13);
            this.textBox_DPI.Name = "textBox_DPI";
            this.textBox_DPI.Size = new System.Drawing.Size(100, 22);
            this.textBox_DPI.TabIndex = 1;
            this.textBox_DPI.Text = "320";
            this.textBox_DPI.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox_DPI_KeyDown);
            // 
            // checkBox_Invert
            // 
            this.checkBox_Invert.AutoSize = true;
            this.checkBox_Invert.Location = new System.Drawing.Point(328, 13);
            this.checkBox_Invert.Name = "checkBox_Invert";
            this.checkBox_Invert.Size = new System.Drawing.Size(61, 20);
            this.checkBox_Invert.TabIndex = 2;
            this.checkBox_Invert.Text = "Invert";
            this.checkBox_Invert.UseVisualStyleBackColor = true;
            this.checkBox_Invert.CheckedChanged += new System.EventHandler(this.checkBox_Invert_CheckedChanged);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.DefaultExt = "svg";
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.Filter = "SVG|*.svg";
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.DefaultExt = "png";
            this.saveFileDialog1.Filter = "PNG|*.png";
            // 
            // button_Save
            // 
            this.button_Save.Location = new System.Drawing.Point(662, 12);
            this.button_Save.Name = "button_Save";
            this.button_Save.Size = new System.Drawing.Size(75, 23);
            this.button_Save.TabIndex = 3;
            this.button_Save.Text = "Save";
            this.button_Save.UseVisualStyleBackColor = true;
            this.button_Save.Click += new System.EventHandler(this.button_Save_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox1.Location = new System.Drawing.Point(12, 41);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(640, 480);
            this.pictureBox1.TabIndex = 4;
            this.pictureBox1.TabStop = false;
            // 
            // textBox1
            // 
            this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox1.Location = new System.Drawing.Point(12, 527);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(1290, 189);
            this.textBox1.TabIndex = 5;
            // 
            // comboBox_alphaMode
            // 
            this.comboBox_alphaMode.FormattingEnabled = true;
            this.comboBox_alphaMode.Items.AddRange(new object[] {
            "Transparent is BLACK",
            "Transparent is WHITE"});
            this.comboBox_alphaMode.Location = new System.Drawing.Point(395, 11);
            this.comboBox_alphaMode.Name = "comboBox_alphaMode";
            this.comboBox_alphaMode.Size = new System.Drawing.Size(167, 24);
            this.comboBox_alphaMode.TabIndex = 6;
            this.comboBox_alphaMode.Text = "Transparent is Whatever";
            this.comboBox_alphaMode.SelectedIndexChanged += new System.EventHandler(this.checkBox_Invert_CheckedChanged);
            // 
            // pictureBox2
            // 
            this.pictureBox2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox2.Location = new System.Drawing.Point(662, 41);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(640, 480);
            this.pictureBox2.TabIndex = 7;
            this.pictureBox2.TabStop = false;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(117, 13);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(99, 23);
            this.button1.TabIndex = 8;
            this.button1.Text = "Open Image";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1312, 729);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.comboBox_alphaMode);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.button_Save);
            this.Controls.Add(this.checkBox_Invert);
            this.Controls.Add(this.textBox_DPI);
            this.Controls.Add(this.button_Open);
            this.Name = "Form1";
            this.Text = "SVG to PNG Converter";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button_Open;
        private System.Windows.Forms.TextBox textBox_DPI;
        private System.Windows.Forms.CheckBox checkBox_Invert;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.Button button_Save;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.ComboBox comboBox_alphaMode;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Button button1;
    }
}

