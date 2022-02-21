using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringFunctions
{
    class Program
    {
        static void Main(string[] args)
        {
            //string name = "Alain";
            //string quote = "This string has an \\ escape character.\nThis string starts on a new line.\tThis \"string\" is tabbed.";
            //string fileName = @"C:\users\alain\onedrive\desktop";

            ////you can call various functions on a string variable that has a string value
            //bool trueOrFalse = name.Contains("s");//checks if variable 'name' has the character 's' in it
            //bool trueOrFalse2 = name.EndsWith("n");//checks if variable 'name' ends with character 'n'

            //int length = name.Length; //outputs a numerical value representing the length in characters of a string

            //string name2 = name.ToUpper();//converts to upper case
            //string name3 = name.ToLower();//converts to all lower case


            //Console.WriteLine(quote);
            //Console.WriteLine(fileName);
            //Console.WriteLine(trueOrFalse);
            //Console.WriteLine(trueOrFalse2);
            //Console.WriteLine(length);
            //Console.WriteLine(name2);
            //Console.WriteLine(name3);

            //Console.ReadLine();

            //strings are IMMUTABLE: you cannot change them once made. They're allocated in memory. If you modify one, it merely creates another one. 
            //for example:
            //string name = "Jesse";
            //name = "Joe";
            //You just changed the value of name from Jesse to Joe, but in reality it preserved the old value in memory and merely created another place in memory and stored Joe...both still exist
            //This becomes problematic when, say, you need to concatenate and modify a string 10,000 times, like for a printing company: you really notice slowdown after 10,000...what do you do?
            //C# thought this through and the way around that is using the StringBuilder object, which is dynamic and allows a multiple of string modifications without a loss in performance.

            StringBuilder sb = new StringBuilder();//this creates an instance of the class stringbuilder, which allows string manipulation without high memory overhead
            sb.Append("My name is Alain");
            Console.WriteLine(sb);
            Console.Read();


        }
    }
}
