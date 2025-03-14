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
using System.Xml.Linq;
using System.Threading;
using System.IO.Ports;

namespace HX_20_LCD_Interface
{
    public partial class Form1 : Form
    {
        public int Xpos=0, Ypos =0, offset = 0;

        static SerialPort _serialPort;
        public Graphics gContext;

        public Stream inData = new MemoryStream();
        public byte[] inBuffer = new byte[64 * 1024];
        public int inBufferStart = 0;

        public Brush BackBrush = new SolidBrush(Color.LightGray);
        public Brush FrontBrush = new SolidBrush(Color.Black);
        public Brush CommandBrush = new SolidBrush(Color.Red);
        public Brush Set64Brush = new SolidBrush(Color.Blue);
        public Form1()
        {
            InitializeComponent();

            _serialPort = new SerialPort();
            _serialPort.DataReceived += onDataReceived;
            _serialPort.ErrorReceived += onErrorReceived;

            pictureBox1.Image = new Bitmap(pictureBox1.ClientRectangle.Width, pictureBox1.ClientRectangle.Height, System.Drawing.Imaging.PixelFormat.Format24bppRgb);
            gContext = Graphics.FromImage(pictureBox1.Image);
        }

        #region UI
        private void button1_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() != DialogResult.OK) return;
            var fData = File.ReadAllBytes(openFileDialog1.FileName);

            // check sequence of ==0x55 &0x80>0 0xdd ==0xAA
            inData.Position = 0;
            inData.SetLength(0);

            for (var i = 0; i < fData.Length - 3; ++i)
            {
                if (checkPattern(fData[i + 0], fData[i + 1], fData[i + 2], fData[i + 3]))
                {
                    inData.WriteByte(fData[i + 0]);
                    inData.WriteByte(fData[i + 1]);
                    inData.WriteByte(fData[i + 2]);
                    inData.WriteByte(fData[i + 3]);
                    i += 3;
                }
                else
                {

                }
            }

