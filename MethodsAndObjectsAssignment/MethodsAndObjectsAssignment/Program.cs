using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MethodsAndObjectsAssignment
{
    class Program
    {
        static void Main(string[] args)
        {
            Employee employee = new Employee() { FirstName = "Sample", LastName = "Student" };//instantiates class object employee and initializes it with values for its properties
            employee.SayName();//calling Employee superclass method 'SayName' on employee object
            Console.ReadLine();//keeps console window open



        }
    }
}
