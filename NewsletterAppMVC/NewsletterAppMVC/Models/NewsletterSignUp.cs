using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NewsletterAppMVC.Models
{
    //this model with map exactly to our SignUps table in the Newsletter dB
    public class NewsletterSignUp
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; }
        public string SocialSecurityNumber { get; set; }
    }
}

//MODELS

/*
 Always singular - it's a business object. If it's gonna be plural then it's a list of them.
 */