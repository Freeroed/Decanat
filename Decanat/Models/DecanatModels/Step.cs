﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Decanat.Models.DecanatModels
{
    //Есть изменения
    public class Step
    {
        public int id { get; set; }
        public string name { get; set; }
        public DateTime date { get; set; }
        public int status { get; set; } //Возмоно, можно будет удалить, но пока пусть будет
  
        public string comment { get; set; }
        public int planId { get; set; }
        

        //*******************************************************************
        //Конструкторы
        //*******************************************************************
        public Step()
        {

        }

        public Step(int id, string name, DateTime date, string comment, int planId)
        {
            this.id = id;
            this.name = name;
            this.date = date;
            this.comment = comment;
            this.planId = planId;
        }




    }
}