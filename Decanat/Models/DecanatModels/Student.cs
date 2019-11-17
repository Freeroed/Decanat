using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Decanat.Models.DecanatModels
{
    public class Student
    {
        private int id { get; set; }
        private string surname { get; set; }
        private string firstName { get; set; }
        private string patrinymic { get; set; }
        private string mobileNomber { get; set; }
        private string email { get; set; }
        private int gruppaId { get; set; }

        public Student()
        {

        }

        public Student(int id, string surname, string firstName, string patronymic, string mobileNomber, string email, int gruppaid) 
        {
            this.id = id;
            this.surname = surname;
            this.firstName = firstName;
            this.patrinymic = patrinymic;
            this.mobileNomber = mobileNomber;
            this.email = email;
            this.gruppaId = gruppaid;
        }


        public override string ToString()
        {
            String s = surname + " " + firstName + " " + patrinymic + " " + mobileNomber + " " + email;
            return s;
        }
    }
}