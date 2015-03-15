﻿using System;
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
        private int minPanX, minPanY;
        private bool panning;
        public Point PanPosition;
        private Rectangle destRectangle, srcRectangle;

        private float destCenterX, destCenterY;

        private float srcCenterX, srcCenterY;

        public ImageControl()
        {
            InitializeComponent();
            MouseWheel += ImageControl_MouseWheel;
        }

        private void setZoomLevel(float newLevel)
        {
            if (sourceImage != null)
            {
              //  var panOffsetX = sourceImage.Width * (newLevel - zoomLevel);
              //  var panOffsetY = sourceImage.Height * (newLevel - zoomLevel);
              //  PanPosition = new Point((int)(PanPosition.X + panOffsetX), (int)(PanPosition.Y + panOffsetY));

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

                zoomLevel = newLevel;

                PanPosition = new Point(clamp(PanPosition.X, minPanX, maxPanX), clamp(PanPosition.Y, minPanY, maxPanY));
                
                Refresh();
            }
        }

        private void loadNewSourceImage(Image img)
        {
            if (img != null)
            {
                sourceImage = img;

                srcCenterX = img.Width / 2.0f;
                srcCenterY = img.Height / 2.0f;

                FitImageToControl();
            }
        }

        public void FitImageToControl()
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
            PanPosition = new Point((int)(((sourceImage.Width * fitZoomLevel) - Width) * 0.5f), (int)(((sourceImage.Height * fitZoomLevel) - Height) * 0.5f));
            ZoomLevel = fitZoomLevel;
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

        private void ImageControl_MouseMove(object sender, MouseEventArgs e)
        {
            if (panning)
            {
                var tempX = clamp(PanPosition.X + lastMouseX - e.X, minPanX, maxPanX);
                var tempY = clamp(PanPosition.Y + lastMouseY - e.Y, minPanY, maxPanY);

                PanPosition = new Point(tempX, tempY);

                lastMouseX = e.X;
                lastMouseY = e.Y;
                Refresh();
            }
        }

        private void ImageControl_Resize(object sender, EventArgs e)
        {
            destCenterX = Width / 2.0f;
            destCenterY = Height / 2.0f;
        }

        private void getCurrentRectangle()
        {
            //    var l = (PanPosition.X / zoomLevel) + srcCenterX - (destCenterX / ZoomLevel);
            //    var t = (PanPosition.Y / zoomLevel) + srcCenterY - (destCenterY / ZoomLevel);
            var l = PanPosition.X / zoomLevel;
            var t = PanPosition.Y / zoomLevel;

            var w = Width / zoomLevel;
            var h = Height / zoomLevel;

            //      if (t < 0) t = 0;
            //      if (l < 0) l = 0;
            //if ((l+w) > sourceImage.Width) w = sourceImage.Width-l;
            //if ((t+h) > sourceImage.Height) h = sourceImage.Height-t;

            srcRectangle = new Rectangle((int)l, (int)t, (int)w, (int)h);

            //TODO clip if out of bounds
            destRectangle = new Rectangle(0, 0, Width, Height);

        }

        private static int clamp(int val, int min, int max)
        {
            if (val > max) val = max;
            if (val < min) val = min;
            return val;
        }

    }


}
