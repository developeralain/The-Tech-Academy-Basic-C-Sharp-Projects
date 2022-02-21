using System;
using System.Collections.Generic;//this is used with lists and arrays b/c you can contain any data type within these


namespace ArraysAndLists
{
    class Program
    {
        static void Main(string[] args)
        {   
            //BELOW ARE EXPLANATIONS AND EXAMPLES FOR LISTS: MUCH MORE ADATABLE AND MORE COMMONLY USED THAN ARRAYS
            List<int> intList = new List<int>();
            intList.Add(4);
            intList.Add(10);
            intList.Remove(10);

            Console.WriteLine(intList[0]);
            Console.Read();



            //BELOW REPRESENTS EXPLANATIONS AND EXAMPLES FOR ARRAYS ... THEY ARE LESS ADAPTABLE THAN LISTS
            //When do you use arrays over lists? When there's some fixed quantity of related data that isn't going to change
            //You'd also use arrays when you're storing a very large quantity of something:
            /*For example to store images in a table using C# you use a byte array, and from there you can perform a C#
             action to store it in the database: byte[] byteArray = */

            //int[] numArray = new int[5];//instantiate an array object of class array

            ////[5] is pre-defining the length of an array, with is required for a blank array that you fill afterwards
            //numArray[0] = 5;
            //numArray[1] = 2;
            //numArray[2] = 10;
            //numArray[3] = 200;
            //numArray[4] = 5000;
            ////that took a long time to include those numbers into the array...there;s a better way!

            //int[] numArray1 = new int[] { 5, 2, 10, 200, 5000, 600, 2300 };//easier way to insert values into an array off the bat
            ////the above method doesn't require you specify length of array off the bat as you are pre-filling the values
            ////for ANY array, once you set its length, whether explicitly or by inserting values at the onset, it is fixed
            ////at that length...that is a distinct characteristic for arrays in C#

            ////actually, you don't even need to specify new int[] when you pre-fill an array:
            //int[] numArray2 = { 5, 2, 10, 200, 5000, 600, 2300 };

            ////if I wanted to changed 600 to 650 in numArray2 I would do this:
            //numArray2[5] = 650;
            ////you can target specific elements of an array after you've created it, but you are limited to its fixed size


            //Console.WriteLine(numArray2[5]);
            //Console.Read();
        }
    }
}

//to create an array in C# you must instantiate a class object first, b/c they're considered objects in C#
//you must define length of array before you begin...how many elements will it hold?
