using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Ports;
using System.Threading;

namespace animalsTrack
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        private SerialPort comport = new SerialPort();
        //private int totalLength = 0;
        //delegate void Display(byte[] buffer);
        bool rs232Key;
        private bool Console_receiving = false;
        private Thread t;
        delegate void Display(string buffer);

        private void Form2_Load(object sender, EventArgs e)
        {
            try
            {
                this.button1.Text = "Open COM";

                this.button1.Click += new EventHandler(Rs232PortDoor);

                rs232Key = true;

                //comport = new SerialPort("COM5", 115200, Parity.None, 8, StopBits.One);
                //comport.ReadTimeout = 100;

                //comport.Open();
                //if (!comport.IsOpen)
                //{
                //    MessageBox.Show("埠開啟失敗");
                //    return;
                //}
                //else
                //{
                //    textBox1.AppendText("埠開啟成功\r\n");
                //}
                //comport.DataReceived += new SerialDataReceivedEventHandler(comport_DataReceived);
            }
            catch (Exception ex)
            {
                comport.Dispose();
                textBox4.AppendText(ex.Message);
            }
        }

        private void Rs232PortDoor(object sender, EventArgs e)
        {
            if (rs232Key)
            {
                this.button1.Text = "Close Port";

                // 設定使用的 PORT
                this.comport.PortName = "COM5";

                // 檢查 PORT 是否關閉
                if (!comport.IsOpen)
                    this.comport.Close();

                // 初始化 PORT
                this.comport.BaudRate = 115200;            // baud rate = 9600
                this.comport.Parity = Parity.None;       // Parity = none
                this.comport.StopBits = StopBits.One;    // stop bits = one
                this.comport.DataBits = 8;               // data bits = 8

                // 設定 PORT 接收事件
                //comport.DataReceived += new SerialDataReceivedEventHandler(SerialPort_DataReceived);

                // 打開 PORT
                //comport.Open();

                if (!comport.IsOpen)
                {
                    //開啟 Serial Port
                    comport.Open();

                    Console_receiving = true;

                    //開啟執行續做接收動作
                    t = new Thread(DoReceive);
                    t.IsBackground = true;
                    t.Start();
                }

                // 清空 serial port 的緩存
                comport.DiscardInBuffer();       // RX
                comport.DiscardOutBuffer();      // TX

                rs232Key = false;
            }
            else
            {
                this.button1.Text = "Open Port";

                // 清空 serial port 的緩存
                comport.DiscardInBuffer();       // RX
                comport.DiscardOutBuffer();      // TX

                // 關閉 PORT
                this.comport.Close();

                rs232Key = true;
            }
        }

        private void DoReceive()
        {
            Byte[] buffer = new Byte[1024];

            try
            {
                while (Console_receiving)
                {
                    if (comport.BytesToRead > 0)
                    {
                        Int32 length = comport.Read(buffer, 0, buffer.Length);

                        string buf = Encoding.ASCII.GetString(buffer);

                        Array.Resize(ref buffer, length);
                        Display d = new Display(ConsoleShow);
                        this.Invoke(d, new Object[] { buf });
                        Array.Resize(ref buffer, 1024);
                    }

                    Thread.Sleep(200);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        delegate void SetTextCallback(string buffer);
        public void ConsoleShow(string buffer)
        {
            if (this.textBox4.InvokeRequired)
            {
                SetTextCallback d = new SetTextCallback(ConsoleShow);
                this.Invoke(d, new object[] { buffer });
            }
            else
            {
                this.textBox4.Text = buffer;
            }
        }

        //void SerialPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
        //{
        //    byte RB = Byte.Parse(comport.ReadByte().ToString());
        //    //SetText(RB.ToString());
        //    SetText(textBox4.Text + RB.ToString() + " ");
        //}

        //delegate void SetTextCallback(string text);
        //private void SetText(string text)
        //{
        //    if (this.textBox4.InvokeRequired)
        //    {
        //        SetTextCallback d = new SetTextCallback(SetText);
        //        this.Invoke(d, new object[] { text });
        //    }
        //    else
        //    {
        //        this.textBox4.Text = text;
        //    }
        //}

        //private void comport_DataReceived(Object sender, SerialDataReceivedEventArgs e)
        //{
        //    Byte[] buffer = new Byte[1024];
        //    Int32 length = (sender as SerialPort).Read(buffer, 0, buffer.Length);
        //    Array.Resize(ref buffer, length);
        //    Display d = new Display(DisplayText);
        //    this.Invoke(d, new Object[] { buffer });
        //}

        //private void DisplayText(Byte[] buffer)
        //{
        //    textBox1.Text += String.Format("{0}{1}", BitConverter.ToString(buffer), Environment.NewLine);
        //    totalLength = totalLength + buffer.Length;
        //    label1.Text = totalLength.ToString();
        //}

        private void button2_Click(object sender, EventArgs e)
        {
            textBox4.Clear();
        }

        //切換遠端
        private void Btn_changeFar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }
    }
}
