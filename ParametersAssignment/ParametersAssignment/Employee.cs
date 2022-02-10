using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParametersAssignment
{
    public class Employee<T> : Person//this class inherits from abstract class Person
    {
        public List<T> Things { get; set; }
        public override void SayName()//override keyword allows us to add in our own implementation details to this abstract method we are inheriting
        {
            Console.WriteLine(FirstName + " " + LastName);//prints First and Last Name properties, which aren't explicitly written here but inherited from Person, to console
        }
    }
}