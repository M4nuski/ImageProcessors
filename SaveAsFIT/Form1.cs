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

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                sourceBitmap = new Bitmap(openFileDialog1.FileName);
                imageControl1.SourceImage = sourceBitmap;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (toolStripTextBox1.TextBox != null)
                toolStripTextBox1.TextBox.Text = (imageControl1.ZoomLevel*100).ToString("F0") + "%";
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
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
                var pixelBufferSize = sourceBitmap.Width * sourceBitmap.Height * pixelSize;
                var PixelSource = new byte[pixelBufferSize];
                var pixData = sourceBitmap.LockBits(new Rectangle(0, 0, sourceBitmap.Width, sourceBitmap.Height), 
                    ImageLockMode.ReadOnly,
                    sourceBitmap.PixelFormat);
                Marshal.Copy(pixData.Scan0, PixelSource, 0, pixelBufferSize);
                sourceBitmap.UnlockBits(pixData);

                for (var i = sourceBitmap.Height-1; i >= 0; i--)
                {
                    for (var j = 0; j < sourceBitmap.Width; j++)
                    {
                        var index = ((i * sourceBitmap.Width) + j) * pixelSize;

                        writer.Write(stackPixels(PixelSource[index], PixelSource[index + 1], PixelSource[index + 2]));
                     //   writer.Write(PixelSource[index]);
                    }
                }

                fileStream.Flush();
                fileStream.Dispose();
            } 
        }

        private static short stackPixels(byte r, byte g, byte b)
        {
            //return (short) ((128*r)-32768);
               return (short)(g * 256);
        }
    }
}
