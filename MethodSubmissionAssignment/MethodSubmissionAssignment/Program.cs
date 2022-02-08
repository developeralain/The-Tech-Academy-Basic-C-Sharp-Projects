using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MethodSubmissionAssignment
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Math time! Enter any whole number: ");
            string xString = Console.ReadLine();
            int x = Convert.ToInt32(xString);

            Console.WriteLine("Optional - enter a second number (press 'Enter' to skip): ");
            
            string yString = Console.ReadLine();

            if (!string.IsNullOrEmpty(yString))//checks to see if the user chose not to enter a second number: only executes if they DID enter a second number i.e. not true that yString is empty/null
            {
                
                int AddFive = new math1().AddNum(x, yString);//calls method AddFive in object math1 and passes in userInt; method returns an int that is stored in AddFive variable
                Console.WriteLine("MATH RESULTS: " + AddFive);
                Console.Read();
            }
            else//only executes if there is no second number entered by the user i.e. only executes if user entered one number and skipped the optional.
            {

                int AddFive = new math1().AddNum(x);//calls method AddFive in object math1 and passes in userInt; method returns an int that is stored in AddFive variable
                Console.WriteLine("MATH RESULTS: " + AddFive);
                Console.Read();
            }

        }
        
    }
}
