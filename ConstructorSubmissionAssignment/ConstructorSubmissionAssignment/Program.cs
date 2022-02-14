using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConstructorSubmissionAssignment
{
    class Program
    {
        static void Main(string[] args)
        {
            const string myName = "Alain";//declares a constant 
            Console.WriteLine(myName);
            var favFruit = "Apple";
            Console.WriteLine(favFruit);

            Dog dog = new Dog("Pebbles");//instantiates new Dog object as dog and passes in 1 parameter only, using chained constructors 
            Console.WriteLine(dog.Prefix + dog.Name); //OUTPUT = "Mr. Pebbles"


            Dog doggie = new Dog("Mr. ", "Doggles");//instantiates new Dog object as doggie and passes in 2 parameters
            Console.WriteLine(doggie.Prefix + doggie.Name);//OUTPUT = "Mr. Doggles"
            Console.Read();

        }
    }
}
