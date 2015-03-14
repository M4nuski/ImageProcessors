using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Memo;

namespace AlgoTest1
{
    public partial class Form1 : Form
    {
        public byte[] bmp;
        public double sigma = 0.2025d*0.2025d;
        public double sigma2 = 0.500d;
      //  private readonly StringBuilder _textBuilder = new StringBuilder();
        public Form1()
        {
            InitializeComponent();
        }

        private void msg(string s)
        {
            //_/textBuilder.AppendLine(s);
         //   textBox1.Text = _textBuilder.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var slope = new double[512];
            for (int i = -256; i < 256; i++)
            {
                var x = i/256.0d;
                slope[i + 256] = Math.Exp(-(x * x) / sigma);
            }
            for (int i = 0; i < 512; i++)
            {
                int y = 256-(int)(slope[i]*255);
                y = (y < 0) ? 0 : (y > 511) ? 511 : y; //clamp
                SetPixel(i, y, 255, 0, 0);
            }
            pictureBox1.Image = DataToImage(bmp, 512, 512, PixelFormat.Format24bppRgb);
        }

        private void SetPixel(int X, int Y, byte R, byte G, byte B)
        {
            var offset = 3 * ((512*Y) + X);
            bmp[offset] = B;
            bmp[offset+1] = G;
            bmp[offset+2] = R;
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            bmp = new byte[512*512*3];
       
            for (int i = 0; i < bmp.Length; i++) bmp[i] = 255;
            for (int i = 0; i < 512 * 3; i++) bmp[i + (256*512*3)] = 0;
            for (int i = 0; i < 512; i++)
            {
                bmp[768 + (i * 512 * 3)] = 0;
                bmp[769 + (i * 512 * 3)] = 0;
                bmp[770 + (i * 512 * 3)] = 0;
            }
       
            pictureBox1.Image = DataToImage(bmp, 512, 512, PixelFormat.Format24bppRgb);
        }

        public Image DataToImage(byte[] Data, int Width, int Height, PixelFormat Format)
        {
            var BytesPerPixel = Image.GetPixelFormatSize(Format) / 8;
            if (Data.Length == (Width*Height*BytesPerPixel))
            {
                var bmpData = new Bitmap(Width, Height);
                var pixdata = bmpData.LockBits(new Rectangle(0, 0, Width, Height), ImageLockMode.WriteOnly, Format);
                Marshal.Copy(Data, 0, pixdata.Scan0, Width * Height * BytesPerPixel);
                bmpData.UnlockBits(pixdata);
                return bmpData;
            } else return null;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            memo1.Clear();
            for (int i = 0; i < bmp.Length; i++) bmp[i] = 255;
            for (int i = 0; i < 512 * 3; i++) bmp[i + (256 * 512 * 3)] = 0;
            for (int i = 0; i < 512; i++)
            {
                bmp[768 + (i * 512 * 3)] = 0;
                bmp[769 + (i * 512 * 3)] = 0;
                bmp[770 + (i * 512 * 3)] = 0;
            }

            pictureBox1.Image = DataToImage(bmp, 512, 512, PixelFormat.Format24bppRgb);
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            sigma = trackBar1.Value/100.0d;
            button1.Text = sigma.ToString("F3");
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1) button1_Click(sender, e);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var slope = new double[512];
            for (int i = -256; i < 256; i++)
            {
                var x = Math.Abs(i);

                slope[i + 256] = (x == 0) ? 1.0d :  (256.0d/(x*sigma2))/256.0d;
            }
            for (int i = 0; i < 512; i++)
            {
                int y = 256 - (int)(slope[i] * 255);
                y = (y < 0) ? 0 : (y > 511) ? 511 : y; //clamp
                SetPixel(i, y, 0, 0, 255);
            }
            pictureBox1.Image = DataToImage(bmp, 512, 512, PixelFormat.Format24bppRgb);
        }

        private void trackBar2_Scroll(object sender, EventArgs e)
        {
            sigma2 = trackBar2.Value / 20.0d;
            button3.Text = sigma2.ToString("F3");
        }
    }
}
