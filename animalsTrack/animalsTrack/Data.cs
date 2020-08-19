using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace animalsTrack
{
    class Data
    {
        //從資料庫拉資料的格式
        public class coordinates
        {
            public string DateTime { get; set; }
            public int ID { get; set; }
            public double X_axis { get; set; }
            public double Y_axis { get; set; }
            public int Z_axis { get; set; }
        }

        public class AsixInfo
        {
            public double[] x_axis { get; set; }
            public double[] y_axis { get; set; }
            public int[] z_axis { get; set; }
        }

        public class VecInfo
        {
            public int clockwise { get; set; }
            public int counterclockwise { get; set; }
        }
    }
}
