using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Decanat.Models.DecanatModels
{
    public class Student
    {
        private int id { get; set; }
        private String surname { get; set; }
        private String firstName { get; set; }
        private String patrinymic { get; set; }
        private String mobileNomber { get; set; }
        private String email { get; set; }
        private int gruppaId { get; set; }

        public Student()
        {

        }

        public Student(int id, String surname, String firstName, String patronymic) 
        {
            this.id = id;
            this.surname = surname;
            this.firstName = firstName;
            this.patrinymic = patrinymic;
        }


        public override string ToString()
        {
            String s = surname + " " + firstName + " " + patrinymic + " " + mobileNomber + " " + email;
            return s;
        }
    }
}