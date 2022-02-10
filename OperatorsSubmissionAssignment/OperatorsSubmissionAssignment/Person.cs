using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OperatorsSubmissionAssignment
{
    public class Person
    {
        public string FirstName { get; set; }//first property
        public string LastName { get; set; }//second property

        public void SayName()//void (doesn't return anything) method that prints First and Last Name in console
        {
            
            Console.WriteLine("Name: {0} {1}", FirstName, LastName);//prints firstname and lastname properties to console window as a formatted string

        }
    }
}
