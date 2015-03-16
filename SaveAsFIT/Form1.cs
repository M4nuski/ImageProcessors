using System;
using System.Drawing;
using System.Windows.Forms;

namespace SaveAsFIT
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                imageControl1.SourceImage = new Bitmap(openFileDialog1.FileName);
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (toolStripTextBox1.TextBox != null)
                toolStripTextBox1.TextBox.Text = (imageControl1.ZoomLevel*100).ToString("F0") + "%";
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                //TODO save as FITS
            } 
        }
    }
}
