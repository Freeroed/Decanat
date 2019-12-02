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
        PlanDAO pDAO = new PlanDAO();
        StepDAO stepDAO = new StepDAO();

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

        //Добавление группы
        public ActionResult AddGroup()
        {
            return View();
        }
        [Authorize(Roles = "decan,director")]
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult AddGroup([Bind(Exclude = "ID")] Gruppa grup)
        {
            if (gDAO.add(grup)) return RedirectToAction("Index");
            else return View("AddGroup");
        }

        //Добавление этапа П-Г
        public ActionResult AddStep()
        {
            return View();
        }

        [Authorize(Roles = "decan,director")]
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult AddStep([Bind(Exclude = "ID")] Step step, int id)
        {
            Step st = step;
            st.planId = id;
            if (stepDAO.Add(st)) {
                int tId = id;
                return RedirectToAction("ShowPlanInfo", new { id = tId}); 
            }
            else return View("AddStep");
        }

        //Добавление плана-графика
        public ActionResult AddPlan()
        {
            return View();
        }

        [Authorize(Roles = "decan,director")]
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult AddPlan([Bind(Exclude = "ID")] Plan plan )
        {
            if (pDAO.add(plan)) return RedirectToAction("Index");
            else return View("AddPlan");
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

        public ActionResult ShowPlanInfo(int id)
        {
            Plan plan = pDAO.showPlanInfo(id);
            List<Step> steps = stepDAO.getStepsByPlanId(id);
            PlanAndStepsViewModel pASVM = new PlanAndStepsViewModel(plan, steps);
            return View(pASVM);
        }

        public ActionResult GetAllGrous()
        {
            List<Gruppa> groups = gDAO.getAllGroups();
            return View(groups);
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