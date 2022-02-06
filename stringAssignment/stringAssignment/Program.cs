using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace stringAssignment
{
    class Program
    {
        static void Main(string[] args)
        {
            string one = "I am a lion";
            string two = ". I eat Greeneries.";
            string three = " Sometimes I like to sleep--A LOT.";
            StringBuilder sb = new StringBuilder();//instantiates object of class StringBuilder under name sb
            sb.Append(one);//adds string one to an empty StringBuilder object named sb
            sb.Append(two);//same as above: is appended to end of existing string.
            sb.Append(three);//same as above
            string four = "I like turtles";
            string five = "I like them A LOT";
            string six = "Turtles are LIFE";
            string combo = four + five + six;//concatenates three strings.
            string combo2 = combo.ToUpper();//converts newly concatenated string to all uppercase letters

            Console.WriteLine(sb);
            Console.WriteLine(combo2);
            Console.Read();
        }
    }
}
