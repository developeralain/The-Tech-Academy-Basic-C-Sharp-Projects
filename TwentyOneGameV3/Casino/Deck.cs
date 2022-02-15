using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Casino
{
    public class Deck
    {
        public Deck()//we will use this constructor (a method that is called as soon as a class object is instantiated) to assign default values to property 'Cards' for all instantiated objects
                     //of class Deck immediately upon creation...this constructor will append all 52 card objects to the deck object's property 'Cards' via embedded foreach loops
        {
            Cards = new List<Card>();

            //This embedded for loop will run a total of 52 times b/c 13 * 4 = 52, and for each run we will create a new card for a full deck of cards
            for (int i = 0; i < 13; i++)//we first loop through all faces, which have an index range of 0 through 13 (hence loop stop condition is < 13)
            {
                for (int j=0; j < 4; j++)
                {
                    Card card = new Card();
                    card.Face = (Face)i;//each enum datatype Face element has an underlying integer value, i, by default this value starts at 0 and goes up by 1 for each subsequent element (0,1,2,...)
                    card.Suit = (Suit)j;//(Suit) casts the underlying integer datatype, j, of the enum datatype element to its Suit datatype (being a string value that corresponds to j)
                    Cards.Add(card);//each cycle a card is made with its Face and Suit properties initialized and the card is added to Cards list attribute of the Deck class
                }
            }
            //after embedded for loops have run 52 times, you'll have a fully populated list of 52 cards for the Cards property of the deck
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