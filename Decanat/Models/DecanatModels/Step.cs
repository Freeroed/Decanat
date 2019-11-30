using System;
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
        public int status { get; set; }
        public string comment { get; set; }
        public int planId { get; set; }


    }
}