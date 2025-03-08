using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Runtime.InteropServices;
using System.Security.Cryptography;

namespace HX_20_LCD_Interface
{
    public partial class Form1 : Form
    {

        public byte[] fData;
        public int fDataPos = -1;

        public int Xpos, Ypos, offset;


        public Brush BackBrush = new SolidBrush(Color.LightGray);
        public Brush FrontBrush = new SolidBrush(Color.Black);
        public Brush CommandBrush = new SolidBrush(Color.Red);
        public Brush Set64Brush = new SolidBrush(Color.Blue);
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() != DialogResult.OK) return;
            fData = File.ReadAllBytes(openFileDialog1.FileName);
            // TODO check sequence of ==0x55 &0x80>0 0xdd ==0xAA

            fDataPos = fData.Length;
            panel1.Refresh();
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
        }

        private void checkBox_dataOnly_CheckedChanged(object sender, EventArgs e)
        {
            panel1.Refresh();
        }

        private void checkBox_maskB7_CheckedChanged(object sender, EventArgs e)
        {
            panel1.Refresh();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            if (fDataPos == -1)
            {
                e.Graphics.FillRectangle(BackBrush, panel1.ClientRectangle);
                return;
            }
            if (fData == null) return;
            //==0x55 &0x80>0 0xdd ==0xAA
            Xpos = 0;
            Ypos = 0;
            offset = 0;

            int[] nCS = new int[6];

            for (var i = 0; i < fDataPos; i += 4)
            {
                var mode = fData[i + 1];
                var isCommand = (mode & 0x40) > 0;
                var dta = fData[i + 2];
                var cs = mode & 0x0F;
                nCS[cs]++;
                if (!isCommand && checkBox_maskB7.Checked) dta = (byte)(dta & 0x7F);

                if (!checkBox_dataOnly.Checked || (checkBox_dataOnly.Checked && !isCommand))
                {
                    Brush cb = FrontBrush;
                    if (isCommand) cb = (dta == 0x64) ? Set64Brush : CommandBrush;
                    e.Graphics.FillRectangle(((dta & 0x01) > 0) ? cb : BackBrush, 4 * (Xpos + offset), 4 * (Ypos + 0), 4, 4);
                    e.Graphics.FillRectangle(((dta & 0x02) > 0) ? cb : BackBrush, 4 * (Xpos + offset), 4 * (Ypos + 1), 4, 4);
                    e.Graphics.FillRectangle(((dta & 0x04) > 0) ? cb : BackBrush, 4 * (Xpos + offset), 4 * (Ypos + 2), 4, 4);
                    e.Graphics.FillRectangle(((dta & 0x08) > 0) ? cb : BackBrush, 4 * (Xpos + offset), 4 * (Ypos + 3), 4, 4);
                    e.Graphics.FillRectangle(((dta & 0x10) > 0) ? cb : BackBrush, 4 * (Xpos + offset), 4 * (Ypos + 4), 4, 4);
                    e.Graphics.FillRectangle(((dta & 0x20) > 0) ? cb : BackBrush, 4 * (Xpos + offset), 4 * (Ypos + 5), 4, 4);
                    e.Graphics.FillRectangle(((dta & 0x40) > 0) ? cb : BackBrush, 4 * (Xpos + offset), 4 * (Ypos + 6), 4, 4);
                    e.Graphics.FillRectangle(((dta & 0x80) > 0) ? cb : BackBrush, 4 * (Xpos + offset), 4 * (Ypos + 7), 4, 4);
                    offset++;
                    if (offset >= 120)
                    {
                        offset = 0;
                        Ypos += 8;
                    }
                }
            }

            label_stats.Text = $"nCS: {nCS[0]}, {nCS[1]}, {nCS[2]}, {nCS[3]}, {nCS[4]}, {nCS[5]}";
            return;
            /*
            offset = 0;
            for (var i = 0; i < fDataPos; i += 4)
            {
                var cmd = fData[i + 1];
                var dta = fData[i + 2];

                if ((cmd & 0x40) == 0) // #CMD
                {
                    var cs = cmd & 0x0F;
                    if (dta == 0x64)
                    {
                        offset = 0;
                        switch (cs)
                        {
                            case 0:
                                Xpos = 0;
                                Ypos = 0;
                                break;
                            case 1:
                                Xpos = 40;
                                Ypos = 0;
                                break;
                            case 2:
                                Xpos = 80;
                                Ypos = 0;
                                break;
                            case 3:
                                Xpos = 0;
                                Ypos = 16;
                                break;
                            case 4:
                                Xpos = 40;
                                Ypos = 16;
                                break;
                            case 5:
                                Xpos = 80;
                                Ypos = 16;
                                break;
                        }

                        i += 4;
                        if ((i + 2) > fData.Length) return;

                        cmd = fData[i + 1];
                        dta = fData[i + 2];

                        offset = dta;
                        if (offset >= 64)
                        {
                            offset -= 64;

                            Ypos += 8;
                        }
                    }
                } else
                {
                     dta = fData[i + 2];
                    e.Graphics.FillRectangle(((dta & 0x01) > 0) ? FrontBrush : BackBrush, 4 * (Xpos + offset), 4 * (Ypos + 7), 4, 4);
                    e.Graphics.FillRectangle(((dta & 0x02) > 0) ? FrontBrush : BackBrush, 4 * (Xpos + offset), 4 * (Ypos + 6), 4, 4);
                    e.Graphics.FillRectangle(((dta & 0x04) > 0) ? FrontBrush : BackBrush, 4 * (Xpos + offset), 4 * (Ypos + 5), 4, 4);
                    e.Graphics.FillRectangle(((dta & 0x08) > 0) ? FrontBrush : BackBrush, 4 * (Xpos + offset), 4 * (Ypos + 4), 4, 4);
                    e.Graphics.FillRectangle(((dta & 0x10) > 0) ? FrontBrush : BackBrush, 4 * (Xpos + offset), 4 * (Ypos + 3), 4, 4);
                    e.Graphics.FillRectangle(((dta & 0x20) > 0) ? FrontBrush : BackBrush, 4 * (Xpos + offset), 4 * (Ypos + 2), 4, 4);
                    e.Graphics.FillRectangle(((dta & 0x40) > 0) ? FrontBrush : BackBrush, 4 * (Xpos + offset), 4 * (Ypos + 1), 4, 4);
                    e.Graphics.FillRectangle(((dta & 0x80) > 0) ? FrontBrush : BackBrush, 4 * (Xpos + offset), 4 * (Ypos + 0), 4, 4);
                    offset++;
                }

            }*/
        }

        private void button2_Click(object sender, EventArgs e)
        {
            fDataPos = -1;
            panel1.Refresh();
        }
    }
}
