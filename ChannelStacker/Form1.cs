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

namespace ChannelStacker
{
    public partial class Form1 : Form
    {
        private int _width, _height, _pixelBufferSize;
        private PixelFormat _pixelFormat;
        private List<PixelFormat> supportedFormats; 

        private double[] _redSource, _greenSource, _blueSource;

        public Form1()
        {
            InitializeComponent();
            supportedFormats = new List<PixelFormat>
            {
                PixelFormat.Format24bppRgb,
                PixelFormat.Format32bppRgb,
                PixelFormat.Format32bppPArgb,
                PixelFormat.Format16bppGrayScale,
                PixelFormat.Format48bppRgb,
                PixelFormat.Format64bppPArgb,
                PixelFormat.Format32bppArgb,
                PixelFormat.Format64bppArgb,
            };
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                var data = new Bitmap(openFileDialog1.FileName);
                _redSource = ImageToData(data);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                var data = new Bitmap(openFileDialog1.FileName);
                _greenSource = ImageToData(data);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                var data = new Bitmap(openFileDialog1.FileName);
                _blueSource = ImageToData(data);
            }
        }

        public Image DataToImage(byte[] Data, int Width, int Height, PixelFormat Format)
        {
            var BytesPerPixel = Image.GetPixelFormatSize(Format) / 8;
            if (Data.Length == (Width * Height * BytesPerPixel))
            {
                var bmpData = new Bitmap(Width, Height);
                var pixdata = bmpData.LockBits(new Rectangle(0, 0, Width, Height), ImageLockMode.WriteOnly, Format);
                Marshal.Copy(Data, 0, pixdata.Scan0, Width * Height * BytesPerPixel);
                bmpData.UnlockBits(pixdata);
                return bmpData;
            }
            else return null;
        }

        public double[] ImageToData(Bitmap data)
        {
            if (supportedFormats.Any(f => f == data.PixelFormat))
            {
                _width = data.Width;
                _height = data.Height;
                _pixelFormat = data.PixelFormat;

                var depth = Image.GetPixelFormatSize(data.PixelFormat);
                var pixelSize = depth / 8;
                var bytesPerChannel = ((depth > 32) | (depth == 16)) ? 2 : 1;

                _pixelBufferSize = _width*_height*pixelSize;

                var pixelBuffer = new double[_width * _height];

                if (bytesPerChannel == 1)
                {
                    var pixelSource = new byte[_pixelBufferSize];
                    var pixData = data.LockBits(new Rectangle(0, 0, _width, _height), ImageLockMode.ReadOnly, _pixelFormat);
                    Marshal.Copy(pixData.Scan0, pixelSource, 0, _pixelBufferSize);
                    data.UnlockBits(pixData);

                    for (int i = 0; i < _pixelBufferSize; i += pixelSize) pixelBuffer[i / pixelSize] = pixelSource[i];
                }
                else if (bytesPerChannel == 2)
                {
                    _pixelBufferSize /= 2;
                    pixelSize /= 2;
                    var pixelSourceShort = new short[_pixelBufferSize];
                    var pixData = data.LockBits(new Rectangle(0, 0, _width, _height), ImageLockMode.ReadOnly, _pixelFormat);
                    Marshal.Copy(pixData.Scan0, pixelSourceShort, 0, _pixelBufferSize);
                    data.UnlockBits(pixData);

                    var pixelSource = new UInt16[_pixelBufferSize];
                    for (int i = 0; i < _pixelBufferSize; i++)
                    {
                        pixelSource[i] = (UInt16)pixelSourceShort[i];
                    }
                    UInt16 _max = 0;
                    UInt16 _min = 0;
                    for (int i = 0; i < (_width*_height) - 1; i ++)
                    {
                        pixelBuffer[i] = pixelSource[i*pixelSize];
                        if (pixelSource[i * pixelSize] > _max) _max = pixelSource[i * pixelSize];
                        if (pixelSource[i * pixelSize] < _min) _min = pixelSource[i * pixelSize];
                    }
                    button1.Text = _max.ToString("F4");
                    button2.Text = _min.ToString("F4");
                } 
                return pixelBuffer;
            } else {
                MessageBox.Show(@"Unsupported Format", @"Error loading image", MessageBoxButtons.OK);
                return null;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            var bmpData = new byte[_width*_height*3];
            for (int i = 0; i < _width; i++)
            {
                for (int j = 0; j < _height; j++)
                {
                    var offset = ((j*_width) + i)*3;
                    bmpData[offset] = (byte)(_blueSource[offset / 3] / 256d);
                    bmpData[offset + 1] = (byte)(_greenSource[offset / 3] / 256d);
                    bmpData[offset + 2] = (byte)(_redSource[offset / 3] / 256d);
                }
            }
            pictureBox1.Image = DataToImage(bmpData, _width, _height, PixelFormat.Format24bppRgb);
        }
    }
}
