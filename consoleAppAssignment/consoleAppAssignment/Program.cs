using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace consoleAppAssignment
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter a word that rhymes with the word 'lime' (please use lower-case only and no punctuation)");//solicts user input
            string rhyme = Console.ReadLine();//takes user input and stores in variable named rhyme

            //below line isn't absolutely correct in its scope of words, but uses equality and OR operators to run through most common rhymes for the word 'lime'
            //if user does select one of the 6 strings below, the while loop runs. If uses selects one of the strings correctly, the while loop is still run because of the do statement.
            bool doesItRhyme = rhyme == "crime" || rhyme == "dime" || rhyme == "sublime" || rhyme == "mime" || rhyme == "rhyme" || rhyme == "time";

            do //this ensures even if a user types a correctly rhyming word right away, that the while loop executes. If do was not here, an immediate correct guess would prevent below code from running.
            {
                switch (rhyme)//looks to see if user-entry matches any of the below cases. If not, runs default code block at bottom.
                {
                    case "fine":
                        Console.WriteLine("Did you go to rhyme school? You should consider it.");
                        Console.WriteLine("Try again: What rhymes with 'lime'? Think about it...");
                        rhyme = Console.ReadLine();
                        break;
                    case "crime":
                        Console.WriteLine("Somebody should be a rapper! You are CORRECT! =D");
                        rhyme = Console.ReadLine();
                        doesItRhyme = true;//every correct case has this statement in order to exit the while loop.
                        break;
                    case "dime":
                        Console.WriteLine("Somebody should be a rapper! You are CORRECT! =D");
                        rhyme = Console.ReadLine();
                        doesItRhyme = true;
                        break;
                    case "sublime":
                        Console.WriteLine("Somebody should be a rapper! You are CORRECT! =D");
                        rhyme = Console.ReadLine();
                        doesItRhyme = true;
                        break;
                    case "mime":
                        Console.WriteLine("Somebody should be a rapper! You are CORRECT! =D");
                        rhyme = Console.ReadLine();
                        doesItRhyme = true;
                        break;
                    case "rhyme":
                        Console.WriteLine("Somebody should be a rapper! You are CORRECT! =D");
                        rhyme = Console.ReadLine();
                        doesItRhyme = true;
                        break;
                    case "time":
                        Console.WriteLine("Somebody should be a rapper! You are CORRECT! =D");
                        rhyme = Console.ReadLine();
                        doesItRhyme = true;
                        break;
                    default://runs in event user input does not match any above case.
                        Console.WriteLine("Hmm...not so sure about that one! Try again.");
                        rhyme = Console.ReadLine();
                        break;
                }
            }
            while (!doesItRhyme);//this while loop keeps running the switch until a case breaks the while loop by setting doesItRhyme to true.
            Console.Read();//this ensure the console window doesn't just close by itself.

            //BELOW LIES THE WHILE LOOP WITHOUT A DO STATEMENT - IT IS COMMENTED OUT SO THAT THE DO WHILE LOOP ABOVE RUNS AS THE PRIORITY. CTRL+K+U BELOW TO ACTIVATE IT

            //Console.WriteLine("Enter a word that rhymes with the word 'lime' (please use lower-case only and no punctuation)");
            //string rhyme = Console.ReadLine();
            ////below line isn't absolutely correct in its scope of words, but uses equality and OR operators to run through most common rhymes for the word 'lime'
            ////if user does select one of the 6 strings below, the while loop runs. If uses selects one of the strings correctly, the while loop is not run. We need a go while loop to cover this possibility...
            //bool doesItRhyme = rhyme == "crime" || rhyme == "dime" || rhyme == "sublime" || rhyme == "mime" || rhyme == "rhyme" || rhyme == "time";

            //while (!doesItRhyme)
            //{
            //    switch (rhyme)
            //    {
            //        case "fine":
            //            Console.WriteLine("Did you go to rhyme school? You should consider it.");
            //            Console.WriteLine("Try again: What rhymes with 'lime'? Think about it...");
            //            rhyme = Console.ReadLine();
            //            break;
            //        case "crime":
            //            Console.WriteLine("Somebody should be a rapper! You are CORRECT! =D");
            //            rhyme = Console.ReadLine();
            //            doesItRhyme = true;
            //            break;
            //        case "dime":
            //            Console.WriteLine("Somebody should be a rapper! You are CORRECT! =D");
            //            rhyme = Console.ReadLine();
            //            doesItRhyme = true;
            //            break;
            //        case "sublime":
            //            Console.WriteLine("Somebody should be a rapper! You are CORRECT! =D");
            //            rhyme = Console.ReadLine();
            //            doesItRhyme = true;
            //            break;
            //        case "mime":
            //            Console.WriteLine("Somebody should be a rapper! You are CORRECT! =D");
            //            rhyme = Console.ReadLine();
            //            doesItRhyme = true;
            //            break;
            //        case "rhyme":
            //            Console.WriteLine("Somebody should be a rapper! You are CORRECT! =D");
            //            rhyme = Console.ReadLine();
            //            doesItRhyme = true;
            //            break;
            //        case "time":
            //            Console.WriteLine("Somebody should be a rapper! You are CORRECT! =D");
            //            rhyme = Console.ReadLine();
            //            doesItRhyme = true;
            //            break;
            //        default:
            //            Console.WriteLine("Hmm...not so sure about that one! Try again.");
            //            rhyme = Console.ReadLine();
            //            break;
            //    }





            //}
            //Console.Read();
        }
    }
}
