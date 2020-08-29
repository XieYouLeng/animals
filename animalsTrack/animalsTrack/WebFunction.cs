using Org.BouncyCastle.Asn1.Cms;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace animalsTrack
{
    class WebFunction
    {
        private int[] id;
        private double[] x;
        private double[] y;
        private int[] z;
        private int count;
        private float x_axis1;
        private float y_axis1;
        private float x_axis2;
        private float y_axis2;

        public Tuple<Data.AxisInfo> GetAxis(List<Data.Coordinates> data, int userSelectID)
        {
            id = new int[data.Count];
            x = new double[data.Count];
            y = new double[data.Count];
            z = new int[data.Count];
            count = 0;

            //取出ID相符的X軸、Y軸座標和Z軸的值
            for (int i = 0; i < data.Count; i++)
            {
                id[i] = data[i].ID;

                if (userSelectID == id[i])
                {
                    x[count] = data[i].X_axis;
                    y[count] = data[i].Y_axis;
                    z[count] = data[i].Z_axis;
                    count++;
                }
            }

            Data.AxisInfo asixInfo = new Data.AxisInfo
            {
                x_axis = x,
                y_axis = y,
                z_axis = z,
            };
            return new Tuple<Data.AxisInfo>(asixInfo);
        }

        //篩選後的X軸
        public double[] SelectXAxis(List<Data.Coordinates> data, int userSelectID)
        {
            var axis = GetAxis(data, userSelectID);
            var x = axis.Item1.x_axis;

            return x;
        }

        //篩選後的Y軸
        public double[] SelectYAxis(List<Data.Coordinates> data, int userSelectID)
        {
            var axis = GetAxis(data, userSelectID);
            var y = axis.Item1.y_axis;

            return y;
        }

        //計算垂直活動
        public string CountZAxis(List<Data.Coordinates> data, int userSelectID)
        {
            var axis = GetAxis(data, userSelectID);
            var z = axis.Item1.z_axis;      //抓出Z軸資料
            int count_z = 0;    //計算1的次數

            for (int i = 0; i < count; i++)
            {
                if (z[i] == 1)
                {
                    count_z++;
                }
            }
            return count_z.ToString();
        }

        //畫圖
        public void DrawLine(List<Data.Coordinates> data, int userSelectID, Graphics g, Bitmap bmp, SolidBrush b, PictureBox p)
        {
            SelectXAxis(data, userSelectID);
            SelectYAxis(data, userSelectID);

            Pen pen_b = new Pen(Color.Black, 1);
            Pen pen_r = new Pen(Color.Red, 1);
            b = new SolidBrush(pen_b.Color);

            //清除PictureBox資料
            if (p.Image != null)
                p.Image = null;
            if (bmp != null)
                bmp.Dispose();

            bmp = new Bitmap((int)p.Width, (int)p.Width);

            g = Graphics.FromImage(bmp);

            g.Clear(Color.White);

            g.DrawLine(pen_r, 2 * (float)x[0], 2 * (float)y[0], 2 * (float)x[1], 2 * (float)y[1]);

            for (int i = 1; i < count - 1; i++)
            {
                x_axis1 = (float)x[i];
                y_axis1 = (float)y[i];
                x_axis2 = (float)x[i + 1];
                y_axis2 = (float)y[i + 1];

                g.DrawLine(pen_b, 2 * x_axis1, 2 * y_axis1, 2 * x_axis2, 2 * y_axis2);
            }
            g.Dispose();
            p.Image = bmp;
        }

        //計算向量
        public Tuple<Data.VecInfo> XYVector(List<Data.Coordinates> data, int userSelectID, int show_num, int start_num)
        {
            double[] vec = new double[count];   //創建一個陣列存放向量
            int clockwise = 0;      //順時針
            int counterclockwise = 0;       //逆時針
            SelectXAxis(data, userSelectID);
            SelectYAxis(data, userSelectID);

            if (show_num == count && start_num == 0)    //只做到篩選ID，顯示全部資料，初始值為第一筆開始
            {
                for (int i = 0; i < count - 1; i++)
                {
                    var X1 = x[i + 1] - x[i];
                    var X2 = x[i + 2] - x[i];
                    var Y1 = y[i + 1] - y[i];
                    var Y2 = y[i + 2] - y[i];
                    vec[i] = X1 * Y2 - Y1 * X2;

                    if (vec[i] > 0)
                    {
                        counterclockwise++;
                    }
                    else if (vec[i] < 0)
                    {
                        clockwise++;
                    }
                }
            }
            else if (show_num != 0 && start_num == 0)     //顯示筆數不為0，起始值為初始
            {
                for (int i = 0; i < show_num - 1; i++)
                {
                    var X1 = x[i + 1] - x[i];
                    var X2 = x[i + 2] - x[i];
                    var Y1 = y[i + 1] - y[i];
                    var Y2 = y[i + 2] - y[i];
                    vec[i] = X1 * Y2 - Y1 * X2;

                    if (vec[i] > 0)
                    {
                        counterclockwise++;
                    }
                    else if (vec[i] < 0)
                    {
                        clockwise++;
                    }
                }
            }
            else if (show_num == 0)
            {
                for (int i = 0; i < count; i++)
                {
                    var X1 = x[i + 1] - x[i];
                    var X2 = x[i + 2] - x[i];
                    var Y1 = y[i + 1] - y[i];
                    var Y2 = y[i + 2] - y[i];
                    vec[i] = X1 * Y2 - Y1 * X2;

                    if (vec[i] > 0)
                    {
                        counterclockwise++;
                    }
                    else if (vec[i] < 0)
                    {
                        clockwise++;
                    }
                }
            }
            else if (show_num != 0 && start_num != 0)
            {
                for (int i = start_num - 1; i < start_num + show_num - 2; i++)
                {
                    var X1 = x[i + 1] - x[i];
                    var X2 = x[i + 2] - x[i];
                    var Y1 = y[i + 1] - y[i];
                    var Y2 = y[i + 2] - y[i];
                    vec[i] = X1 * Y2 - Y1 * X2;

                    if (vec[i] > 0)
                    {
                        counterclockwise++;
                    }
                    else if (vec[i] < 0)
                    {
                        clockwise++;
                    }
                }
            }
            else if (show_num == 0 && start_num != 0)
            {
                for (int i = start_num - 1; i < count - 1; i++)
                {
                    var X1 = x[i + 1] - x[i];
                    var X2 = x[i + 2] - x[i];
                    var Y1 = y[i + 1] - y[i];
                    var Y2 = y[i + 2] - y[i];
                    vec[i] = X1 * Y2 - Y1 * X2;

                    if (vec[i] > 0)
                    {
                        counterclockwise++;
                    }
                    else if (vec[i] < 0)
                    {
                        clockwise++;
                    }
                }
            }

            Data.VecInfo vecInfo = new Data.VecInfo
            {
                clockwise = clockwise,
                counterclockwise = counterclockwise,
            };
            return new Tuple<Data.VecInfo>(vecInfo);
        }

        //傳順時針
        public string Clockwise(List<Data.Coordinates> data, int userSelectID, int show_num, int start_num)
        {
            var vect = XYVector(data, userSelectID, show_num, start_num);
            var clockwise = vect.Item1.clockwise;

            return clockwise.ToString();
        }

        //傳逆時針
        public string Counterclockwise(List<Data.Coordinates> data, int userSelectID, int show_num, int start_num)
        {
            var vect = XYVector(data, userSelectID, show_num, start_num);
            var counterclockwise = vect.Item1.counterclockwise;

            return counterclockwise.ToString();
        }

        //傳目前總共幾筆資料
        public string Str_DataBaseNumber()
        {
            return count.ToString();
        }

        //傳目前共有幾筆資料
        public int Int_DataBaseNumber()
        {
            return count;
        }

        //改變顯示數量
        public void DL_ChangeShowNumber(List<Data.Coordinates> data, int userSelectID, Graphics g, Bitmap bmp, SolidBrush b, PictureBox p, int show_num, int start_num)
        {
            SelectXAxis(data, userSelectID);
            SelectYAxis(data, userSelectID);

            Pen pen_b = new Pen(Color.Black, 1);
            Pen pen_r = new Pen(Color.Red, 1);
            b = new SolidBrush(pen_b.Color);

            //清除PictureBox資料
            if (p.Image != null)
                p.Image = null;
            if (bmp != null)
                bmp.Dispose();

            bmp = new Bitmap((int)p.Width, (int)p.Width);

            g = Graphics.FromImage(bmp);

            g.Clear(Color.White);

            g.DrawLine(pen_r, 2 * (float)x[0], 2 * (float)y[0], 2 * (float)x[1], 2 * (float)y[1]);

            for (int i = 1; i < show_num - 1; i++)
            {
                x_axis1 = (float)x[i];
                y_axis1 = (float)y[i];
                x_axis2 = (float)x[i + 1];
                y_axis2 = (float)y[i + 1];

                g.DrawLine(pen_b, 2 * x_axis1, 2 * y_axis1, 2 * x_axis2, 2 * y_axis2);
            }
            g.Dispose();
            p.Image = bmp;
        }

        //改變起始值
        public void DL_ChangeStartNumber(List<Data.Coordinates> data, int userSelectID, Graphics g, Bitmap bmp, SolidBrush b, PictureBox p, int show_num, int start_num)
        {
            SelectXAxis(data, userSelectID);
            SelectYAxis(data, userSelectID);

            Pen pen_b = new Pen(Color.Black, 1);
            Pen pen_r = new Pen(Color.Red, 1);
            b = new SolidBrush(pen_b.Color);

            //清除PictureBox資料
            if (p.Image != null)
                p.Image = null;
            if (bmp != null)
                bmp.Dispose();

            bmp = new Bitmap((int)p.Width, (int)p.Width);

            g = Graphics.FromImage(bmp);

            g.Clear(Color.White);

            if (start_num != 0)
            {
                g.DrawLine(pen_r, 2 * (float)x[start_num - 1], 2 * (float)y[start_num - 1], 2 * (float)x[start_num], 2 * (float)y[start_num]);
                for (int i = start_num; i < start_num + show_num - 2; i++)
                {
                    x_axis1 = (float)x[i];
                    y_axis1 = (float)y[i];
                    x_axis2 = (float)x[i + 1];
                    y_axis2 = (float)y[i + 1];

                    g.DrawLine(pen_b, 2 * x_axis1, 2 * y_axis1, 2 * x_axis2, 2 * y_axis2);
                }
            }
            else if (show_num == 0 && start_num != 0)
            {
                g.DrawLine(pen_r, 2 * (float)x[start_num - 1], 2 * (float)y[start_num - 1], 2 * (float)x[start_num], 2 * (float)y[start_num]);
                for (int i = start_num; i < count - start_num + 1; i++)
                {
                    x_axis1 = (float)x[i];
                    y_axis1 = (float)y[i];
                    x_axis2 = (float)x[i + 1];
                    y_axis2 = (float)y[i + 1];

                    g.DrawLine(pen_b, 2 * x_axis1, 2 * y_axis1, 2 * x_axis2, 2 * y_axis2);
                }
            }
            else
            {
                DrawLine(data, userSelectID, g, bmp, b, p);
            }
        }
    }
}
