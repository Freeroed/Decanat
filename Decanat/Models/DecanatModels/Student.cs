using Decanat.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Decanat.Models.DecanatModels
{
    public class Student
    {
        public int id { get; set; }
        public string surname { get; set; }
        public string firstName { get; set; }
        public string patronymic { get; set; }
        public string mobileNomber { get; set; }
        public string email { get; set; }
        public int gruppaId { get; set; }
        public string gruppaName
        {
            get
            {
                GruppaDAO gDAO = new GruppaDAO();
                return gDAO.getGruppaName(this.id);
            }
        }

        public Student()
        {

        }

        public Student(int id, string surname, string firstName, string patronymic, string mobileNomber, string email, int gruppaId) 
        {
            this.id = id;
            this.surname = surname;
            this.firstName = firstName;
            this.patronymic = patronymic;
            this.mobileNomber = mobileNomber;
            this.email = email;
            this.gruppaId = gruppaId;
        }
        public Student(string surname, string firstName, string patronymic, string mobileNomber, string email, int gruppaId)
        {
            this.surname = surname;
            this.firstName = firstName;
            this.patronymic = patronymic;
            this.mobileNomber = mobileNomber;
            this.email = email;
            this.gruppaId = gruppaId;
        }


        public string getFIO()
        {
            return surname + " " + firstName + " " + patronymic;
        }
    }
}