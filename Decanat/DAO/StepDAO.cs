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
                cmd.Parameters.Add(new SqlParameter("@id", id));
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    s = Convert.ToString(reader["Name"]);
                    return s;
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

        public bool Add(Step step)
        {
            bool result = true;
            Connect();
            try
            {
                SqlCommand cmd = new SqlCommand("INSERT INTO Step(Name, Date, PlanId) VALUES (@Name, @Date, @PlanId)");
                cmd.Parameters.Add(new SqlParameter("@Name", step.name));
                cmd.Parameters.Add(new SqlParameter("@Date", step.date));
                cmd.Parameters.Add(new SqlParameter("@PlanId", step.planId));
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