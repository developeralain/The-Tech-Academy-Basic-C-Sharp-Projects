using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CallingMethodsAssignment
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter a number. I'll show you some legendary math operations in just a moment.");
            string userInput = Console.ReadLine();
            int userInt = Convert.ToInt32(userInput);
            int AddFive = new math1().AddNum(userInt);
            int SubFive = new math1().SubNum(userInt);
            int MultiFive = new math1().MultiNum(userInt);
            Console.WriteLine("Voila! We turned " + userInput + " into :" + AddFive + ", " + SubFive + ", " + MultiFive);
            Console.Read();

        }
    }
}
