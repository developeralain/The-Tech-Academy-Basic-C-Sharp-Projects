using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwentyOneGameV2
{
    public class TwentyOneGame : Game, IWalkAway
    {
        public override void Play()//this is an abstract method of the Game abstract class. We mimic the datatype (void) and name/parameters of the abstract method, but use 
                                    //override keyword to allow us to include our own implementation details.
        {
            throw new NotImplementedException();//makes sure that if you try to use this method, it will throw an exception.
        }

        public override void ListPlayers()//this is a virtual method of the Game abstract class. We use the override keyword to add our own implementation details to it.
        {
            Console.WriteLine("21 Players:");//this is code not existing in the Game class' virtual method, but code that we added ourselves for this class specifically
            base.ListPlayers();//this is equivalent to the code that exists within this virtual method in the Game class (it encapsulates the existing logic of this method)
        }
        public void WalkAway(Player player)//b/c this class inherits from interface IWalkAway, it MUST implement its methods as well
            //you must match the interface method's return type, being 'void'. If you tried to make the return type 'int', it wouldn't work.
        {
            throw new NotImplementedException();
        }
    }
}
//ABSTRACT METHOD:
/*This Class inherits from abstract Game class, which has the abstract method Play():
  This means it MUST implement Play(): the code will not run, this will not compile, unless you include Play() and implement it. That is the significance of having an abstract method.
*/