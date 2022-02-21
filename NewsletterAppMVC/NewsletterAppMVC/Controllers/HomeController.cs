using NewsletterAppMVC.Models;
using NewsletterAppMVC.ViewModels;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NewsletterAppMVC.Controllers
{
    public class HomeController : Controller
    {
        //good practice to define something private and confidential like connectionString as a private and readonly string
        private readonly string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Newsletter;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        public ActionResult Index()
        {
            return View();
        }

        //Below function uses Entity Framework, which is a wrapper for ADO.NET
        //We used the Input element Name attributes, within our form, from Index.cshtml as parameters for this controller: 
        [HttpPost]
        public ActionResult SignUp(string firstName, string lastName, string socialSecurityNumber, string emailAddress)
        {
            if (string.IsNullOrEmpty(firstName) || string.IsNullOrEmpty(lastName) || string.IsNullOrEmpty(socialSecurityNumber) || string.IsNullOrEmpty(emailAddress))
            {
                return View("~/Views/Shared/Error.cshtml");//~ indicates a relative path starting from root; this returns error message page located in Shared folder
            }
            else
            {
                using (NewsletterEntities db = new NewsletterEntities())
                {
                    //taking arguments that were passed in from the user via the form and mapped them to the properties of the signup object we've instantiated
                    var signup = new SignUp();
                    signup.FirstName = firstName;
                    signup.LastName = lastName;
                    signup.EmailAddress = emailAddress;
                    signup.SocialSecurityNumber = socialSecurityNumber;

                    //now we need to transfer this signup object's property values to our dB table 
                    db.SignUps.Add(signup);
                    db.SaveChanges();
                }
                return View("Success");

            }

        }

        //ADO.NET VERSION: BELOW CODE IS SAME AS ABOVE CODE EXCEPT IT USES ADO.NET INSTEAD OF ENTITY FRAMEWORK 
        //We used the Input element Name attributes, within our form, from Index.cshtml as parameters for this controller: 
        //[HttpPost]
        //public ActionResult SignUp(string firstName, string lastName, string socialSecurityNumber, string emailAddress)
        //{
        //    if (string.IsNullOrEmpty(firstName) || string.IsNullOrEmpty(lastName) || string.IsNullOrEmpty(socialSecurityNumber) || string.IsNullOrEmpty(emailAddress))
        //    {
        //        return View("~/Views/Shared/Error.cshtml");//~ indicates a relative path starting from root; this returns error message page located in Shared folder
        //    }
        //    else
        //    {

        //        string queryString = @"INSERT INTO SignUps (FirstName, LastName, EmailAddress, SocialSecurityNumber) VALUES
        //                                (@FirstName, @LastName, @EmailAddress, @SocialSecurityNumber)"; //you never want to pass user input directly into your query d/t SQL injection risk; these parameters (@FirstName, ... etc.) help prevent that


        //        using (SqlConnection connection = new SqlConnection(connectionString))//anytime you open an outside connection, like to a dB, you want the using as it closes the connection when you're done to prevent memory leaks/slowdowns later 
        //        {
        //            SqlCommand command = new SqlCommand(queryString, connection);
        //            command.Parameters.Add("@FirstName", SqlDbType.VarChar);
        //            command.Parameters.Add("@LastName", SqlDbType.VarChar);
        //            command.Parameters.Add("@EmailAddress", SqlDbType.VarChar);
        //            command.Parameters.Add("@SocialSecurityNumber", SqlDbType.VarChar);


        //            command.Parameters["@FirstName"].Value = firstName;
        //            command.Parameters["@LastName"].Value = lastName;
        //            command.Parameters["@EmailAddress"].Value = emailAddress;
        //            command.Parameters["@SocialSecurityNumber"].Value = socialSecurityNumber;



        //            connection.Open();
        //            command.ExecuteNonQuery();
        //            connection.Close();

        //        }
        //        return View("Success");
        //    }

        //}

        //we want to grab all signups from database and display them to admin user --> we'll use Entity Framework to accomplish this
        public ActionResult Admin()
        {
            //we are instantiating newsletter entities class ... best practice to wrap instantiated entity objects in using statements 
            using (NewsletterEntities db = new NewsletterEntities())//remember, this automatically passes in our connection string so we now have access to our database in one line!
            {
                var signups = db.SignUps;//db has a property called SignUps which represents all of our records in our database (it is a list object: list of database records as objects)
                //so we will now use this NewsletterEntities db class object to access the database
                var signupVms = new List<SignupVm>();//if obvious what datatype is you can use var to avoid redundancy
                //we'll still use this logic in Entity, where we map our dB object to a view model so we don't pass private info to view
                foreach (var signup in signups)
                {
                    var signupVm = new SignupVm();
                    signupVm.FirstName = signup.FirstName;
                    signupVm.LastName = signup.LastName;
                    signupVm.EmailAddress = signup.EmailAddress;
                    signupVms.Add(signupVm);



                }
                return View(signupVms);

            }

        }
    }
}
//ADO.NET VERSION: Below code demonstrates the same above Admin() method, except using ADO.NET instead of Entity Framework (LOTS more code involved with ADO):
//we want to grab all signups from database and display them to admin user --> we'll use ADO.NET to accomplish this
//public ActionResult Admin()
//{
//    string queryString = @"SELECT Id, FirstName, LastName, EmailAddress, SocialSecurityNumber from Signups";
//    List<NewsletterSignUp> signups = new List<NewsletterSignUp>();//we've instantiated an empty list of NewsletterSignUp Model objects (i.e. rows from table will be stored as objects in list)

