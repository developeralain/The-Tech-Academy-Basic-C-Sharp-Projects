using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MethodSubmissionAssignment
{
    class math1
    {
        public int AddNum(int x, int y = 985497685)//the default value is unlikely to be entered by a user, hence no input means y=985497685 which means else block runs and ignores y
        {
            if (y != 985497685)//meaning if user enters any second value (i.e. y = any number other than its default value)
            {
                int sum = x + y;
                return sum;
            }
            else//so if y is its default value, ignore y and only compute with single user input x 
            {
                int sum = x + 5;
                return sum;
            }

        }
    }
}
