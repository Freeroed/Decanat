using Decanat.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Decanat.Models.DecanatModels
{
    public class Answer
    {
        private int id { get; set; }
        private string link { get; set; }
        private string mark { get; set; }
        private DateTime markDate { get; set; }
        private DateTime answerDate { get; set; }
        private int vkrId { get; set; }
        private string vkrName
        {
            get
            {
                VkrDAO vDAO = new VkrDAO();
                return vDAO.getVKRName(vkrId);
            }
        }
        private int gruppaId { get; set; }
        private string gruppaName
        {
            get
            {
                GruppaDAO gDAO = new GruppaDAO();
                return gDAO.getGruppaName(gruppaId);
            }
        }
        private int status { get; set; }
        //1 - представлен
        //2 - проверен
        //3 - Отправлен на исправление
        //4 - Оценён
        //5 - Просрочен
        public string GetStatusName()
        {
                {
                switch (this.status)
                {
                    case 1:
                        return "Представлен";
                    case 2:
                        return "Проверен";
                    case 3:
                        return "Отправлен на исправление";
                    case 4:
                        return "Оценён";
                    case 5:
                        return "Просрочен";
                    default:
                        return "error 404";
                }
            }
        }


    }
}