            textBox_start.Text = "0";
            textBox_stop.Text = (inData.Length / 4).ToString("D");
            panel1_reset();
        }

        private void checkBox_dataOnly_CheckedChanged(object sender, EventArgs e)
        {
            panel1_reset();
        }

        private void checkBox_maskB7_CheckedChanged(object sender, EventArgs e)
        {
            panel1_reset();
        }

        private void checkBox_stream_CheckedChanged(object sender, EventArgs e)
        {
            panel1_reset();
        }

        private void textBox_start_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return) panel1_reset();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            panel1_reset();
        }

        private void panel1_reset()
        {
            offset = 0;
            Xpos = 0;
            Ypos = 0;
            panel1_Paint();
        }
        private void button_close_Click(object sender, EventArgs e)
        {
            if (!_serialPort.IsOpen) return;
            _serialPort.DiscardOutBuffer();
            _serialPort.DiscardInBuffer();
            Invoke(new void_voidDelegate(_serialPort.Close), null);
            log("Closed.");
        }

        delegate void void_stringDelegate(string text);
        delegate void void_voidDelegate();

        private void Form1_Resize(object sender, EventArgs e)
        {
            pictureBox1.Refresh();
        }

        private void pictureBox1_SizeChanged(object sender, EventArgs e)
        {
            pictureBox1.Image = new Bitmap(pictureBox1.ClientRectangle.Width, pictureBox1.ClientRectangle.Height, System.Drawing.Imaging.PixelFormat.Format24bppRgb);
            gContext = Graphics.FromImage(pictureBox1.Image);
        }

        #endregion


        #region COM
        private void log(string t)
        {
            if (textBox1.InvokeRequired)
            {
                textBox1.Invoke((void_stringDelegate)log, new object[] { "\r\n" + t });
            } else
            {
                textBox1.Text += "\r\n" + t;
                textBox1.SelectionStart = textBox1.TextLength;
            }
        }

        private void onErrorReceived(object sender, SerialErrorReceivedEventArgs e)
        {
            log("Error: " + e.EventType.ToString());
        }
        private void button_list_Click(object sender, EventArgs e)
        {
            comboBox_portName.Items.Clear();
            foreach (string s in SerialPort.GetPortNames())
            {
                comboBox_portName.Items.Add(s);
                if (comboBox_portName.Items.Contains(comboBox_portName.Text)) comboBox_portName.SelectedItem = comboBox_portName.Text;
            }

            if (comboBox_portName.Items.Count == 0) comboBox_portName.Text = "";
            if (comboBox_portName.Items.Count == 1) comboBox_portName.SelectedIndex = 0;
        }
        private void button_open_Click(object sender, EventArgs e)
        {
            if (_serialPort.IsOpen) button_close_Click(sender, e);

            try
            {
                _serialPort.PortName = comboBox_portName.Text;
                _serialPort.BaudRate = 1000000;
                _serialPort.DataBits = 8;
                _serialPort.Handshake = Handshake.None;
                _serialPort.Parity = Parity.None;
                _serialPort.StopBits = StopBits.One;
                _serialPort.ReadTimeout = 500;
                _serialPort.WriteTimeout = 500;
            }
            catch (Exception ex)
            {
                log("Error setting up serial port: " + ex.Message);
                return;
            }

            try
            {
                _serialPort.Open();
                var cnt = 25;
                while (!_serialPort.IsOpen && (cnt-- > 0)) Thread.Sleep(200);
                if (cnt > 0)
                {
                    log("Session Started: " + DateTime.Now.ToString("yyyy-MM-dd"));
                    log(_serialPort.PortName + "@" + _serialPort.BaudRate);
                }
                else
                {
                    log("Failed to open port");
                    button_close_Click(sender, e);
                }
            }
            catch (Exception ex)
            {
                log("Error opening serial port: " + ex.Message);
            }
        }

        private void onDataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            var toRead = _serialPort.BytesToRead;
            toRead -= (toRead % 4);
            if (toRead > inBuffer.Length) toRead = inBuffer.Length;

            var didRead = _serialPort.Read(inBuffer, inBufferStart, toRead);

            // var chunks = didRead % 4;
            var sp = inData.Position;
            inData.Write(inBuffer, 0, didRead);
            inData.Position = sp;
            Invoke(new void_voidDelegate(panel1_Paint), null);
        }

        #endregion

        #region Parser
        private bool checkPattern(byte a, byte b, byte c, byte d)
        {
            if (a != 0x55) return false;
            if ((b & 0x80) == 0) return false;
            if (d != 0xAA) return false;
            return true;
        }

        private void button_clear_Click(object sender, EventArgs e)
        {
            gContext.FillRectangle(BackBrush, pictureBox1.ClientRectangle);
            inData.Position = 0;
            inData.SetLength(0);
            panel1_reset();
        }

        private int clamp (int val, int min, int max)
        {
            if (val < min) return min;
            if (val > max) return max;
            return val;
        }

        private void panel1_Paint()
        {
            if (inData.Length == 0) return;

           // Xpos = 0;
           // Ypos = 0;
            //offset = 0;
            int start, stop;

            if (_serialPort.IsOpen)
            {
                start = (int)inData.Position;
                stop = (int)inData.Length;
                textBox_stop.Text = stop.ToString("D");
            }
            else
            {
                start = int.Parse(textBox_start.Text) * 4;
                stop = int.Parse(textBox_stop.Text) * 4;
                stop = clamp(stop, 0, (int)inData.Length);
                textBox_stop.Text = (stop/4).ToString("D");
                start = clamp(start, 0, stop);
                textBox_start.Text = (start/4).ToString("D");

                inData.Position = start;
            }

            int[] nCS = new int[6];

            for (var i = start; i < stop; i += 4)
            {
                var junk = inData.ReadByte();
                var mode = (byte)inData.ReadByte();
                var isCommand = (mode & 0x40) > 0;
                var dta = (byte)inData.ReadByte();
                var cs = mode & 0x0F;
                junk = inData.ReadByte();
                nCS[cs]++;

                if (!isCommand && checkBox_maskB7.Checked) dta = (byte)(dta & 0x7F);

                if (isCommand && (dta == 0x64) && !checkBox_stream.Checked && ((i+4) < stop-1))
                {
                    i += 4;
                    junk = inData.ReadByte();
                    var Nmode = (byte)inData.ReadByte();
                    var NisCommand = (Nmode & 0x40) > 0;
                    var Ndta = (byte)inData.ReadByte();
                    var Ncs = Nmode & 0x0F;
                    junk = inData.ReadByte();

                    nCS[Ncs]++;

                    switch (Ncs)
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

                    offset = Ndta & 0x7F;
                    if (offset >= 64)
                    {
                        offset -= 64;
                        Ypos += 8;
                    }

                }

                if (!checkBox_dataOnly.Checked || (checkBox_dataOnly.Checked && !isCommand))
                {
                    Brush cb = FrontBrush;
                    if (isCommand) cb = (dta == 0x64) ? Set64Brush : CommandBrush;
                    gContext.FillRectangle(((dta & 0x01) > 0) ? cb : BackBrush, 4 * (Xpos + offset), 4 * (Ypos + 0), 4, 4);
                    gContext.FillRectangle(((dta & 0x02) > 0) ? cb : BackBrush, 4 * (Xpos + offset), 4 * (Ypos + 1), 4, 4);
                    gContext.FillRectangle(((dta & 0x04) > 0) ? cb : BackBrush, 4 * (Xpos + offset), 4 * (Ypos + 2), 4, 4);
                    gContext.FillRectangle(((dta & 0x08) > 0) ? cb : BackBrush, 4 * (Xpos + offset), 4 * (Ypos + 3), 4, 4);
                    gContext.FillRectangle(((dta & 0x10) > 0) ? cb : BackBrush, 4 * (Xpos + offset), 4 * (Ypos + 4), 4, 4);
                    gContext.FillRectangle(((dta & 0x20) > 0) ? cb : BackBrush, 4 * (Xpos + offset), 4 * (Ypos + 5), 4, 4);
                    gContext.FillRectangle(((dta & 0x40) > 0) ? cb : BackBrush, 4 * (Xpos + offset), 4 * (Ypos + 6), 4, 4);
                    gContext.FillRectangle(((dta & 0x80) > 0) ? cb : BackBrush, 4 * (Xpos + offset), 4 * (Ypos + 7), 4, 4);
                    
                    offset++;

                    if ((offset >= 120) && checkBox_stream.Checked)
                    {
                        offset = 0;
                        Ypos += 8;

                        if (Ypos > (pictureBox1.Size.Height-32) / 4)
                        {
                            Ypos = 0;
                            Xpos += 121;
                        }
                    }
                    if (checkBox_slower.Checked && !isCommand)
                    {
                        Thread.Sleep(5);
                        if ((i % 80) == 0) Application.DoEvents();
                    }
                }
            }

            pictureBox1.Refresh();
            label_stats.Text = $"nCS: {nCS[0]}, {nCS[1]}, {nCS[2]}, {nCS[3]}, {nCS[4]}, {nCS[5]}";
            return;

        }

        #endregion


    }
}
