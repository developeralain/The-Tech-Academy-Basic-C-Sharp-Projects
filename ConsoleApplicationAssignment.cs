using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplicationAssignment
{
    class Program
    {
        static void Main(string[] args)
        {
            ////This takes a user's input, multiples it by 50, and prints the output.
            //Console.WriteLine("Enter a value and I'll output the product of multiplying it by 50");
            //string multiplyFiftyString = Console.ReadLine();
            //double multiplyFiftyDouble = Convert.ToDouble(multiplyFiftyString);
            //double product = 50 * multiplyFiftyDouble;
            //Console.WriteLine(product);
            //Console.ReadLine();

            ////This takes a user's input, adds 25 to it, and prints the output.
            //Console.WriteLine("Enter a value and I'll output 25 plus whatever you entered");
            //string addTwentyFiveString = Console.ReadLine();
            //double addTwentyFiveDouble = Convert.ToDouble(addTwentyFiveString);
            //double sum = 25 + addTwentyFiveDouble;
            //Console.WriteLine(sum);
            //Console.ReadLine();

            ////This takes a user's input, divides it by 12.5, then prints the output
            //Console.WriteLine("Enter a value and I'll output whatever you entered divided by 12.5");
            //string divideTwelvePointFiveString = Console.ReadLine();
            //double divideTwelvePointFiveDouble = Convert.ToDouble(divideTwelvePointFiveString);
            //double difference = divideTwelvePointFiveDouble / 12.5;
            //Console.WriteLine(difference);
            //Console.ReadLine();

            ////This takes a user's input, checks if it is > 50 , then prints the output
            //Console.WriteLine("Enter a value and I'll tell you if it is > 50");
            //string greaterThanFiftyString = Console.ReadLine();
            //double greaterThanFiftyDouble = Convert.ToDouble(greaterThanFiftyString);
            //bool greaterThanFiftyBool = greaterThanFiftyDouble > 50;
            //Console.WriteLine(greaterThanFiftyBool);
            //Console.ReadLine();

            //This takes a user's input, divides it by 7, then prints the remainder to the console
            Console.WriteLine("Enter a value and I'll divide it by 7 and tell you the remainder");
            string checkRemainderString = Console.ReadLine();
            double checkRemainderDouble = Convert.ToDouble(checkRemainderString);
            double remainder = checkRemainderDouble % 7;
            Console.WriteLine(remainder);
            Console.ReadLine();
        }
    }       
}
