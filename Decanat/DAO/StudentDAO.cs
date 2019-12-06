using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Linq;
using Decanat.Models.DecanatModels;
using System.Diagnostics;

namespace Decanat.DAO
{
    public class StudentDAO : AbstractDAO
    {
        
        //Получение информации о студенте
        public Student getStudentInfo(int id)
        {
            Student st = new Student();
            Connect();
            try
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM Student WHERE Id =@id", Connection);
                cmd.Parameters.Add(new SqlParameter("@id", id));
                SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                int tId = Convert.ToInt32(reader["Id"]);
                string tSurname = Convert.ToString(reader["Surname"]);
                string tFirstName = Convert.ToString(reader["FirstName"]);
                string tPanronymic = Convert.ToString(reader["Patronymic"]);
                string tMobileNomber = Convert.ToString(reader["MobileNumber"]);
                string tEmail = Convert.ToString(reader["Email"]);
                int tGruppaId = Convert.ToInt32(reader["GruppaId"]);
                st.id = tId; st.surname = tSurname; st.firstName = tFirstName; st.patronymic = tPanronymic;
                st.mobileNomber = tMobileNomber; st.email = tEmail; st.gruppaId = tGruppaId;
            }
            }

            catch (Exception e)
            {
                loger.Error("Произошла ошибка при запросе информации о студенте");
                loger.Trace(e.StackTrace);
            }
            finally
            {
                Disconnect();
            }
            return st;

        }

        //Получить ID студента по email
        public int getStudentId(string email)
        {
            int id = 0;
            loger.Info("Вызван метод " + new StackTrace(false).GetFrame(0).GetMethod().Name);
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
                loger.Error("Произошла ошибка при поиске студента");
                loger.Trace(e.StackTrace);
            }
            finally
            {
                Disconnect(); 
            }
            return id;
        }
        //Добавление студента
        public bool add(Student student)
        {
            bool result = true;
            Connect();
            loger.Info("Вызван метод " + new StackTrace(false).GetFrame(0).GetMethod().Name);
            try
            {
                SqlCommand cmd = new SqlCommand("INSERT INTO Student (Surname, FirstName, Patronymic, MobileNumber, Email, GruppaId) VALUES " +
                    "(@Surname, @FirstName, @Patronymic, @MobileNumber, @Email, @GruppaId)", Connection);
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
                loger.Error("Произошла ошибка при добавлении студента");
                loger.Trace(e.StackTrace);
            }
            finally
            {
                Disconnect();
            }
            return result;
        }

        //Вывод всех студентов в группе
        public List<Student> getAllStudentInProup(int groupId)
        {
            List<Student> students = new List<Student>();
            loger.Info("Вызван метод " + new StackTrace(false).GetFrame(0).GetMethod().Name);
            Connect();
            try
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM Student WHERE GruppaId = @GruppaId", Connection);
                cmd.Parameters.Add(new SqlParameter("@GruppaId", groupId));
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    int id = Convert.ToInt32(reader["Id"]);
                    string surname = Convert.ToString(reader["Surname"]);
                    string firstName = Convert.ToString(reader["FirstName"]);
                    string patronymic = Convert.ToString(reader["Patronymic"]);
                    string mobileNumber = Convert.ToString(reader["MobileNumber"]);
                    string email = Convert.ToString(reader["Email"]);
                    students.Add(new Student(id, surname, firstName, patronymic, mobileNumber, email));
                }
                loger.Info("Успешный заспрос информации о всех студентах в группе");
            }
            catch(Exception e)
            {
                loger.Error("Произошла ошибка при Запросе информации о всех студентах в группе");
                loger.Trace(e.StackTrace);
            }
            finally
            {
                Disconnect();
            }
            return students;
        }

    }
       
    
}