using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BranchingAssignment
{
    class Program
    {
        static void Main(string[] args)
        {   //Introductory statements
            Console.WriteLine("Welcome to Package Express. Please follow the instructions below.");
            Console.WriteLine("What is the package weight? Please enter only a number representing lbs (pounds).");
            double pWeight = Convert.ToDouble(Console.ReadLine());//stores weight as int upon conversion from string

            //filters out packages > 50 lbs
            if (pWeight > 50)
            {
                Console.WriteLine("Package too heavy to be shipped via Package Express. Have a good3 day.");
                Console.ReadLine();
            }
            //if package < 50 lbs, program proceeds below
            else
            {
                Console.WriteLine("What is the package width? Please enter only a number representing inches.");
                double pWidth = Convert.ToDouble(Console.ReadLine());

                Console.WriteLine("What is the package height? Please enter only a number representing inches.");
                double pHeight = Convert.ToDouble(Console.ReadLine());

                Console.WriteLine("What is the package length? Please enter only a number representing inches.");
                double pLength = Convert.ToDouble(Console.ReadLine());

                double pDimensions = pWidth + pHeight + pLength;

                //if dimensions > 50 inches, program exits after displaying message to user
                if (pDimensions > 50)
                {
                    Console.WriteLine("Package too big to be shipped via Package Express.");
                    Console.ReadLine();
                }
                //if dimensions < 50 inches, program proceeds with calculating a quote and printing it for the user to see in dollars
                else
                {
                    double pQuote = (pHeight * pLength * pWidth * pWeight) / 100;
                    double pQuoteDollars = Math.Round((Double)pQuote, 2);//this rounds the decimals to 2 places only, like a monetary figure should be

                    Console.WriteLine("The quote for your shipment is : $" + pQuoteDollars);
                    Console.ReadLine();
                }

            }
            
        }
    }
}
