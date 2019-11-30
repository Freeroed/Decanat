using Decanat.Models.DecanatModels;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Decanat.DAO
{
    public class TeacherDAO: AbstractDAO
    {
        //Получить ID учителя по email
        public int getTeacherId(string email)
        {
            Connect();
            try
            {
                SqlCommand cmd = new SqlCommand("SELECT Id FROM Prepod where email = @email", Connection);
                cmd.Parameters.Add(new SqlParameter("@email", email));
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    return Convert.ToInt32(reader["Id"]);

                }
            }
            catch (Exception e)
            {
                loger.Error("Произошла ошибка поиске преподавателя");
                loger.Trace(e.StackTrace);
            }
            finally
            {
                Disconnect();
            }
            return 0;
        }

        //Добавление учителя
        public bool add(Teacher teacher)
        {
            bool result = true;
            Connect();
            try
            {
                SqlCommand cmd = new SqlCommand("INSERT INTO Prepod (Surname, FirstName, Patronymic, Position, KafedraId, Email) VALUES (@Surname, @FirstName, @Patronymic, @Position, @KafedraId, @Email)",Connection);
                cmd.Parameters.Add(new SqlParameter("@Surname", teacher.surname));
                cmd.Parameters.Add(new SqlParameter("@FirstName", teacher.firstName));
                cmd.Parameters.Add(new SqlParameter("@Patronymic", teacher.patronymic));
                cmd.Parameters.Add(new SqlParameter("@Position",teacher.position));
                cmd.Parameters.Add(new SqlParameter("@KafedraId", teacher.kafedraId));
                cmd.Parameters.Add(new SqlParameter("@Email", teacher.email));
                cmd.ExecuteNonQuery();
            }
            catch(Exception e)
            {
                result = false;
                loger.Error("Произошла ошибка при добавлнеии преподавателя");
                loger.Trace(e.StackTrace);
            }
            finally
            {
                Disconnect();
            }
            return result;
        }
    }
}