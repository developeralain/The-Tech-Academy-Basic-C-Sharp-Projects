using System;
using System.Collections.Generic;


namespace Iteration
{
    class Program
    {
        static void Main(string[] args)
        {
            ////ITERATION: going through a list of items and doing something /w each item...opens up ability to have a group of elements and so something with each of those

            //int[] testScores = { 98, 99, 85, 70, 82, 34, 91, 90, 94 };//an array of test scores 

            ////iterate over testScores array

            //for (int i = 0; i < testScores.Length; i++)//this part sets up your loop: i starts at 0 and is the counter. i < testScores.Length is the condition for when to stop the for loop.
            //    //i++ increments up by 1 for each time the loop is run. 
            //{
            //    if (testScores[i] > 85)//only prints scores >85 to the console
            //    {
            //        Console.WriteLine("Passing test score: " + testScores[i]);
            //    }
            //}
            //Console.ReadLine();


            ////CREATING A STRING ARRAY
            //string[] names = { "Erik", "Billy", "Silly", "Willy" };

            //for (int j = 0; j < names.Length; j++)
            //{
            //    if (names[j] == "Willy")
            //    {
            //        Console.WriteLine(names[j]);
            //    }
            //}
            //Console.Read();


            ////String array: iterate through and print entire array contents
            //string[] names = { "Erik", "Billy", "Silly", "Willy" };

            //for (int j = 0; j < names.Length; j++)
            //{

            //    {
            //        Console.WriteLine(names[j]);//iterates through entire list and prints each array element
            //    }
            //}
            //Console.Read();


            ////LIST: creates a list of integers containing test scores. Each score is manually added to the list
            //List<int> testScores = new List<int>();//this line instantiates a list object and assigns it to variable testScores
            ////here we manually add each score to the list
            //testScores.Add(98);
            //testScores.Add(81);
            //testScores.Add(31);
            //testScores.Add(66);
            //testScores.Add(73);
            //testScores.Add(99);

            //foreach (int score in testScores)//scores represents the item in the list which we're at; foreach will iterate through all list elements, and score will hold the value for a given index
            //{
            //    if (score > 85)//as foreach iterates through testScores list, if it encounters a score > 85 it will do the below code
            //    {
            //        Console.WriteLine("Passing test score:" + score);//score will contain only values > 85 from the testScores list
            //    }

            //}
            //Console.Read();


            ////FAST LIST: populates list values at same time you are instantiating the list object (faster method of list creation)
            ////The below code uses a foreach loop with an if statement to isolate printing only "Alain" from the list of string names
            //List<string> names = new List<string>() { "Billy", "Bobby", "Flobby", "Alain" };

            //foreach (string name in names)
            //{
            //    if (name == "Alain")
            //    {
            //        Console.WriteLine(name);
            //    }
            //}
            //Console.Read();

            //FAST LIST METHOD: quickly populates list elements at time of list creation
            List<string> names = new List<string>() { "Billy", "Bobby", "Flobby", "Alain" };

            foreach (string name in names)
            {

                Console.WriteLine(name);

            }
            Console.Read();


            //LIST: ITERATE OVER LIST AND TRANSFER CERTAIN ELEMENTS FROM LIST INTO ANOTHER LIST

            List<int> testScores = new List<int>() { 98, 99, 12, 74, 23, 99 };
            List<int> passingScores = new List<int>();//we create an empty list that we will pass certain values from testScores list into. Unlike array, you don't need to specify size of the list

            foreach (int score in testScores)
            {
                if (score > 85)
                {
                    passingScores.Add(score);
                }
            }

            Console.WriteLine(passingScores.Count);//Count is same as .Length, except we use Count for lists and Length for arrays
            Console.ReadLine();
        }


    }
}
