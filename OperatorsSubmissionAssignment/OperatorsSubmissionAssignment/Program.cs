using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OperatorsSubmissionAssignment
{
    class Program
    {
        static void Main(string[] args)
        {
            Employee Bobbers = new Employee() { FirstName = "Bobbers", LastName = "Spindle", Id = 13 };//instantiates class object employee and initializes it with values for its properties
            Employee Arnie = new Employee() { FirstName = "Arnie", LastName = "Flanders", Id = 12 };//instantiates class object employee and initializes it with values for its properties
            bool isEqual = Bobbers == Arnie;//essentially 'calls' our overload == method in Person class and evalutes Bobbers' and Arnie's Ids for equality, storing return value in isEqual

            Console.WriteLine("It is {0} that {1} and {2} have identical Ids.", isEqual, Bobbers.FirstName, Arnie.FirstName);
            Console.ReadLine();//keeps console window open
        }
    }
}
