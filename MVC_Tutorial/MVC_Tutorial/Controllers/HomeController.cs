using MVC_Tutorial.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_Tutorial.Controllers
{
    public class HomeController : Controller
    {
        //public ActionResult Index()
        //{
        //    List<string> names = new List<string>()
        //    {
        //        "Jesse",
        //        "Adam",
        //        "Brett"
        //    };
        //    return View(names);//passing above list to the View
        //}

        public ActionResult Index()
        {
            User user = new User();
            user.Id = 1;
            user.FirstName = "Jesse";
            user.LastName = "Johnson";
            user.Age = 32;


            return View(user);//passing above User class object user to the Index.cshtml View within the Home folder
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            throw new Exception("Invalid page");

            return View();
        }

        public ActionResult Contact(int id=0)
        {
            ViewBag.Message = id;

            return View();
        }
    }
}
//ActionResult
/*
 Just a datatype. It is defined in the System.Web.Mvc namespace, thus it is very specific to MVC
 */

//View()
/*
 A method that lives in the controller class (and HomeController inherits from Controller)
 It finds the right .cshtml file to return back to the browser and it does this by looking at the Views folder
EXAMPLE: localhost45233/Home/Contact
 View knows to look at the View folder and within that folder to look at the Home subfolder and once it's in that folder it knows to look for the .cshtml file named Contact 

 //ViewBag 
 is a dynamic View data dictionary, somewhat like a dictionary, it's like a bag where you can throw in any data type and it will naturally get sent to view and you can reference it

EXAMPLE LOGIC:

        public ActionResult Index()
        {
            Random rnd = new Random(10);
            var num = rnd.Next();

            if (num > 20000)
            {
                return View("About");
            }
               
            return View();
        }

//RETURNING THINGS IN CONTROLLER METHODS

//Content
  you can return content or leave content as blank to return nothing (e.g. return Content(""))

//Redirect
  Redirects you to another Controller method (e.g. return RedirextToAction("Contact")). Note that all controller methods are known as actions.

**DISTINGUISH**

If you did: 

        public ActionResult Index()
        {
            return RedirectToAction("Contact");
        }

it would take you to the Contact method/action within this controller and execute it, thus your URL would change to reflect that (e.g. ../Home/Contact)

Whereas if you did:

        public ActionResult Index()
        {
            return View("Contact");
        }

the Contact action wouldn't be run--it would just return the .cshtml file for Contact (the contact page) and the URL wouldn't change in the browser as Contact action wasn't called (didn't hit controller method)

//CONTROLLER METHODS (AKA ACTIONS) AND URLS
  when a controller method is run that then serves a view, that is how a URL is generated that we see in the browser address bar
  if we skip the controller and simply serve the view directly, the URL does not change
  for instance, the Index method/action above can return another View and in doing so it would not change the URL path at all, whereas if it redirected to another Action it would

//Index
MVC is built to return index by default if your view is empty : return View(); is same as return View("index");




 */