using Decanat.Models.DecanatModels;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Decanat.DAO
{
    public class KafedraDAO: AbstractDAO
    {
        //Получение названия кафедры
        public string getKafedraName(int id)
        {
            Connect();
            try
            {
                SqlCommand cmd = new SqlCommand("SELECT Name FROM Kafedra WHERE id=@id");
                cmd.Parameters.Add(new SqlParameter("@id", id));
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    string name = Convert.ToString(reader["Name"]);
                    return name;
                }
            }
            catch(Exception e)
            {
                //
            }
            finally
            {
                Disconnect();
            }
            return "";
        }

        //Получение инфармации о кафедре
        public Kafedra getKafedraInfo(int id)
        {
            Kafedra kaf = new Kafedra();
            Connect();
            try
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM Kafedra WHERE id=@id");
                cmd.Parameters.Add(new SqlParameter("@id", id));
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    kaf.id = Convert.ToInt32(reader["Id"]);
                    kaf.name = Convert.ToString(reader["Name"]);
                    kaf.email = Convert.ToString(reader["Email"]);
                }
            }
            catch(Exception e)
            {
                ///
            }
            finally
            {
                Disconnect();
            }
            return kaf;
        }
    }
}