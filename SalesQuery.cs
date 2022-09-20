using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;
using System.Configuration;

namespace kluke_mgtsys.cs
{ 
    public class SalesQuery
    {
        //查询区域销售的邮箱
        public static string[] SupervisorSalesQuery(string cityinput) {
            string[] salesmailbox=new string[3];
            //根据城市查询区域销售的邮箱地址
            string sql = "select * from region where 地级市='" + cityinput +"'";
            //连接数据库
            MySqlConnection conn = SalesCreateConn();
            MySqlCommand comm = new MySqlCommand(sql, conn);
            conn.Open();
            MySqlDataReader reader = comm.ExecuteReader();
            while (reader.Read())
            {
                salesmailbox[0] = reader.GetString("负责人");
                salesmailbox[1] = reader.GetString("邮箱");
                salesmailbox[2] = reader.GetString("电话");
            }
            conn.Close();
            return salesmailbox;
        }

        //通用链接
        protected static MySqlConnection SalesCreateConn()
        {
            string _conn = ConfigurationManager.ConnectionStrings["DataConnectionString"].ConnectionString;
            MySqlConnection conn = new MySqlConnection(_conn);
            return conn;
        }
    }
}