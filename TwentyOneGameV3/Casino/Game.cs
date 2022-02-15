using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Casino
{
    //in applying the Design towards Abstraction Principle, we want to make things generic. So when making Game class we think "What things apply to ALL games in general?"
    public abstract class Game//As an Abstract Class aka Base Class, we can never instantiate Game: we can only have other classes inherit from Game
    {
        private Dictionary<Player, int> _bets = new Dictionary<Player, int>();//we instantiate an empty dictionary object to avoid errors in trying to add to null dictionaries

        //the private _players and public Players lists are the same as a single get; set; list, except we are using the private list to instantiate a list object and avoid null list errors
        //we expand on the get; set; for public Players list to specify that we will be using the instantiated _players list to return and set values
        private List<Player> _players = new List<Player>();//instantiates an empty list so we never have a null list and this prevents errors from trying to populate a null list
        public List<Player> Players { get { return _players; } set { _players = value; } }//all games have a list of players playing the game; value represents w/e you're setting it as
        //your program will throw an error if you try to add something to a null, like a null list, hence we use above code to ensure we at least have an empty list to work with that is not null
        
        
        public string Name { get; set; }//all games have names (twenty one, poker, solitaire, etc.)
        //there was a dealer property here before but we deleted it b/c not all games have a dealer--instead we added it to twentyonegame class
        public Dictionary<Player, int> Bets { get { return _bets; } set { _bets = value; } }//keeps track of total $ each player has bet; value represents w/e they're setting it as
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