using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;

namespace SaveAsFITS
{
    public partial class ImageControl : UserControl
    {
        #region Properties
        public Point PanPosition;
        public float ZoomIncrements = 1.25f;
        private float zoomLevel;
        public float ZoomLevel
        {
            get
            {
                return zoomLevel;
            }
            set
            {
                setZoomLevel(clamp(value, fitZoomLevel, maxZoomLevel));
            }
        }

        private Image sourceImage;
        public Image SourceImage
        {
            get
            {
                return sourceImage;
            }
            set
            {
                if (value != null)
                {
                    sourceImage = value;
                    FitImageToControl();
                }
            }
        }

        private float fitZoomLevel; //also happens to be minimum zoom level
        private float maxZoomLevel = 10.0f;
        public float MaxZoomLevel
        {
            get
            {
                return maxZoomLevel;
            }
            set
            {
                if (value > fitZoomLevel)
                {
                    maxZoomLevel = value;
                }
            }
        }

        private int lastMouseX, lastMouseY;
        private int maxPanX, maxPanY;
        private int minPanX, minPanY;
        private bool panning;
        public ImageAttributes SourceAttributes;
        #endregion

        #region UI Methods
        public ImageControl()
        {
            InitializeComponent();
            MouseWheel += ImageControl_MouseWheel;
        }

        private void ImageControl_Paint(object sender, PaintEventArgs e)
        {
            if (SourceImage != null)
            {
                if (SourceAttributes == null)
                {
                    e.Graphics.DrawImage(SourceImage, DisplayRectangle, getCurrentRectangle(), GraphicsUnit.Pixel);
                }
                else
                {
                    var destinationRectangle = getCurrentRectangle();
                    e.Graphics.DrawImage(SourceImage, DisplayRectangle, 
                        destinationRectangle.Left, 
                        destinationRectangle.Top,
                        destinationRectangle.Width,
                        destinationRectangle.Height, GraphicsUnit.Pixel, SourceAttributes);
                }
            }
        }

        private void ImageControl_MouseDown(object sender, MouseEventArgs e)
        {
            panning = true;
        }

        private void ImageControl_MouseWheel(object sender, MouseEventArgs e)
        {
            if (e.Delta > 0)
            {
                ZoomLevel = Math.Min(maxZoomLevel, ZoomLevel * ZoomIncrements);
            }
            else if (e.Delta < 0)
            {
                ZoomLevel = Math.Max(fitZoomLevel, ZoomLevel / ZoomIncrements);
            }
        }

        private void ImageControl_MouseUp(object sender, MouseEventArgs e)
        {
            panning = false;
        }

        private void ImageControl_MouseMove(object sender, MouseEventArgs e)
        {
            if (panning)
            {
                var tempX = clamp(PanPosition.X + lastMouseX - e.X, minPanX, maxPanX);
                var tempY = clamp(PanPosition.Y + lastMouseY - e.Y, minPanY, maxPanY);

                PanPosition = new Point(tempX, tempY);

                Refresh();
            }
            lastMouseX = e.X;
            lastMouseY = e.Y;
        }

        private void ImageControl_Resize(object sender, EventArgs e)
        {
            var lastFitZoomLevel = fitZoomLevel;
            setFitZoomLevel();
            ZoomLevel = zoomLevel * fitZoomLevel / lastFitZoomLevel;
        }
        #endregion

        #region Control Methods
        private void setZoomLevel(float newLevel)
        {
            if (sourceImage != null)
            {
                maxPanX = (int)((newLevel * sourceImage.Width) - Width);
                maxPanY = (int)((newLevel * sourceImage.Height) - Height);

                if ((newLevel * sourceImage.Width) < Width)
                {
                    minPanX = (int)(Width - (newLevel * sourceImage.Width)) / -2;
                }
                else
                {
                    minPanX = 0;
                }
                if ((newLevel * sourceImage.Height) < Height)
                {
                    minPanY = (int)(Height - (newLevel * sourceImage.Height)) / -2;
                }
                else
                {
                    minPanY = 0;
                }

                //find new pan offset
                var tempX = (((PanPosition.X + lastMouseX) / zoomLevel) * newLevel) - lastMouseX;
                var tempY = (((PanPosition.Y + lastMouseY) / zoomLevel) * newLevel) - lastMouseY;

                PanPosition = new Point((int)clamp(tempX, minPanX, maxPanX), (int)clamp(tempY, minPanY, maxPanY));

                zoomLevel = newLevel;
                Refresh();
            }
        }

        private void setFitZoomLevel()
        {
            if (sourceImage != null)
            {
                if (sourceImage.Width != Width)
                {
                    fitZoomLevel = (float)Width / sourceImage.Width;
                }
                else
                {
                    fitZoomLevel = 1.0f;
                }

                if ((sourceImage.Height * fitZoomLevel) > Height)
                {
                    fitZoomLevel = (float)Height / sourceImage.Height;
                }
            }
        }

        public void FitImageToControl()
        {
            setFitZoomLevel();
            PanPosition = new Point((int)(((sourceImage.Width * fitZoomLevel) - Width) * 0.5f), (int)(((sourceImage.Height * fitZoomLevel) - Height) * 0.5f));
            zoomLevel = fitZoomLevel;//override panPosition compensation
            ZoomLevel = fitZoomLevel;
        }

        private Rectangle getCurrentRectangle()
        {
            var l = PanPosition.X / zoomLevel;
            var t = PanPosition.Y / zoomLevel;

            var w = Width / zoomLevel;
            var h = Height / zoomLevel;

            return new Rectangle((int)l, (int)t, (int)w, (int)h);
        }
        #endregion

        #region Helper Methods
        private static int clamp(int val, int min, int max)
        {
            if (val > max) val = max;
            if (val < min) val = min;
            return val;
        }

        private static float clamp(float val, float min, float max)
        {
            if (val > max) val = max;
            if (val < min) val = min;
            return val;
        }
        #endregion
    }
}
