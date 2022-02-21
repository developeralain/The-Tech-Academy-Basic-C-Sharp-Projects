using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwentyOneGame
{
    //TWENTYONE AKA BLACKJACK GAME: 
    /*This game demonstrates almost all aspects of C# that will be taught in the course quite well.
     * A big part of this will be learning C# classes and objects 
     * We will go back and re-factor code: the process of going over old code and making it more efficient, extensible, and readable
     * This will model important parts of C# 

     * HOW THE GAME WORKS: player vs dealer ... person to get closest to 21 without going over wins
     * Dealer: has specific rules to follow re: how many cards he can take
     * Player: can take as many or as few cards as he likes
     */

    //NOTE ON OBJECTS:
    /*The backbone of object-oriented programming
     * Objects are items that can be represented by a program. They're meant to represent real world things quite often.
     * Objects have STATE and BEHAVIOR: 
     * STATE: Size, Color, Etc. at any point in time 

     We will create basic models for objects and give these models properties*/
    class Program
    {
        static void Main(string[] args)
        {
            Deck deck = new Deck();//we have instantiated an object of datatype (also, of class) Deck that we are storing in a variable called deck...it would be empty until assigned values;
            //however, we created a constructor method within Deck object that automatically populates an entire deck of cards under its 'Card' property, which is a list. 

            int timesShuffled = 0;//initialized variable timesShuffled so that when Shuffle method returns the out parameter timesShuffled, it can be stored here

            //deck = Shuffle(deck);//we call Shuffle method (below) and pass deck into it: it returns a shuffled deck object that we store in deck 
            deck = Shuffle(deck, out timesShuffled, 3);//we pass in deck and 3, we get back deck which is stored in deck. We also get back timesShuffled which is not stored in deck but in timesShuffled
            //The below foreach loop allows us to print the contents of our deck; each list element--each element being of datatype Card, also an object-- of the deck object's property 'Cards'
            //is printed into the console for inspection. This allows us to see every card as a combination of its Face and Suit in a "Face of Suit" format
            foreach (Card card in deck.Cards)
            
            {
                Console.WriteLine(card.Face + " of " + card.Suit);
                
            }
            Console.WriteLine(deck.Cards.Count);
            Console.WriteLine("Times shuffled: {0}", timesShuffled);//this is a method of formatting strings similar to what we learned in Python where {0} stores timesShuffled's value.
            Console.Read();



            //BELOW CODE COMMENTED OUT: the below code would require you to do a lot of manual coding, whereas we will simply create a constructor for the Deck class to make our job easier.

            //deck.Cards = new List<Card>();//deck object has one property called Cards, which is a list. deck has a property called Cards which is of data type List<Card>
            //                              //in order to assign anything to a list you must first instantiate a list object using the new keyword (as above with 'new List<Card>();')

            ////in order to add a card to this property Cards--to this list--for object deck, we must first create a card

            //Card cardOne = new Card();//we have an object of data type Card assigned to the variable cardOne (uses camelCase as naming convention for variables in C#)
            ////we've instantiated the object but it is empty; it has no values. We need to give the properties (Suit and Face) some values

            //cardOne.Face = "Queen";//we have set the value of Face to 'Queen' for our cardOne object of class Card
            //cardOne.Suit = "Spades";//we have set the value of Suit to 'Spades' for our cardOne object of class Card


            ////let us add our first card to our deck 
            //deck.Cards.Add(cardOne);//we've added one card to this deck!





        }
        public static Deck Shuffle(Deck deck, out int timesShuffled, int times = 1)//int times = 1 means by default this will shuffle only once unless the user provides another parameter to override the default
            //you create an option parameter, like int times = 1, by giving it a default value.
            //public:accessible everywhere, static:do not need to first instantiate Program class, Deck:datatype of method, Shuffle:name of method, Deck deck:
            //datatype is Deck and we are calling the instantiated Deck class object 'deck' (hence Deck deck; we're calling it deck and it is of Deck datatype)
        {
            timesShuffled = 0;
            for (int i = 0; i < times; i++)
            {
                timesShuffled++;//this is our out parameter: it increments each time the loop runs so we can keep track of how many times the deck was shuffled within timesShuffled variable
                List<Card> TempList = new List<Card>();//creating an empty list of cards
                Random random = new Random();//we are instantiating a class object called random of C#'s Random class, which has methods that allow us to randomize things (useful to shuffle a deck)

                while (deck.Cards.Count > 0)//we will take random card out of the deck and store it in our TempList until our deck.Cards.Count is at 0 
                {
                    int randomIndex = random.Next(0, deck.Cards.Count);//generates a random number b/w 0 (min value) and 52 (max value)
                    TempList.Add(deck.Cards[randomIndex]);//uses the randomly generated number (randomIndex) to pull a card of that index from deck and store it in TempList sequentially (indices 0,1,2...)
                    deck.Cards.RemoveAt(randomIndex);//this removes the card that was just added to TempList from deck.Cards, decreasing the total cards in deck.Cards by 1

                }
                deck.Cards = TempList;//this transfers the 'shuffled' TempList of Cards over to the empty deck.Cards list of Cards, thus populating it with a shuffled deck of 52 cards.
            }

            return deck;

        }
        //Below method represents Method Overloading: same name as above Shuffle method except it has 2 parameters which allows the compiler to distinguish it from other Shuffle method
        //The purpose of this shuffle method is it allows a user to specify how many times they'd like the deck shuffled. This method essentially iterates through the prior Shuffle method 
        //however many times the user specified and returns deck...we commented it out b/c we are using a default value for the above Shuffle to only shuffle once unless otherwise specified.
        //I.E. we condensed both this method and the above method into a single method that can perform both functions, hence we commented out the below Method Overload.

        //METHOD OVERLOADING SHUFFLE METHOD
        //public static Deck Shuffle(Deck deck, int times)
        //{
        //    for (int i = 0; i < times; i++)
        //    {
        //        deck = Shuffle(deck);
        //    }
        //    return deck;
        //}
    }
}
//WHAT ARE METHODS?
//They are blocks of reusable code that do something! Also known as: functions, routines, etc.
//METHOD COMPOSITION:
/*Access modifier: states if method is available throughout program or just within the class (i.e. public or private) 
 * Return Type: specifies the class or datatype being returned (e.g. int)...void means nothing is being returned, as in static void Main(string) above
 * Parameters: e.g. Main() method takes a string[] (array) of args
 * Class: methods have to be part of a class. If a method is being used without first creating an object of that class then it has to be marked static (e.g. static void Main() above)
 * to expand on Class, we did not instantiate an object of class Program before using the Main() method, hence we had to use static keyword on it for it to work*/

