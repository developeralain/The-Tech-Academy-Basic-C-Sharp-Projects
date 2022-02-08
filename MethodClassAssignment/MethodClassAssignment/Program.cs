using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MethodClassAssignment
{
    class Program
    {
        static void Main(string[] args)
        {
            math1 mathMagic = new math1();
            mathMagic.mathPrint(3, 4);//runs void method in class object 
            Console.ReadLine();//keeps console open

            mathMagic.mathPrint(x: 3, y: 4);//also runs method but specifies in arguements passed the parameters by name
            Console.ReadLine();
        }
    }
}
