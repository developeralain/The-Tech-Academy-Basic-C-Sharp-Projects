//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace NewsletterAppMVC
{
    using System;
    using System.Collections.Generic;
    
    public partial class SignUp
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; }
        public string SocialSecurityNumber { get; set; }
    }
}

//This maps perfectly to our dB table: the reason for this is entity framework is going to allow us to pull in a list of these objects--SignUp.cs objects--and each one will represent 
//a record in our database. From there we could make changes to the object and then call a method such as save() and then those changes would automatically get replicated in the database.

//It's a partial class which is simply a class that can be added on to...not too important for our purposes but introduces the idea of having one class defined in separate CS files
//so if you wanted to extend this class, maybe give it specialized methods, you would want to define them outside of the file itself as another partial public class NewsletterEntities 
//the reason you'd want to do that is anytime we import an updated Database schema, this file gets re-created. So if we added a bunch of methods and then imported a new schema then everything 
//would get overwritten. So if you want to add to it, you create a partial class and C# merges them together into one big class composed of 2 or more partial classes. 
