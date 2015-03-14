using System;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        public double[,,] SmoothBuffer, Buffer;
        public byte[] PixelSource, PixelOutput;
        private PixelFormat _pixelFormat;
        private int _width, _height, _pixelSize, _pixelBufferSize;
        public double MaxStack;
        public double[] Distances;
        public bool SmoothFactorChanged;
        public double Gamma;

      //  public int ThreadProgress;

        private delegate void DelegateUpdateProgressBar(int iValue);
        private readonly DelegateUpdateProgressBar _updateProgressBar;
        
        public Form1()
        {
            InitializeComponent();
            _updateProgressBar = UpdateProgressBar;
        }

        private void UpdateProgressBar(int iValue)
        {
            progressBar1.Value = iValue;
            progressBar1.Update();
        }

        public static T Clamp<T>(T val, T min, T max) where T : IComparable<T>
        {
            return (val.CompareTo(min) < 0) ? min : (val.CompareTo(max) > 0) ? max : val;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            button1.Enabled = false;
            var sw = new Stopwatch();
            sw.Start();

            double x;
            int i;
            int j;
            int k;
            int offset;

            if (SmoothFactorChanged) SmoothPixels(trackBar1.Value);

            //sharpen
            var sharpenFactor = trackBar2.Value / 5.0000d;

            for (k = 0; k < _pixelSize; k++)
            {
                for (i = 0; i < _width - 1; i++)
                {
                    for (j = 0; j < _height - 1; j++)
                    {
                        offset = (_pixelSize * (i + (j * _width))) + k;

                        //Delta
                        x = PixelSource[offset] - SmoothBuffer[i, j, k];
                        //Gamma
                      //  x += Math.Pow(x / 255.0d, Gamma)*255.0d;
                        //Sharpen
                        Buffer[i, j, k] = PixelSource[offset] + (x * sharpenFactor);
                        //Clamp
                        if (Buffer[i, j, k] > 255) Buffer[i, j, k] = 255;
                        if (Buffer[i, j, k] < 0) Buffer[i, j, k] = 0;
                    }
                }
            }



            //display
            PixelOutput = new byte[_pixelBufferSize];

            for (k = 0; k < _pixelSize; k++)
            {
                for (i = 0; i < _width - 1; i++)
                {
                    for (j = 0; j < _height - 1; j++)
                    {
                        PixelOutput[(_pixelSize * (i + (j * _width))) + k] = (byte)(255.0d * Math.Pow(Buffer[i, j, k] / 255.0d, Gamma)); 
                    }
                }
            }

            var bmp = new Bitmap(_width, _height, _pixelFormat);

            var pixdata = bmp.LockBits(new Rectangle(0, 0, _width, _height), ImageLockMode.WriteOnly, _pixelFormat);
            Marshal.Copy(PixelOutput,0, pixdata.Scan0, _pixelBufferSize);
            bmp.UnlockBits(pixdata);
    
            pictureBox2.Image = bmp;
            
            sw.Stop();
            button1.Text = @"Process " + sw.ElapsedMilliseconds;
            button1.Enabled = true;
        }
        
        private void SmoothPixels(int smoothRange)
        {
            int x;
            int k;
            int l;

            Distances = new double[2*smoothRange + 1];
            double d; //hahaha
            MaxStack = 0;
            double maxSingle = 0;

            /*
             * 0 Square Full
             * 1 Square Linear
             * 2 Square Cross
             * 2 Round Full
             * 3 Round Linear
             * 4 Round Spherical

            0 Rational .5
            1 Gaussian .2
            2 Spherical
            3 Linear
            4 Flat
             */

            if (comboBox1.SelectedIndex == 4) // Flat
            {
                for (k = -smoothRange; k < smoothRange + 1; k++)
                {
                        d = 1.0d;
                        Distances[k + smoothRange] = d;
                        MaxStack += d;
                } 
                        maxSingle = 1.0d;
            }

            if (comboBox1.SelectedIndex == 3) // Linear
            {
                    for (k = -smoothRange; k < smoothRange + 1; k++)
                    {
                        d = smoothRange - Math.Abs(k);
                            Distances[k + smoothRange] = d;
                            MaxStack += d;
                        }
                    maxSingle = smoothRange;
            }

            if (comboBox1.SelectedIndex == 2) // Spherical
            {
                for (k = -smoothRange; k < smoothRange + 1; k++)
                {
                //    d = Clamp(1.0000d - (Math.Abs(k)/(double)smoothRange), 0.0000d, 1.0000d);
                //        d = 1.0000d - Math.Cos(d * Math.PI);
                    d = Math.Sqrt((smoothRange*smoothRange)-(k*k));
                        Distances[k + smoothRange] = d;
                        MaxStack += d;
                        if (d > maxSingle) maxSingle = d;
                    }
             
            }

            if (comboBox1.SelectedIndex == 1) // Gaussian
            {
                for (k = -smoothRange; k < smoothRange + 1; k++)
                {
                    d = k / (double)smoothRange;
                    d = Math.Exp(-(d * d) / 0.2d);
                    Distances[k + smoothRange] = d;
                    MaxStack += d;
                    if (d > maxSingle) maxSingle = d;
                }
            }

            if (comboBox1.SelectedIndex == 0) // Rational
            {
                for (k = -smoothRange; k < smoothRange + 1; k++)
                {
                    d = Math.Abs(k/(double)smoothRange);
                    d = (k == 0) ? (smoothRange*2d) : (1.0d / (d * 0.7d));
                    Distances[k + smoothRange] = d;
                    MaxStack += d;
                    if (d > maxSingle) maxSingle = d;
                }
            }


            var bmp = new Bitmap(2 * smoothRange + 1, 2 * smoothRange + 1);
            
            for (k = -smoothRange; k < smoothRange + 1; k++)
            {
                for (l = -smoothRange; l < smoothRange + 1; l++)
                {
                    d = (Distances[k + smoothRange] / maxSingle) + (Distances[l + smoothRange] / maxSingle);
                    x = (int)(255.0 * d / 2.0d);
                    x = (x < 0) ? 0: (x > 255) ? 255 : x;
                    bmp.SetPixel(k + smoothRange, l + smoothRange, Color.FromArgb(x, Color.White));
                }
            }

            for (k = -smoothRange; k < smoothRange +1; k++)
            {
                bmp.SetPixel(k + smoothRange, (2*smoothRange) - 2*(int)(smoothRange*(Distances[k + smoothRange] / maxSingle)), Color.Red);
            }

            pictureBox3.Image = bmp;
            pictureBox3.Update();


            // Normalize;
            for (k = -smoothRange; k < smoothRange + 1; k++)
            {
                Distances[k + smoothRange] /= (MaxStack*2.0d);
            }
            progressBar1.Value = 0;
            progressBar1.Maximum = _width;
            progressBar1.Update();

            //Smooth
           // Parallel.For(0, _pixelSize, i => SmoothChannel(i, smoothRange));
            Parallel.For(0, _pixelSize, i => SmoothChannelHV(i, smoothRange));

            SmoothFactorChanged = false;
        }

        private void SmoothChannel(int channel, int smoothRange)
        {
            int x;
            int y;
            int computedX;
            int computedY;
            int smoothingX;
            int smoothingY;
            int offset;

            for (x = 0; x < _width - 1; x++)
            {
                if (channel == 0) BeginInvoke(_updateProgressBar, new object[] { x });

                for (y = 0; y < _height - 1; y++)
                {
                    SmoothBuffer[x, y, channel] = 0;
                    for (smoothingX = -smoothRange; smoothingX < smoothRange + 1; smoothingX++)
                    {
                        for (smoothingY = -smoothRange; smoothingY < smoothRange + 1; smoothingY++)
                        {
                            //clamp
                            computedX = x + smoothingX;
                            if (computedX < 0) computedX = 0;
                            if (computedX > _width - 1) computedX = _width - 1;
                            computedY = y + smoothingY;
                            if (computedY < 0) computedY = 0;
                            if (computedY > _height - 1) computedY = _height - 1;

                            //stack
                            offset = (_pixelSize * (computedX + (computedY * _width))) + channel;
                            SmoothBuffer[x, y, channel] += (PixelSource[offset] * Distances[smoothingY + smoothRange]);
                        }
                    }
                    SmoothBuffer[x, y, channel] /= MaxStack;
                }
            }  
        }

        private void SmoothChannelHV(int channel, int smoothRange)
        {
            int x;
            int y;
            int computedX;
            int computedY;
            int smoothingX;
            int smoothingY;
            int offset;






            for (x = 0; x < _width - 1; x++)
            {
                for (y = 0; y < _height - 1; y++)
                {
                    SmoothBuffer[x, y, channel] = 0;
                   // for (smoothingX = -smoothRange; smoothingX < smoothRange + 1; smoothingX++)
                   // {
                        for (smoothingY = -smoothRange; smoothingY < smoothRange + 1; smoothingY++)
                        {
                            //clamp
                          //  computedX = x + smoothingX;
                          //  if (computedX < 0) computedX = 0;
                          //  if (computedX > _width - 1) computedX = _width - 1;
                            computedY = y + smoothingY;
                            if (computedY < 0) computedY = 0;
                            if (computedY > _height - 1) computedY = _height - 1;

                            //stack
                            offset = (_pixelSize * (x + (computedY * _width))) + channel;
                            SmoothBuffer[x, y, channel] += (PixelSource[offset] * Distances[smoothingY + smoothRange]);
                        }
                   // }
              //      SmoothBuffer[x, y, channel] /= MaxStack;
                }
            }

            for (x = 0; x < _width - 1; x++)
            {
                for (y = 0; y < _height - 1; y++)
                {
                 //   SmoothBuffer[x, y, channel] = 0;
                     for (smoothingX = -smoothRange; smoothingX < smoothRange + 1; smoothingX++)
                     {
                 //   for (smoothingY = -smoothRange; smoothingY < smoothRange + 1; smoothingY++)
                 //   {
                        //clamp
                          computedX = x + smoothingX;
                          if (computedX < 0) computedX = 0;
                          if (computedX > _width - 1) computedX = _width - 1;
                        //computedY = y + smoothingY;
                        //if (computedY < 0) computedY = 0;
                        //if (computedY > _height - 1) computedY = _height - 1;

                        //stack
                          offset = (_pixelSize * (computedX + (y * _width))) + channel;
                        SmoothBuffer[x, y, channel] += (PixelSource[offset] * Distances[smoothingX + smoothRange]);
                    }
                    // }
                //    SmoothBuffer[x, y, channel] /= MaxStack;
                }
            }
            /*
           double mshv = 0;
                for (smoothingY = -smoothRange; smoothingY < smoothRange + 1; smoothingY++)
                {
                    mshv += Distances[smoothingY + smoothRange];
                }
                for (smoothingY = -smoothRange; smoothingY < smoothRange + 1; smoothingY++)
                {
                    mshv += Distances[smoothingY + smoothRange];
                }


            for (x = 0; x < _width; x++)
            {
                for (y = 0; y < _height; y++)
                {
                    SmoothBuffer[x, y, channel] /= mshv; 
                }
            }*/



        }


        static private float[] SmoothChannel2(float[] Source, float[,] distances, int smoothRange, float maxstack, int width, int height)
        {
            int x;
            int y;
            int computedX;
            int computedY;
            int smoothingX;
            int smoothingY;

            int SrcOffset;
            int DstOffset;
            float[] output = new float[width * height];

            for (x = 0; x < width - 1; x++)
            {
                for (y = 0; y < height - 1; y++)
                {
                    DstOffset = (y*width) + height;
                    output[DstOffset] = 0;
                    for (smoothingX = -smoothRange; smoothingX < smoothRange + 1; smoothingX++)
                    {
                        for (smoothingY = -smoothRange; smoothingY < smoothRange + 1; smoothingY++)
                        {
                            //clamp
                            computedX = x + smoothingX;
                            if (computedX < 0) computedX = 0;
                            if (computedX > width - 1) computedX = width - 1;
                            computedY = y + smoothingY;
                            if (computedY < 0) computedY = 0;
                            if (computedY > height - 1) computedY = height - 1;

                            //stack
                            SrcOffset = computedX + (computedY * width);
                            output[DstOffset] += (Source[SrcOffset] * distances[smoothingX + smoothRange, smoothingY + smoothRange]);
                        }
                    }
                    output[DstOffset] /= maxstack;
                }
            }
            return output;
        }
        
