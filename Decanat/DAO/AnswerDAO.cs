using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using Decanat.Models.DecanatModels;

namespace Decanat.DAO
{
    public class AnswerDAO : AbstractDAO
    {
        //Просмотр последних ответов для преподавателя
        public List<Answer> getLastAnswers(int id)
        {
            List<Answer> lastAnswers = new List<Answer>();
            Connect();
            try
           {
               SqlCommand cmd = new SqlCommand("SELECT * FROM Answer, VKR WHERE (Answer.VKRId=VKR.Id AND VKR.PrepodId=@id AND Answer.Status=1)", Connection);
                cmd.Parameters.Add(new SqlParameter("@id", id));
                SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                int tempId = Convert.ToInt32(reader["Id"]);
                string tempLink = Convert.ToString(reader["Link"]);
                int tepVkrId = Convert.ToInt32(reader["VKRId"]);
                DateTime tempAnswerDate = Convert.ToDateTime(reader["AnswerDate"]);
                    lastAnswers.Add(new Answer(tempId,tempLink,tepVkrId,tempAnswerDate));
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

        //Поставить оценку
        public bool setMark(int id, int mark)
        {
            bool result = true;
            Connect();
            try
            {
                SqlCommand cmd = new SqlCommand("UPDATE Answer SET Mark = @mark, AnswerDate = @aDate, Status = 2 WHERE Id=@id",Connection);
                cmd.Parameters.Add(new SqlParameter("@id", id));
                cmd.Parameters.Add(new SqlParameter("@mark", mark));
                cmd.Parameters.Add(new SqlParameter("@aDate", DateTime.Now));
                cmd.ExecuteNonQuery();
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
        
        //Просмотреть ответ
        public Answer getInfo(int id)
        {
            Answer ans = new Answer();
            Connect();
            try
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM Answer WHERE Id=@id", Connection);
                cmd.Parameters.Add(new SqlParameter("@id", id));
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    ans.id = Convert.ToInt32(reader["id"]);
                    ans.link = Convert.ToString(reader["Link"]);
                    ans.answerDate = Convert.ToDateTime(reader["AnswerDate"]);
                    ans.vkrId = Convert.ToInt32(reader["VKRId"]);
                    ans.stepid = Convert.ToInt32(reader["StepId"]);
                    ans.status = Convert.ToInt32(reader["Status"]);
                    if (ans.status == 2)
                    {
                        ans.mark = Convert.ToInt32(reader["Mark"]);
                        ans.markDate = Convert.ToDateTime(reader["markDate"]);
                        return ans;
                    }
                    else return ans;
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
            return ans;
        }

        //Смена статуса
        public bool setStatus(int id, int status)
        {
            bool resuln = true;
            Connect();
            try
            {
                SqlCommand cmd = new SqlCommand("UPDATE Answer SET Status=@status WHERE Id = @id");
                cmd.Parameters.Add(new SqlParameter("@id", id));
                cmd.Parameters.Add(new SqlParameter("@sattus", status));
                cmd.ExecuteNonQuery();
            }
            catch(Exception e)
            {
                resuln = false;
            }
            finally
            {
                Disconnect();
            }
            return resuln;
        }

        public bool add(Answer ans)
        {
            bool result = true;
            Connect();
            try
            {
                SqlCommand cmd = new SqlCommand("INSERT INTO Answer(VKRId, StepId) VALUES (@VKRId, @StepId)", Connection );
                cmd.Parameters.Add(new SqlParameter("@VKRId", ans.vkrId));
                cmd.Parameters.Add(new SqlParameter("@StepId", ans.stepid));
                cmd.ExecuteNonQuery();
                

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