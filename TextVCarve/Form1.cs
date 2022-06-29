using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TextVCarve
{
    public partial class Form1 : Form
    {

        public Bitmap b = new Bitmap("t2.png");
        public Bitmap bb, bg;
        public Graphics gg;

        public Color mask = Color.FromArgb(255, 255, 0, 0);
        public Form1()
        {
            InitializeComponent();
            bb = new Bitmap(b);
            bg = new Bitmap(256, 128);
            gg = Graphics.FromImage(bg);
            pictureBox2.Image = bg;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var w = b.Width;
            var h = b.Height;
            var m = Color.FromArgb(255, 255, 255, 255);

            for (var x = 0; x < w; ++x) for (var y = 0; y < h; ++y)
                {
                    if (b.GetPixel(x, y).Equals(m)) b.SetPixel(x, y, mask);
                }

            pictureBox1.Image = b;
        }

        static public int SafeTextToInt(string text, int fallback)
        {
            int res;
            if (int.TryParse(text, System.Globalization.NumberStyles.Integer, CultureInfo.InvariantCulture, out res))
            {
                return res;
            }
            return fallback;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var w = checkBox2.Checked ? 128 : b.Width;
            var h = checkBox2.Checked ? 128 : b.Height;
            var mr = 0;


            int range = SafeTextToInt(textBox1.Text, 24);

            var Circles = new List<Point>[range];

            for (int i = 1; i <= range; i++)
            {
                Circles[i-1] = new List<Point>();

                for (int ii = 0; ii < (10 * i); ii++)
                {
                    var a = 2 * Math.PI * ii / (10 * i);
                    var s = Math.Sin(a) * (i + 0.1f);
                    var c = Math.Cos(a) * (i + 0.1f);
                    Circles[i-1].Add(new Point((int)s, (int)c));
                }
                Circles[i - 1] = Circles[i - 1].Distinct().ToList();
            }

            for (var x = 0; x < w; ++x) for (var y = 0; y < h; ++y) if (!b.GetPixel(x, y).Equals(mask))
                {
                    var d = 0;
                    for (int r = 1; r <= range; r++)
                    {
                            foreach (Point p in Circles[r - 1]) {
                                var xx = x + p.X;
                                var yy = y + p.Y;

                                if ((xx >= 0) && (xx < w) && (yy >= 0) && (yy < h) && b.GetPixel(xx, yy).Equals(mask))
                                {
                                    d = r;
                                    r = range;
                                    break;
                                }
                            }
                    }
                    if (d > mr) mr = d;
                    d = (int)(255 * d / range);
                    b.SetPixel(x, y, Color.FromArgb(255, d, d, d));
                 }

            pictureBox1.Image = b;
            pictureBox1.Refresh();
            label1.Text = "Max R " + mr;
            label1.ForeColor = (mr == range) ? Color.Red : Color.Black;
        }

        private void button3_Click(object sender, EventArgs e)
        {

            var w = checkBox2.Checked ? 128 : b.Width;
            var h = checkBox2.Checked ? 128 : b.Height;
            var m = 0;

            for (var x = 0; x < w; ++x) for (var y = 0; y < h; ++y)
                {
                    var c = b.GetPixel(x, y);
                    if (c.G > m) m = c.G;
                    if (c.Equals(mask)) b.SetPixel(x, y, Color.Black);
                }
            float adj = m / 255.0f;
            for (var x = 0; x < w; ++x) for (var y = 0; y < h; ++y)
                {
                    var c = b.GetPixel(x, y);
                    var v = (int)(c.G / adj);
                    b.SetPixel(x, y, Color.FromArgb(255, v, v, v));
                }

            pictureBox1.Image = b;
            pictureBox1.Refresh();

        }

        private int getGamma(int val, int max, float g)
        {
            float fmax = max;
            if (!checkBox1.Checked)
            {
                float x = val / fmax;
                return max - (int)(fmax * Math.Pow( -x + 1.0f, 1.0f / g));
            } else
            {
                return (int)(fmax * Math.Pow(val / fmax, g));
            }
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {

            var w = checkBox2.Checked ? 128 : b.Width;
            var h = checkBox2.Checked ? 128 : b.Height;
            float adj = 1.0f + (trackBar1.Value / 100.0f); // 0.5f to 1.5f
            //                                                0.25 to 2.0f
            adj = adj * adj;
            gg.FillRectangle(Brushes.White, gg.VisibleClipBounds);
            gg.DrawLine(Pens.Red, 128, 0, 128, 128);
            gg.DrawLine(Pens.Blue, 32, 0, 32, 128);
            gg.DrawLine(Pens.Blue, 64, 0, 64, 128);
            gg.DrawLine(Pens.Blue, 96, 0, 96, 128);
            gg.DrawLine(Pens.Blue, 160, 0, 160, 128);
            gg.DrawLine(Pens.Blue, 192, 0, 192, 128);
            gg.DrawLine(Pens.Blue, 224, 0, 224, 128);

            gg.DrawLine(Pens.Blue, 0, 32, 256, 32);
            gg.DrawLine(Pens.Blue, 0, 64, 256, 64);
            gg.DrawLine(Pens.Blue, 0, 96, 256, 96);

            gg.DrawLine(Pens.Gray, 0, 128, 128, 0);
            gg.DrawLine(Pens.Gray, 255, 128, 128, 0);
            for (var x = 1; x < 128; ++x)
            {
                var v1 = getGamma(x, 128, adj);
                var v2 = getGamma(x-1, 128, adj);
                gg.DrawLine(Pens.Black, x - 1, 128-v2, x, 128-v1);
                gg.DrawLine(Pens.Black, 255-(x - 1), 128 - v2, 255 - x, 128 - v1);
            }


            for (var x = 0; x < w; ++x) for (var y = 0; y < h; ++y)
            {
                var c = b.GetPixel(x, y);
                var v = getGamma(c.G, 255, adj);
                bb.SetPixel(x, y, Color.FromArgb(255, v, v, v));
            }


            pictureBox1.Image = bb;
            pictureBox1.Refresh();
            pictureBox2.Refresh();
        }
    }
}
