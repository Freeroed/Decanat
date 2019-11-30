using Decanat.Models.DecanatModels;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Decanat.DAO
{
    public class GruppaDAO: AbstractDAO
    {
        //Получение названия группы по ID
        public string getGruppaName(int id) // Реализовать!!1
        {
            string s="";
            Connect();
            try
            {
                SqlCommand cmd = new SqlCommand("SELECT Name FROM Gruppa WHERE Id=@id");
                cmd.Parameters.Add(new SqlParameter("@id", id));
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    s = Convert.ToString(reader["Name"]);
                    return s;
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
            return s;

        }

        //Добавление группы
        public bool add(Gruppa gruppa)
        {
            bool result = true;
            Connect();
            try
            {
                SqlCommand cmd = new SqlCommand("INSERT INTO Gruppa(GroupName, Backlavr, KafedraId) VALUES (@GroupNmae, @Bakalavr, @KafedraId)", Connection);
                cmd.Parameters.Add(new SqlParameter("@GroupNmae", gruppa.groupName));
                cmd.Parameters.Add(new SqlParameter("@Bakalavr", gruppa.bakalavr));
                cmd.Parameters.Add(new SqlParameter("@KafedraId", gruppa.kafedra));
            }
            catch(Exception e)
            {
                result = false;
            }
            finally
            {
                Disconnect();
            }
            return result;
        }
    }
}