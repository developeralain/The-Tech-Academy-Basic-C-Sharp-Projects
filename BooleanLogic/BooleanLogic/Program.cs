using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BooleanLogic
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine(true && false); //evaluates to false, because AND is looking for TRUE and TRUE to output TRUE
            //Console.WriteLine(true && true);//evaluates to true
            //Console.WriteLine(false && false);//evaluates to false
            //Console.ReadLine();

            //Console.WriteLine(true || true);//true
            //Console.WriteLine(true || false);//true
            //Console.WriteLine(false || false);//false
            //Console.ReadLine();

            //Console.WriteLine(true == true);
            //Console.WriteLine(true == false);
            //Console.WriteLine(false == false);
            //Console.ReadLine();

            //Console.WriteLine(true != true);//false
            //Console.WriteLine(true != false); //true
            //Console.WriteLine(false != false); //false
            //Console.ReadLine();

            //below is the XOR operator: evalutes to true if one of these are true, but NOT both!
            Console.WriteLine(true ^ true);//false
            Console.WriteLine(true ^ false);//true
            Console.WriteLine(false ^ false);//false
            Console.ReadLine();
        }
    }
}
