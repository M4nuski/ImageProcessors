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
        byte[,] veraPalette = {
            {0, 0, 0}, {255, 255, 255}, {136, 0, 0}, {170, 255, 238}, {204, 68, 204}, {0, 204, 85}, {0, 0, 170}, {238, 238, 119}, {221, 136, 85}, {102, 68, 0}, {255, 119, 119}, {51, 51, 51}, {119, 119, 119}, {170, 255, 102}, {0, 136, 255}, {187, 187, 187}, 
            {0, 0, 0}, {17, 17, 17}, {34, 34, 34}, {51, 51, 51}, {68, 68, 68}, {85, 85, 85}, {102, 102, 102}, {119, 119, 119}, {136, 136, 136}, {153, 153, 153}, {170, 170, 170}, {187, 187, 187}, {204, 204, 204}, {221, 221, 221}, {238, 238, 238}, {255, 255, 255}, 
            {34, 17, 17}, {68, 51, 51}, {102, 68, 68}, {136, 102, 102}, {170, 136, 136}, {204, 153, 153}, {255, 187, 187}, {34, 17, 17}, {68, 34, 34}, {102, 51, 51}, {136, 68, 68}, {170, 85, 85}, {204, 102, 102}, {255, 119, 119}, {34, 0, 0}, {68, 17, 17}, 
            {102, 17, 17}, {136, 34, 34}, {170, 34, 34}, {204, 51, 51}, {255, 51, 51}, {34, 0, 0}, {68, 0, 0}, {102, 0, 0}, {136, 0, 0}, {170, 0, 0}, {204, 0, 0}, {255, 0, 0}, {34, 34, 17}, {68, 68, 51}, {102, 102, 68}, {136, 136, 102}, 
            {170, 170, 136}, {204, 204, 153}, {255, 238, 187}, {34, 17, 17}, {68, 51, 34}, {102, 85, 51}, {136, 119, 68}, {170, 153, 85}, {204, 187, 102}, {255, 221, 119}, {34, 17, 0}, {68, 51, 17}, {102, 85, 17}, {136, 102, 34}, {170, 136, 34}, {204, 170, 51}, 
            {255, 204, 51}, {34, 17, 0}, {68, 51, 0}, {102, 68, 0}, {136, 102, 0}, {170, 136, 0}, {204, 153, 0}, {255, 187, 0}, {17, 34, 17}, {51, 68, 51}, {85, 102, 68}, {119, 136, 102}, {153, 170, 136}, {187, 204, 153}, {221, 255, 187}, {17, 34, 17}, 
            {51, 68, 34}, {68, 102, 51}, {102, 136, 68}, {136, 170, 85}, {153, 204, 102}, {187, 255, 119}, {17, 34, 0}, {34, 68, 17}, {68, 102, 17}, {85, 136, 34}, {102, 170, 34}, {136, 204, 51}, {153, 255, 51}, {17, 34, 0}, {34, 68, 0}, {51, 102, 0}, 
            {68, 136, 0}, {85, 170, 0}, {102, 204, 0}, {119, 255, 0}, {17, 34, 17}, {51, 68, 51}, {68, 102, 85}, {102, 136, 102}, {136, 170, 136}, {153, 204, 170}, {187, 255, 204}, {17, 34, 17}, {34, 68, 34}, {51, 102, 68}, {68, 136, 85}, {85, 170, 102}, 
            {102, 204, 136}, {119, 255, 153}, {0, 34, 0}, {17, 68, 17}, {17, 102, 34}, {34, 136, 51}, {34, 170, 68}, {51, 204, 85}, {51, 255, 102}, {0, 34, 0}, {0, 68, 17}, {0, 102, 17}, {0, 136, 34}, {0, 170, 34}, {0, 204, 51}, {0, 255, 51}, 
            {17, 34, 34}, {51, 68, 68}, {68, 102, 102}, {102, 136, 136}, {136, 170, 170}, {153, 204, 204}, {187, 255, 255}, {17, 34, 34}, {34, 68, 68}, {51, 102, 102}, {68, 136, 136}, {85, 170, 170}, {102, 204, 204}, {119, 255, 255}, {0, 34, 34}, {17, 68, 68}, 
            {17, 102, 102}, {34, 136, 136}, {34, 170, 170}, {51, 204, 204}, {51, 255, 255}, {0, 34, 34}, {0, 68, 68}, {0, 102, 102}, {0, 136, 136}, {0, 170, 170}, {0, 204, 204}, {0, 255, 255}, {17, 17, 34}, {51, 51, 68}, {68, 85, 102}, {102, 102, 136}, 
            {136, 136, 170}, {153, 170, 204}, {187, 204, 255}, {17, 17, 34}, {34, 34, 68}, {51, 68, 102}, {68, 85, 136}, {85, 102, 170}, {102, 136, 204}, {119, 153, 255}, {0, 0, 34}, {17, 17, 68}, {17, 34, 102}, {34, 51, 136}, {34, 68, 170}, {51, 85, 204}, 
            {51, 102, 255}, {0, 0, 34}, {0, 17, 68}, {0, 17, 102}, {0, 34, 136}, {0, 34, 170}, {0, 51, 204}, {0, 51, 255}, {17, 17, 34}, {51, 51, 68}, {85, 68, 102}, {119, 102, 136}, {153, 136, 170}, {187, 153, 204}, {221, 187, 255}, {17, 17, 34}, 
            {51, 34, 68}, {68, 51, 102}, {102, 68, 136}, {136, 85, 170}, {153, 102, 204}, {187, 119, 255}, {17, 0, 34}, {34, 17, 68}, {68, 17, 102}, {85, 34, 136}, {102, 34, 170}, {136, 51, 204}, {153, 51, 255}, {17, 0, 34}, {34, 0, 68}, {51, 0, 102}, 
            {68, 0, 136}, {85, 0, 170}, {102, 0, 204}, {119, 0, 255}, {34, 17, 34}, {68, 51, 68}, {102, 68, 102}, {136, 102, 136}, {170, 136, 170}, {204, 153, 204}, {255, 187, 238}, {34, 17, 17}, {68, 34, 51}, {102, 51, 85}, {136, 68, 119}, {170, 85, 153}, 
            {204, 102, 187}, {255, 119, 221}, {34, 0, 17}, {68, 17, 51}, {102, 17, 85}, {136, 34, 102}, {170, 34, 136}, {204, 51, 170}, {255, 51, 204}, {34, 0, 17}, {68, 0, 51}, {102, 0, 68}, {136, 0, 102}, {170, 0, 136}, {204, 0, 153}, {255, 0, 187}
        };

    Bitmap b, c;
        Graphics g;
        List<byte> bin = new List<byte>();
        int w = 84;
        int h = 48;

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

            // w = pictureBox1.Size.Width;
            // h = pictureBox1.Size.Height;
            //pictureBox1.Size.Width = w;
            pictureBox1.Size = new Size(w, h);

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

        private void button1_Click(object sender, EventArgs e)
        {
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
            pictureBox1.Image = b;
            var nb = new Bitmap(b.Width, b.Height);

            Console.WriteLine(findPaletteMatch(Color.FromArgb(255, 0, 0)));
            Console.WriteLine(findPaletteMatch(Color.FromArgb(0, 255, 0)));
            Console.WriteLine(findPaletteMatch(Color.FromArgb(0, 0, 255)));
            var bList = new List<byte>();
            for (var y = 0; y < b.Height; ++y)
            {
                for (var x = 0; x < b.Width; ++x)
                {
                    var sdfa = findPaletteMatch(b.GetPixel(x, y));
                    //byte sdfa = 0;
                    //var cv = b.GetPixel(x, y).R;
                    //sdfa = (byte)(52 + Math.Floor(cv / 32.0d));
                    //if (sdfa < 53) sdfa = 0;
                    //bList.Add(sdfa);
                    nb.SetPixel(x, y, Color.FromArgb(veraPalette[sdfa, 0], veraPalette[sdfa, 1], veraPalette[sdfa, 2]));


                    textBox1.Text += sdfa.ToString() + " ";
                }
                textBox1.Text += "\r\n";
            }

            pictureBox2.Image = nb;
            pictureBox2.Refresh();
            Console.WriteLine(bList.Count);

  
            saveFileDialog1.DefaultExt = ".bin";
            saveFileDialog1.FileName = "*.bin";
            if (saveFileDialog1.ShowDialog() != DialogResult.OK) return;

            var f = File.Create(saveFileDialog1.FileName);
            f.Write(bList.ToArray(), 0, bList.Count);
            f.Close();

        }

        private byte findPaletteMatch(Color c)
        {
            byte result = 0;
            int error = 256 * 4;

            for (int index = 0; index < 256; ++index)
            {
                int newError = Math.Abs(c.R - veraPalette[index, 0]);
                newError += Math.Abs(c.G - veraPalette[index, 1]);
                newError += Math.Abs(c.B - veraPalette[index, 2]);

                if (newError < error)
                {
                    error = newError;
                    result = (byte)index;
                }
            }

            return result;
        }

        private void button2_Click_1(object sender, EventArgs e)
        {

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
            pictureBox1.Image = b;
            var nb = new Bitmap(b.Width, b.Height, System.Drawing.Imaging.PixelFormat.Format16bppRgb565);


            var bList = new List<UInt16>();
            for (var y = 0; y < b.Height; ++y)
            {
                for (var x = 0; x < b.Width; ++x)
                {
                    var ccol = b.GetPixel(x, y);
                    byte cr = (byte)(ccol.R >> 3); // 000r rrrr 5
                    byte cg = (byte)(ccol.G >> 2); // 00gg gggg 6
                    byte cb = (byte)(ccol.B >> 3); // 000b bbbb 5

                    UInt16 res = (UInt16)((cr << 11) | (cg << 5) | (cb));
                    // 54321098 76543210
                    // rrrrrggg gggbbbbb
                    bList.Add(res);

                    nb.SetPixel(x, y, Color.FromArgb(cr << 3, cg << 2, cb << 3));

                }
                textBox1.Text += "line to 565\r\n";
            }

            pictureBox2.Image = nb;
            pictureBox2.Refresh();
            Console.WriteLine(bList.Count);


            saveFileDialog1.DefaultExt = ".bin";
            saveFileDialog1.FileName = "*.bin";
            if (saveFileDialog1.ShowDialog() != DialogResult.OK) return;

            // var f = File.CreateText(saveFileDialog1.FileName);
            var f = File.Create(saveFileDialog1.FileName);
            foreach (var b in bList) {
                byte lbyte = (byte)((b >> 8) & 0x00FF);
                byte hbyte = (byte)(b & 0x00FF);
                //f.Write(hbyte.ToString("X2") + " " + lbyte.ToString("X2") + " ");
                f.WriteByte(lbyte);
                f.WriteByte(hbyte);
            };
            f.Close();



        }

        private void button_rasterize_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            var sb = new StringBuilder();
            if (POS_HDR_checkBox.Checked)
            {
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
            }

            var col = 128;
            for (var y = 0; y < h; y += 8) {
                for (var x = 0; x < w; x++)
                {
                    byte data = 0;
                    if (POS_HDR_checkBox.Checked)
                    {
                        if (c.GetPixel(x++, y).R < col) data |= 0x80;
                        if (c.GetPixel(x++, y).R < col) data |= 0x40;
                        if (c.GetPixel(x++, y).R < col) data |= 0x20;
                        if (c.GetPixel(x++, y).R < col) data |= 0x10;

                        if (c.GetPixel(x++, y).R < col) data |= 0x08;
                        if (c.GetPixel(x++, y).R < col) data |= 0x04;
                        if (c.GetPixel(x++, y).R < col) data |= 0x02;
                        if (c.GetPixel(x++, y).R < col) data |= 0x01;
                    } else
                    {
                        if (c.GetPixel(x, y+7).R < col) data |= 0x80;
                        if (c.GetPixel(x, y+6).R < col) data |= 0x40;
                        if (c.GetPixel(x, y+5).R < col) data |= 0x20;
                        if (c.GetPixel(x, y+4).R < col) data |= 0x10;

                        if (c.GetPixel(x, y+3).R < col) data |= 0x08;
                        if (c.GetPixel(x, y+2).R < col) data |= 0x04;
                        if (c.GetPixel(x, y+1).R < col) data |= 0x02;
                        if (c.GetPixel(x, y+0).R < col) data |= 0x01;
                    }
                        sb.Append(data.ToString("X2") + " ");
                    bin.Add(data);
                }
            }
            textBox1.Text = sb.ToString();
        }
    }
}
