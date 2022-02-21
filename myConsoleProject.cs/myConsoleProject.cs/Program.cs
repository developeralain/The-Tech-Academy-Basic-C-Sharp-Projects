using System;
//using System.Collections.Generic;//Collections is a namespace that contains specialized classes that store a series of values/objects, as well as interfaces. Generic collections are strongly-typed & typesafe (like dictionaries)
//using System.Linq;//Linq is a namespace pertaining to the database that allows you to run queries on data such as "find first person by name of "John"
//using System.Text;//Text is a namespace that allows you to call various functions that manipulate strings
//using System.Threading.Tasks;//A section of the base class library (being System) that deals with having a CPU do two things at once (Multiple threads)
//above, anything that is dulled out means that it hasn't been used yet within the code of this file.

//namespace is an added layer of organization for our code. It is listed above class. Namespaces make it easier to remember where items are stored. 
namespace myConsoleProject.cs
{
    //in a console application, the Program class is the main class. The computer searches for this class, along with the Main() method, as the place to start the application
    class Program
    {
        static void Main()
        {
            Console.WriteLine("What is your name?");
            //Notice that using System is no longer grayed out. This is because the Console.WriteLine() method is part of the System library, which is now officially being “used” in our application.
            string name = Console.ReadLine();
            Console.WriteLine("Hello, " + name + "!");
            Console.Read();//this prevents the window from closing until you do so manually, thus allowing you time to actually read the output it writes


        }
    }
}
