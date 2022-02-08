using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassSubmissionAssignment
{
    class Program
    {
        static void Main(string[] args)
        {
            math1 mathMagic = new math1();//instantiate math1 class object as mathMagic

            Console.WriteLine("Please enter a number, sir or madame: ");
            string x = Console.ReadLine();
            mathMagic.Math(x);
            

            
            Console.WriteLine("Another number, if you please: ");
            
            string userInput = Console.ReadLine();//stores user input as string
            int addThis; //this variable will store the output value returned from mathMagic's Add method.
            int sum = mathMagic.Add(userInput, out addThis);//passes userInput string to Add method along with required arguments
            Console.WriteLine("Your magic math result is : {0}, which is the result of adding {1} to {2}.", sum, addThis, userInput);//displays math operation result, what was added to it via our out parameter, and value user inputted 
            

            Console.WriteLine("Type yet another number, if you please: ");

            string userInput2 = Console.ReadLine();//stores user input as string
            
            int sum2 = mathMagic.Add(userInput);//passes userInput string to Add method along with required arguments
            Console.WriteLine("Your magic math result is : {0}.", sum2);//displays math operation result, what was added to it via our out parameter, and value user inputted 
            


            //ALL OF THE ABOVE, EXCEPT WITH A STATIC VERSION OF THE CLASS (SAME CLASS METHODS, BUT STATIC)


            Console.WriteLine("Please enter a number, sir or madame: ");
            string x2 = Console.ReadLine();
            math1s.Math(x2);//because this is a static version of the same class & methods we used above, we don't need to instantiate it prior to using its methods.
      


            Console.WriteLine("Another number, if you please: ");

            string userInput3 = Console.ReadLine();//stores user input as string
            int addThis2; //this variable will store the output value returned from mathMagic's Add method.
            int sum3 = math1s.Add(userInput3, out addThis2);//passes userInput string to Add method along with required arguments
            Console.WriteLine("Your magic math result is : {0}, which is the result of adding {1} to {2}.", sum3, addThis2, userInput3);//displays math operation result, what was added to it via our out parameter, and value user inputted 
            

            Console.WriteLine("Type yet another number, if you please: ");

            string userInput4 = Console.ReadLine();//stores user input as string

            int sum4 = math1s.Add(userInput4);//passes userInput string to Add method along with required arguments
            Console.WriteLine("Your magic math result is : {0}.", sum4);//displays math operation result, what was added to it via our out parameter, and value user inputted 
            Console.Read();


        }
    }
}
