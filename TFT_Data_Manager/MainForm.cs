using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace TFT_Data_Manager
{
    public partial class MainForm : Form
    {
        public struct imageData
        {
            public string SourcePath; //fullpath or relative to location of database file
            public Bitmap SourceBitmap;
            //     public Bitmap ResultBitmap;
            public byte[,,] ResultBytes; // new byte[128, 160, 3]; 128 rows, 160 columns, 3 bytes per pixel (RGB888) 
            public int top, left, width, height;
            public int index;
        }

        public Dictionary<string, imageData> imageDataList = new Dictionary<string, imageData>();

        public struct rawTFTDTA
        {
            public byte RGB_Code; // 565:05h 666:06h
            public byte num_images; // 0-255
            public ushort bytes_per_image; // 565:A000h 666:F000h
            public byte MADCTL;
            public byte[] data;

        }

        private Brush clearBrush = new SolidBrush(Color.Green);
        private float sourceAR = 640f / 480f;
        private bool updatingTrackBars;

        private Bitmap currentWorkingBitmap;
        private string currentWorkingImagePath;

        public MainForm()
        {
            InitializeComponent();
        }


        private void addButton_Click(object sender, EventArgs e)
        {
            if (currentWorkingBitmap != null)
            {
                var new_key = Guid.NewGuid().ToString();

                imageDataList.Add(new_key, new imageData()
                {
                    SourceBitmap = currentWorkingBitmap,
                    SourcePath = currentWorkingImagePath,
                    top = Convert.ToInt32(TopTextBox.Text),
                    left = Convert.ToInt32(LeftTextBox.Text),
                    width = Convert.ToInt32(WidthTextBox.Text),
                    height = Convert.ToInt32(HeightTextBox.Text)
                });

                var bmpBuffer = new Bitmap(previewLabel.ClientRectangle.Width, previewLabel.ClientRectangle.Height);
                previewLabel.DrawToBitmap(bmpBuffer, previewLabel.ClientRectangle);
                bmpBuffer = new Bitmap(bmpBuffer, 80, 64);

                thumbnailList.Images.Add(new_key, bmpBuffer);

                bmpBuffer.Dispose();

                listView1.Items.Add(Path.GetFileName(currentWorkingImagePath), new_key);
            }
        }

        private void OpenDataMenuItem_Click(object sender, EventArgs e)
        {
            if (openLIBFileDialog1.ShowDialog() == DialogResult.OK)
            {
                //open library file
            }
        }

        private void SaveAsMenuItem_Click(object sender, EventArgs e)
        {
            if (saveLIBFileDialog1.ShowDialog() == DialogResult.OK)
            {
                //save library file
                var data = JsonConvert.SerializeObject(imageDataList, Formatting.Indented);
                Debug.WriteLine(data);
            }
        }

        private void FlashMemoryMenuItem_Click(object sender, EventArgs e)
        {
            if (saveDTAFileDialog2.ShowDialog() == DialogResult.OK)
            {
                //save TFT data file
            }
        }

        private void loadSourceButton_Click(object sender, EventArgs e)
        {
            openImageFileDialog1.FileName = "*.*";
            if (openImageFileDialog1.ShowDialog() == DialogResult.OK)
            {
                //open image file and display in sourceLabel

                currentWorkingBitmap?.Dispose();
                try
                {
                    currentWorkingBitmap = new Bitmap(openImageFileDialog1.FileName);
                    currentWorkingImagePath = openImageFileDialog1.FileName;
                    sourceLabel.Refresh();
                    fitMostButton_Click(this, null);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error Loading Image File", MessageBoxButtons.OK);
                    currentWorkingBitmap = null;
                }
            }
        }

        private void sourceLabel_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.FillRectangle(clearBrush, sourceLabel.ClientRectangle);

            if (currentWorkingBitmap != null)
            {
                e.Graphics.DrawImage(currentWorkingBitmap, sourceLabel.ClientRectangle,
                    new Rectangle(0, 0, currentWorkingBitmap.Width, currentWorkingBitmap.Height), GraphicsUnit.Pixel);
            }
        }

        private void fitMostButton_Click(object sender, EventArgs e)
        {
            updatingTrackBars = true;
            if (currentWorkingBitmap != null)
            {
                var imageAR = currentWorkingBitmap.Width / (float)currentWorkingBitmap.Height;

                var x = 0;
                var y = 0;
                var w = 100;
                var h = 100;

                if (imageAR > sourceAR)
                {
                    x = (int)(50 - (sourceAR / imageAR * 50));
                    w = 100 - x;
                }
                else if (imageAR < sourceAR)
                {
                    y = (int)(50 - (imageAR / sourceAR * 50));
                    h = 100 - y;
                }

                leftTrackBar.Value = x;
                rightTrackBar.Value = w;
                topTrackBar.Value = -y;
                bottomTrackBar.Value = -h;
                updatingTrackBars = false;

                TrackBar_ValueChanged(sender, e);
            }
        }


        private void TrackBar_ValueChanged(object sender, EventArgs e)
        {
            //update previewLabel
            if (!updatingTrackBars)
            {
                updatingTrackBars = true; // lock to avoid infinite recursion
                if (topTrackBar.Value < bottomTrackBar.Value) topTrackBar.Value = bottomTrackBar.Value;
                if (bottomTrackBar.Value > topTrackBar.Value) bottomTrackBar.Value = topTrackBar.Value;
                if (leftTrackBar.Value > rightTrackBar.Value) leftTrackBar.Value = rightTrackBar.Value;
                if (rightTrackBar.Value < leftTrackBar.Value) rightTrackBar.Value = leftTrackBar.Value;
                previewLabel.Refresh();
                updatingTrackBars = false;
            }
        }

        private void previewLabel_Paint(object sender, PaintEventArgs e)
        {
            if (currentWorkingBitmap != null)
            {
                var dta = getXYWH();
                LeftTextBox.Text = dta.Item1.ToString();
                TopTextBox.Text = dta.Item2.ToString();
                WidthTextBox.Text = dta.Item3.ToString();
                HeightTextBox.Text = dta.Item4.ToString();
                e.Graphics.DrawImage(currentWorkingBitmap, previewLabel.ClientRectangle, new Rectangle(dta.Item1, dta.Item2, dta.Item3, dta.Item4), GraphicsUnit.Pixel);
            }
        }

        private Tuple<int, int, int, int> getXYWH()
        {
            return new Tuple<int, int, int, int>(

                leftTrackBar.Value * currentWorkingBitmap.Width / 100, //x
                -topTrackBar.Value * currentWorkingBitmap.Height / 100, //y
                (rightTrackBar.Value - leftTrackBar.Value) * currentWorkingBitmap.Width / 100, //w
                (-bottomTrackBar.Value + topTrackBar.Value) * currentWorkingBitmap.Height / 100 //h
                );
        }

        private void removeButton_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count == 1)
            {
                thumbnailList.Images.RemoveByKey(listView1.SelectedItems[0].ImageKey);
                imageDataList.Remove(listView1.SelectedItems[0].ImageKey);
                listView1.Items.RemoveAt(listView1.SelectedIndices[0]);
            }
        }

        private void fitAllButton_Click(object sender, EventArgs e)
        {
            updatingTrackBars = true;
            topTrackBar.Value = 0;
            bottomTrackBar.Value = -100;
            leftTrackBar.Value = 0;
            rightTrackBar.Value = 100;
            updatingTrackBars = false;
            TrackBar_ValueChanged(sender, e);
        }

        private void moveUpButton_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count == 1)
            {
                var original_item = listView1.SelectedItems[0];
                var original_index = original_item.Index;
                if (original_index > 0)
                {
                    listView1.Items.RemoveAt(original_index);
                    listView1.Items.Insert(original_index - 1, original_item);

                    forceUpdateCrappyListViewBehaviour();

                    listView1.Focus();
                    listView1.Items[original_index - 1].Selected = true;
                }

            }
        }

        private void moveDownButton_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count == 1)
            {
                var original_item = listView1.SelectedItems[0];
                var original_index = original_item.Index;
                if (original_index < listView1.Items.Count - 1)
                {
                    listView1.Items.RemoveAt(original_index);
                    listView1.Items.Insert(original_index + 1, original_item);

                    forceUpdateCrappyListViewBehaviour();

                    listView1.Focus();
                    listView1.Items[original_index + 1].Selected = true;
                }

            }
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if (listView1.SelectedIndices.Count > 0) Text = listView1.SelectedIndices[0].ToString();
        }

        private void forceUpdateCrappyListViewBehaviour()
        {
            listView1.BeginUpdate();
            listView1.Alignment = ListViewAlignment.Default;
            listView1.Alignment = ListViewAlignment.Top;
            listView1.EndUpdate();
        }
    }
}
