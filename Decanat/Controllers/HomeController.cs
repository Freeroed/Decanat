using Decanat.DAO;
using Decanat.Models.DecanatModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Decanat.Controllers
{
    public class HomeController : Controller
    {
        VkrDAO vDAO = new VkrDAO();
        StudentDAO sDAO = new StudentDAO();
        AnswerDAO aDAO = new AnswerDAO();
        TeacherDAO tDAO = new TeacherDAO();
        GruppaDAO gDAO = new GruppaDAO();

        //Стартовая страница
        public ActionResult Index()
        {

            if (User.IsInRole("student"))
            {
                int id = sDAO.getStudentId(User.Identity.Name);
                Console.WriteLine(id);
                ViewAnswerAndVKR vav = new ViewAnswerAndVKR(vDAO.getVKRbyStudent(id), id);
                return View(vav);

            }
            else if (User.IsInRole("teacher"))
            {
                int id = tDAO.getTeacherId(User.Identity.Name);
                ViewAnswerAndVKR vav = new ViewAnswerAndVKR(aDAO.getLastAnswers(id), id);
                return View(vav);
            } else
            {
                return View();
            }


        }
        //******************************************************************
        //Добавления
        //******************************************************************


        //Добавление студента
        public ActionResult AddStudent()
        {
            return View();
        }

        [Authorize(Roles ="decan,director")]
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult AddStudent([Bind(Exclude = "ID")] Student st)
        {
            if (sDAO.add(st)) return RedirectToAction("Index");
            else return View("AddStudent");
        }

        //Добавление учителя
        public ActionResult AddTeacher()
        {
            return View();
        }

        [Authorize(Roles = "decan,director")]
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult AddTeacher([Bind(Exclude = "ID")] Teacher teach)
        {
            if (tDAO.add(teach)) return RedirectToAction("Index");
            else return View("AddTeacher");
        }


        //**********************************************************************
        //Предоставление информации
        //**********************************************************************


        //Подробная информация о представленном ответе
        [Authorize(Roles = "teacher,student")]
        public ActionResult ShowAnswerInfo(int id)
        {
            Answer ans = aDAO.getInfo(id);
            return View(ans);

        }
        //GET: VKR
        //Просмотреть все документы
        public ActionResult getAllWorks()
        {
            return View(vDAO.getAllVKR());
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