using Dapper;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace animalsTrack
{
    class DataBase
    {
        String db_connect { get { return "server=140.130.35.236;uid=usblab;pwd=usblab603;database=animals_tracks;"; } } //server、帳號、密碼、資料庫
        public void getAllData()
        {
            using (MySqlConnection conn = new MySqlConnection(db_connect))
            {
                conn.Open();
                string sql_command = "SELECT * FROM `coordinates`";  //指令
                var result = conn.Query(sql_command).ToList();  //拿到資料
                conn.Close();
            }
        }

        public void selectData()
        {
            string id = "1";
            using (MySqlConnection conn = new MySqlConnection(db_connect))
            {
                conn.Open();
                string sql_command = "SELECT * FROM `coordinates` WHERE `ID` = @id";
                var result = conn.Query(sql_command, new { id = id }).ToList();
                conn.Close();
            }
        }

        public void insertData()
        {
            string id = "4";
            string dateTime = "2020-7-30 16:56:20";
            string x_axis = "20.33";
            string y_axis = "30.28";
            string z_axis = "0";


            using (MySqlConnection conn = new MySqlConnection(db_connect))
            {
                conn.Open();
                string sql_command = "INSERT INTO coordinates (ID, DateTime, X_axis, Y_axis, Z_axis) " +
                    "VALUES(@id, @dateTime, @x_axis, @y_axis, @z_axis);";
                dynamic datas = new
                {
                    id = id,
                    dateTime = dateTime,
                    x_axis = x_axis,
                    y_axis = y_axis,
                    z_axis = z_axis
                };
                object data = datas;
                conn.Execute(sql_command, data);
                conn.Close();
            }
        }

        public void updateData()
        {
            string id = "4";
            string x_axis = "20.44";
            string y_axis = "35.58";

            using (MySqlConnection conn = new MySqlConnection(db_connect))
            {
                conn.Open();
                string sql_command = "UPDATE coordinates SET X_axis = @x_axis, Y_axis = @y_axis WHERE id=@id;";
                dynamic datas = new
                {
                    id = id,
                    x_axis = x_axis,
                    y_axis = y_axis,
                };
                object data = datas;
                conn.Execute(sql_command, data);
                conn.Close();
            }
        }

        public void deleteData()
        {
            string id = "4";
            string dateTime = "2020-7-30 16:56:20";

            using (MySqlConnection conn = new MySqlConnection(db_connect))
            {
                conn.Open();
                string sql_command = "DELETE FROM coordinates WHERE id=@id && dateTime=@dateTime;";
                dynamic datas = new
                {
                    id = id,
                    dateTime = dateTime,
                };
                object data = datas;
                conn.Execute(sql_command, data);
                conn.Close();
            }
        }
    };
}
