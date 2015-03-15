using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SaveAsFIT
{        

    public partial class ImageControl : UserControl
    {        
        


        private float zoomLevel;

        public float ZoomLevel
        {
            get
            {
                return zoomLevel;
            }
            set
            {
                setZoomLevel(value);
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
                loadNewSourceImage(value);
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
        private bool panning;
        public Point PanPosition;
        private Rectangle destRectangle, srcRectangle;

        private float destScaleX, destScaleY;
        private float destOffsetX, destOffsetY;
        private float srcPosX, srcPosY;
        private float srcScaleX, srcScaleY;
        private float srcOffsetX, srcOffsetY;

        /* pixels coordinate system
         * 0.0, 0.0                 width, 0.0
         * 
         * 
         * 0.0, height                 width, height
         * 
         * float coordinates system
         * -1.0,-1.0       0.0,-1.0        1.0,-1.0
         * 
         * -1.0, 0.0       0.0, 0.0        1.0, 0.0
         * 
         * -1.0, 1.0       0.0, 1.0        1.0, 1.0
         * 
         */


        public ImageControl()
        {
            InitializeComponent();
            MouseWheel += ImageControl_MouseWheel;
        }

        private void setZoomLevel(float newLevel)
        {
            zoomLevel = newLevel;
            if (sourceImage != null)
            {
                srcOffsetX = sourceImage.Width*zoomLevel/2.0f;
                srcOffsetY = sourceImage.Height*zoomLevel/2.0f;
                maxPanX = (int) (sourceImage.Width*zoomLevel) - Width;
                maxPanY = (int) (sourceImage.Height*zoomLevel) - Height;
                Refresh();
            }
        }

        private void loadNewSourceImage(Image img)
        {
            if (img != null)
            {
                sourceImage = img;

                srcOffsetX = img.Width/2.0f;
                srcOffsetY = img.Height/2.0f;
                srcScaleX = img.Width;
                srcScaleY = img.Height;
                srcPosX = 0.0f;
                srcPosY = 0.0f;

                PanPosition = Point.Empty;

                FitImageToControl();
            }
        }

        public void FitImageToControl()
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
            ZoomLevel = fitZoomLevel;
            Refresh();
        }

        private void ImageControl_Paint(object sender, PaintEventArgs e)
        {
            if (SourceImage != null)
            {
                getCurrentRectangle();
                e.Graphics.DrawImage(SourceImage, destRectangle, srcRectangle, GraphicsUnit.Pixel);
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
                ZoomLevel = Math.Min(maxZoomLevel, ZoomLevel * 1.5f);
            }
            else if (e.Delta < 0)
            {
                ZoomLevel = Math.Max(fitZoomLevel, ZoomLevel / 1.5f);
            }
        }

        private void ImageControl_MouseUp(object sender, MouseEventArgs e)
        {
            panning = false;
        }

        private void ImageControl_MouseLeave(object sender, EventArgs e)
        {
            panning = false;
        }

        private void ImageControl_MouseMove(object sender, MouseEventArgs e)
        {
            if (panning)
            {
                var tempX = Math.Min(PanPosition.X + lastMouseX - e.X, maxPanX);
                if (tempX < 0) tempX = 0;

                var tempY = Math.Min(PanPosition.Y + lastMouseY - e.Y, maxPanY);
                if (tempY < 0) tempY = 0;

                PanPosition = new Point(tempX, tempY);
                lastMouseX = e.X;
                lastMouseY = e.Y;
                Refresh();
            }
        }

        private void ImageControl_Resize(object sender, EventArgs e)
        {
            destOffsetX = Width/2.0f;
            destOffsetY = Height/2.0f;
            destScaleX = 2.0f/Width;
            destScaleY = 2.0f/Height;
        }

        private void getCurrentRectangle()
        {
            //process matrix to create source and destination area
            var a = (PanPosition.X / zoomLevel) + ((srcOffsetX / ZoomLevel) + destOffsetX);
            var b = (PanPosition.Y / zoomLevel) + ((srcOffsetY / ZoomLevel) + destOffsetY);
            var c = Width / zoomLevel;
            var d = Height / zoomLevel;

            if (a < 0) a = 0;
            if (b < 0) b = 0;
            if ((a+c) > sourceImage.Width) c = sourceImage.Width-a;
            if ((b+d) > sourceImage.Height) d = sourceImage.Height-b;

            srcRectangle = new Rectangle((int)a, (int)b, (int)c, (int)d);

            destRectangle = new Rectangle(0, 0, Width, Height);

        }

    }


}
