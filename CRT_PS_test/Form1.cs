using System;
using System.CodeDom;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.XPath;

namespace CRT_PS_test
{
    public partial class Form1 : Form
    {
        Bitmap source1 = new Bitmap(@"C:\Workfolder\VGA test2.png");
        List<Bitmap> shaded = new List<Bitmap>();
        List<int> shadedAt = new List<int>();
        List<string> shadeText = new List<string>();
        int currentChange = -1;
     
        float gamma = 1.0f;
        float saturation = 0.0f;
        float contrast = 1.0f;
        float ratio = 0.5f;
        int currentShader = 0;
       

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape) this.Close();
            if (e.KeyCode == Keys.Return)
            {
                if (this.WindowState == FormWindowState.Maximized)
                {
                    this.WindowState = FormWindowState.Normal;
                    this.Size = new System.Drawing.Size(1280, 720);
                    this.FormBorderStyle = FormBorderStyle.Sizable;
                } else
                {
                    this.FormBorderStyle = FormBorderStyle.None;
                    this.Size = new System.Drawing.Size(1920, 1080);
                    this.WindowState = FormWindowState.Maximized;
                  //  this.TopMost = true;
                 //   pictureBox1.Size = new System.Drawing.Size(960, 720);
                }
            }
            if (e.KeyCode == Keys.S) pictureBox1.Image.Save(DateTime.Now.ToString("yyyy-MM-dd HH-mm-ss-ff") + ".png");


            if (e.KeyCode == Keys.D1) currentShader = 0; // source image
            if (e.KeyCode == Keys.D2) currentShader = 1; // 
            if (e.KeyCode == Keys.D3) currentShader = 2; //
            if (e.KeyCode == Keys.D4) currentShader = 3; // 
            if (e.KeyCode == Keys.D5) currentShader = 4; // 
            if (e.KeyCode == Keys.D6) currentShader = 5; // 


            if (e.KeyCode == Keys.D0) currentShader = 6; // 

