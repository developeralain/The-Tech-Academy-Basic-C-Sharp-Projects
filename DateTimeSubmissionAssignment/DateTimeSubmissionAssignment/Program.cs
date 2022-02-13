using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DateTimeSubmissionAssignment
{
    class Program
    {
        static void Main(string[] args)
        {
            DateTime now = DateTime.Now;//stores current date and time in variable called now as a datetype value type
            Console.WriteLine("The current date and time: {0} ", now);//prints current date and time to console

            Console.WriteLine("Please type in a number: ");
            int userNum = Convert.ToInt32(Console.ReadLine());//stores user number entry as userNum int
            double userNumD = Convert.ToDouble(userNum);//converts int to double, as the .AddHours DateTime object method requires this 




            DateTime userTime = now.AddHours(userNumD);//new userTime variable takes current date/time as 'now' and calls method AddHours and passes argument userNumD (the user value as a double)
            //this returns the current date/time plus a certain amount of hours as represented by whatever number the user entered 
            Console.WriteLine(userTime);//writes out the modified datetime value by adding the number entered by user to the current date/time
            Console.Read();//keeps console window open
        }
    }
}
