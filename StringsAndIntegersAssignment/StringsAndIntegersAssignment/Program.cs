using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringsAndIntegersAssignment
{
    class Program
    {
        static void Main(string[] args)
        {
            //STRINGS AND INTEGERS SUBMISSION ASSIGNMENT:
            /*Create a list of integers. Ask the user for a number to divide each number in the list by. Write a loop that takes each integer in the list, divides it by the number the user entered, 
             and displays the result to the screen.
            * Run the code and enter non zero numbers as a user--look at displayed results.
            * Run again, entering zero as a number to divide by and note error messages you get.
            * Run again, entering in a string as a number to divide by
            * Place the loop in a Try/Catch block. Below and outside this Try/Catch block, make the program print a message to let you know the program has emerged from this block
            * and continued on with program execution.
            * In the catch block display the error message on the screens. Try various combos and ensure proper error message displays.
            */


            try
            {
                List<int> intList = new List<int>() { 2, 3, 15, 423, 32, 1, 2, 3 };//list with integers

                Console.WriteLine("Please enter a number.");
                string divisorString = Console.ReadLine();
                int divisor = Convert.ToInt32(divisorString);
                Console.WriteLine("Here are the results of dividing our string list by your divisor: ");
                foreach (int number in intList)//iterates the intList and divides each value by the user-input value (the divisor)
                {
                    int dividend = number / divisor;
                    Console.WriteLine(dividend);
                }
            }
            catch (DivideByZeroException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (FormatException ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.WriteLine("The program has emerged from the Try/Catch block and has continued on with program execution.");
            Console.Read();

        }
    }
}
