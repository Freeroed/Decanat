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
    }
}