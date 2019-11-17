using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Linq;
using Decanat.Models.DecanatModels;

namespace Decanat.DAO
{
    public class StudentDAO : AbstractDAO
    {
        
        public string getStudentInfo(int id)
        {
             string s = "";
            Connect();
            try
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM Student WHERE Id =@id", Connection);
                cmd.Parameters.Add(new SqlParameter("@id", id));
                SqlDataReader reader = cmd.ExecuteReader();
                int tId = Convert.ToInt32(reader["Id"]);
                string tSurname = Convert.ToString(reader["Surname"]);
                string tFirstName = Convert.ToString(reader["FirstName"]);
                string tPanronymic = Convert.ToString(reader["Patronymic"]);
                string tMobileNomber = Convert.ToString(reader["MobileNomber"]);
                string tEmail = Convert.ToString(reader["Email"]);
                int tGruppaId = Convert.ToInt32(reader["GruppaId"]);
                Student st = new Student(tId,tSurname,tFirstName,tPanronymic,tMobileNomber,tEmail,tGruppaId);
                
            }

            catch (Exception)
            {
                //Обработка ошибки
            }
            finally
            {
                Disconnect();
            }
            return s;

        }

        public Boolean testmethod()
        {
            
            try
            {
                Connect();
                SqlCommand cmd = new SqlCommand("SELECT * FROM Student WHERE Id=@id", Connection);
                cmd.Parameters.Add(new SqlParameter("@id", 1));
                SqlDataReader reader = cmd.ExecuteReader();
                Student st;
                while (reader.Read())
                {
                    //int id = Convert.ToInt32(reader["Id"]);
                    int tId = Convert.ToInt32(reader["Id"]);
                    string tSurname = Convert.ToString(reader["Surname"]);
                    string tFirstName = Convert.ToString(reader["FirstName"]);
                    string tPanronymic = Convert.ToString(reader["Patronymic"]);
                    string tMobileNomber = Convert.ToString(reader["MobileNomber"]);
                    string tEmail = Convert.ToString(reader["Email"]);
                    int tGruppaId = Convert.ToInt32(reader["GruppaId"]);
                    st = new Student(tId, tSurname, tFirstName, tPanronymic, tMobileNomber, tEmail, tGruppaId);
                }

                // int tId = Convert.ToInt32(reader["Id"]);
                // string tSurname = Convert.ToString(reader["Surname"]);
                // string tFirstName = Convert.ToString(reader["FirstName"]);
                //string tPanronymic = Convert.ToString(reader["Patronymic"]);
                //string tMobileNomber = Convert.ToString(reader["MobileNomber"]);
                //string tEmail = Convert.ToString(reader["Email"]);
                // int tGruppaId = Convert.ToInt32(reader["GruppaId"]);
                // st = new Student(tId, tSurname, tFirstName, tPanronymic, tMobileNomber, tEmail, tGruppaId);
                return true;
                //return true;
            }
            catch (Exception)
            {
                return false;
            }
            finally
            {
                Disconnect();
            }
        }
    }
       
    
}