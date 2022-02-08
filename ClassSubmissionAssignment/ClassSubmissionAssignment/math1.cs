using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassSubmissionAssignment
{
    class math1
    {
        public void Math(string x)//void: this method outputs nothing: no value is returned to caller.
        {
            int xInt = Convert.ToInt32(x);
            int quotient = xInt / 2;
            Console.WriteLine("Your number / 2 is : " + quotient);

        }

        public int Add(string x, out int addThis)//int: this method returns the computed sum to the caller. It also returns addThis (number it is adding to x) to a variable of same name in Program.cs
        {
            int xInt = Convert.ToInt32(x);
            int add = 12;
            int sum = xInt + add;
            addThis = add;
            return sum;

        }

        public int Add(string x)//int: this method returns the computed sum to the caller and is a Method Overload of the above method (difference is it omits the out parameter)
        {
            int xInt = Convert.ToInt32(x);
            int add = 12;
            int sum = xInt + add;

            return sum;
        }
    }
}
