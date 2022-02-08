using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainMethodAssignment
{
    class math1
    {
        public int AddNum(int x)//publicly accessible integer method that takes in an integer and outputs int
        {
            int y = x + 5;//adds 5 to what was passed into it as an argument (x) and stores it as y
            return y;//returns y to code that called it
        }
        //below methods follow same logic / explanations as above
        public int SubNum(decimal x)//publicly accessible int method that takes in a decimal and returns int
        {
            decimal y = x - 5;//computes with decimals
            int yInt = Convert.ToInt32(y);//converts outcome of subtraction operation to an int value
            return yInt;//returns integer
        }
        public int MultiNum(string x)//publicly accessible int method that takes in a string & outputs int
        {
            int yInt = Convert.ToInt32(x);//convert to int
            int y = yInt * 5;
            return y;
        }
    }
}
