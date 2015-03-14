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
        public float ZoomLevel { get; set; }
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
        private float aspectRatio;
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
        //private int maxPanX, maxPanY;
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

        private void loadNewSourceImage(Image img)
        {
            if (img != null)
            {
                sourceImage = img;

                aspectRatio = (float)img.Width / img.Height;
                srcOffsetX = img.Width/2.0f;
                srcOffsetY = img.Height/2.0f;
                srcScaleX = 1.0f/img.Width;
                srcScaleY = 1.0f/img.Height;
                srcPosX = 0.0f;
                srcPosY = 0.0f;

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
            //repaint with current zoom/pan
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
                PanPosition.Offset((lastMouseX - e.X), (lastMouseY - e.Y));
                lastMouseX = e.X;
                lastMouseY = e.Y;
            }
        }

        private void ImageControl_Resize(object sender, EventArgs e)
        {
            destOffsetX = Width/2.0f;
            destOffsetY = Height/2.0f;
            destScaleX = 1.0f/Width;
            destScaleY = 1.0f/Height;
        }

        private void getCurrentRectangle()
        {
            //process matrix to create source and destination area
            var a = PanPosition.X + (int)((srcOffsetX * ZoomLevel) - destOffsetX);
            var b = PanPosition.X + (int)((srcOffsetY * ZoomLevel) - destOffsetY);
            var c = PanPosition.X + (int)(2.0f * destOffsetX * ZoomLevel);
            var d = PanPosition.X + (int)(2.0f * destOffsetY * ZoomLevel);

            var ad = 0;
            var bd = 0;
            var cd = Width;
            var dd = Height;

            if (a < 0)
            {
                ad = (int) (destOffsetX - (srcOffsetX*ZoomLevel));
                a = 0;
            }

            if (b < 0)
            {
                bd = (int) (destOffsetY - (srcOffsetY*ZoomLevel));
                b = 0;
            }
            if ((a + c) > sourceImage.Width)
            {
                cd = (int)(2.0f * srcOffsetX * ZoomLevel);
                c = sourceImage.Width;
            }
            if ((b + d) > sourceImage.Height)
            {
                dd = (int)(2.0f * srcOffsetX * ZoomLevel);
                d = sourceImage.Height;
            }



            srcRectangle = new Rectangle(a, b, c, d);
            destRectangle = new Rectangle(ad, bd, cd, dd);


            //clamp
        }




    }
}
