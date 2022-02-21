using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace conditionalChallenge
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("What is your favorite color?");
            string favColor = Console.ReadLine();

            if (favColor == "Orange")
            {
                Console.WriteLine("YOU, sir, are a LEGEND!!!");
            }
            else if (favColor == "Pink")
            {
                Console.WriteLine("Meh.");
            }
            else if (favColor == "Blue")
            {
                Console.WriteLine("Hmm...");
            }
            else
            {
                Console.WriteLine("I think you should look at a color wheel and come back when you're ready.");
            }
            Console.ReadLine();
        }
    }
}
