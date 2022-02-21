using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TechAcadStudentsMVC.Models;


namespace TechAcadStudentsMVC.Controllers
{
    public class StudentsController : Controller
    {
      public ActionResult Index()
        {
            return View();
        }
    }
}