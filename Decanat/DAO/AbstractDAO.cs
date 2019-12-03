using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using NLog;

namespace Decanat.DAO
{
    public class AbstractDAO
    {
        //private const string connectionString = "Data Source=DESKTOP-4NGH6J2; Initial Catalog=model;Integrated Security=True"; // Для компа
        private const string connectionString = "Data Source=DESKTOP-FQ15R95\\SQLEXPRESS;Initial Catalog=master;Integrated Security=True"; // Для ноута

        public static Logger loger = LogManager.GetCurrentClassLogger();

        protected SqlConnection Connection { get; set; }

        public void Connect()
        {
            Connection = new SqlConnection(connectionString);
            Connection.Open();
        }

        public void Disconnect()
        {
            Connection.Close();
        }
    }
}