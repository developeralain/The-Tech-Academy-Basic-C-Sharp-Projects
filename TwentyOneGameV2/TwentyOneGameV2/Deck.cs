using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwentyOneGameV2
{
    public class Deck
    {
        public Deck()//we will use this constructor (a method that is called as soon as a class object is instantiated) to assign default values to property 'Cards' for all instantiated objects
                     //of class Deck immediately upon creation...this constructor will append all 52 card objects to the deck object's property 'Cards' via embedded foreach loops
        {
            //each card has 4 suits (hearts, clubs, spades, diamonds) and there's 13 faces (2,3,4 ..., Jack, King ... etc.) ...  4 suits x 13 faces = 52 total cards in a deck
            //for each face in that list of 13 faces we need to loop through it 4 times: once for each suit ...
            //we will implement this by making a nested foreach loop!

            //This block of code was commented out b/c we have to re-engineer things as we modified Suits to be an enum datatype
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

        public void Shuffle(int times = 1)//int times = 1 means by default this will shuffle only once unless the user provides another parameter to override the default
                                                                                   //you create an option parameter, like int times = 1, by giving it a default value.
                                                                                   //public:accessible everywhere, static:do not need to first instantiate Program class, Deck:datatype of method, Shuffle:name of method, Deck deck:
                                                                                   //datatype is Deck and we are calling the instantiated Deck class object 'deck' (hence Deck deck; we're calling it deck and it is of Deck datatype)
        {
            
            for (int i = 0; i < times; i++)
            {
                
                List<Card> TempList = new List<Card>();//creating an empty list of cards
                Random random = new Random();//we are instantiating a class object called random of C#'s Random class, which has methods that allow us to randomize things (useful to shuffle a deck)

                while (Cards.Count > 0)//we will take random card out of the deck and store it in our TempList until our deck.Cards.Count is at 0 
                {
                    int randomIndex = random.Next(0, Cards.Count);//generates a random number b/w 0 (min value) and 52 (max value)
                    TempList.Add(Cards[randomIndex]);//uses the randomly generated number (randomIndex) to pull a card of that index from deck and store it in TempList sequentially (indices 0,1,2...)
                    Cards.RemoveAt(randomIndex);//this removes the card that was just added to TempList from deck.Cards, decreasing the total cards in deck.Cards by 1

                }
                this.Cards = TempList;//this transfers the 'shuffled' TempList of Cards over to the empty deck.Cards list of Cards, thus populating it with a shuffled deck of 52 cards.
                //the this.Cards is redundant, as Cards alone is fine. Cards property automatically pertains to this method...whether you write this. or not... this. means the method is referring to
                //itself: to its own object.
            }

            

        }
    }
}
