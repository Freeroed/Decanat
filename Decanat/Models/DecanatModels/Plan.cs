using Decanat.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Decanat.Models.DecanatModels
{
    public class Plan
        
    {//Есть изменения
        public int id { get; set; }
        public int gpoupId { get; set; }
        public int status { get; set; }

        public string getStatus()
        {
            switch (this.status)
            {
                case 1:
                    return "Создан";
                case 2:
                    return "Одобрен";
                case 3:
                    return "На исправлении";
                case 4:
                    return "Отменён";
                case 5: 
                    return "На ваполнении";
                case 6:
                    return "Выполнен";
                default:
                    return "Ошибка";

            }
          
        }

        public string getGroupName
        {
            get
            {
                GruppaDAO gDAO = new GruppaDAO();
                return gDAO.getGruppaName(this.gpoupId);
            }
        }


        //************************************************************
        //Конструкторы
        //************************************************************

        public Plan()
        {

        }

        public Plan(int groupId, int status)
        {
            this.gpoupId = groupId;
            this.status = status;
        }

        public Plan(int id, int groupId, int status)
        {
            this.id = id;
            this.gpoupId = groupId;
            this.status = status; 
        }

        public Plan(int groupId)
        {
            this.gpoupId = groupId;
        }

    }
}