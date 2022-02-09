using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PolymorphismSubmissionAssignment
{
    class Program
    {
        static void Main(string[] args)
        {
            IQuittable exEmployee = new Employee() { FirstName = "Homer", LastName = "Simpson" };//polymorphism demonstrated by instantiating class object of datatype IQuittable, of the Employee inheriting class
            
            exEmployee.Quit();//calls method
            Console.ReadLine();//keeps window open
        }
    }
}
