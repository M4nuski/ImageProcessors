using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TFT_Data_Manager
{
    public partial class MainForm : Form
    {
        public struct imageData
        {
            public string SourcePath; //fullpath or relative to location of database file
            public Bitmap SourceBitmap;
            public Bitmap ResultBitmap;
            public byte[,,] ResultBytes; // new byte[128, 160, 3]; 128 rows, 160 columns, 3 bytes per pixel (RGB888) 
            public int top, left, width, height;
        }

 
        public MainForm()
        {
            InitializeComponent();
        }

        private void listView1_RetrieveVirtualItem(object sender, RetrieveVirtualItemEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void previewLabel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }

        private void rightTrackBar_Scroll(object sender, EventArgs e)
        {

        }
    }
}
