namespace SaveAsFIT
{
    partial class ImageControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // ImageControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gray;
            this.DoubleBuffered = true;
            this.MinimumSize = new System.Drawing.Size(32, 18);
            this.Name = "ImageControl";
            this.Size = new System.Drawing.Size(320, 180);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.ImageControl_Paint);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ImageControl_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.ImageControl_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.ImageControl_MouseUp);
            this.Resize += new System.EventHandler(this.ImageControl_Resize);
            this.ResumeLayout(false);

        }

        #endregion
    }
}
