using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MethodSubmissionAssignment
{
    class math1
    {
        public int AddNum(int x, string yString = null)//the default value is unlikely to be entered by a user, hence no input means y=985497685 which means else block runs and ignores y
        {
            if (!string.IsNullOrEmpty(yString))//only executes if they DID enter a second number i.e. not true that yString is empty/null
            {
                int yInt = Convert.ToInt32(yString);
                int sum = x + yInt;
                return sum;
            }
            else//so if y is its default value, meaning null, ignore y and only compute with single user input x 
            {
                int sum = x + 5;
                return sum;
            }

        }
    }
}
