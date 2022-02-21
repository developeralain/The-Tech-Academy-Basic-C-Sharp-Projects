using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace switchStatement
{
    class Program
    {
        static void Main(string[] args)
        {
            int favoriteNum = 13;

            switch (favoriteNum)
            {
                case 13:
                    Console.WriteLine("You're unlucky!");
                    Console.ReadLine();
                    break;
                case 14:
                    Console.WriteLine("You're 1 away from being unlucky!");
                    Console.ReadLine();
                    break;
                case 100:
                    Console.WriteLine("You are WAAAAY off, pal!");
                    Console.ReadLine();
                    break;
                default:
                    Console.WriteLine("Uhh, try again?");
                    Console.ReadLine();
                    break;

            }
        }   
    }
}
