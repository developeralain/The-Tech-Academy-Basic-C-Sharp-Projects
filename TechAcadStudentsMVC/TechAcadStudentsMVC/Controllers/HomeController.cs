using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TechAcadStudentsMVC.Models;

namespace TechAcadStudentsMVC.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Contact Page - The Tech Academy";

            return View();
        }


        public ActionResult Instructor()
        {
            

            Instructor dayTimeInstructor = new Instructor
            {
                Id = 1,
                FirstName = "Erik",
                LastName = "Gross"
            };

            return View(dayTimeInstructor);
        }

        public ActionResult Instructors()
        {
            List<Instructor> instructors = new List<Instructor>
            {
                new Instructor
                {
                    Id = 1,
                    FirstName = "Teddy",
                    LastName = "Barrett"
                },
                new Instructor
                {
                    Id = 2,
                    FirstName = "Eddy",
                    LastName = "Snarritt"
                },
                new Instructor
                {
                    Id = 3,
                    FirstName = "Sned",
                    LastName = "Lardo"
                },

            };
            return View(instructors);
        }
    }
}