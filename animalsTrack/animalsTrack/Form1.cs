using System;
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
using System.Windows.Forms.DataVisualization.Charting;

namespace animalsTrack
{
    public partial class Form1 : Form
    {
        DataBase dataBase = new DataBase();
        WebFunction webFunction = new WebFunction();
        Form2 form2 = new Form2();
        private int[] id;   //放經過時間過濾後的ID
        private int ID = 0;
        private int show_num = 0;
        private int start_num = 0;
        private List<Data.Coordinates> result = new List<Data.Coordinates>();
        Bitmap bmp;
        Graphics g;
        SolidBrush brush;

        public Form1()
        {
            InitializeComponent();
            //處理DateTimePicker會有預設值的問題
            String dateTime = Dtp_dateTime.Value.ToString("yyyy-MM-dd");
            result = dataBase.GetSelectData(dateTime);

            Console.WriteLine(Pic_track.Width + ", " + Pic_track.Height);
        }

        //選擇日期抓出資料庫的東西
        private void Dtp_dateTime_ValueChanged(object sender, EventArgs e)
        {
            String dateTime = Dtp_dateTime.Value.ToString("yyyy-MM-dd");
            result = dataBase.GetSelectData(dateTime);

            id = new int[result.Count];     //創一個跟資料庫裡的資料一樣大小的陣列
            //抓出有資料的ID
            for (int i = 0; i < result.Count; i++)
            {
                id[i] = result[i].ID;
                //防止下拉式選單出現重複ID
                if (Cbo_selectID.Items.Contains(id[i]) != true)
                {
                    Cbo_selectID.Items.Add(id[i]);
                }
            }
        }

        //選擇ID抓出相符的資料
        private void Cbo_selectID_SelectedIndexChanged(object sender, EventArgs e)
        {
            string userSelectID = this.Cbo_selectID.Text;       //抓使用者選了哪個ID
            int.TryParse(userSelectID, out ID);     //轉型態

            webFunction.DrawLine(result, ID, g, bmp, brush, Pic_track);        //畫圖
            show_num = webFunction.Int_DataBaseNumber();        //初始數值跟資料庫的資料一樣
            Lbl_showStartNumber.Text = "從第1筆開始";        //顯示從第1筆開始
            Lbl_showNumber.Text = "共" + webFunction.Str_DataBaseNumber() + "筆";     //顯示目前共有幾筆資料
            Lbl_verticalActivity.Text = webFunction.CountZAxis(result, ID) + "次";    //計算垂直動作
            Lbl_clockwise.Text = webFunction.Clockwise(result, ID, show_num, start_num) + "次";      //順時針
            Lbl_counterclockwise.Text = webFunction.Counterclockwise(result, ID, show_num, start_num) + "次";      //逆時針
            show_num = 0;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        //取出selectNumber的數值，改變顯示數量
        private void Tb_selectNumber_TextChanged(object sender, EventArgs e)
        {
            int.TryParse(Tb_selectNumber.Text, out show_num);       //取出使用者輸入的顯示筆數量
            if (show_num != 0 && show_num <= webFunction.Int_DataBaseNumber())      //顯示筆數有值且小於資料庫筆數
            {
                webFunction.DL_ChangeShowNumber(result, ID, g, bmp, brush, Pic_track, show_num, start_num);        //畫出有限制筆數的圖
                Lbl_showNumber.Text = "共" + Tb_selectNumber.Text + "筆";         //顯示筆數
                Lbl_clockwise.Text = webFunction.Clockwise(result, ID, show_num, start_num) + "次";         //顯示輸入限制筆數後順時針次數
                Lbl_counterclockwise.Text = webFunction.Counterclockwise(result, ID, show_num, start_num) + "次";        //顯示輸入限制筆數後逆時針次數
            }
            else if (show_num > webFunction.Int_DataBaseNumber())       //當限制筆數大於總筆數
            {
                MessageBox.Show("您輸入的筆數大於資料庫內的筆數，總筆數為" + webFunction.Int_DataBaseNumber() + "筆，請重新輸入！");
            }
            else       //處理當顯示筆數為0的情況
            {
                webFunction.DrawLine(result, ID, g, bmp, brush, Pic_track);
                Lbl_showNumber.Text = "共" + webFunction.Int_DataBaseNumber() + "筆";
                Lbl_clockwise.Text = webFunction.Clockwise(result, ID, show_num, start_num) + "次";
                Lbl_counterclockwise.Text = webFunction.Counterclockwise(result, ID, show_num, start_num) + "次";
            }

        }

        //取出startNumber的數值，改變起始值
        private void Tb_startNumber_TextChanged(object sender, EventArgs e)
        {
            int.TryParse(Tb_startNumber.Text, out start_num);
            int db_count = webFunction.Int_DataBaseNumber();
            int count = db_count - start_num + 1;
            int a = start_num - 1 + show_num;
            if (show_num != 0 && start_num != 0)
            {
                if (start_num > webFunction.Int_DataBaseNumber())
                {
                    MessageBox.Show("您輸入的筆數大於資料庫內的筆數，總筆數為" + webFunction.Int_DataBaseNumber() + "筆，請重新輸入！");
                }
                else
                { 
                    webFunction.DL_ChangeStartNumber(result, ID, g, bmp, brush, Pic_track, show_num, start_num);        //畫出有限制起始值的圖
                    if (a <= webFunction.Int_DataBaseNumber())
                    {
                        Lbl_showNumber.Text = "共" + show_num + "筆";
                    }
                    else
                    {
                        Lbl_showNumber.Text = "共" + count + "筆";
                    }
                    Lbl_showStartNumber.Text = "從第" + Tb_startNumber.Text + "筆開始";      //顯示從第幾筆開始
                    Lbl_clockwise.Text = webFunction.Clockwise(result, ID, show_num, start_num) + "次";      //有限制起始點的順時針
                    Lbl_counterclockwise.Text = webFunction.Counterclockwise(result, ID, show_num, start_num) + "次";        //有限制起始點的逆時針
                }
            }
            else if (show_num == 0 && start_num != 0)       //只限制起始點
            {
                if (start_num > webFunction.Int_DataBaseNumber())
                {
                    MessageBox.Show("您輸入的筆數大於資料庫內的筆數，總筆數為" + webFunction.Int_DataBaseNumber() + "筆，請重新輸入！");
                }
                else
                {
                    webFunction.DL_ChangeStartNumber(result, ID, g, bmp, brush, Pic_track, show_num, start_num);        //畫出有限制起始值的圖
                    Lbl_showNumber.Text = "共" + count + "筆";
                    Lbl_showStartNumber.Text = "從第" + Tb_startNumber.Text + "筆開始";      //顯示從第幾筆開始
                    Lbl_clockwise.Text = webFunction.Clockwise(result, ID, show_num, start_num) + "次";      //有限制起始點的順時針
                    Lbl_counterclockwise.Text = webFunction.Counterclockwise(result, ID, show_num, start_num) + "次";        //有限制起始點的逆時針
                }

            }
            else       //無限制起始值
            {
                Tb_selectNumber_TextChanged(sender, e);
                Lbl_showStartNumber.Text = "從第1筆開始";
            }
        }

        //切換PC端
        private void Btn_changePC_Click(object sender, EventArgs e)
        {
            this.Hide();
            if (form2.ShowDialog() == DialogResult.OK)
            {
                this.Show();
            }
        }
    }
}
