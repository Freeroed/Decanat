using Decanat.Models.DecanatModels;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
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
            loger.Info("Вызван метод " + new StackTrace(false).GetFrame(0).GetMethod().Name);
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
            loger.Info("Вызван метод " + new StackTrace(false).GetFrame(0).GetMethod().Name);
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
        
        public List<Teacher> getAllTeachersByKafedra(int id)
        {
            List<Teacher> teachers = new List<Teacher>();
            Connect();
            loger.Info("Вызван метод " + new StackTrace(false).GetFrame(0).GetMethod().Name);
            try
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM Prepod WHERE KafedraId = @id",Connection);
                cmd.Parameters.Add(new SqlParameter("@id", id));
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    int tId = Convert.ToInt32(reader["Id"]);
                    string surname = Convert.ToString(reader["Surname"]);
                    string firstName = Convert.ToString(reader["FirsName"]);
                    string patronymic = Convert.ToString(reader["Patronymic"]);
                    string position = Convert.ToString(reader["Position"]);
                    string email = Convert.ToString(reader["email"]);
                    int kafedraId = Convert.ToInt32(reader["kafedraId"]);
                    teachers.Add(new Teacher(tId, surname,firstName,patronymic,position,kafedraId,email));
                }
                loger.Info("Успешный запрос данных о преподавателях");
            }
            catch(Exception e)
            {
                loger.Error("Произошла ошибка при добавлнеии преподавателя");
                loger.Trace(e.StackTrace);
            }
            finally
            {
                Disconnect();
            }
            return teachers;
        }
    }

     
}