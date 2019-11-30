using Decanat.Models.DecanatModels;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Decanat.DAO
{
    public class VkrDAO: AbstractDAO
    {
        public string getVKRName(int id) //Реализовать!!
        {
            string s = "";
            Connect();
            try
            {
                SqlCommand cmd = new SqlCommand("Select Theme from VKR where id = @id", Connection);
                cmd.Parameters.Add(new SqlParameter("@id", id));
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    s = Convert.ToString(reader["Theme"]);
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
        //Запрос всех ВКР
        public List<VKR> getAllVKR()
        {
            Connect();
            List<VKR> works = new List<VKR>();
            SqlCommand cmd = new SqlCommand("SELECT * FROM VKR",Connection);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                string theme = Convert.ToString(reader["Theme"]);
                works.Add(new VKR(theme));
            }
            Disconnect();
            return works;
        }

        //Поиск ВКР по ID
        public VKR getVKRbyId(int id)
        {
            VKR vkr = new VKR();
            Connect();
            try
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM VKR WHERE Id = @id", Connection);
                cmd.Parameters.Add(new SqlParameter("@id", id));
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    vkr.id = Convert.ToInt32(reader["Id"]);
                    vkr.theme = Convert.ToString(reader["Theme"]);
                    vkr.studentId = Convert.ToInt32(reader["StudentId"]);
                    vkr.teacherId = Convert.ToInt32(reader["PrepodId"]);

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
            return vkr;
        }

        public VKR getVKRbyStudent(int studentid)
        {
            VKR vkr = new VKR();
            Connect();
            SqlCommand cmd = new SqlCommand("SELECT * FROM VKR WHERE StudentId=@stId",Connection);
            cmd.Parameters.Add(new SqlParameter("@stId", studentid));
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                vkr.id = Convert.ToInt32(reader["Id"]);
                vkr.theme = Convert.ToString(reader["Theme"]);
                vkr.studentId = Convert.ToInt32(reader["StudentId"]);
                vkr.teacherId = Convert.ToInt32(reader["PrepodId"]);
            }
            return vkr;
        }
        
    }
}