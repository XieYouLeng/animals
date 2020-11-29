using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace animalsTrack
{
    class PCFunction
    {
        private static int num = 0;

        //畫圖
        public void DrawLine(DataTable data, Graphics g, Bitmap bmp, SolidBrush b, PictureBox p)
        {

            Pen pen_b = new Pen(Color.Black, 1);
            Pen pen_r = new Pen(Color.Red, 1);

            //bmp = new Bitmap((int)p.Width, (int)p.Width);

            //g = Graphics.FromImage(bmp);

            //g.Clear(Color.White);
            //for (int i = num; i >= 0; i--)
            //{
            //    if (i == 0)
            //    {
            //        g.DrawLine(pen_r, 4 * Convert.ToInt32(data.Rows[i]["X"]), 4 * Convert.ToInt32(data.Rows[i]["Y"]), 4 * Convert.ToInt32(data.Rows[i + 1]["X"]), 4 * Convert.ToInt32(data.Rows[i + 1]["Y"]));
            //    }
            //    else
            //        g.DrawLine(pen_b, 4 * Convert.ToInt32(data.Rows[i]["X"]), 4 * Convert.ToInt32(data.Rows[i]["Y"]), 4 * Convert.ToInt32(data.Rows[i + 1]["X"]), 4 * Convert.ToInt32(data.Rows[i + 1]["Y"]));
            //}

            if(num == 0)
            {
                g.DrawLine(pen_r, 4 * Convert.ToInt32(data.Rows[num]["X"]), 4 * Convert.ToInt32(data.Rows[num]["Y"]), 4 * Convert.ToInt32(data.Rows[num + 1]["X"]), 4 * Convert.ToInt32(data.Rows[num + 1]["Y"]));
            }
            else
            {
                g.DrawLine(pen_b, 4 * Convert.ToInt32(data.Rows[num]["X"]), 4 * Convert.ToInt32(data.Rows[num]["Y"]), 4 * Convert.ToInt32(data.Rows[num + 1]["X"]), 4 * Convert.ToInt32(data.Rows[num + 1]["Y"]));
            }

            num++;
            //g.Dispose();    //釋放資源
            p.Image = bmp;
        }

        //計算垂直
        public string CountZAxis(DataTable data)
        {
            var z_count = 0;

            for(int i = 0; i < num + 1; i++)
            {
                if(Convert.ToInt32(data.Rows[i]["Z"]) == 1)
                {
                    z_count++;
                }
            }
            return z_count.ToString();
        }

        //計算向量
        public Tuple<Data.VecInfo> XYVector(DataTable data)
        {
            double[] vec = new double[num];   //創建一個陣列存放向量
            
            int clockwise = 0;      //順時針
            int counterclockwise = 0;       //逆時針

            for (int i = 0; i < num - 1; i++)
            {
                var X1 = Convert.ToInt32(data.Rows[i + 1]["X"]) - Convert.ToInt32(data.Rows[i]["X"]);
                var X2 = Convert.ToInt32(data.Rows[i + 2]["X"]) - Convert.ToInt32(data.Rows[i + 1]["X"]);
                var Y1 = Convert.ToInt32(data.Rows[i + 1]["Y"]) - Convert.ToInt32(data.Rows[i]["Y"]);
                var Y2 = Convert.ToInt32(data.Rows[i + 2]["Y"]) - Convert.ToInt32(data.Rows[i + 1]["Y"]);
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
            Data.VecInfo vecInfo = new Data.VecInfo
            {
                clockwise = clockwise,
                counterclockwise = counterclockwise,
            };
            return new Tuple<Data.VecInfo>(vecInfo);
        }

        //傳順時針
        public string Clockwise(DataTable data)
        {
            var vect = XYVector(data);
            var clockwise = vect.Item1.clockwise;

            return clockwise.ToString();
        }

        //傳逆時針
        public string Counterclockwise(DataTable data)
        {
            var vect = XYVector(data);
            var counterclockwise = vect.Item1.counterclockwise;

            return counterclockwise.ToString();
        }

    }
}
