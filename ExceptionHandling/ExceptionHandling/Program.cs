using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExceptionHandling
{
    class Program
    {
        static void Main(string[] args)
        {
            //We'll put protections in place in the code that cchecks for particular errors and responds to those errors accordingly: That is Exception Handling
            //Here, many exceptions can arise: user inputs a string, user doesn't input anything, user tries to divide by zero...etc
            //The way we do exception handling is with a try catch block
            //Try block: we put the code we want to execute within the try block
            //Catch block: we put the exception handlings in the catch block
            //Uses for try-catch blocks: other than the obvious we can also use this in debugging to try and catch the exact error message that is thrown due to our code.

            try
            {
                Console.WriteLine("Pick a number.");
                int numberOne = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Pick a second number.");
                int numberTwo = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Dividing the two...");
                int numberThree = numberOne / numberTwo;
                Console.WriteLine(numberOne + " divided by " + numberTwo + " equals " + numberThree);
                Console.Read();
            }
            catch (FormatException ex)//here we are only catching FormatExceptions and assigning it as a variable ex...this is one type of possible exception (e.g. you put in string instead of int)
            {
                Console.WriteLine("Please type a whole number");//this displays a custom message in the console instead of exiting the program. 
                
            }
            catch (DivideByZeroException ex)//an exception thrown when user tries to divide by zero is caught and handled with the code in this catch block.
            {
                Console.WriteLine("Please don't divide by zero");
            }
            catch (Exception ex)//Exception handles general exceptions that are not r/t Format or Dividing by Zero, as covered by above blocks
            {
                Console.WriteLine(ex.Message)// the value 'Exception' is stored in 'ex'. 'ex.Message' contains the message string corresponding to the thrown exception. 
            }
            //A 'finally' is a code block that executes whether a try block runs perfectly or whether exceptions occur and are caught in the catch blocks: it runs regardless.
            //Why use this? When you catch something you often stop the execution of whatever is happening. 
            /*You usually want to log errors to a database...sometimes when you have an error you want something else to execute, maybe taking the user to an error page for instance.
             * If your catch block had a 'return' statement in order to take the user to an error page, this would stop execution of everything and the user would not even see the catch block
             * message because the Console.ReadLine(); below would not be hit. 
             * Often the finally block will have a DatabaseLog method that logs the exception to a database. 
             * A DataBaseLog can also log financial transactions to a database because money is something people are very particular about and we need to keep good track of transactions.*/
            finally
            {
                Console.ReadLine();//this guarantees that even if there's a return in our catches, this line of code will 100% execute and thus our users will be able to view the error message.
            }
            //Console.ReadLine(); if we didn't have a finally block and our catch blocks had returns, the Console.ReadLine() would never be hit and the user would never see the message.



        }
    }
}
