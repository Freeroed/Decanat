using Decanat.Models.DecanatModels;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Web;

namespace Decanat.DAO
{
    public class GruppaDAO: AbstractDAO
    {
        //Получение названия группы по ID
        public string getGruppaName(int id) // Реализовать!!1
        {
            string s="";
            Connect();
            loger.Info("Вызван метод " + new StackTrace(false).GetFrame(0).GetMethod().Name);
            try
            {
                SqlCommand cmd = new SqlCommand("SELECT GroupName FROM Gruppa WHERE Id=@id", Connection);
                cmd.Parameters.Add(new SqlParameter("@id", id));
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    s = Convert.ToString(reader["GroupName"]);
                    loger.Info("Успешное получение информации о группе");
                    return s;
                }
            }
            catch(Exception e)
            {
                loger.Error("Произошла ошибка при получении информации о группе");
                loger.Trace(e.StackTrace);
            }
            finally
            {
                Disconnect();
            }
            return s;

        }

        //Добавление группы
        public bool add(Gruppa gruppa)
        {
            bool result = true;
            Connect();
            loger.Info("Вызван метод " + new StackTrace(false).GetFrame(0).GetMethod().Name);
            try
            {
                SqlCommand cmd = new SqlCommand("INSERT INTO Gruppa(GroupName, Backlavr, KafedraId) VALUES (@GroupNmae, @Bakalavr, @KafedraId)", Connection);
                cmd.Parameters.Add(new SqlParameter("@GroupNmae", gruppa.groupName));
                cmd.Parameters.Add(new SqlParameter("@Bakalavr", gruppa.bakalavr));
                cmd.Parameters.Add(new SqlParameter("@KafedraId", gruppa.kafedra));
                cmd.ExecuteNonQuery();
            }
            catch(Exception e)
            {
                result = false;
                loger.Error("Произошла ошибка при добавлении группы");
                loger.Trace(e.StackTrace);
            }
            finally
            {
                Disconnect();
            }
            return result;
        }

        //Добавление ПГ для группы
        public bool sepPlanStatus(bool isHasPlan, int id)
        {
            bool result = true;
            Connect();
            loger.Info("Вызван метод " + new StackTrace(false).GetFrame(0).GetMethod().Name);
            try
            {
                SqlCommand cmd = new SqlCommand("UPDATE Gruppa SET IsHasPlan = @isHasPlan WHERE Id = @id",Connection);
                cmd.Parameters.Add(new SqlParameter("@isHasPlan",isHasPlan));
                cmd.Parameters.Add(new SqlParameter("@id", id));
                cmd.ExecuteNonQuery();
                loger.Info("Успешное изменение статуса наличия ПГ у группы");
            }
            catch(Exception e)
            {
                result = false;
                loger.Error("Произошла ошибка при изменении статуса наличия ПГ у группы");
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