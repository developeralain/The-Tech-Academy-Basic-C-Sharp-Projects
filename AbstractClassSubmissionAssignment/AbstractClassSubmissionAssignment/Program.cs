using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractClassSubmissionAssignment
{
    class Program
    {
        static void Main(string[] args)
        {
            Employee employee = new Employee() { FirstName = "Sample", LastName = "Student" };//instantiates class object employee and initializes it with values for its properties
            employee.SayName();//calls method to print the above initialized attribute values to the console window
            Console.Read();//keep console window open
        }
    }
}