//var data = MemoryMappedFile.CreateNew("big data", 12000L * 55000L);
//var view = data.CreateViewAccessor();
//var rnd = new Random();
//for (var i = 0L; i < 12000L; ++i)
//{
//for (var j = 0L; j < 55000L; ++j)
//{
//var input = rnd.NextDouble();
//view.Write<double>(i * 55000L + j, ref input);
//}
//}

        private void button2_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.Image = Image.FromFile(openFileDialog1.FileName);
                pictureBox2.Image = pictureBox1.Image;//Preview
                //TODO implement direct loading of 48bpp data
                var data = new Bitmap(pictureBox1.Image);

                var depth = Image.GetPixelFormatSize(data.PixelFormat);

                if ((depth != 24) & (depth != 32))
                {
                    MessageBox.Show(@"Only Support 24bpp and 32bpp", @"Error loading image", MessageBoxButtons.OK);
                }
                else
                {
                    _width = data.Width;
                    _height = data.Height;

                    _pixelFormat = data.PixelFormat;

                    _pixelSize = depth/8;
                    _pixelBufferSize = _width * _height * _pixelSize;

                    PixelSource = new byte[_pixelBufferSize];
                    Buffer = new double[_width,_height,_pixelSize];
                    SmoothBuffer = new double[_width, _height, _pixelSize];

                    var pixData = data.LockBits(new Rectangle(0, 0, _width, _height), ImageLockMode.ReadOnly,
                        _pixelFormat);
                    Marshal.Copy(pixData.Scan0, PixelSource, 0, _pixelBufferSize);
                    data.UnlockBits(pixData);

                    SmoothFactorChanged = true;
                }
            }

        }

        private void trackBar1_Scroll_1(object sender, EventArgs e)
        {
            SmoothFactorChanged = true;
        }

        private void trackBar2_Scroll(object sender, EventArgs e)
        {
            button1_Click(sender, e);
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            SmoothPixels(trackBar1.Value);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Gamma = 1.0d;
         //   trackBar3_Scroll(sender,e);
            comboBox1.SelectedIndex = 1;
            SmoothFactorChanged = true;
        }

        private void trackBar3_Scroll(object sender, EventArgs e)
        {
            var bmp = new Bitmap(64, 64);

            var tb3V = trackBar3.Value;

            Gamma = 1.0d + ((tb3V < 0) ? tb3V/ 35.0d : (tb3V > 0) ? tb3V/10.0d : 0.0d);

            for (int i = 0; i < 64; i++)
            {
                var g = 63 * Math.Pow(i/63.0d, Gamma);
                g = Clamp(g, 0, 63);
                bmp.SetPixel(i,63-(int)g,Color.White);
            }
            pictureBox4.Image = bmp;
            button1_Click(sender,e);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            int k;
            int i;
            int j;



            PixelOutput = new byte[_pixelBufferSize];

            for (k = 0; k < _pixelSize; k++)
            {
                for (i = 1; i < _width - 2; i++)
                {
                    for (j = 1; j < _height - 2; j++)
                    {
                        SmoothBuffer[i, j, k] = Buffer[i, j-1, k];
                        SmoothBuffer[i, j, k] += Buffer[i, j, k];
                        SmoothBuffer[i, j, k] += Buffer[i, j+1, k];

                        SmoothBuffer[i, j, k] += Buffer[i-1, j-1, k];
                        SmoothBuffer[i, j, k] += Buffer[i-1, j, k];
                        SmoothBuffer[i, j, k] += Buffer[i-1, j+1, k];

                        SmoothBuffer[i, j, k] += Buffer[i+1, j-1, k];
                        SmoothBuffer[i, j, k] += Buffer[i+1, j, k];
                        SmoothBuffer[i, j, k] += Buffer[i+1, j+1, k];

                        PixelOutput[(_pixelSize*(i + (j*_width))) + k] = (byte) (SmoothBuffer[i, j, k]/9.0f);
                    }
                }
            }

            var bmp = new Bitmap(_width, _height, _pixelFormat);

            var pixdata = bmp.LockBits(new Rectangle(0, 0, _width, _height), ImageLockMode.WriteOnly, _pixelFormat);
            Marshal.Copy(PixelOutput, 0, pixdata.Scan0, _pixelBufferSize);
            bmp.UnlockBits(pixdata);

            pictureBox2.Image = bmp;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                var bmp = new Bitmap(_width, _height, _pixelFormat);

                var pixdata = bmp.LockBits(new Rectangle(0, 0, _width, _height), ImageLockMode.WriteOnly, _pixelFormat);
                Marshal.Copy(PixelOutput, 0, pixdata.Scan0, _pixelBufferSize);
                bmp.UnlockBits(pixdata);
                bmp.Save(saveFileDialog1.FileName, ImageFormat.Tiff);
            }
        }
    }
}
