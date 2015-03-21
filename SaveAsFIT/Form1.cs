using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace SaveAsFITS
{
    public partial class Form1 : Form
    {
        private Bitmap sourceBitmap, grayScaleBitmap;
        private bool silentUpdate;

        public Form1()
        {
            InitializeComponent();
            grayScaleBitmap = new Bitmap(100,100);
            //TODO fill bitmap
            GrayAdjustBox.Image = grayScaleBitmap;
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
                silentUpdate = true;
                RedCheckBox.Checked = GreenCheckBox.Checked = BlueCheckBox.Checked = AlphaCheckBox.Checked = true;
                GrayScaleCheckBox.Checked = false;
                silentUpdate = false;
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
            var stack = (r + g + b)<<5;
            var stackbytes = BitConverter.GetBytes(stack);
            stack = BitConverter.ToInt16(new []{stackbytes[1],stackbytes[0]}, 0);

            return (short)(stack);
        }

        private void toolStripQuit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void toolStripGrayscale_CheckedChanged(object sender, EventArgs e)
        {
            if (!silentUpdate)
            {
                imageControl1.SourceAttributes.SetColorMatrix(new ColorMatrix(createColorMatrix()));
                imageControl1.Refresh();
            }
        }

        private float[][] createColorMatrix()
        {
            if (GrayScaleCheckBox.Checked)
            {
                var red = (RedCheckBox.Checked) ? 1.00f : 0.00f;
                var green = (GreenCheckBox.Checked) ? 1.00f : 0.00f;
                var blue = (BlueCheckBox.Checked) ? 1.00f : 0.00f;
                //var alpha = (AlphaCheckBox.Checked) ? 1.00f : 0.00f;
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
                var red = (RedCheckBox.Checked) ? 1.00f : 0.00f;
                var green = (GreenCheckBox.Checked) ? 1.00f : 0.00f;
                var blue = (BlueCheckBox.Checked) ? 1.00f : 0.00f;
                var alpha = (AlphaCheckBox.Checked) ? 1.00f : 0.00f;

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