//    using (SqlConnection connection = new SqlConnection(connectionString))
//    {
//        SqlCommand command = new SqlCommand(queryString, connection);

//        connection.Open();

//        SqlDataReader reader = command.ExecuteReader();

//        while (reader.Read())
//        {
//            var signup = new NewsletterSignUp();
//            signup.Id = Convert.ToInt32(reader["Id"]);
//            signup.FirstName = reader["FirstName"].ToString();
//            signup.LastName = reader["LastName"].ToString();
//            signup.EmailAddress = reader["EmailAddress"].ToString();
//            signup.SocialSecurityNumber = reader["SocialSecurityNumber"].ToString();
//            signups.Add(signup);//after reader has finished populating attributes of our signup object per the first table row contents, this object is added to our list of said objects
//        }
//    }

//    var signupVms = new List<SignupVm>();//if obvious what datatype is you can use var to avoid redundancy
//    foreach (var signup in signups)
//    {
//        var signupVm = new SignupVm();
//        signupVm.FirstName = signup.FirstName;
//        signupVm.LastName = signup.LastName;
//        signupVm.EmailAddress = signup.EmailAddress;
//        signupVms.Add(signupVm);



//    }
//    return View(signupVms);
//}
//    }
//}

//If you want to avoid an error with ActionResult methods and you haven't made any code yet, just do return null; 

//Anytime you create  POST method, it's good practice to use the [HttpPost] tag to mark it as POST; a POST carries with it changes in your dB or in you're data and this can be harmful so we want
//to mark it as such 

//How MVC knows what to map information coming in to is called 'Model Binding' (e.g. it knows to map input element name tag names to controller method parameters of the same name)

//SAVING FORM ENTRY DATA INTO A DATABASE USING ADO.NET
/*
 The first thing we need is a database! After we have a database we then need to create a table.
 Open Microsoft SQL Server management studio and connect to the following database: (localdB)\MSSQLLocalDB
 Right click on Databases and click add new database 
 Right click on Tables and add new table
 Set first column name to Id, int datatype, not null, and then right click properties --> Set Table Designed Identity Column to Id so that it auto increments and is the primary key for our table 

 After creating a database and table, you'll put in the logic of ADO.NET in your controller method :
 1) Connection String : a string of characters that has info like your server name, passwords, credential info, etc. - specific info so your code knows how to access data in database ... how do you 
 get the connection string? You connect to your database inside of visual studio and examine the connection string from there
 2) Using ADO.NET, you use the connection string to connect to the database

 */
//if you go CTRL + M + O it closes all methods

//WHAT IF WE DONT WANT TO RETURN ALL OF OUR ADMIN() METHOD TABLE COLUMNS TO OUR VIEW - WE DONT WANT SSN FOR EXAMPLE - WHAT DO WE DO?
/*
 Create a View Model : a model that is stripped down to only what you need for the view 
 View Models live in a separate folder called ViewModels
 When we create a ViewModel within our ViewModels folder, a common naming convention to signify that the class is a view model is to use suffix Vm (see our SignupVm class within ViewModels)
 A common practice is, on the controller, to map your dB objects to a View Model 
 As you can see, once we have the signups list object fully populated with all table rows and columns, we will selectively map each row to a signupVm object and place it in a new list signupVms.
 This way we omit mapping sensitive data, like SSN, to our signupVms list that we end up sending to the Admin View (we don't want sensitive info going to View).
 

 There are libraries that exist that would automatically take any properties that match b/w two objects and map them for you, but here we do it manually...
 What these libraries do is use the process of Reflection under the hood, which is the idea of having an object look at itself to see what its properties are
 This reflection process can cost you a bit of overhead and if you use it too much, for example, it can cause issues with too much memory use 
 One such tool is called Automapper
 
 */