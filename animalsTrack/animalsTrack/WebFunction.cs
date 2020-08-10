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
        //篩選完日期的資料放來這篩選ID
        public void SelectId(List<Form1> forms)
        {

        }

        public void DrawLinePoint(PaintEventArgs e)
        {
            Pen blackPen = new Pen(Color.Black, 3);

            PointF point1 = new PointF(100.0F, 100.0F);
            PointF point2 = new PointF(500.0F, 100.0F);

            e.Graphics.DrawLine(blackPen, point1, point2);
        }
    }
}
