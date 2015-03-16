using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace SaveAsFIT
{

    public partial class ImageControl : UserControl
    {
    #region Properties
        public Point PanPosition;

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

        private float fitZoomLevel; //also hapens to be minimum zoom level
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
                e.Graphics.DrawImage(SourceImage, DisplayRectangle, getCurrentRectangle(), GraphicsUnit.Pixel);
            }
        }

        private void ImageControl_MouseDown(object sender, MouseEventArgs e)
        {
            panning = true;
            lastMouseX = e.X;
            lastMouseY = e.Y;
        }

        private void ImageControl_MouseWheel(object sender, MouseEventArgs e)
        {
            if (e.Delta > 0)
            {
                ZoomLevel = Math.Min(maxZoomLevel, ZoomLevel * 1.25f);
            }
            else if (e.Delta < 0)
            {
                ZoomLevel = Math.Max(fitZoomLevel, ZoomLevel / 1.25f);
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
            ZoomLevel = zoomLevel*fitZoomLevel/lastFitZoomLevel;
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
                //find out where the cursor is relative to source image
                float tempX = ((PanPosition.X/zoomLevel)*newLevel); 
                float tempY = ((PanPosition.Y/zoomLevel)*newLevel);
                
                //ajust to zoom level
                //pan pos = tempx * (panpos + mousepos
               // tempX = ((PanPosition.X * newLevel) * tempX) + lastMouseX;
               // tempY = ((PanPosition.Y * newLevel) * tempY) + lastMouseY;

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
                    fitZoomLevel = (float) Width/sourceImage.Width;
                }
                else
                {
                    fitZoomLevel = 1.0f;
                }

                if ((sourceImage.Height*fitZoomLevel) > Height)
                {
                    fitZoomLevel = (float) Height/sourceImage.Height;
                }
            }
        }

        public void FitImageToControl()
        {
            setFitZoomLevel();
            PanPosition = new Point((int)(((sourceImage.Width * fitZoomLevel) - Width) * 0.5f), (int)(((sourceImage.Height * fitZoomLevel) - Height) * 0.5f));
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
