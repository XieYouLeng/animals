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
        private int[] id;
        private int no_num = 0;
        private List<Data.Coordinates> result = new List<Data.Coordinates>();
        Bitmap bmp;
        Graphics g;
        SolidBrush brush;
        Point? prevPosition = null;
        ToolTip tooltip = new ToolTip();

        public Form1()
        {
            InitializeComponent();
            this.tooltip.AutomaticDelay = 10;
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
            //Cbo_selectID.Items.Add(id); //新增選項
            id = new int[result.Count];
            for (int i = 0; i < result.Count; i++)
            {
                id[i] = result[i].ID;
                //防止重複ID
                if (Cbo_selectID.Items.Contains(id[i]) != true)
                {
                    Cbo_selectID.Items.Add(id[i]);
                }
            }
        }
 
        //選擇ID抓出相符的資料
        private void Cbo_selectID_SelectedIndexChanged(object sender, EventArgs e)
        {
            string userSelectID = this.Cbo_selectID.Text;
            int ID = 0;
            int.TryParse(userSelectID, out ID);

            
            webFunction.DrawLine(result, ID, g, bmp, brush, Pic_track);
            Lbl_showNumber.Text = "共" + webFunction.Str_DataBaseNumber() + "筆";
            Lbl_verticalActivity.Text = webFunction.CountZAxis(result, ID) + "次";
            Lbl_clockwise.Text = webFunction.Clockwise(result, ID) + "次";
            Lbl_counterclockwise.Text = webFunction.Counterclockwise(result, ID) + "次";
        }

        //void chart1_MouseMove(object sender, MouseEventArgs e)
        //{
        //    var pos = e.Location;
        //    if (prevPosition.HasValue && pos == prevPosition.Value)
        //        return;
        //    tooltip.RemoveAll();
        //    prevPosition = pos;
        //    var results = Pic_track.HitTest(pos.X, pos.Y, false,
        //                                    ChartElementType.DataPoint);
        //    foreach (var result in results)
        //    {
        //        if (result.ChartElementType == ChartElementType.DataPoint)
        //        {
        //            var prop = result.Object as DataPoint;
        //            if (prop != null)
        //            {
        //                var pointXPixel = result.ChartArea.AxisX.ValueToPixelPosition(prop.XValue);
        //                var pointYPixel = result.ChartArea.AxisY.ValueToPixelPosition(prop.YValues[0]);

        //                //check if the cursor is really close to the point(2 pixels around)
        //                if (Math.Abs(pos.X - pointXPixel) < 2 &&
        //                    Math.Abs(pos.Y - pointYPixel) < 2)
        //                {
        //                    tooltip.Show("X=" + prop.XValue + ", Y=" + prop.YValues[0], this.Pic_track,
        //                                    pos.X, pos.Y - 15);
        //                }
        //            }
        //        }
        //    }
        //}
        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        //取出TextBox的數值
        private void Tb_selectNumber_TextChanged(object sender, EventArgs e)
        {
            Lbl_showNumber.Text = "共" + Tb_selectNumber.Text + "筆";
        }
    }
}
