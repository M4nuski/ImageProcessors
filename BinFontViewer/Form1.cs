using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace BinFontViewer
{
    public partial class Form1 : Form
    {

        Bitmap bp = new Bitmap(1024, 512);
        public Form1()
        {
            InitializeComponent();
        }

        private void button_load_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() != DialogResult.OK) return;
            var data = File.ReadAllBytes(openFileDialog1.FileName);

            if (data.Length == 0) return;

            var BBruh = new SolidBrush(Color.Black);
            var WBruh = new SolidBrush(Color.White);

            var d_w = int.Parse(textBox_w.Text);
            if (d_w < 0) d_w = 1;
            var d_s = int.Parse(textBox_s.Text);
            if (d_s < 0) d_s = 1;

            bp = new Bitmap(1024, 512);
           
            var row = 0;
            var col = 0;
            var g = Graphics.FromImage(bp);
            for (var i = 0; i < data.Length; i++)
            {
                g.FillRectangle(((data[i] & 0x80) == 0) ? BBruh : WBruh, (col + 0) * d_s, row * d_s, d_s, d_s);
                g.FillRectangle(((data[i] & 0x40) == 0) ? BBruh : WBruh, (col + 1) * d_s, row * d_s, d_s, d_s);
                g.FillRectangle(((data[i] & 0x20) == 0) ? BBruh : WBruh, (col + 2) * d_s, row * d_s, d_s, d_s);
                g.FillRectangle(((data[i] & 0x10) == 0) ? BBruh : WBruh, (col + 3) * d_s, row * d_s, d_s, d_s);

                g.FillRectangle(((data[i] & 0x08) == 0) ? BBruh : WBruh, (col + 4) * d_s, row * d_s, d_s, d_s);
                g.FillRectangle(((data[i] & 0x04) == 0) ? BBruh : WBruh, (col + 5) * d_s, row * d_s, d_s, d_s);
                g.FillRectangle(((data[i] & 0x02) == 0) ? BBruh : WBruh, (col + 6) * d_s, row * d_s, d_s, d_s);
                g.FillRectangle(((data[i] & 0x01) == 0) ? BBruh : WBruh, (col + 7) * d_s, row * d_s, d_s, d_s);

                row++;
                if (row >= 256)
                {
                    row = 0;
                    col += d_w;
                }
            }
            pictureBox1.Image = bp;
            pictureBox1.Refresh();

        }

        private void button_save_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() != DialogResult.OK) return;

            bp.Save(saveFileDialog1.FileName);
        }
    }
}
