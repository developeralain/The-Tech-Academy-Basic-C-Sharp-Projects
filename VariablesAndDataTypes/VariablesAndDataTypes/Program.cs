using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


//we'll create a simple program that asks for your name and explore data types
//to highlight and comment-out code: CTRL+K+C ... to comment-in code: CTRL+K+U
namespace VariablesAndDataTypes
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("What is your name?");
            //string yourName = Console.ReadLine();
            //Console.WriteLine("Your name is: " + yourName);
            //Console.ReadLine();

            //Console.WriteLine("What is your favorite Number?");
            //string favoriteNumber = Console.ReadLine(); //user input is only taken-in as a string...you can't do int favoriteNumber because ReadLine only returns strings not int
            //int favNum = Convert.ToInt32(favoriteNumber);//this line performs 'casting', which is the process of converting one data type to another (string to int in this case)
            //int total = favNum + 5;
            //Console.WriteLine("Your favorite number plus 5 is: " + total);
            //Console.ReadLine();

            bool isStudying = false;
            byte hoursWorked = 42;
            sbyte currentTemperature = -23;
            char questionMark = '\u2103';//this is unicode for a question mark ?

            decimal moneyInBank = 100.5m;//used primarily for financial transactions. Very long. 128 bits (up to 29 digits long). 

            double heightInCentimeters = 211.302092232;//any number up to 16 digits long (64 bits)

            float secondsLeft = 2.62f;//any number up to 7 digits long (32 bits)

            short temperatureOnMars = -341;//represents a whole number b/w -32,678 and 32,767 (16 bit version of int, which is 32 bit)

            string myName = "Alain";

            int currentAge = 30;//represents whole number b/w -2 billion and 2 billion (32-bit)
            string yearsOld = currentAge.ToString();

            bool isRaining = true;
            string rainingStatus = Convert.ToString(isRaining);

            Console.WriteLine(rainingStatus);
            Console.ReadLine();
        }
    }
}
