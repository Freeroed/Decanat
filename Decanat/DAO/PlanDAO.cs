using Decanat.Models.DecanatModels;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Decanat.DAO
{//Дообален класс
    public class PlanDAO: AbstractDAO
    {
        //Добавление нового плана-графика
        public bool add(Plan plan)
        {
            bool result = true;
            Connect();
            try
            {
                SqlCommand cmd = new SqlCommand("INSERT INTO Plan (GruppaId) VALUES (@GruppaId)", Connection);
                cmd.Parameters.Add(new SqlParameter("@GruppaId",plan.gpoupId));
                cmd.ExecuteNonQuery();
            }
            catch(Exception e)
            {
                result = false;
                loger.Error("Произошла ошибка при добавлении плана-графика");
                loger.Trace(e.StackTrace);
            }
            finally
            {
                Disconnect();
            }
            return result;
        }
        public List<Plan> showPlansByStatus(int status)
        {
            Connect();
            List<Plan> plans = new List<Plan>();
            try
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM Plan WHERE Status=@Status");
                cmd.Parameters.Add(new SqlParameter("@Status", status));
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    int gruoupId = Convert.ToInt32(reader["GruppaId"]);
                    plans.Add(new Plan(gruoupId));
                }
            }
            catch(Exception e)
            {
                loger.Error("Произошла ошибка при запросе планов-графиков");
                loger.Trace(e.StackTrace);
            }
            finally
            {
                Disconnect();
            }
            return plans;
        }
    }
}