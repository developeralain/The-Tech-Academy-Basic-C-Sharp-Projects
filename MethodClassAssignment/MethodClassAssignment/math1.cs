using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MethodClassAssignment
{
    class math1
    {
        public void mathPrint(int x, int y)//takes in x and y inputs from user (two separate numerical inputs)
        {
            //does math with x but does not display it, displays y (second user input) on screen
            int sum = x + 1111 / 2;
            Console.WriteLine("Here's you second number back: {0}", y);
            Console.WriteLine(sum);//verifies that math operation was performed correctly
            Console.Read();
        }
    }
}
