using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwentyOneGameV2
{
    public class Dealer
    {
        public string Name { get; set; }
        public Deck Deck { get; set; }
        public int Balance { get; set; }

        public void Deal(List<Card> Hand)//dealer takes in a Hand (list of cards) from a player and adds a card to that hand from the Dealer's Deck
        {
            Hand.Add(Deck.Cards.First());//we take the first card in the Deck and add it to the player's hand that is passed in to deal; Cards is a property of Deck and is a list.
            Console.WriteLine(Deck.Cards.First().ToString() + "\n");//writing to console the card I am about to put into the deck--the card that was dealt
            //First() is a method available to a list which takes the very first element in the list 

            Deck.Cards.RemoveAt(0);//Removes the first card from the Dealer's Deck at index 0, as we just dealt that card to the player's hand 
        }
    }
}
//QUESTION: Why doesn't Dealer just inherit from Deck class? It would automatically inherit the Deck and you wouldn't have to re-create it again:
/* Inheritance is a IS A relationship, not a HAS A relationship:
    A Dealer IS NOT a Deck. A Dealer HAS A deck. Hence he cannot inherit from a Deck.
    In contrast, TwentyOneGame IS A Game, so it can inherit from the Game class. 
  *IF  HAS A thing, you include it as a class property: a Dealer HAS A Deck, therefore Deck is included as a class property
  *IF it IS A thing, then you can create a separate class that inherits from the thing that it is: therefore TwentyOneGame inherits from Game 
  These practices keep things more aligned with the real world and make it easier to think with

    Martin Fowler: COMPOSITION OVER INHERITANCE! That is what we described above: err on the side of adding a class as a property of another class over inheriting from it
    So if you're unsure if it is a IS A or a HAS A relationship, just put it in as a property*/