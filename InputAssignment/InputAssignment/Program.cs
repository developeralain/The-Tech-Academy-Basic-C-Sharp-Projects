using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace InputAssignment
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please enter in a number: ");
            string userNum = Console.ReadLine();
            using (StreamWriter fileNums = new StreamWriter(@"C:\Users\Alain\OneDrive\Desktop\Basic_C#_Programs\log.txt", true))//instantiates StreamWriter object as fileNums, given absolute path to log file
            {
                fileNums.WriteLine(userNum);//writes user string as a line into our log.txt file using StreamWriter object fileNums
            }                                                                                                             //and append set as 'true'

            string content = File.ReadAllText(@"C:\Users\Alain\OneDrive\Desktop\Basic_C#_Programs\log.txt");//reads the file in the specified file path (the one we just wrote to)
            Console.WriteLine(content);//prints the contents of the log.txt file we just wrote to, to the console
            Console.Read();


        }
    }
}
