using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParsingEnumsAssignment
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Please enter the current day of the week: ");
                string userEntry = Console.ReadLine();//stores user entry as a string.
                Weekdayenum weekday;//we declare an enum-type variable called weekday, but we did not initialize it with any values yet

                //we must run a method that checks to see if we can parse the user string entry into an enum constant and insert it as a value into 'weekday' (insert user entry into weekday enum)
                //i.e. we check if what the user entered actually exists as one of the constants listed within the definition of the Weekdayenum (e.g. Monday, Tuesday, Wednesday, etc.)...
                //we run a TryParse method to see if userEntry can be parsed into the weekday enum type variable.
                bool checkParse = Enum.TryParse(userEntry, out weekday);//this method exists within the Enum base class in the library; we pass in userEntry and have it return weekday with userEntry inside
                                                                        //checkPase stores boolean True or False, depending on if this parse attempt was successful or not.

                if (checkParse)//if checkParse is True, that means userEntry matched one of the Weekdayenum datatype constants and so was successfully added to our weekday variable.
                {
                    Console.WriteLine("Thank you! Your entry \" "+ weekday + " \" was successfully added to the weekday enum variable.");
                }
                else//if checkParse is false, that means what the user entered did not match a valid constant listed in the Weekdayenum datatype, thus we throw an exception and catch block responds
                {
                    throw new System.Exception();
                }
            }
            catch (Exception ex)//when an exception is thrown in the event of a failed parse, we inform the user per the string message below
            {
                Console.WriteLine("Please print an actual day of the week.");
            }
            Console.Read();//keeps terminal window open

        }
        
    }
}
