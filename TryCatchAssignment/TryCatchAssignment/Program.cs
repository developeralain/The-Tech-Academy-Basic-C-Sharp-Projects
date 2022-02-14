using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TryCatchAssignment
{
    class Program
    {
        static void Main(string[] args)
        {
            try//monitors enclosed code block for any errors, and if any arise then passes them to the correspond catch block(s)
            {
                Console.WriteLine("What is your age in years?");
                int ageYears = Convert.ToInt32(Console.ReadLine());//captures user string and converts to integer value
                
                if (ageYears < 0)//as it stands, no exception is thrown automatically if user enters a negative age value. Hence, we make the program throw an exception to avoid future year of births.
                {
                    throw new FormatException();//artifically throws this exception, triggered the same catch block as for a FormatException
                    
                }

                DateTime currentYear = DateTime.Now;//Gets the current datetime per the local user's computer
                int year = currentYear.Year;//extracts the Year property from the instatiated datetime object currentYear and stores it as an integer year
                int yearOfBirth = year - ageYears;//subtracts the user's age in years from the current year in order to calculate year of birth


                Console.WriteLine("Your were born in {0}. Am I psychic, or what?", yearOfBirth);//print user's year of birth
                Console.ReadLine();
        }
            catch (FormatException)////this is an exception that is thrown if a user enters a decimal, non-numeric characters
            {
                Console.WriteLine("Please make sure you are entering non-negative numbers with no decimals or letters or spaces");
                Console.Read();
            }
            catch (Exception)//catches all exceptions that don't fit into any of the above and handles them with below string message.
            {
                Console.WriteLine("Something went wrong. Please contact your System Administrator.");
                Console.Read();
            }
        }
    }
}
