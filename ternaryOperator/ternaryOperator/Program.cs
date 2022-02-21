using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ternaryOperator
{
    class Program
    {
        static void Main(string[] args)
        {
            int value = 13;
            string evaluation = value > 13 ? "Value is > 13" : "Value is < 13";
            Console.WriteLine(evaluation);
            Console.ReadLine();
        }
    }
}
