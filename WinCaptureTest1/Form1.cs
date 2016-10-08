using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace WinCaptureTest1
{
    public partial class Form1 : Form
    {
        private Bitmap _lastBitmap;
        private Bitmap bmp;
        //private Bitmap deltaBitmap;

        private const int targetSize = 25;
        private const int maxScore = targetSize * targetSize * 255 * 3;
        private int[,] Scores;


        public Form1()
        {
            InitializeComponent();
        }

        [DllImport("user32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool PrintWindow(IntPtr hwnd, IntPtr hDC, uint nFlags);

        [DllImport("user32.dll")]
        private static extern bool GetWindowRect(IntPtr hWnd, out RECT rect);
        [StructLayout(LayoutKind.Sequential)]
        public struct RECT
        {
            public int Left;        // x position of upper-left corner
            public int Top;         // y position of upper-left corner
            public int Right;       // x position of lower-right corner
            public int Bottom;      // y position of lower-right corner
        }
        [DllImport("user32.dll", EntryPoint = "FindWindow", SetLastError = true)]
        static extern IntPtr FindWindowByCaption(IntPtr ZeroOnly, string lpWindowName);


        private void button1_Click(object sender, EventArgs e)
        {
            if (bmp != null) _lastBitmap = (Bitmap)bmp.Clone();

            var pt = FindWindowByCaption(IntPtr.Zero, "WinCaptureTest 2");
            if (pt != IntPtr.Zero)
            {
                textBox1.Text = pt.ToString();

                RECT si;
                GetWindowRect(pt, out si);
                bmp = new Bitmap(si.Right - si.Left, si.Bottom - si.Top, PixelFormat.Format32bppArgb);
                var grap = Graphics.FromImage(bmp);
                PrintWindow(pt, grap.GetHdc(), 0);
                if (_lastBitmap == null) _lastBitmap = new Bitmap(bmp.Width, bmp.Height, PixelFormat.Format32bppArgb);
                grap.ReleaseHdc();
                grap.Dispose();

                var newData = GetPixels(bmp);
                // var oldData = GetPixels(_lastBitmap);

                //   var deltas = diff(newData, oldData, bmp.Width, bmp.Height);

                // deltaBitmap = GetBitmap(deltas, bmp.Width, bmp.Height);

                Scores = GetScores(newData, bmp.Width, bmp.Height, targetSize, Color.Black);

                panel1.Refresh();
            }
        }



        private byte[] GetPixels(Bitmap fromBitmap)
        {
            var pf = Image.GetPixelFormatSize(fromBitmap.PixelFormat);
            if (pf == 32)
            {
                var pdata = fromBitmap.LockBits(new Rectangle(0, 0, fromBitmap.Width, fromBitmap.Height), ImageLockMode.ReadOnly,
                    fromBitmap.PixelFormat);
                var outData = new byte[fromBitmap.Width * fromBitmap.Height * 4];
                Marshal.Copy(pdata.Scan0, outData, 0, outData.Length);
                fromBitmap.UnlockBits(pdata);
                return outData;
            }
            return null;
        }

        private Bitmap GetBitmap(byte[] data, int width, int height)
        {
            var result = new Bitmap(width, height, PixelFormat.Format32bppArgb);

            if (data.Length == (4 * width * height))
            {
                var pdata = result.LockBits(new Rectangle(0, 0, width, height), ImageLockMode.WriteOnly, PixelFormat.Format32bppArgb);
                Marshal.Copy(data, 0, pdata.Scan0, data.Length);

                result.UnlockBits(pdata);
            }
            return result;
        }

        private static int[,] GetScores(byte[] bmpData, int width, int height, int squareSize, Color targetColor)
        {
            var nX = width / squareSize;
            var nY = height / squareSize;
            var results = new int[nX, nY];
            var tR = targetColor.R;
            var tG = targetColor.G;
            var tB = targetColor.B;

            for (var Y_index = 0; Y_index < nY; Y_index++)
            {
                for (var X_index = 0; X_index < nX; X_index++)
                {
                    var thisScore = maxScore;
                    for (var Y_subIndex = 0; Y_subIndex < squareSize; Y_subIndex++)
                    {
                        for (var X_subIndex = 0; X_subIndex < squareSize; X_subIndex++)
                        {
                            thisScore -= Math.Abs(tR - bmpData[get24BPPdataoffset((X_index * squareSize) + X_subIndex, (Y_index * squareSize) + Y_subIndex, width) + 2]);
                            thisScore -= Math.Abs(tG - bmpData[get24BPPdataoffset((X_index * squareSize) + X_subIndex, (Y_index * squareSize) + Y_subIndex, width) + 1]);
                            thisScore -= Math.Abs(tB - bmpData[get24BPPdataoffset((X_index * squareSize) + X_subIndex, (Y_index * squareSize) + Y_subIndex, width) + 0]);
                        }
                    }
                    results[X_index, Y_index] = thisScore;
                }
            }

            return results;
        }

        private static int get24BPPdataoffset(int x, int y, int scanlineLength)
        {
            return 4 * (x + (y * scanlineLength));
        }

        private static byte[] diff(byte[] newData, byte[] oldData, int width, int height)
        {
            var result = new byte[4 * width * height];

            for (var Y = 0; Y < height; Y++)
            {
                for (var X = 0; X < width; X++)
                {
                    var offset = get24BPPdataoffset(X, Y, width);
                    for (var color_index = 0; color_index < 3; color_index++)
                    {
                        if (newData[offset + color_index] != oldData[offset + color_index])
                            result[offset + color_index] = newData[offset + color_index];
                    }
                }
            }


            return result;
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            if (bmp != null)
            {
                e.Graphics.DrawImage(bmp, panel1.DisplayRectangle, 0, 0, bmp.Width, bmp.Height, GraphicsUnit.Pixel);

                //if (_lastBitmap != null) e.Graphics.DrawImage(_lastBitmap, new Rectangle(300, 0, 300, 200), 0, 0, _lastBitmap.Width, _lastBitmap.Height, GraphicsUnit.Pixel);
                //if (outputBitmap != null) e.Graphics.DrawImage(outputBitmap, new Rectangle(600,0,300,200), 0, 0, outputBitmap.Width, outputBitmap.Height, GraphicsUnit.Pixel);
                var xRatio = (float)panel1.Width / bmp.Width * targetSize;
                var yRatio = (float)panel1.Height / bmp.Height * targetSize;

                for (var i = 0; i < bmp.Width / targetSize; i++)
                {
                    for (var j = 0; j < bmp.Height / targetSize; j++)
                    {
                        e.Graphics.DrawString((100 * Scores[i, j] / maxScore).ToString("D"), DefaultFont, new SolidBrush(Color.Brown),
                            i * xRatio, j * yRatio);
                    }
                }
            }
        }

    }
}