          //  if (currentChange != shadedAt[currentShader]) genShade();
            pictureBox1.Image = shaded[currentShader];
            label4.Text = shadeText[currentShader];
           
           
        }

        public void genShade()
        {
            this.Cursor = Cursors.WaitCursor;
            switch (currentShader)
            {
                case 4: // Blur
                    {
                        for (var x = 0; x < shaded[4].Width; x++)
                            for (var y = 0; y < shaded[4].Height; y = y + 3)
                            {
                                var c1 = shaded_GetPixel(1, (x - 2) / 3, y / 3);
                                var c2 = shaded_GetPixel(1, (x - 1) / 3, y / 3);
                                var c3 = shaded_GetPixel(1, (x    ) / 3, y / 3);
                                var c4 = shaded_GetPixel(1, (x + 1) / 3, y / 3);
                                var c5 = shaded_GetPixel(1, (x + 2) / 3, y / 3);
                                var c = wMax(c1, c2, c3, c4, c5, 0.25f, 0.707f, 1.0f, 0.707f, 0.25f);
                                c = saturationColor(c, 0.7f);
                                shaded[4].SetPixel(x, y    , c);
                                shaded[4].SetPixel(x, y + 1, c);
                                shaded[4].SetPixel(x, y + 2, c);
                            }
                        break;
                    }
                case 5: // RGB subpixels
                    {
                        for (var x = 0; x < shaded[5].Width; x++)
                            for (var y = 0; y < shaded[5].Height; y++)
                            {
                                var c = shaded[4].GetPixel(x, y);
                                if ((x % 3) == 0) c = getR(c);
                                if ((x % 3) == 1) c = getG(c);
                                if ((x % 3) == 2) c = getB(c);
                                c = contrastColor(c);
                                c = saturationColor(c);
                                c = gammaColor(c);
                                shaded[5].SetPixel(x, y, c);
                            }
                        break;
                    }


                case 6: // even field
                    {
                        for (var x = 0; x < shaded[4].Width; x++)
                            for (var y = 0; y < shaded[4].Height; y = y + 3)
                            {
                                var c1 = shaded_GetPixel(1, (x - 2) / 3, y / 3);
                                var c2 = shaded_GetPixel(1, (x - 1) / 3, y / 3);
                                var c3 = shaded_GetPixel(1, (x) / 3, y / 3);
                                var c4 = shaded_GetPixel(1, (x + 1) / 3, y / 3);
                                var c5 = shaded_GetPixel(1, (x + 2) / 3, y / 3);
                                var c = wMax(c1, c2, c3, c4, c5, 0.25f, 0.707f, 1.0f, 0.707f, 0.25f);
                                c = saturationColor(c, 0.7f);
                                shaded[4].SetPixel(x, y, c);
                                shaded[4].SetPixel(x, y + 1, c);
                                shaded[4].SetPixel(x, y + 2, c);
                            }
                        break;
                    }

                case 7: // odd field
                    {
                        for (var x = 0; x < shaded[4].Width; x++)
                            for (var y = 0; y < shaded[4].Height; y = y + 3)
                            {
                                var c1 = shaded_GetPixel(1, (x - 2) / 3, y / 3);
                                var c2 = shaded_GetPixel(1, (x - 1) / 3, y / 3);
                                var c3 = shaded_GetPixel(1, (x) / 3, y / 3);
                                var c4 = shaded_GetPixel(1, (x + 1) / 3, y / 3);
                                var c5 = shaded_GetPixel(1, (x + 2) / 3, y / 3);
                                var c = wMax(c1, c2, c3, c4, c5, 0.25f, 0.707f, 1.0f, 0.707f, 0.25f);
                                c = saturationColor(c, 0.7f);
                                shaded[4].SetPixel(x, y, c);
                                shaded[4].SetPixel(x, y + 1, c);
                                shaded[4].SetPixel(x, y + 2, c);
                            }
                        break;
                    }

                case 14: // RGB subpixels + blur
                    {
                        for (var x = 0; x < shaded[1].Width; x++)
                            for (var y = 0; y < shaded[1].Height; y++)
                            {
                                var c = wAvg(shaded[2].GetPixel(x, y), shaded[3].GetPixel(x, y), ratio, 1.0f - ratio);
                              //  c = contrastColor(c);
                              //  c = saturationColor(c);
                              //  c = gammaColor(c);
                                shaded[4].SetPixel(x, y, c);
                            }
                        break;
                    }

                case 15: // blur minus CMY
                    {
                        for (var x = 0; x < shaded[1].Width; x++)
                            for (var y = 0; y < shaded[1].Height; y++)
                            {
                                var cBase = shaded[2].GetPixel(x, y);
                                Color cMask = Color.White;
                                if ((x % 3) == 0) cMask = getC(cBase);
                                if ((x % 3) == 1) cMask = getM(cBase);
                                if ((x % 3) == 2) cMask = getY(cBase);
                            //    cMask = gammaColor(cMask);
                                Color c = Color.FromArgb( 
                                    Math.Max(cBase.R - cMask.R/2, 0),
                                    Math.Max(cBase.G - cMask.G/2, 0),
                                    Math.Max(cBase.B - cMask.B/2, 0)
                                    );
                                shaded[5].SetPixel(x, y, c);
                            }
                        break;
                    }
                case 16: // blur minus CMY even odd
                    //640x480 to 320x240
                    //even odd to 960(1280)x720 letterboxed
                    //blur
                    //RGB subpixel
                    {
                        for (var x = 0; x < shaded[1].Width; x++)
                            for (var y = 0; y < shaded[1].Height; y++)
                            {
                                var c = shaded[5].GetPixel(x, y);
                                if (y % 2 == 0)
                                {
                                    shaded[6].SetPixel(x, y, c);
                                    shaded[6].SetPixel(x, y+1, c);
                                } else
                                {
                                    shaded[7].SetPixel(x, y-1, c);
                                    shaded[7].SetPixel(x, y, c);
                                }
                                    
                            }
                        break;
                    }
            }

            shadedAt[currentShader] = currentChange;
            this.Refresh();
            this.Cursor = Cursors.Default;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            shadedAt.AddRange(new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 });


            // shaded[0]
            pictureBox1.Image = source1;
            shaded.Add(source1);
            shadeText.Add("Source 640x480 VGA");

            // shaded[1]
            shaded.Add(new Bitmap(960, 480));
            shadeText.Add("Blur+Sat 960x480");
            for (var x = 0; x < shaded[1].Width; x++)
                for (var y = 0; y < shaded[1].Height; y++)
                {
                    var c1 = shaded_GetPixel(0, (2*x/3) - 2, y);
                    var c2 = shaded_GetPixel(0, (2*x/3) - 1, y);
                    var c3 = shaded_GetPixel(0, (2*x/3) + 0, y);
                    var c4 = shaded_GetPixel(0, (2*x/3) + 1, y);
                    var c5 = shaded_GetPixel(0, (2*x/3) + 2, y);
                    var c = wMax(c1, c2, c3, c4, c5, 0.25f, 0.707f, 1.0f, 0.707f, 0.25f);
                    c = saturationColor(c, 0.7f);
                    shaded[1].SetPixel(x, y, c);
                }

            // shaded[2]
            shaded.Add(new Bitmap(960, 720));
            shadeText.Add("Even 2/3 960x720");
            for (var x = 0; x < shaded[2].Width; x++)
                for (var y = 0; y < 240; y++)
                {
                    var c1 = shaded[1].GetPixel(x, 2 * y);
                    var c2 = shaded[1].GetPixel(x, 2 * y + 1);
                    shaded[2].SetPixel(x, 3 * y + 0, c1);
                    shaded[2].SetPixel(x, 3 * y + 1, c1);
                    shaded[2].SetPixel(x, 3 * y + 2, c2);
                }

            // shaded[3]
            shaded.Add(new Bitmap(960, 720));
            shadeText.Add("Odd 2/3 960x720");
            for (var x = 0; x < shaded[3].Width; x++)
                for (var y = 0; y < 240; y++)
                {
                    var c1 = shaded[1].GetPixel(x, 2 * y);
                    var c2 = shaded[1].GetPixel(x, 2 * y + 1);
                    shaded[3].SetPixel(x, 3 * y + 0, c1);
                    shaded[3].SetPixel(x, 3 * y + 1, c2);
                    shaded[3].SetPixel(x, 3 * y + 2, c2);
                }



            // shaded[4]
            shaded.Add(new Bitmap(960, 720));
            shadeText.Add("Even subPix 960x720");
            for (var x = 0; x < shaded[4].Width; x++)
                for (var y = 0; y < shaded[4].Height; y++)
                {
                    var cBase = shaded[2].GetPixel(x, y);
                    Color cMask = Color.White;
                    if ((x % 3) == 0) cMask = getC(cBase);
                    if ((x % 3) == 1) cMask = getM(cBase);
                    if ((x % 3) == 2) cMask = getY(cBase);
                    Color c = Color.FromArgb(
                        Math.Max(cBase.R - cMask.R / 2, 0),
                        Math.Max(cBase.G - cMask.G / 2, 0),
                        Math.Max(cBase.B - cMask.B / 2, 0)
                        );
                    shaded[4].SetPixel(x, y, c);
                    // var c = subPixelColor(cBase);
                    // shaded[4].SetPixel(x, y, c[(x % 3)]);
                }

            // shaded[5]
            shaded.Add(new Bitmap(960, 720));
            shadeText.Add("Odd subPix 960x720");
            for (var x = 0; x < shaded[5].Width; x++)
                for (var y = 0; y < shaded[5].Height; y++)
                {
                    var cBase = shaded[3].GetPixel(x, y);
                    Color cMask = Color.White;
                    if ((x % 3) == 0) cMask = getC(cBase);
                    if ((x % 3) == 1) cMask = getM(cBase);
                    if ((x % 3) == 2) cMask = getY(cBase);
                    Color c = Color.FromArgb(
                        Math.Max(cBase.R - cMask.R / 2, 0),
                        Math.Max(cBase.G - cMask.G / 2, 0),
                        Math.Max(cBase.B - cMask.B / 2, 0)
                        );
                    shaded[5].SetPixel(x, y, c);
                }

            // shaded[6]
            shaded.Add(shaded[5]); // dummy
            shadeText.Add("Jitter");



            //  shadeText.Add("");
            //  shadeText.Add("even/odd jitter");


            /*
            shaded2 = new Bitmap(source1.Width, source1.Height);
            for (var x = 0; x < source1.Width; x++)
                for (var y = 0; y < source1.Height; y++)   
                {
                    var c = source1.GetPixel(x, y);
                    if ((x % 3) == 0) c = getR(c);
                    if ((x % 3) == 1) c = getG(c);
                    if ((x % 3) == 2) c = getB(c);

                    shaded2.SetPixel(x, y, c);
                }

            shaded6 = new Bitmap(source1.Width * 2, source1.Height * 2);
            for (var x = 0; x < shaded6.Width; x++)
                for (var y = 0; y < shaded6.Height; y++)
                {
                    var c = source1.GetPixel(x / 2, y / 2);
                    shaded6.SetPixel(x, y, c);
                }

            shaded3 = new Bitmap(source1.Width*2, source1.Height*2);
            for (var x = 0; x < shaded3.Width; x++)
                for (var y = 0; y < shaded3.Height; y++)
                {
                    var c = source1.GetPixel(x/2, y/2);
                    if ((x % 3) == 0) c = getR(c);
                    if ((x % 3) == 1) c = getG(c);
                    if ((x % 3) == 2) c = getB(c);

                    shaded3.SetPixel(x, y, c);

                }

            shaded4 = new Bitmap(source1.Width, source1.Height);
            for (var x = 0; x < source1.Width; x++)
                for (var y = 0; y < source1.Height; y++)
                {
                    var c1 = source1_GetPrevPixel(x, y);
                    var c2 = source1.GetPixel(x, y);
                    var c3 = source1_GetNextPixel(x, y);

                    var c = wAvg(c1, c2, c3, 0.5f, 1.0f, 0.5f);
                    if ((x % 3) == 0) c = wAvg(getR(c), getG(c), getB(c), 1.0f, 0.25f, 0.25f);
                    if ((x % 3) == 1) c = wAvg(getR(c), getG(c), getB(c), 0.25f, 1.0f, 0.25f);
                    if ((x % 3) == 2) c = wAvg(getR(c), getG(c), getB(c), 0.25f, 0.25f, 1.0f);

                    shaded4.SetPixel(x, y, saturationColor(contrastColor(gammaColor(c))));
                }

            shaded5 = new Bitmap(source1.Width*2, source1.Height*2);
            for (var x = 0; x < shaded5.Width; x++)
                for (var y = 0; y < shaded5.Height; y++)
                {
                    var c1 = source1_GetPixel((x-1)/2, y/2);
                    var c2 = source1_GetPixel(x/2, y/2);
                    var c3 = source1_GetPixel((x+1)/2, y/2);

                    var c = wAvg(c1, c2, c3, 0.5f, 1.0f, 0.5f);
                    if ((x % 3) == 0) c = wAvg(getR(c), getG(c), getB(c), 1.0f, 0.25f, 0.25f);
                    if ((x % 3) == 1) c = wAvg(getR(c), getG(c), getB(c), 0.25f, 1.0f, 0.25f);
                    if ((x % 3) == 2) c = wAvg(getR(c), getG(c), getB(c), 0.25f, 0.25f, 1.0f);

                    shaded5.SetPixel(x, y, saturationColor(contrastColor(gammaColor(c))));
                }*/
        }
        private Color[] subPixelColor(Color c)
        {
            var max = Math.Max(Math.Max(c.R, c.G), c.B);

            if (max >= 128)
            {

                return new Color[3] { 
                    Color.FromArgb(c.R, c.G * (max - 127) / 128, c.B * (max - 127) / 128), 
                    Color.FromArgb(c.R * (max - 127) / 128, c.G, c.B * (max - 127) / 128), 
                    Color.FromArgb(c.R * (max - 127) / 128, c.G * (max - 127) / 128, c.B) 
                };
            } else
            {
                return new Color[3] { 
                    Color.FromArgb(c.R * 2, 0, 0), 
                    Color.FromArgb(0, c.G * 2, 0), 
                    Color.FromArgb(0, 0, c.B * 2) 
                };
            }
        } 

        private Color gammaColor(Color c)
        {
            // return (c);
            var nr = Math.Pow(c.R / 255.0, gamma) * 255;
            var ng = Math.Pow(c.G / 255.0, gamma) * 255;
            var nb = Math.Pow(c.B / 255.0, gamma) * 255;
            return Color.FromArgb((int)nr, (int)ng, (int)nb);
        }
        private Color gammaColor(Color c, float f)
        {
            // return (c);
            var nr = Math.Pow(c.R / 255.0, f) * 255;
            var ng = Math.Pow(c.G / 255.0, f) * 255;
            var nb = Math.Pow(c.B / 255.0, f) * 255;
            return Color.FromArgb((int)nr, (int)ng, (int)nb);
        }
        private Color contrastColor(Color c)
        {
            var nr = (c.R / 255.0f) * contrast * 255;
            var ng = (c.G / 255.0f) * contrast * 255;
            var nb = (c.B / 255.0f) * contrast * 255;
            if (nr > 255) nr = 255;
            if (ng > 255) ng = 255;
            if (nb > 255) nb = 255;
            return Color.FromArgb((int)nr, (int)ng, (int)nb);
        }
        private Color contrastColor(Color c, float f)
        {
            var nr = (c.R / 255.0f) * f * 255;
            var ng = (c.G / 255.0f) * f * 255;
            var nb = (c.B / 255.0f) * f * 255;
            if (nr > 255) nr = 255;
            if (ng > 255) ng = 255;
            if (nb > 255) nb = 255;
            return Color.FromArgb((int)nr, (int)ng, (int)nb);
        }
        private Color saturationColor(Color c)
        { // = 0.2989 R + 0.5870 G + 0.1140 B 
          // float lum = c.R * 0.2989f + c.G * 0.5870f + c.B * 0.1140f;
            float lum = c.R;// * 0.3333f + c.G * 0.3334f + c.B * 0.3333f;
            if (lum < c.G) lum = c.G;
            if (lum > c.B) lum = c.B;

            var nr = c.R - ((lum - c.R) * saturation);
            if (nr < 0) nr = 0;
            if (nr > 255) { nr = 255; }

            var ng = c.G - ((lum - c.G) * saturation);
            if (ng < 0) ng = 0;
            if (ng > 255) { ng = 255; }

            var nb = c.B - ((lum - c.B) * saturation);
            if (nb < 0) nb = 0;
            if (nb > 255) { nb = 255; }

            return Color.FromArgb((int)nr, (int)ng, (int)nb);
        }
        private Color saturationColor(Color c, float f)
        { // = 0.2989 R + 0.5870 G + 0.1140 B 
          // float lum = c.R * 0.2989f + c.G * 0.5870f + c.B * 0.1140f;
            float lum = c.R * 0.3333f + c.G * 0.3334f + c.B * 0.3333f;
            var nr = c.R - ((lum - c.R) * f);
            if (nr < 0) nr = 0;
            if (nr > 255) { nr = 255; }

            var ng = c.G - ((lum - c.G) * f);
            if (ng < 0) ng = 0;
            if (ng > 255) { ng = 255; }

            var nb = c.B - ((lum - c.B) * f);
            if (nb < 0) nb = 0;
            if (nb > 255) { nb = 255; }

            return Color.FromArgb((int)nr, (int)ng, (int)nb);
        }


        private Color shaded_GetPixel(int index, int x, int y)
        {
            if (x < 0) { x = 0; }
            if (x > shaded[index].Width - 1) x = shaded[index].Width - 1;
            return shaded[index].GetPixel(x, y);
        }

        private void trackBar1_ValueChanged(object sender, EventArgs e)
        {
            gamma = trackBar1.Value / 10.0f;
            label1.Text = "Gamma: " + gamma.ToString("F2");
            saturation = trackBar2.Value / 10.0f;
            label2.Text = "saturation: " + saturation.ToString("F2");
            contrast = trackBar3.Value / 10.0f;
            label3.Text = "Contrast: " + contrast.ToString("F2");
            ratio = trackBar4.Value / 10.0f;
            label5.Text = "Blur/Sub Ratio: " + ratio.ToString("F2");
            currentChange++;
            genShade();

        }

        private Color getR(Color c)
        {
            return Color.FromArgb(c.R, 0, 0);
        }
        private Color getG(Color c)
        {
            return Color.FromArgb(0, c.G, 0);
        }
        private Color getB(Color c)
        {
            return Color.FromArgb(0, 0, c.B);
        }
        private Color getC(Color c)
        {
            return Color.FromArgb(0, c.G, c.B);
        }
        private Color getM(Color c)
        {
            return Color.FromArgb(c.R, 0, c.B);
        }
        private Color getY(Color c)
        {
            return Color.FromArgb(c.R, c.G, 0);
        }
        private Color wAvg(Color c1, Color c2, Color c3, Color c4, Color c5, float f1, float f2, float f3, float f4, float f5)
        {
            float sum = f1 + f2 + f3 + f4 + f5;

            // float sum = 1.0f;
            var nr = c1.R * f1 + c2.R * f2 + c3.R * f3 + c4.R * f4 + c5.R * f5;
            var ng = c1.G * f1 + c2.G * f2 + c3.G * f3 + c4.G * f4 + c5.G * f5;
            var nb = c1.B * f1 + c2.B * f2 + c3.B * f3 + c4.B * f4 + c5.B * f5;
            return Color.FromArgb((int)(nr / sum), (int)(ng / sum), (int)(nb / sum));
        }

        private Color wMax(Color c1, Color c2, Color c3, Color c4, Color c5, float f1, float f2, float f3, float f4, float f5)
        {
            float maxR = 0;
            float maxG = 0;
            float maxB = 0;   
            if (c1.R * f1 > maxR) maxR = c1.R * f1;
            if (c1.G * f1 > maxG) maxG = c1.G * f1;
            if (c1.B * f1 > maxB) maxB = c1.B * f1;
            if (c2.R * f2 > maxR) maxR = c2.R * f2;
            if (c2.G * f2 > maxG) maxG = c2.G * f2;
            if (c2.B * f2 > maxB) maxB = c2.B * f2;
            if (c3.R * f3 > maxR) maxR = c3.R * f3;
            if (c3.G * f3 > maxG) maxG = c3.G * f3;
            if (c3.B * f3 > maxB) maxB = c3.B * f3;
            if (c4.R * f4 > maxR) maxR = c4.R * f4;
            if (c4.G * f4 > maxG) maxG = c4.G * f4;
            if (c4.B * f4 > maxB) maxB = c4.B * f4;
            if (c5.R * f5 > maxR) maxR = c5.R * f5;
            if (c5.G * f5 > maxG) maxG = c5.G * f5;
            if (c5.B * f5 > maxB) maxB = c5.B * f5;
            return Color.FromArgb((int)maxR, (int)maxG, (int)maxB);
        }
        private int colorMax(Color c1)
        {
            return Math.Max(Math.Max(c1.R, c1.G), c1.B);
        }
        private Color toMax(Color c, int max)
        {
            var currentMax = colorMax(c);
            if (currentMax == 0) return c;
            var nR = c.R * max / currentMax;
            var nG = c.G * max / currentMax;
            var nB = c.B * max / currentMax;
            return Color.FromArgb(nR, nG, nB);  
        }
        private Color wAvg(Color c1, Color c2, Color c3, Color c4, float f1, float f2, float f3, float f4)
        {
            float sum = f1 + f2 + f3 + f4;
            // float sum = 1.0f;
            var nr = c1.R * f1 + c2.R * f2 + c3.R * f3 + c4.R * f4;
            var ng = c1.G * f1 + c2.G * f2 + c3.G * f3 + c4.G * f4;
            var nb = c1.B * f1 + c2.B * f2 + c3.B * f3 + c4.B * f4;
            return Color.FromArgb((int)(nr / sum), (int)(ng / sum), (int)(nb / sum));
        }
        private Color wAvg(Color c1, Color c2, Color c3, float f1, float f2, float f3)
        {
            float sum = f1 + f2 + f3;
           // float sum = 1.0f;
            var nr = c1.R * f1 + c2.R * f2 + c3.R * f3;
            var ng = c1.G * f1 + c2.G * f2 + c3.G * f3;
            var nb = c1.B * f1 + c2.B * f2 + c3.B * f3;
            return Color.FromArgb((int)(nr / sum), (int)(ng / sum), (int)(nb / sum));
        }
        private Color wAvg(Color c1, Color c2, float f1, float f2)
        {
            float sum = f1 + f2;
            // float sum = 1.0f;
            var nr = c1.R * f1 + c2.R * f2;
            var ng = c1.G * f1 + c2.G * f2;
            var nb = c1.B * f1 + c2.B * f2;
            return Color.FromArgb((int)(nr / sum), (int)(ng / sum), (int)(nb / sum));
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (currentShader == 6) 
                pictureBox1.Image = (pictureBox1.Image == shaded[4]) ? shaded[5] : shaded[4];
        }

        //private int GammaColor
    }


    class ColorF
    {
        public float R; 
        public float G;
        public float B;

        public ColorF(Color c)
        {
            R = c.R;
            G = c.G;
            B = c.B;
        }
        public ColorF(float r, float g, float b)
        {
            R = r;
            G = g;
            B = b;
        }
        public void gamma(float gamma)
        {
            R = (float)Math.Pow(R, 1.0 / gamma);
            G = (float)Math.Pow(G, 1.0 / gamma);
            B = (float)Math.Pow(B, 1.0 / gamma);
        }

        public void scale(float f)
        {
            R = R * f;
            G = G * f;
            B = B * f;
        }

        public void clamp()
        {
            if (R > 1.0f) R = 1.0f;
            if (G > 1.0f) G = 1.0f;
            if (B > 1.0f) B = 1.0f;

            if (R < 0.0f) R = 0.0f;
            if (G < 0.0f) G = 0.0f;
            if (B < 0.0f) B = 0.0f;
        }

        public void normalize()
        {
            float max = 0.0f;
            if (R > max) max = R;
            if (G > max) max = G;
            if (B > max) max = B;

            R = R / max;
            G = G / max;
            B = B / max;
        }

        public Color ToColor()
        {
            var r = Math.Max((int)R, 255);
            var g = Math.Max((int)G, 255);
            var b = Math.Max((int)B, 255);
            return Color.FromArgb(r, g, b);
        }
    }

}