//METHOD OVERLOADING
/*Where you can create as many functions as you want with the same name as long as they're kind of different: the compiler has specific rules it uses to determine which method to use and 
 * if it is too confused then it throws an error. */

//OPTIONAL PARAMETERS
/*May be used in lieu of method overloading. Sets a default value for a parameter unless explicitly specified by the user. This in effect can make it is a single method has extended 
 functionality based on whether additional parameters were provided or not. (e.g. for our Shuffle method above default is shuffle once, but a user can specify a number >1 for more shuffles)
* Why use Method Overloading at all? B/C if you have A LOT of optional parameters it can get confusing in terms of code readability...hard to keep track of...
* Also, if you create an API for your program where someone else out there can call your method then default parameters don't work as well and you may need to create overloaded parameters to 
get around that*/

//NAMED PARAMETERS
/*These improve code readability. For example with our Shuffle method, when calling it you could just do deck = Shuffle(deck, 3); and it'll run. 
 However, if you wrote deck = Shuffle(deck: deck, times: 3); it is much more readable for a developer when they encounter your code. It communicates better and doesn't change 
the functionality of the code at all. */

//OUT PARAMETER
/*Rather than return a value, you can have the method throw it back to the variable when the method is done
 e.g. here is how using return within a method looks (call method and store returned value in variable): deck = Shuffle(deck, 3)
 and here is how using an out parameter looks like within a method: public static Deck Shuffle(Deck deck, out int timesShuffled, int times = 1)...here it outputs the # times the deck was shuffled
to the variable timesShuffled. We don't need to define this outside of our method, we've already defined timesShuffled as a variable inside of an out parameter
*/