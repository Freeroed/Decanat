using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using Decanat.Models.DecanatModels;

namespace Decanat.DAO
{
    public class AnswerDAO: AbstractDAO
    {
        public List<Answer> getLastAnswers()
        {
            List<Answer> lastAnswers = new List<Answer>();
            Connect();
            try
            {
                //SqlCommand cmd = new SqlCommand("SELECT * FROM Answer Where Status = 1");//("SELECT VKR.Name FROM Answer INNER JOIN VKR ON Answer.vkrId=VKR.Id//")
                SqlCommand cmd = new SqlCommand("SELECT VKR.Name FROM Answer INNER JOIN VKR ON Answer.vkrId=VKR.Id WHERE Answer.Status=1");
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    string str = Convert.ToString(reader["Name"]);
                }
            }
            catch (Exception e)
            {
                //Обработка ошибки
            }
            finally
            {
                Disconnect();
            }
            return lastAnswers;

        }
    }
}