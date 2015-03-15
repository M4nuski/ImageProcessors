using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SaveAsFIT
{
    public partial class Form1 : Form
    {
        private Bitmap sourceImage;
        private StringBuilder sb = new StringBuilder();
        public Form1()
        {
            InitializeComponent();
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                //sourceImage = new Bitmap(openFileDialog1.FileName);
               // pictureBox1.Image = new Bitmap(sourceImage, pictureBox1.Width, pictureBox1.Height);
                imageControl1.SourceImage = new Bitmap(openFileDialog1.FileName);
            }
            
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            sb.Clear();
            sb.Append("Zoom Level: ");
            sb.Append(imageControl1.ZoomLevel.ToString("F2"));
            sb.Append(" PanPosition: ");
            sb.Append(imageControl1.PanPosition);
            label1.Text = sb.ToString();
        }
    }
}
