using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Globalization;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace SaveAsFIT
{
    public partial class Form1 : Form
    {
        private string[] headerStrings;
        private Bitmap sourceBitmap;

        private const string FITS_Header_Simple = "SIMPLE  = ";//                   T / file conforms to FITS standard
        private const string FITS_Header_BitPix = "BITPIX  = ";//                  16 / number of bits per data pixel
        private const string FITS_Header_NAxis  = "NAXIS   = ";//                   2 / number of data axes
        private const string FITS_Header_NAxis1 = "NAXIS1  = ";//                 440 / length of data axis 1
        private const string FITS_Header_NAxis2 = "NAXIS2  = ";//                 300 / length of data axis 2
        private const string FITS_Header_BZero  = "BZERO   = ";//               32768 /
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
                headerStrings = new string[32];

                headerStrings[0] = createHeaderString(FITS_Header_Simple, true, "file conforms to FITS standard");
                headerStrings[1] = createHeaderString(FITS_Header_BitPix, 16, "16 bits per pixels");
                headerStrings[2] = createHeaderString(FITS_Header_NAxis, 2, "2D image");
                headerStrings[3] = createHeaderString(FITS_Header_NAxis1, sourceBitmap.Width, "image width");
                headerStrings[4] = createHeaderString(FITS_Header_NAxis2, sourceBitmap.Height, "image height");
                headerStrings[5] = createHeaderString(FITS_Header_BZero, 32768, "0 offset for unsigned");

                for (var i = 6; i < 32; i++)
                {
                    headerStrings[i] = string.Empty;
                }

                //init new file
                var fileStream = File.Create(saveFileDialog1.FileName);
                var writer = new BinaryWriter(fileStream);

                //write header
                for (var i = 0; i < 32; i++)
                {
                    writer.Write(Encoding.ASCII.GetBytes(headerStrings[i]));
                }

                //write data
                var depth = Image.GetPixelFormatSize(sourceBitmap.PixelFormat);
                var pixelSize = (depth > 16) ? (depth / 8) : 2;
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

        private static string createHeaderString(string varName, int val, string comment)
        {
            var sb = new StringBuilder(varName);
            sb.Append(val.ToString(CultureInfo.InvariantCulture).PadLeft(20));
            sb.Append(" / ");
            sb.Append(comment);

            return sb.ToString().PadRight(80);
        }

        private static string createHeaderString(string varName, bool val, string comment)
        {
            var vb = (val) ? "T" : "F";
            var sb = new StringBuilder(varName);
            sb.Append(vb.PadLeft(20));
            sb.Append(" / ");
            sb.Append(comment);

            return sb.ToString().PadRight(80);
        }

        private static short stackPixels(byte r, byte g, byte b)
        {
            //return (short) ((128*r)-32768);
               return (short)(g * 256);
        }
    }
}
