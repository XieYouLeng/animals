using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace animalsTrack
{
    public partial class Form1 : Form
    {
        DataBase dataBase = new DataBase();
        WebFunction webFunction = new WebFunction();

        public Form1()
        {
            InitializeComponent();

            //處理DateTimePicker會有預設值的問題
            String dateTime = Dtp_dateTime.Value.ToString("yyyy-MM-dd");
            List<Data.coordinates> result = dataBase.GetSelectData(dateTime);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dataBase.selectData();
        }

        //選擇日期抓出資料庫的東西
        private void Dtp_dateTime_ValueChanged(object sender, EventArgs e)
        { 
            String dateTime = Dtp_dateTime.Value.ToString("yyyy-MM-dd");
            label1.Text = dateTime;
            List<Data.coordinates> result = dataBase.GetSelectData(dateTime);
        }

        private void Btn_cancel_Click(object sender, EventArgs e)
        {
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Cbo_selectID.Items.Add("1"); //新增選項
        }
    }
}
