using Decanat.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Decanat.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            //StudentDAO stDAO = new StudentDAO();
            // stDAO.getStudentInfo(0);
            /* if (stDAO.testmethod())
             {
                 return View("Test");
             }
             else return View("Index");*/
            /* if (User.IsInRole("admin"))
             {
                 return View("AdminStartPage");
             }
             else if (User.IsInRole("student")) { return View("StudentStartPage"); }
             else if (User.IsInRole("teacher")) { return View("TSeacherStartPage"); }
             else return View("AdminStartPage");*/
            AnswerDAO aDAO = new AnswerDAO();
            aDAO.getLastAnswers();
            return View();
            
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}