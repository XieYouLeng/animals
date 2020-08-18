using Org.BouncyCastle.Asn1.Cms;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
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

        public Tuple<Data.AsixInfo> GetAxis(List<Data.coordinates> data, int userSelectID)
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

            Data.AsixInfo asixInfo = new Data.AsixInfo
            {
                x_axis = x,
                y_axis = y,
                z_axis = z
            };
            return new Tuple<Data.AsixInfo>(asixInfo);
        }

        //篩選後的X軸
        public double[] SelectXAxis(List<Data.coordinates> data, int userSelectID)
        {
            var axis = GetAxis(data, userSelectID);
            var x = axis.Item1.x_axis;

            return x;
        }

        //篩選後的Y軸
        public double[] SelectYAxis(List<Data.coordinates> data, int userSelectID)
        {
            var axis = GetAxis(data, userSelectID);
            var y = axis.Item1.y_axis;

            return y;
        }

        //計算垂直活動
        public string CountZAxis(List<Data.coordinates> data, int userSelectID)
        {
            var axis = GetAxis(data, userSelectID);
            var z = axis.Item1.z_axis;
            int count_z = 0;

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
        public void DrawLine(List<Data.coordinates> data, int userSelectID, float wid, float hei, Graphics g, Bitmap bmp, SolidBrush b, PictureBox p)
        {
            SelectXAxis(data, userSelectID);
            SelectYAxis(data, userSelectID);


            Pen pen_b = new Pen(Color.Black, 1);
            Pen pen_r = new Pen(Color.Blue, 1);
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

            for (int j = 1; j < count - 1; j++)
            {
                x_axis1 = (float)x[j];
                y_axis1 = (float)y[j];
                x_axis2 = (float)x[j + 1];
                y_axis2 = (float)y[j + 1];

                g.DrawLine(pen_b, 2 * x_axis1, 2 * y_axis1, 2 * x_axis2, 2 * y_axis2);
            }
            g.Dispose();
            p.Image = bmp;
        }
    }
}
