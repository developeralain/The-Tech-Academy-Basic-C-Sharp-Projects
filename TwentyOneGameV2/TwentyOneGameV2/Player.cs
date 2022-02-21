using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwentyOneGameV2
{
    public class Player
    {
        public List<Card> Hand { get; set; }
        public int Balance { get; set; }
        public string Name { get; set; }
        public bool isActivelyPlaying { get; set; }

        //ADDING OVERLOADED OPERATOR METHOD: so we can do Game + Player and it will add the player to the game
        //Our goal is to go Game + Player and Player will automatically be added to the list of Players property of the Game object
        public static Game operator+ (Game game, Player player)//we're adding a game and we're adding a player, and it's returning a game with that player added
        {
            game.Players.Add(player);//players is a list which has an Add() method built-in, so we call it and add player to the Players list of the game object
            return game;
        }
        public static Game operator- (Game game, Player player)//we're adding a game and we're adding a player, and it's returning a game with that player removed
        {
            game.Players.Remove(player);//players is a list which has a Remove() method built-in, so we call it and add player to the Players list of the game object
            return game;
        }
    }
}
//WHAT IS HAPPENING WITH OVERLOADED OPERATOR+ METHOD: public static Game operator+ (Game game, Player player)
/*
 We're overloading the operator + 
 it's taking two operands: a game and a player 
 and it's returning a game
 it takes the game, adds player to it, and returns game

NOTES ABOUT OUR OVERLOADED OPERATORS
 * Polymorphism is at play because we are adding class Player to class Game and we're returning a game
 because we're using class Game and not class TwentyOneGame, this method will work for any future game
 *
 */