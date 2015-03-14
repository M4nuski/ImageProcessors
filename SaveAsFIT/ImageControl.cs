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
        private float maxZoomLevel, minZoomLevel;
        private int lastMouseX, lastMouseY;
        private int maxPanX, maxPanY;
        private bool panning;
        public Point PanPosition { get; set; }
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
                getCurrentRectangle()
                e.Graphics.DrawImage(SourceImage, destRectangle, srcRectangle, GraphicsUnit.Pixel);
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
                ZoomLevel = Math.Min(maxZoomLevel, ZoomLevel * 1.5f);
            }
            else if (e.Delta < 0)
            {
                ZoomLevel = Math.Max(minZoomLevel, ZoomLevel / 1.5f);
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
                //
            }
        }

        private void ImageControl_Resize(object sender, EventArgs e)
        {
            //
        }

        private void getCurrentRectangle()
        {
            srcRectangle = new Rectangle(0, 0, (int)(sourceImage.Width * ZoomLevel), (int)(sourceImage.Height * ZoomLevel));
            destRectangle = new Rectangle( )
        }




    }
}
