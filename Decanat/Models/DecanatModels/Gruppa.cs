using Decanat.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Decanat.Models.DecanatModels
{
    public class Gruppa
    {
        public int id { get; set; }
        public string groupName { get; set; }
        public bool bakalavr { get; set; }
        public int kafedra { get; set; }
        public bool study { get; set; }
        public bool isHasPlan { get; set; }
        public string getLivel
        {
            get
            {
                if (bakalavr)
                { return "Бакалавриат"; }
                else
                { return "Магистратура"; }
            }
        }

        public string isStudy
        {
            get
            {
                if (study)
                {
                    return "Обучается";
                }
                else
                {
                    return "Обучение завершено";
                }
            }
        }

        public string getIsHasPlan
        {
            get
            {
                if (isHasPlan)
                {
                    return "Есть План-График";
                }
                else
                {
                    return "План-график не добавлен";
                }
            }
        }

        public string getKafedraName
        {
            get
            {
                KafedraDAO kDAO = new KafedraDAO();
                return kDAO.getKafedraName(kafedra);
            }
        }

        

        //***********************************************************************************
        //Конструкторы
        //***********************************************************************************
        public Gruppa()
        {

        }

        public Gruppa(string gruppaName, bool bakalavr, int kafedra)
        {
            this.groupName = gruppaName;
            this.bakalavr = bakalavr;
            this.kafedra = kafedra;
        }

        public Gruppa (int id, string gruppaName, bool bakalavr, int kafedra, bool study, bool isHasPlan)
        {
            this.id = id;
            this.groupName = gruppaName;
            this.bakalavr = bakalavr;
            this.kafedra = kafedra;
            this.study = study;
            this.isHasPlan = isHasPlan;
        }
    }
}