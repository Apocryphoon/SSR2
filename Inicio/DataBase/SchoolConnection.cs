
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inicio.DataBase
{
    public class Connection
    {
        public MySqlConnection Create()
        {
            string connectionString = "server=sql130.main-hosting.eu;SslMode=none;database=u877132465_micro;uid=u877132465_micro;pwd=91893409";

            MySqlConnection connection = new MySqlConnection(connectionString);
            connection.Open();
            return connection;
        }

    }
}
