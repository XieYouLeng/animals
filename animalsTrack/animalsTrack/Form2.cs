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
using System.IO;

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
        DataTable data = new DataTable();
        PCFunction pcFunction = new PCFunction();
        Bitmap bmp;
        Graphics g;
        SolidBrush brush;
        string strFilePath = @"C:\New folder\Data.csv";

        private void Form2_Load(object sender, EventArgs e)
        {
            try
            {
                DataTable_init();
                this.button1.Text = "Open COM";

                bmp = new Bitmap((int)Pic_track.Width, (int)Pic_track.Width);
                g = Graphics.FromImage(bmp);
                g.Clear(Color.White);
                
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
                this.comport.PortName = "COM8";

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

                    if (comport.IsOpen)
                        Console.WriteLine("open");

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

            while (Console_receiving)
            {
                if (comport.BytesToRead > 0)
                {
                    DateTime localDate = DateTime.Now;
                    Int32 length = comport.Read(buffer, 0, buffer.Length);

                    Console.WriteLine(buffer[length - 1]);
                    Console.WriteLine("2222");

                    if (buffer[0] == '!' && buffer[length - 1] == ']')
                    {
                        string buf = Encoding.ASCII.GetString(buffer);
                        string[] bArray = buf.Split(new char[3] { '!', ',', ']' });


                        DataRow row = data.NewRow();
                        row["ID"] = bArray[1];
                        row["Datetime"] = localDate;
                        row["X"] = bArray[3];
                        row["Y"] = bArray[4];
                        row["Z"] = bArray[5];
                        data.Rows.Add(row);

                        Console.WriteLine("1");
                        if (data.Rows.Count != 1)
                        {
                            Console.WriteLine("2");
                            pcFunction.DrawLine(data, g, bmp, brush, Pic_track);
                            Console.WriteLine("3");
                        }


                        Array.Resize(ref buffer, length);
                        Display d = new Display(ConsoleShow);
                        this.Invoke(d, new Object[] { buf });
                        Array.Resize(ref buffer, 1024);
                    }
                }
                Thread.Sleep(50);
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
                Lbl_showStartTime.Text = (string)data.Rows[0]["DateTime"];
                Lbl_showEndTime.Text = (string)data.Rows[data.Rows.Count - 1]["DateTime"];
                Lbl_showVerAct.Text = pcFunction.CountZAxis(data);
                Lbl_showClockwise.Text = pcFunction.Clockwise(data);
                Lbl_showCounterClockwise.Text = pcFunction.Counterclockwise(data);
            }
        }

        public void DataTable_init()
        {
            data.Columns.Clear();
            data.Clear();

            data.Columns.Add("ID");
            data.Columns.Add("Datetime");
            data.Columns.Add("X");
            data.Columns.Add("Y");
            data.Columns.Add("Z");
        }

        public static bool SaveCSV(DataTable dt, string fullPath)
        {
            try
            {
                FileInfo fil = new FileInfo(fullPath);
                if(!fil.Directory.Exists)
                {
                    fil.Directory.Create();
                }
                FileStream fs = new FileStream(fullPath, System.IO.FileMode.Create, System.IO.FileAccess.ReadWrite);
                StreamWriter sw = new StreamWriter(fs, System.Text.Encoding.UTF8);
                string data = "";

                for (int i = 0; i < dt.Columns.Count; i++)
                {
                    data += "\"" + dt.Columns[i].ColumnName.ToString() + "\"";
                    if(i < dt.Columns.Count - 1)
                    {
                        data += ",";
                    }
                }
                sw.WriteLine(data);
                for(int i = 0; i < dt.Rows.Count; i++)
                {
                    data = "";
                    for(int j = 0; j < dt.Columns.Count; j++)
                    {
                        string str = dt.Rows[i][j].ToString();
                        str = string.Format("\"{0}\"", str);
                        data += str;
                        if (j < dt.Columns.Count - 1)
                        {
                            data += ",";
                        }
                    }
                    sw.WriteLine(data);
                }
                sw.Close();
                fs.Close();
                return true;
            }
            catch
            {
                return false;
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

        private void Btn_saveCSV_Click(object sender, EventArgs e)
        {
            SaveCSV(data, strFilePath);
        }
    }
}
