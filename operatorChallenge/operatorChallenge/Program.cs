using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace operatorChallenge
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Let's see if Apple is NOT equal to Orange.");
            string apple = "apple";
            string orange = "orange";
            bool compare = apple != orange;
            Console.WriteLine("Is is " + compare + " that APPLE is NOT equal to ORANGE!!!");
            Console.ReadLine();
        }
    }
}
