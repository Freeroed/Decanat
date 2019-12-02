﻿using Decanat.Models.DecanatModels;
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

        public List<Gruppa> getAllGroups()
        {
            List<Gruppa> groups = new List<Gruppa>();
            loger.Info("Вызван метод " + new StackTrace(false).GetFrame(0).GetMethod().Name);
            Connect();
            try
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM Gruppa WHERE Study = 1",Connection);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    int id = Convert.ToInt32(reader["Id"]);
                    String gruppaName = Convert.ToString(reader["GruppaName"]);
                    bool bakalavr = Convert.ToBoolean(reader["Bakalavr"]);
                    int kafedra = Convert.ToInt32(reader["KafedraId"]);
                    bool study = Convert.ToBoolean(reader["Study"]);
                    bool isHasPlan = Convert.ToBoolean(reader["IsHasPlan"]);
                    groups.Add(new Gruppa(id,gruppaName,bakalavr,kafedra,study,isHasPlan));
                }
                loger.Info("Успешное получение информации о группах");
            }
            catch(Exception e)
            {
                loger.Error("Произошла ошибка при запросе информации о группах");
                loger.Trace(e.StackTrace);
            }
            finally
            {
                Disconnect();
            }
            return groups;
        }
    }
}