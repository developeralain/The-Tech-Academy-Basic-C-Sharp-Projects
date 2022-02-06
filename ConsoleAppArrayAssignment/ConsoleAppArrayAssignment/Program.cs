using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppArrayAssignment
{
    class Program
    {
        static void Main(string[] args)
        {   
            ////create string array of 5 string elements
            //string[] stringArray = { "Cats", "Bats", "Mats", "Hats", "Gnats" };
            //Console.WriteLine("Please select between index 0 and 4 to display a string in the array. Type an index value:");
            //string userIndexString = Console.ReadLine();//capture user input as a string.
            //int userIndex = Convert.ToInt32(userIndexString);//convert input to an int
            //Console.WriteLine("You selected: " + stringArray[userIndex]);
            //Console.ReadLine();

//            //create int array of 5 int elements
//            int[] intArray = { 1,2,3,4,5 };
//            Console.WriteLine(@"Please select between index 0 and 4 to display an integer in the array. 
//Type an index value:");
//            string userIndexString2 = Console.ReadLine();//capture user input as a string.

//            int userIndex2 = Convert.ToInt32(userIndexString2);//convert input to an int

//            if (userIndex2 > 4)
//            {
//                Console.WriteLine("Sorry, the value at that index does not exist. Please enter a value between 0 and 4.");
//                Console.WriteLine(@"Please select between index 0 and 4 to display an integer in the array. 
//Type an index value:");
//            }
            
                

             
//            else
//            {
//                Console.WriteLine("You selected: " + intArray[userIndex2]);
//                Console.ReadLine();
                
//            }

            List<string> stringList = new List<string>();//instantiates a list object and holds it in a variable called stringList
            stringList.Add("Hello");
            stringList.Add("Goodbye");
            stringList.Add("Howcome");
            stringList.Add("And why");
            //added 4 string elements to the list



            Console.WriteLine("Please select an index number between (and including) 0 and 3 to display a list string value:");
            string userIndexString = Console.ReadLine();
            int userIndex = Convert.ToInt32(userIndexString);
            Console.WriteLine("You have selected: " + stringList[userIndex] + "! Well done.");
            Console.ReadLine();




        }


    }
}
