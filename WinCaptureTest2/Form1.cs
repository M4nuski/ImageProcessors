using System;
using System.Drawing;
using System.Windows.Forms;

namespace WinCaptureTest2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        //private Bitmap p1;
        private Random r = new Random();
        //private Bitmap p2 = new Bitmap("FT2.bmp");
        private void Form1_Load(object sender, EventArgs e)
        {
            pictureBox1.Image = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            //p1 = new Bitmap(pictureBox1.Image);
            textBox1.Text = this.Handle.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(textBox1.Text);
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.FillEllipse(new SolidBrush(Color.Black), r.Next(pictureBox1.Width), r.Next(pictureBox1.Height), 20, 20);
            e.Graphics.FillEllipse(new SolidBrush(Color.Red), r.Next(pictureBox1.Width), r.Next(pictureBox1.Height), 20, 20);
            e.Graphics.FillEllipse(new SolidBrush(Color.Green), r.Next(pictureBox1.Width), r.Next(pictureBox1.Height), 20, 20);
            e.Graphics.FillEllipse(new SolidBrush(Color.Blue), r.Next(pictureBox1.Width), r.Next(pictureBox1.Height), 20, 20);
            e.Graphics.FillEllipse(new SolidBrush(Color.White), r.Next(pictureBox1.Width), r.Next(pictureBox1.Height), 20, 20);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            pictureBox1.Refresh();
        }
    }
}
