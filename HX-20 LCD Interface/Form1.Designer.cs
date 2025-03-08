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
            this.panel1 = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.button2 = new System.Windows.Forms.Button();
            this.label_stats = new System.Windows.Forms.Label();
            this.checkBox_dataOnly = new System.Windows.Forms.CheckBox();
            this.checkBox_maskB7 = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Location = new System.Drawing.Point(12, 41);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1008, 666);
            this.panel1.TabIndex = 0;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
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
            this.button2.Text = "Clear";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label_stats
            // 
            this.label_stats.AutoSize = true;
            this.label_stats.Font = new System.Drawing.Font("Courier New", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_stats.Location = new System.Drawing.Point(12, 710);
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
            this.checkBox_maskB7.Location = new System.Drawing.Point(268, 15);
            this.checkBox_maskB7.Name = "checkBox_maskB7";
            this.checkBox_maskB7.Size = new System.Drawing.Size(89, 20);
            this.checkBox_maskB7.TabIndex = 6;
            this.checkBox_maskB7.Text = "Mask bit 7";
            this.checkBox_maskB7.UseVisualStyleBackColor = true;
            this.checkBox_maskB7.CheckedChanged += new System.EventHandler(this.checkBox_maskB7_CheckedChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1034, 769);
            this.Controls.Add(this.checkBox_maskB7);
            this.Controls.Add(this.checkBox_dataOnly);
            this.Controls.Add(this.label_stats);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.panel1);
            this.Name = "Form1";
            this.Text = "HX-20 LCD Interface";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label_stats;
        private System.Windows.Forms.CheckBox checkBox_dataOnly;
        private System.Windows.Forms.CheckBox checkBox_maskB7;
    }
}

