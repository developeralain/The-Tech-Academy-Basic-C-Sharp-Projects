using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BooleanLogicInsuranceAssignment
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("What is your age?");
            string ageString = Console.ReadLine();
            byte age = Convert.ToByte(ageString);//age won't exceed 130 ever, so byte can be use for memory resourcefulness

            Console.WriteLine("Have you ever had a DUI? Please answer with \"Yes\" or \"No\" only.");
            string DUI = Console.ReadLine();

            Console.WriteLine("How many speeding tickets do you have?");
            string speedingTicketsString = Console.ReadLine();
            byte speedingTickets = Convert.ToByte(speedingTicketsString);//no one will have > 255 speeding tickets AND be allowed to drive ever again


            bool boolNoDUI = DUI == "No"; //compares user-entered value for DUI question and if equal to "No", assigns boolean True which means they've never had a DUI if "No" == "No" is true.
            bool qualifies = age > 15 && boolNoDUI && speedingTickets <= 3;//checks if all 3 conditional requirements for insurance are True
            Console.WriteLine("It is " + qualifies + " that you qualify for auto insurance at this time.");//outputs whether they qualify or not
            Console.ReadLine();//keeps console open


        }
    }
}
