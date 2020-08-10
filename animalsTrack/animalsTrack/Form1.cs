﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace animalsTrack
{
    public partial class Form1 : Form
    {
        DataBase dataBase = new DataBase();
        WebFunction webFunction = new WebFunction();
        private int[] id;
        private List<Data.coordinates> result = new List<Data.coordinates>();

        public Form1()
        {
            InitializeComponent();

            //處理DateTimePicker會有預設值的問題
            String dateTime = Dtp_dateTime.Value.ToString("yyyy-MM-dd");
            label1.Text = dateTime;
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
            result = dataBase.GetSelectData(dateTime);
            //Cbo_selectID.Items.Add(id); //新增選項
            id = new int[result.Count];
            for (int i = 0; i < result.Count; i++)
            {
                id[i] = result[i].ID;
                if (Cbo_selectID.Items.Contains(id[i]) == true)
                {

                }
                else
                {
                    Cbo_selectID.Items.Add(id[i]); //傳入ComboBox
                }
            }
        }

        //選擇ID抓出相符的資料
        private void Cbo_selectID_SelectedIndexChanged(object sender, EventArgs e)
        {
            string id = this.Cbo_selectID.Text;
            int ID = 0;
            int.TryParse(id, out ID);
            for (int i = 0; i < result.Count; i++)
            {
                if (result[i].ID == ID)
                {
                    
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            List<Data.coordinates> result = new List<Data.coordinates>();
            
            //result.Add(new Data.coordinates() { ID = @ID });
        }

        private void Btn_cancel_Click(object sender, EventArgs e)
        {

        }
    }
}
