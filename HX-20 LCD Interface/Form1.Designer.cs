namespace HX_20_LCD_Interface
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
            this.button1 = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.button2 = new System.Windows.Forms.Button();
            this.label_stats = new System.Windows.Forms.Label();
            this.checkBox_dataOnly = new System.Windows.Forms.CheckBox();
            this.checkBox_maskB7 = new System.Windows.Forms.CheckBox();
            this.checkBox_stream = new System.Windows.Forms.CheckBox();
            this.checkBox_slower = new System.Windows.Forms.CheckBox();
            this.textBox_start = new System.Windows.Forms.TextBox();
            this.textBox_stop = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button_list = new System.Windows.Forms.Button();
            this.comboBox_portName = new System.Windows.Forms.ComboBox();
            this.button_open = new System.Windows.Forms.Button();
            this.button_close = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.button_clear = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "Load BIN";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(93, 12);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 3;
            this.button2.Text = "Redraw";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label_stats
            // 
            this.label_stats.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label_stats.AutoSize = true;
            this.label_stats.Font = new System.Drawing.Font("Courier New", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_stats.Location = new System.Drawing.Point(12, 618);
            this.label_stats.Name = "label_stats";
            this.label_stats.Size = new System.Drawing.Size(62, 17);
            this.label_stats.TabIndex = 4;
            this.label_stats.Text = "Stats:";
            // 
            // checkBox_dataOnly
            // 
            this.checkBox_dataOnly.AutoSize = true;
            this.checkBox_dataOnly.Location = new System.Drawing.Point(174, 14);
            this.checkBox_dataOnly.Name = "checkBox_dataOnly";
            this.checkBox_dataOnly.Size = new System.Drawing.Size(88, 20);
            this.checkBox_dataOnly.TabIndex = 5;
            this.checkBox_dataOnly.Text = "Data Only";
            this.checkBox_dataOnly.UseVisualStyleBackColor = true;
            this.checkBox_dataOnly.CheckedChanged += new System.EventHandler(this.checkBox_dataOnly_CheckedChanged);
            // 
            // checkBox_maskB7
            // 
            this.checkBox_maskB7.AutoSize = true;
            this.checkBox_maskB7.Location = new System.Drawing.Point(268, 14);
            this.checkBox_maskB7.Name = "checkBox_maskB7";
            this.checkBox_maskB7.Size = new System.Drawing.Size(89, 20);
            this.checkBox_maskB7.TabIndex = 6;
            this.checkBox_maskB7.Text = "Mask bit 7";
            this.checkBox_maskB7.UseVisualStyleBackColor = true;
            this.checkBox_maskB7.CheckedChanged += new System.EventHandler(this.checkBox_maskB7_CheckedChanged);
            // 
            // checkBox_stream
            // 
            this.checkBox_stream.AutoSize = true;
            this.checkBox_stream.Location = new System.Drawing.Point(372, 14);
            this.checkBox_stream.Name = "checkBox_stream";
            this.checkBox_stream.Size = new System.Drawing.Size(72, 20);
            this.checkBox_stream.TabIndex = 7;
            this.checkBox_stream.Text = "Stream";
            this.checkBox_stream.UseVisualStyleBackColor = true;
            this.checkBox_stream.CheckedChanged += new System.EventHandler(this.checkBox_stream_CheckedChanged);
            // 
            // checkBox_slower
            // 
            this.checkBox_slower.AutoSize = true;
            this.checkBox_slower.Location = new System.Drawing.Point(459, 14);
            this.checkBox_slower.Name = "checkBox_slower";
            this.checkBox_slower.Size = new System.Drawing.Size(70, 20);
            this.checkBox_slower.TabIndex = 8;
            this.checkBox_slower.Text = "Slower";
            this.checkBox_slower.UseVisualStyleBackColor = true;
            // 
            // textBox_start
            // 
            this.textBox_start.Font = new System.Drawing.Font("Courier New", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_start.Location = new System.Drawing.Point(616, 10);
            this.textBox_start.Name = "textBox_start";
            this.textBox_start.Size = new System.Drawing.Size(100, 24);
            this.textBox_start.TabIndex = 9;
            this.textBox_start.Text = "0";
            this.textBox_start.KeyUp += new System.Windows.Forms.KeyEventHandler(this.textBox_start_KeyUp);
            // 
            // textBox_stop
            // 
            this.textBox_stop.Font = new System.Drawing.Font("Courier New", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_stop.Location = new System.Drawing.Point(722, 10);
            this.textBox_stop.Name = "textBox_stop";
            this.textBox_stop.Size = new System.Drawing.Size(100, 24);
            this.textBox_stop.TabIndex = 10;
            this.textBox_stop.Text = "0";
            this.textBox_stop.KeyUp += new System.Windows.Forms.KeyEventHandler(this.textBox_start_KeyUp);
            // 
            // textBox1
            // 
            this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox1.BackColor = System.Drawing.Color.White;
            this.textBox1.Location = new System.Drawing.Point(325, 549);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox1.Size = new System.Drawing.Size(1114, 83);
            this.textBox1.TabIndex = 11;
            // 
            // button_list
            // 
            this.button_list.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button_list.Location = new System.Drawing.Point(1075, 12);
            this.button_list.Name = "button_list";
            this.button_list.Size = new System.Drawing.Size(75, 23);
            this.button_list.TabIndex = 12;
            this.button_list.Text = "List";
            this.button_list.UseVisualStyleBackColor = true;
            this.button_list.Click += new System.EventHandler(this.button_list_Click);
            // 
            // comboBox_portName
            // 
            this.comboBox_portName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBox_portName.FormattingEnabled = true;
            this.comboBox_portName.Location = new System.Drawing.Point(1156, 11);
            this.comboBox_portName.Name = "comboBox_portName";
            this.comboBox_portName.Size = new System.Drawing.Size(121, 24);
            this.comboBox_portName.TabIndex = 13;
            // 
            // button_open
            // 
            this.button_open.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button_open.Location = new System.Drawing.Point(1283, 12);
            this.button_open.Name = "button_open";
            this.button_open.Size = new System.Drawing.Size(75, 23);
            this.button_open.TabIndex = 14;
            this.button_open.Text = "Open";
            this.button_open.UseVisualStyleBackColor = true;
            this.button_open.Click += new System.EventHandler(this.button_open_Click);
            // 
            // button_close
            // 
            this.button_close.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button_close.Location = new System.Drawing.Point(1364, 12);
            this.button_close.Name = "button_close";
            this.button_close.Size = new System.Drawing.Size(75, 23);
            this.button_close.TabIndex = 15;
            this.button_close.Text = "Close";
            this.button_close.UseVisualStyleBackColor = true;
            this.button_close.Click += new System.EventHandler(this.button_close_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.Location = new System.Drawing.Point(12, 40);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(1427, 503);
            this.pictureBox1.TabIndex = 16;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.SizeChanged += new System.EventHandler(this.pictureBox1_SizeChanged);
            // 
            // button_clear
            // 
            this.button_clear.Location = new System.Drawing.Point(535, 11);
            this.button_clear.Name = "button_clear";
            this.button_clear.Size = new System.Drawing.Size(75, 23);
            this.button_clear.TabIndex = 17;
            this.button_clear.Text = "Clear";
            this.button_clear.UseVisualStyleBackColor = true;
            this.button_clear.Click += new System.EventHandler(this.button_clear_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1451, 644);
            this.Controls.Add(this.button_clear);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.button_close);
            this.Controls.Add(this.button_open);
            this.Controls.Add(this.comboBox_portName);
            this.Controls.Add(this.button_list);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.textBox_stop);
            this.Controls.Add(this.textBox_start);
            this.Controls.Add(this.checkBox_slower);
            this.Controls.Add(this.checkBox_stream);
            this.Controls.Add(this.checkBox_maskB7);
            this.Controls.Add(this.checkBox_dataOnly);
            this.Controls.Add(this.label_stats);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Name = "Form1";
            this.Text = "HX-20 LCD Interface";
            this.Resize += new System.EventHandler(this.Form1_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label_stats;
        private System.Windows.Forms.CheckBox checkBox_dataOnly;
        private System.Windows.Forms.CheckBox checkBox_maskB7;
        private System.Windows.Forms.CheckBox checkBox_stream;
        private System.Windows.Forms.CheckBox checkBox_slower;
        private System.Windows.Forms.TextBox textBox_start;
        private System.Windows.Forms.TextBox textBox_stop;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button button_list;
        private System.Windows.Forms.ComboBox comboBox_portName;
        private System.Windows.Forms.Button button_open;
        private System.Windows.Forms.Button button_close;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button button_clear;
    }
}

