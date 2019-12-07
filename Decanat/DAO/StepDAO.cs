using Decanat.Models.DecanatModels;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Decanat.DAO
{
    public class StepDAO: AbstractDAO
    {
        public string getStepName(int id)
        {
            string s = "";
            Connect();
            try
            {
                SqlCommand cmd = new SqlCommand("SELECT Name FROM Step WHERE Id=@Id",Connection);
                cmd.Parameters.Add(new SqlParameter("@Id", id));
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    s = Convert.ToString(reader["Name"]);
                    return s;
                }
            }
            catch(Exception e)
            {
                loger.Error("Произошла ошибка при запросе названия этапа");
                loger.Trace(e.StackTrace);
            }
            finally
            {
                Disconnect();
            }
            return s;
        }

        public bool Add(Step step)
        {
            bool result = true;
            Connect();
            try
            {
                SqlCommand cmd = new SqlCommand("INSERT INTO Step(Name, Date, PlanId) VALUES (@Name, @Date, @PlanId)", Connection);
                cmd.Parameters.Add(new SqlParameter("@Name", step.name));
                cmd.Parameters.Add(new SqlParameter("@Date", step.date));
                cmd.Parameters.Add(new SqlParameter("@PlanId", step.planId));
                cmd.ExecuteNonQuery();
            }
            catch(Exception e)
            {
                result = false;
                loger.Error("Произошла ошибка при добавлении этапа");
                loger.Trace(e.StackTrace);
            }
            finally
            {
                Disconnect();
            }
            return result;
        }

        public List<Step> getStepsByPlanId(int id)
        {
            List<Step> steps = new List<Step>();
            Connect();
            try
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM Step WHERE PlanId=@id", Connection);
                cmd.Parameters.Add(new SqlParameter("@id", id));
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    int stepid = Convert.ToInt32(reader["Id"]);
                    string stepName = Convert.ToString(reader["Name"]);
                    DateTime stepDate = Convert.ToDateTime(reader["Date"]);
                    string stepComment = Convert.ToString(reader["Comment"]);
                    int planId = Convert.ToInt32(reader["PlanId"]);
                    steps.Add(new Step(stepid, stepName, stepDate, stepComment, planId));

                }
            }
            catch (Exception e)
            {
                loger.Error("Произошла ошибка при запросе всех этапов плана");
                loger.Trace(e.StackTrace);
            }
            finally
            {
                Disconnect();
            }
            return steps;
        }
    }
}