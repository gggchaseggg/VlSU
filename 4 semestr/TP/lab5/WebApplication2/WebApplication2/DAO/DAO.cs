using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using MySql.Data.MySqlClient;

namespace WebApplication2.DAO
{
    public class DAO
    {
        private static string ConnectionString = "server=localhost;user id=root;Password=daniil;persistsecurityinfo=True;" +
                                          "port=3306;;database=newslist;CharSet=utf8";
        public static MySqlConnection Connection { get; set; }
        public static void Connect()
        {
            Connection = new MySqlConnection(ConnectionString);
            Connection.Open();
        }
        public static void Disconnect()
        {
            Connection.Close();
        }
    }
}