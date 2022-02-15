using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Casino
{
    public class Player
    {
        public Player(string name, int beginningBalance)//our constructor that automatically executes upon instantiating a Player class object
        {
            Hand = new List<Card>();//we instantiate the hand property as an empty list object
            Balance = beginningBalance;//assigns second argument beginningBalance to the Balance property of the class
            Name = name;//assigns first argument name to the Name property of the class

        }
        private List<Card> _hand = new List<Card>();
        public List<Card> Hand { get { return _hand; } set { _hand = value; } }
        public int Balance { get; set; }
        public string Name { get; set; }
        public bool isActivelyPlaying { get; set; }
        public bool Stay { get; set; }//when a player stays it means they don't want another card from the dealer
        public Guid Id { get; set; }//property that allows for the setting of a unique ID using the C# Guid built-in class

        //We create bet logic within the player class b/c we want to keep logic enclosed within the relevant entity  as per OOP principles
        public bool Bet(int amount)//why a bool? B/c we want to bake into the logic of the method whether the player even has enough $ to bet or not
        {
            if (Balance - amount < 0)//if player bets more $ than he has 
            {
                Console.WriteLine("You do not have enough to place a bet that size.");
                return false;//means bet didn't work, it failed
            }
            else
            {
                Balance -= amount;
                return true;
            }
        }
        //ADDING OVERLOADED OPERATOR METHOD: so we can do Game + Player and it will add the player to the game
        //Our goal is to go Game + Player and Player will automatically be added to the list of Players property of the Game object
        public static Game operator +(Game game, Player player)//we're adding a game and we're adding a player, and it's returning a game with that player added
        {
            game.Players.Add(player);//players is a list which has an Add() method built-in, so we call it and add player to the Players list of the game object
            return game;
        }
        public static Game operator -(Game game, Player player)//we're adding a game and we're adding a player, and it's returning a game with that player removed
        {
            game.Players.Remove(player);//players is a list which has a Remove() method built-in, so we call it and add player to the Players list of the game object
            return game;
        }
    }
}
