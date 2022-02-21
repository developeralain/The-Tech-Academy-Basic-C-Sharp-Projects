using System;




    class Program
    {
        static void Main()
        {
        Console.WriteLine("Hello, \"World!\"");
        Console.ReadLine();//this keeps the window open until we close it, otherwise it closes right away and we can't see "Hello, World!" in the console
        }
    }

//a namespace is a part of a library that you may want to use (we're just using the system namespace for now)
//you can also make your own namespaces in order to refer to code within a namespace from another application
//when a console app starts, it looks for class Program --> Main() ... that is the entrance point for the application 
//A solution is a way of organzing related projects...it doesn't do anything by itself. Here out solution is called 'HelloWorld' and it has one project inside also called 'HelloWorld'
//When you compile a project, it compiles down to a .exe or a .dll--that is what a project is: a grouping of files that will compile down to either .exe or .dll files