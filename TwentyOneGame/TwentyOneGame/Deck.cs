using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwentyOneGame
{
    public class Deck
    {
        public Deck()//we will use this constructor (a method that is called as soon as a class object is instantiated) to assign default values to property 'Cards' for all instantiated objects
                     //of class Deck immediately upon creation...this constructor will in face append all 52 card objects to the deck object's property 'Cards' via embedded foreach loops
        {
            //each card has 4 suits (hearts, clubs, spades, diamonds) and there's 13 faces (2,3,4 ..., Jack, King ... etc.) ...  4 suits x 13 faces = 52 total cards in a deck
            //for each face in that list of 13 faces we need to loop through it 4 times: once for each suit ...
            //we will implement this by making a nested foreach loop!

            List<string> Suits = new List<string>() { "Clubs", "Hearts", "Diamonds", "Spades" };//there are 4 suits inside of this list
            List<string> Faces = new List<string>()//there are 13 Faces inside this list
            {
                "Two", "Three", "Four", "Five", "Six", "Seven", "Eight", "Nine", "Ten", "Jack",
                "King", "Queen","Ace"
            };
            Cards = new List<Card>();//constructor runs and automatically sets the value for property Cards as an empty list of Card objects
            foreach (string face in Faces)
            {
                foreach (string suit in Suits)
                {
                    Card card = new Card();//this variable 'card' only exists for the duration of each loop cycle/iteration. When the next interation begins, it is wiped out anew and re-created anew.
                    card.Suit = suit;
                    card.Face = face;
                    Cards.Add(card);
                }
            }
            
            ////using the below code would require that we manually add 51 more cards in this fashion to the constructor...that takes a lot of time
            //Cards = new List<Card>();//we are setting the Card property's value to be an empty List that stores Card data types inside of it. 
            ////Each time a Deck is instantiated it will automatically give Cards property this value.
            //Card cardOne = new Card();
            //cardOne.Face = "Two";
            //cardOne.Suit = "Hearts";
            //Cards.Add(cardOne);
        }
        public List<Card> Cards { get; set; }//this Deck class will have a property 'Cards' which will be a List of datatype 'Card' (it will be a list of cards, as opposed to a list of integers)
    }
}


//The Deck is a collection of cards.
//We use List datatype as it is easier to work with and will help explain concepts along the way.