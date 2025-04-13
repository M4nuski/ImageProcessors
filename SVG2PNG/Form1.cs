using System;
using System.Drawing;
using System.Windows.Forms;
using Svg;

namespace SVG2PNG
{
    public partial class Form1 : Form
    {
        public SvgDocument svgDoc;
        public string lastFileName = "";

        public Form1()
        {
            InitializeComponent();

            comboBox_alphaMode.SelectedIndex = 1;
        }
        private void log(string s)
        {
            textBox1.AppendText(s + "\r\n");
            textBox1.SelectionStart = textBox1.TextLength - 1;
        }
        private void button_Open_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() != DialogResult.OK) return;

            try
            {
                svgDoc = SvgDocument.Open(openFileDialog1.FileName);
                lastFileName = System.IO.Path.GetFileNameWithoutExtension(openFileDialog1.FileName);

                log(openFileDialog1.FileName);
                log(svgDoc.GetDimensions().ToString());
                log(svgDoc.Width.Value.ToString() + " " + svgDoc.Width.Type.ToString());
                log(svgDoc.Height.Value.ToString() + " " + svgDoc.Height.Type.ToString());

                var bitmap = svgDoc.Draw();
                pictureBox1.Image = bitmap;
                pictureBox1.Refresh();

                checkBox_Invert_CheckedChanged(sender, e);
            } catch (Exception ex)
            {
                log(ex.Message);
            }
        }

        private void button_Save_Click(object sender, EventArgs e)
        {
            saveFileDialog1.FileName = lastFileName + ".png";
            if (saveFileDialog1.ShowDialog() != DialogResult.OK) return;
            if (pictureBox2.Image == null) return;

            log("Saving as " + saveFileDialog1.FileName);
            try
            {
                pictureBox2.Image.Save(saveFileDialog1.FileName);
            } catch (Exception ex)
            {
                log(ex.Message);
            }
        }

        private void checkBox_Invert_CheckedChanged(object sender, EventArgs e) // reprocess
        {
            if (svgDoc == null) return;
            log("Processing...");

            var dpi = int.Parse(textBox_DPI.Text);
            if (dpi == 0) dpi = 96;
            svgDoc.Ppi = dpi;

            log("DPI set to: " + dpi);

            var bitmap = svgDoc.Draw();
            bitmap.SetResolution(dpi, dpi);

            var cw = Color.White;
            var cb = Color.Black;
            var repCol = (comboBox_alphaMode.SelectedIndex == 0) ? Color.Black : Color.White;
            log("Checking transperency");
            for (var x = 0; x < bitmap.Width; ++x)
                for (var y = 0; y < bitmap.Height; ++y)
                {
                    var cc = bitmap.GetPixel(x, y);
                    if (cc.A < 128) bitmap.SetPixel(x, y, repCol);
                }

            if (checkBox_Invert.Checked)
            {
                log("Inverting");
                for (var x = 0; x < bitmap.Width; ++x)
                    for (var y = 0; y < bitmap.Height; ++y)
                    {
                        var cc = bitmap.GetPixel(x, y);
                        if (cEqRGB(cc, cw)) bitmap.SetPixel(x, y, cb);
                        if (cEqRGB(cc, cb)) bitmap.SetPixel(x, y, cw);
                    }
            }

            pictureBox2.Image = bitmap;
            log("Done");
            pictureBox2.Refresh();

        }

        private bool cEqRGB(Color a, Color b)
        {
            return ((a.R == b.R) && (a.G == b.G) && (a.B == b.B));
        }

        private void textBox_DPI_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return) checkBox_Invert_CheckedChanged(sender, null);
        }
    }
}
