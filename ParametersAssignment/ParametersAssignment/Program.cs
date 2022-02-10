using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParametersAssignment
{
    class Program
    {
        static void Main(string[] args)
        {
            Employee<string> Billy = new Employee<string>();//instantiate class object of Employee class as 'Billy' of 'string' datatype 
            Billy.Things = new List<string>() { "Chicken egg", "Pretzel sandwich", "Old widget", "Neutral pacifier" } ;//instantiated the Things list property as a list of strings and initialized it with values

            Employee<int> PointDexter = new Employee<int>();//instantiate class object of Employee class as 'PointDexter' of 'integer' datatype 
            PointDexter.Things = new List<int>() { 2,3,52,3,111 };//instantiated the Things list property as a list of integers and initialized it with numerical values

            foreach (string thing in Billy.Things)
            {
                Console.WriteLine(thing);
            }
            foreach (int thing in PointDexter.Things)
            {
                Console.WriteLine(thing);
            }
            Console.Read();
        }
    }
}
