using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainMethodAssignment
{
    class Program
    {
        static void Main(string[] args)
        {
            
            
            

            Console.WriteLine("Enter a number. I'll show you some legendary math operations in just a moment.");
            string userInput = Console.ReadLine();//stores user input as a string variable
            int userInt = Convert.ToInt32(userInput);//converts user input string variable into an int variable 
            int AddFive = new math1().AddNum(userInt);//calls method AddFive in object math1 and passes in userInt; method returns an int that is stored in AddFive variable
            Console.WriteLine("Voila! We turned " + userInput + " into : " + AddFive);//prints a coherent string for user to see the outcomes of these math operations  

            Console.WriteLine("Enter another number. Don't be afraid to use decimals! I'll show you some legendary math operations in just a moment.");
            string userInput2 = Console.ReadLine();//stores user input as a string variable
            decimal userDec = Convert.ToDecimal(userInput2);//converts user input string variable into a decimal variable 
            int SubFive = new math1().SubNum(userDec);//calls method SubNum in object math1 and passes in userDec; method returns an int that is stored in SubFive variable
            Console.WriteLine("Voila! We turned " + userInput2 + " into : " + SubFive);

            Console.WriteLine("Enter a number. I'll show you some legendary math operations in just a moment.");
            string userInput3 = Console.ReadLine();//stores user input as a string variable
            int MultiFive = new math1().MultiNum(userInput3);//calls method MultiNum in object math1 and passes in userInput3 string; method returns an int that is stored in MultiFive variable
            Console.WriteLine("Voila! We turned " + userInput3 + " into : " + MultiFive);

            


           
            Console.Read();//prevents console window from closing
        }
    }
}
