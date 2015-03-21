using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Globalization;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace SaveAsFITS
{
    public partial class Form1 : Form
    {
        private Bitmap sourceBitmap;

        public Form1()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (toolStripTextBox1.TextBox != null)
                toolStripTextBox1.TextBox.Text = (imageControl1.ZoomLevel*100).ToString("F0") + "%";
        }

        private void toolStripLoadImage_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                sourceBitmap = new Bitmap(openFileDialog1.FileName);
                imageControl1.SourceAttributes = new ImageAttributes(); 
                imageControl1.SourceImage = sourceBitmap;
            }
        }

        private void toolStripSaveAsFITS_Click(object sender, EventArgs e)
        {
            if ((saveFileDialog1.ShowDialog() == DialogResult.OK) & (sourceBitmap != null))
            {
                var headerStrings = FITSMaker.CreateFITSHeader(true, 16, sourceBitmap.Width, sourceBitmap.Height, 32768, "Created With SaveAsFITS");

                //init new file
                var fileStream = File.Create(saveFileDialog1.FileName);
                var writer = new BinaryWriter(fileStream);

                //write header
                for (var i = 0; i < 36; i++)
                {
                    writer.Write(Encoding.ASCII.GetBytes(headerStrings[i]));
                }

                //write data
                var depth = Image.GetPixelFormatSize(sourceBitmap.PixelFormat);
                var pixelSize = depth / 8;
                var pixData = sourceBitmap.LockBits(new Rectangle(0, 0, sourceBitmap.Width, sourceBitmap.Height),
                    ImageLockMode.ReadOnly,
                    sourceBitmap.PixelFormat);
                var pixelBufferSize = sourceBitmap.Height * pixData.Stride;
                var PixelSource = new byte[pixelBufferSize];

                Marshal.Copy(pixData.Scan0, PixelSource, 0, pixelBufferSize);
                sourceBitmap.UnlockBits(pixData);

                for (var i = sourceBitmap.Height - 1; i >= 0; i--)
                {
                    for (var j = 0; j < sourceBitmap.Width; j++)
                    {
                        var index = (i * pixData.Stride) + (j * pixelSize);

                        writer.Write(stackPixels(PixelSource[index], PixelSource[index + 1], PixelSource[index + 2]));
                    }
                }

                fileStream.Flush();
                fileStream.Dispose();
            } 
        }

        private static short stackPixels(byte r, byte g, byte b)
        {
            int stack = (r*256) + (g*256) + (b*256);
            return (short)(stack/3);
        }

        private void toolStripQuit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void toolStripGrayscale_CheckedChanged(object sender, EventArgs e)
        {
            imageControl1.SourceAttributes.SetColorMatrix(new ColorMatrix(createColorMatrix()));
            imageControl1.Refresh();
        }

        private float[][] createColorMatrix()
        {
            if (toolStripGrayscale.Checked)
            {
                var red = (toolStripRed.Checked) ? 1.00f : 0.00f;
                var green = (toolStripGreen.Checked) ? 1.00f : 0.00f;
                var blue = (toolStripBlue.Checked) ? 1.00f : 0.00f;
                //var alpha = (toolStripAlpha.Checked) ? 1.00f : 0.00f;
                var stack = red + green + blue;
                red /= stack;
                green /= stack;
                blue /= stack;
                //alpha /= stack;
                return new[]
                {
                    new[] {red  , red  , red  , 0.00f, 0.00f},
                    new[] {green, green, green, 0.00f, 0.00f},
                    new[] {blue , blue , blue , 0.00f, 0.00f},
                    new[] {0.00f, 0.00f, 0.00f, 1.00f, 0.00f},
                    new[] {0.00f, 0.00f, 0.00f, 0.00f, 1.00f}
                };
            }
            else
            {
                var red = (toolStripRed.Checked) ? 1.00f : 0.00f;
                var green = (toolStripGreen.Checked) ? 1.00f : 0.00f;
                var blue = (toolStripBlue.Checked) ? 1.00f : 0.00f;
                var alpha = (toolStripAlpha.Checked) ? 1.00f : 0.00f;

                return new[]
                {
                    new[] {red  , 0.00f, 0.00f, 0.00f, 0.00f},
                    new[] {0.00f, green, 0.00f, 0.00f, 0.00f},
                    new[] {0.00f, 0.00f, blue , 0.00f, 0.00f},
                    new[] {0.00f, 0.00f, 0.00f, alpha, 0.00f},
                    new[] {0.00f, 0.00f, 0.00f, 0.00f, 1.00f}
                };
            }

        }
    }
}
