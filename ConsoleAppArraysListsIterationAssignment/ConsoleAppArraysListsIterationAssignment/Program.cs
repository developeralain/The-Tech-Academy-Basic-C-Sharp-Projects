using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppArraysListsIterationAssignment
{
    class Program
    {
        static void Main(string[] args)
        {
            //CONSOLE APP PART ONE ASSIGNMENT
            //REQUIREMENTS: 1D array of strings, ask user for input, append user input to each element of the string array,
            //print this out to console.

            //string[] stringArray = { "bat fins", "Chicken wings", "Cass", "Spelling spells", "Finnish hounds"};
            ////above line instantiates array of strings 



            //Console.WriteLine("Enter some text, ANY text. Do what you feel in your gut: ");
            //string userText = Console.ReadLine();


            //for (int i = 0; i < stringArray.Length; i++)
            //{
            //    string modifiedElement = stringArray[i] + " " + userText;
            //    stringArray.SetValue(modifiedElement, i);
            //    Console.WriteLine(stringArray[i]);
            //}
            //Console.Read();


            //CONSOLE APP PART TWO ASSIGNMENT
            //REQUIREMENTS: infinite loop, save code, fix infinite loop so it executes properly

            //below shows an infinite loop: prints value 3 at index 1 infinitely
            //int[] myArray = { 2, 3, 4, 55, 123, 2323, 2 };

            //for (int i = 0; i >= 0; i=1)
            //{
            //    Console.WriteLine(myArray[i]);
            //}

            //The below code fixes the above infinite loop
            //int[] myArray = { 2, 3, 4, 55, 123, 2323, 2 };

            //for (int i = 0; i < myArray.Length; i++)
            //{
            //    Console.WriteLine(myArray[i]);
            //}
            //Console.Read();

            //CONSOLE APP PART THREE ASSIGNMENT
            /*REQUIREMENTS: A loop where comparison used to determine whether to continue iterating the loop is a '<'
             operator, a loop where the comparison that's used to determine whether to continue iterating the loop is a 
            '<=' operator*/

            //Loop with '<' operator
            //int[] myArray = { 1, 2, 3, 4, 5, 6, 6, 5, 4, 3, 3, 2 };
            //for (int i=0; i < myArray.Length; i++)
            //{
            //    Console.WriteLine(myArray[i]);
            //}
            //Console.Read();

            //Loop with '<=' operator
            //int[] myArray = { 1, 2, 3, 4, 2323, 232, 2315, 5, 2323, 5 };
            //for (int i = 0; i <= (myArray.Length - 1); i++)
            //{
            //    Console.WriteLine(myArray[i]);
            //}
            //Console.Read();


            //CONSOLE APP PART FOUR ASSIGNMENT
            /*REQUIREMENTS: 
             * A list of strings where each element of the list is unique, 
             * ask user to input text to search for in the list, 
             * a loop that iterates through the list and displays the index of the list that contains 
            matching text on the screen, 
            add code to the loop to check if user put in text that is not on the list and if they did tells the user 
            their input is not on the list, 
            * add code to the loop that stops it from executing once a match has been found*/

            //List<string> names = new List<string>() { "Billy", "Bobby", "Flobby", "Alain" };

            //Console.WriteLine("Please enter search query: ");
            //string userSearch = Console.ReadLine();

            //for (int i = 0; i < names.Count; i++)
            //{
            //    if (names[i] == userSearch)
            //    {
            //        Console.WriteLine(i);
            //        break;//breaks out of loop once query-match found
            //    }
            //    if (names.Contains(userSearch) == false)
            //    {
            //        Console.WriteLine("Your query did not match any values in the list.");
            //        break;//breaks out if query doesn't match any existing list elements
            //    }
            //}
            //Console.Read();


            //CONSOLE APP PART FIVE ASSIGNMENT
            /*REQUIREMENTS: 
             * A list of strings that has >= 2 identical strings in the list. Ask user to select text 
             to search for in the list 
            * Create a loop that iterates through list and displays the indices of the items matching user-selected
            text
            * Add code to the loop to check if user-inputted text is not in the list and have it tell user if this is the
            case
            */

            //List<string> names = new List<string>() { "Billy", "Bobby", "Flobby", "Alain", "Alain", "Flobby" };
            //Console.WriteLine("Type text you'd like to search for in the list: ");
            //string query = Console.ReadLine();
            //for (int i = 0; i < names.Count; i++)
            //{
            //    if (names[i] == query)
            //    {
            //        Console.WriteLine(i);
            //    }
            //    if (names.Contains(query) == false)
            //    {
            //        Console.WriteLine("Your query did not match any names in the list.");
            //        break;
            //    }
            //}
            //Console.Read();


            //CONSOLE APP PART SIX ASSIGNMENT 
            /*REQUIREMENTS:
             * List of strings with >= 2 identical strings in the list
             * foreach loop that evaluates each element in the list and displays a message showing the 
             string and whether or not it has already appeared in the list
            * Add comments to this code explaining it*/

            //List<string> names = new List<string>() { "Billy", "Bobby", "Flobby", "Alain", "Alain", "Flobby" };
            ////above is the list we will be iterating through
            //List<string> names2 = new List<string>();
            ////above is a blank list we will use to mirror the names list as we iterate through. It will be used to check
            ////if a string in names has already appeared or not during the iteration process.
            //foreach (string name in names)//iterates through names list, storing index value in name for each iteration
            //{

            //    if (names2.Contains(name))/*if our blank list, that we are adding to for each iteration, already contains
            //                               the same string, then execute the below code*/
            //    {
            //        Console.WriteLine("String " + name + " has already appeared in the list.");
            //        names2.Add(name);//adds element from name to our names2 list  
            //    }
            //    if (names2.Contains(name) == false)/*If our dynamic/growing names2 list doesn't yet have the string we 
            //                                        are at during the iteration, then execute below code.*/
            //    {
            //        Console.WriteLine("String " + name + " hasn't appeared in the list yet.");
            //        names2.Add(name);//add this name to the growing names2 list
            //    }



            //}
            //Console.Read();//keep console window open

        }


    }
}
