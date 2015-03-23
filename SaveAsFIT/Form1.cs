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
        private Bitmap sourceBitmap;
        private bool silentUpdate, pickingColor;

        private float redGrayFactor = 0.2126f;
        private float greenGrayFactor = 0.7151f;
        private float blueGrayFactor = 0.0723f;

        public Form1()
        {
            InitializeComponent();
            var grayScaleBitmap = new Bitmap(100, 87);
            for (int y = 0; y < 87; y++)
            {
                for (int x = 0; x < 100; x++)
                {
                    //red origin = 50, 0
                    //green origin = 0, 87
                    //blue origin = 100, 87
                    var redFactor = 255-Math.Min(GetDistance(x, y, 50, 0) * 2.55f, 255);
                    var greenFactor =  255-Math.Min(GetDistance(x, y, 0, 87) * 2.55f, 255);
                    var blueFactor = 255-Math.Min(GetDistance(x, y, 100, 87) * 2.55f, 255);
                    if ((((87-y) * 50) < ((100-x)*87))&(((87-y) * 50) < (x*87))) grayScaleBitmap.SetPixel(x, y, Color.FromArgb((int)redFactor, (int)greenFactor, (int)blueFactor));
                }
            }
            GrayAdjustBox.Image = grayScaleBitmap;
        }

        private static float GetDistance(int x, int y, int originX, int originY)
        {
            var dx = originX - x;
            var dy = originY - y;

            return (float)Math.Sqrt((dx*dx) + (dy*dy));
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
                var red = (RedCheckBox.Checked) ? redGrayFactor : 0.00f;
                var green = (GreenCheckBox.Checked) ? greenGrayFactor : 0.00f;
                var blue = (BlueCheckBox.Checked) ? blueGrayFactor : 0.00f;
                //var alpha = (AlphaCheckBox.Checked) ? 1.00f : 0.00f;
                var stack = red + green + blue;
                red /= stack;
                green /= stack;
                blue /= stack;

                label1.Text = "R:" + red.ToString("F4");
                label2.Text = "G:" + green.ToString("F4");
                label3.Text = "B:" + blue.ToString("F4");
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

        private void LuminanceButton_Click(object sender, EventArgs e)
        {
            /*
            .2126 R
            .7151 G
            .0723 B
            */
            redGrayFactor = 0.2126f;
            greenGrayFactor = 0.7151f;
            blueGrayFactor = 0.0723f;
            GrayScaleCheckBox.Checked = true;
            imageControl1.SourceAttributes.SetColorMatrix(new ColorMatrix(createColorMatrix()));
            imageControl1.Refresh();
        }

        private void AverageButton_Click(object sender, EventArgs e)
        {
             /*
             .3333 R
             .3334 G
             .3333 B             
             */
            redGrayFactor = 0.3333f;
            greenGrayFactor = 0.3334f;
            blueGrayFactor = 0.3333f;
            GrayScaleCheckBox.Checked = true;
            imageControl1.SourceAttributes.SetColorMatrix(new ColorMatrix(createColorMatrix()));
            imageControl1.Refresh();
        }

        private void GrayAdjustBox_MouseDown(object sender, MouseEventArgs e)
        {
            pickingColor = true;
        }

        private void GrayAdjustBox_MouseUp(object sender, MouseEventArgs e)
        {
            pickingColor = false;
        }

        private void GrayAdjustBox_MouseMove(object sender, MouseEventArgs e)
        {
            if (pickingColor)
            {
                var redFactor = 1.0f - Math.Min(GetDistance(e.X, e.Y, 50, 0) / 100.0f, 1.0f);
                var greenFactor = 1.0f - Math.Min(GetDistance(e.X, e.Y, 0, 87) / 100.0f, 1.0f);
                var blueFactor = 1.0f - Math.Min(GetDistance(e.X, e.Y, 100, 87) / 100.0f, 1.0f);
                if ((((87 - e.Y)*50) < ((100 - e.X)*87)) & (((87 - e.Y)*50) < (e.X*87)))
                {
                    redGrayFactor = redFactor;
                    greenGrayFactor = greenFactor;
                    blueGrayFactor = blueFactor;
                    imageControl1.SourceAttributes.SetColorMatrix(new ColorMatrix(createColorMatrix()));
                    imageControl1.Refresh();
                }
            }
        }
    }
}
