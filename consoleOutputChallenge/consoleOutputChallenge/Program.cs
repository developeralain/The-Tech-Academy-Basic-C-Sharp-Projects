using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace consoleOutputChallenge
{
    class Program
    {
        static void Main(string[] args)
        {
            int three = 3;
            int fourteen = 14;
            bool greaterThan = three > fourteen;
            bool lesserThan = three < fourteen;
            Console.WriteLine("Let's compare three and fourteen. Is 3 greater than 14?");
            Console.WriteLine(greaterThan);
            Console.ReadLine();
            Console.WriteLine("Cool. Now, is three less than fourteen?");
            Console.WriteLine(lesserThan);
            Console.ReadLine();
        }
    }
}
