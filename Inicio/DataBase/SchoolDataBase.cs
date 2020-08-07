using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inicio.DataBase
{
    public class Database
    {
        public void ExecuteInsert(string script, List<MySqlParameter> param)
        {
            Connection s = new Connection();
            MySqlConnection c = s.Create();

            MySqlCommand c1 = c.CreateCommand();
            c1.CommandText = script;

            if (param != null)
            {
                foreach (MySqlParameter p in param)
                {
                    c1.Parameters.Add(p);
                }
            }

            c1.ExecuteNonQuery();
            c.Close();
        }


        public MySqlDataReader ExecuteSelect(string script, List<MySqlParameter> parameters)
        {
            Connection s = new Connection();
            MySqlConnection c = s.Create();

            MySqlCommand c1 = c.CreateCommand();
            c1.CommandText = script;

            if (parameters != null)
            {
                foreach (MySqlParameter p in parameters)
                {
                    c1.Parameters.Add(p);
                }
            }

            MySqlDataReader r = c1.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
            return r;

        }
    }
}
