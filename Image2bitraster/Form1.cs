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

namespace Image2bitraster
{
    public partial class Image2bitrasterForm : Form
    {
        Bitmap b, c;
        Graphics g;
        List<byte> bin = new List<byte>();
        int w = 320;
        int h = 240;

        public Image2bitrasterForm()
        {
            InitializeComponent();
        }

        private void button_load_Click(object sender, EventArgs e)
        {
            openFileDialog1.FileName = @"D:\progData\ApertureLogo.png";
            if (openFileDialog1.ShowDialog() != DialogResult.OK) return;
            try
            {
                //     b = new Bitmap(@"D:\progData\ApertureLogo.png");
                b = new Bitmap(openFileDialog1.FileName);
            }
            catch (Exception ex)
            {
                textBox1.Text += "\r\nError loading image file: " + ex.Message;
                return;
            }
            for (var y = 0; y < b.Height; ++y)
            {
                for (var x = 0; x < b.Width; ++x)
                {
                    var pc = b.GetPixel(x, y);
                    var gs = pc.R * 298 + pc.G * 587 + pc.B * 114; // Y' = 0.2989 R + 0.5870 G + 0.1140 B 
                    gs = gs / 1000;
                    b.SetPixel(x, y, Color.FromArgb(255, gs, gs, gs));
                }
            }

            w = pictureBox1.Size.Width;
            h = pictureBox1.Size.Height;


            pictureBox1.Image = new Bitmap(w, h);
            g = Graphics.FromImage(pictureBox1.Image);
            g.DrawImage(b, 0, 0, w, h);

            c = new Bitmap(w, h);
            dither();
        }

        private void dither()
        {
            c = new Bitmap(w, h);
            pictureBox1.Refresh();
            pictureBox1.DrawToBitmap(c, pictureBox1.ClientRectangle);
            pictureBox2.Image = new Bitmap(w, h);
            g = Graphics.FromImage(pictureBox2.Image);
            int error = 0;
            for (var y = 0; y < h; ++y)
            {
                for (var x = 0; x < w; ++x)
                {
                    var val = c.GetPixel(x, y).R;
                    if ((val + error) > trackBar1.Value)
                    {
                        c.SetPixel(x, y, Color.White);
                        error = val - 255;
                    }
                    else
                    {
                        c.SetPixel(x, y, Color.Black);
                        error = val + error;
                    }
                }
            }

            g.DrawImage(c, 0, 0, w, h);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (bin.Count == 0) return;
            saveFileDialog1.DefaultExt = ".bin";
            saveFileDialog1.FileName = "*.bin";
            if (saveFileDialog1.ShowDialog() != DialogResult.OK) return;

            var f = File.Create(saveFileDialog1.FileName);
            f.Write(bin.ToArray(), 0, bin.Count);
            f.Close();
        }

        private void button_saveTXT_Click(object sender, EventArgs e)
        {
            if (bin.Count == 0) return;
            saveFileDialog1.DefaultExt = ".txt";
            saveFileDialog1.FileName = "*.txt";
            if (saveFileDialog1.ShowDialog() != DialogResult.OK) return;

            var f = File.CreateText(saveFileDialog1.FileName);
            f.Write(textBox1.Text);
            f.Close();
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            dither();
        }


        private void button_rasterize_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            var sb = new StringBuilder();

          //  sb.Append("1D 76 30 00 20 00 F0 00 ");
            bin.Clear();
            bin.Add(Convert.ToByte("1D", 16));
            bin.Add(Convert.ToByte("76", 16));
            bin.Add(Convert.ToByte("30", 16));

            bin.Add(Convert.ToByte("00", 16));

            var wh = ((w / 8) & 0xFF00) >> 8;
            var wl = (w / 8) & 0xFF;
            bin.Add((byte)wl);// Convert.ToByte("28", 16));//320 / 8 = 40 (0x28)
            bin.Add((byte)wh);// Convert.ToByte("00", 16));

            var hh = (h & 0xFF00) >> 8;
            var hl = h & 0xFF;
            bin.Add((byte)hl);// Convert.ToByte("F0", 16));//240
            bin.Add((byte)hh);// Convert.ToByte("00", 16));


            var col = 128;
            for (var y = 0; y < h; ++y) {
                for (var x = 0; x < w; )
                {
                    byte data = 0;
                    if (c.GetPixel(x++, y).R < col) data |= 0x80;
                    if (c.GetPixel(x++, y).R < col) data |= 0x40;
                    if (c.GetPixel(x++, y).R < col) data |= 0x20;
                    if (c.GetPixel(x++, y).R < col) data |= 0x10;

                    if (c.GetPixel(x++, y).R < col) data |= 0x08;
                    if (c.GetPixel(x++, y).R < col) data |= 0x04;
                    if (c.GetPixel(x++, y).R < col) data |= 0x02;
                    if (c.GetPixel(x++, y).R < col) data |= 0x01;

                    sb.Append(data.ToString("X2") + " ");
                    bin.Add(data);
                }
            }
            textBox1.Text = sb.ToString();
        }
    }
}
