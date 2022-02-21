using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathAndComparisonOperators
{
    class Program
    {
        static void Main(string[] args)
        {
            //int total = 5 + 10;
            //Console.WriteLine("Five plus Ten = " + total);//compiler implicitly casts int total to string data type and concatenates 
            //Console.ReadLine();

            //int total = 5 + 10;
            //Console.WriteLine("Five plus Ten = " + total.ToString());//this ToString() method is redundant, as it's unnecessary, but instructor Jesse does it 
            //Console.ReadLine();

            //int total = 5 + 10;
            //int otherTotal = 12 + 22;
            //int combined = total + otherTotal;
            //Console.WriteLine(combined);//this ToString() method is redundant, as it's unnecessary, but instructor Jesse does it 
            //Console.ReadLine();

            //int difference = 10 - 5;
            //Console.WriteLine("Ten minus Five = " + difference);
            //Console.ReadLine();

            //int product = 10 * 5;
            //Console.WriteLine(product);
            //Console.ReadLine();

            //int quotient = 100 / 17;
            //Console.WriteLine(quotient);
            //Console.ReadLine();
            ////the output of this is 5, which isn't accurate but integers can only be whole numbers, so decimals are ignored.

            //double quotient = 100 / 17;//the compiler implicitly assigns 100 and 17 as integers...thus quotient will store 5 as its answer, which isn't accurate.
            //Console.WriteLine(quotient);
            //Console.ReadLine();
            ////output is 5, despite making quotient a double, because compiler assigns 100 and 17 as integers (whole numbers) and thus computes the quotient as an integer as well.

            ////we add .0 to the end of 100 and 17 to tell the compiler that we are working with doubles. This outputs an accurate double with decimals included.
            //double quotient = 100.0 / 17.0;
            //Console.WriteLine(quotient);
            //Console.ReadLine();
            ////this outputs, accurately, 5.88235294117647
            ///

            //int remainder = 10 % 2;
            //Console.WriteLine(remainder);
            //Console.ReadLine();

            //bool trueOrFalse = 12 > 5;
            //Console.Write(trueOrFalse);
            //Console.ReadLine();

            //int roomTemperature = 70;
            //int currentTemperature = 72;

            //bool isWarm = currentTemperature >= roomTemperature;
            //Console.WriteLine(isWarm);
            //Console.ReadLine();

            int roomTemperature = 70;
            int currentTemperature = 72;

            bool isWarm = currentTemperature != roomTemperature;
            Console.WriteLine(isWarm);
            Console.ReadLine();


        }
    }
}
