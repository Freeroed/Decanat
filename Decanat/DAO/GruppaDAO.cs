using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Decanat.DAO
{
    public class GruppaDAO: AbstractDAO
    {
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
    }
}