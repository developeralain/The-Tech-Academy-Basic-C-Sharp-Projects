using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwentyOneGameV2
{
    //in applying the Design towards Abstraction Principle, we want to make things generic. So when making Game class we think "What things apply to ALL games in general?"
    public abstract class Game//As an Abstract Class aka Base Class, we can never instantiate Game: we can only have other classes inherit from Game
    {
        public List<Player> Players { get; set; }//all games have a list of players playing the game
        public string Name { get; set; }//all games have names (twenty one, poker, solitaire, etc.)
        public string Dealer { get; set; }//all games, for our purposes of card games, have a dealer

        public abstract void Play();//An abstract method that any class inheriting from Game must have, along with same return type, name, and parameters
        public virtual void ListPlayers()//this void method doesn't return anything (b/c it is void), it just prints the Players list to show who is playing the game currently
            //this ListPlayers() method is a Virtual Method: inheriting class acquires its implementation details BUT they can be overriden
        {
            foreach (Player player in Players)
            {
                Console.WriteLine(player.Name);
            }
        }
    }
}
//PLAY() METHOD AS PART OF ABSTRACT CLASS Game: we can have other classes inherit the Play() method from Game
/*It would be impossible to have the implementation logic of the play() method be implemented specifically for every class that derives from Game: there's too much variety in how different games
  are played. Solitaire, Poker, etc. ... so we can't generalize the logic, but ...
 * It is valuable for Game to have a play() method because all derived games require a play method, the specifics of which can be hashed out within the given derivative class...
 * Benefits: all games can be played, makes life easy if start of every game was a method called Play(), easier to add features in the future and keeps things organized
 * How do we make it so every Class that inherited the Play() method had the exact same look to it? 
 * We add an Abstract Method: a method that is marked with abstract keyword; can only exist inside an abstract class; contains no implementation; all it does is state:
   any class inheriting this class must inherit this method
  An abstract method is a contract b/w abstract class an inheriting class saying the inheriting class must implement this method; inheriting class must define method somewhere in its class
and must have exact same name, return type, and parameters */

//LISTPLAYERS() METHOD AS A VIRTUAL METHOD:
/*Right now our ListPlayers() method is inherited by default for any inheriting class (e.g. TwnetyOneGame). What if we wanted inheriting classes to have their own implementations of this method?
 * Enter Virtual Methods:
 * Virtual methods exist only inside of abstract classes
 * We use the 'virtual' keyword to create a virtual method
 * A virtual method means that this method gets inherited by the inherting class (e.g. TwentyOneGame), but it can be overriden by the inheriting class*/