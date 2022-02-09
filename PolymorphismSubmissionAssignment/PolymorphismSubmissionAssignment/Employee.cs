using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PolymorphismSubmissionAssignment
{
    public class Employee : Person, IQuittable//this class inherits from abstract class Person as well as the interface IQuittable
    {
        public override void SayName()//override keyword allows us to add in our own implementation details to this abstract method we are inheriting
        {
            Console.WriteLine(FirstName + " " + LastName);//prints First and Last Name properties, which aren't explicitly written here but inherited from Person, to console
        }
        public void Quit()//implementing method Quit() of inherited interface IQuittable
        {
            Console.WriteLine("Hey boss: I QUIT! You will never see {0} {1} here again.", FirstName, LastName);
        }
    }
}
