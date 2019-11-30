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
        //Получить ID студента по email
        public int getStudentId(string email)
        {
            int id = 0;
            try
            {
                Connect();
                SqlCommand cmd = new SqlCommand("SELECT Id FROM Student WHERE email = @email", Connection);
                cmd.Parameters.Add(new SqlParameter("@email", email));
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    id = Convert.ToInt32(reader["Id"]);
                    return id;
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
            return id;
        }

        public bool add(Student student)
        {
            bool result = true;
            Connect();
            try
            {
                SqlCommand cmd = new SqlCommand("INSERT INTO Student (Surname, FirstName, Patronymic, MobileNumber, Email, GruppaId) VALUES (@Surname, @FirstName, @Patronymic, @MobileNumber, @Email, @GruppaId)", Connection);
                cmd.Parameters.Add(new SqlParameter("@Surname", student.surname));
                cmd.Parameters.Add(new SqlParameter("@FirstName", student.firstName));
                cmd.Parameters.Add(new SqlParameter("@Patronymic", student.patronymic));
                cmd.Parameters.Add(new SqlParameter("@MobileNumber", student.mobileNomber));
                cmd.Parameters.Add(new SqlParameter("@Email", student.email));
                cmd.Parameters.Add(new SqlParameter("@GruppaId", student.gruppaId));
                cmd.ExecuteNonQuery();
            }
            catch (Exception e)
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