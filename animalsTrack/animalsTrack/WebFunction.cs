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
        private float x_axis1;
        private float y_axis1;
        private float x_axis2;
        private float y_axis2;
        public string DrawLine(List<Data.coordinates> data, int userSelectID, float wid, float hei, Graphics g, Bitmap bmp, SolidBrush b, PictureBox p)
        {
            id = new int[data.Count];
            x = new double[data.Count];
            y = new double[data.Count];
            z = new int[data.Count];

            int count = 0;
            int count_z = 0;
            //取出ID相符的X軸、Y軸座標
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

            //計算垂直活動次數
            for (int i = 0; i < count; i++)
            {
                if (z[i] == 1)
                {
                    count_z++;
                }
            }
            
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

            return count_z.ToString();
        }
    }
}
