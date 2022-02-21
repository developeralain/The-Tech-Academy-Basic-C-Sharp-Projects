using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwentyOneGameV2
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
            Card card = new Card();
            card.Suit.Clubs;
            Deck deck = new Deck();
            deck.Shuffle(3);
            


            //Game game = new TwentyOneGame();
            //game.Players = new List<Player>();//instantiates the list attribute Players so that we can add to it; lists must first be instantiated before you can add to them...
            //Player player = new Player();
            //player.Name = "Alain";
            //game = game + player;//this implicitly calls the overloaded + operator method and adds player to game and returns a game just as defined within the Player class
            //game -= player;//this is exact same as writing game = game - player...can also write above as game += player;

            //Deck deck = new Deck();
            //deck.Shuffle(3);

            foreach (Card card in deck.Cards)

            {
                Console.WriteLine(card.Face + " of " + card.Suit);

            }
            Console.WriteLine(deck.Cards.Count);
            Console.Read();


            //Game game = new TwentyOneGame();//You are creating an object named game of datatype Game by instantiating the object from the TwentyOneGame class--this is polymorphism
            ////TwentyOneGame game = new TwentyOneGame();//instantiates a game object of class TwentyOneGame
            ////Because TwentyOneGame class inherits from Game class, we will have access to all properties and methods of Game class
            //game.Players = new List<string>() { "Alain", "Bill", "Joe" };//we instantiate the Players property and initialize it with values
            //game.ListPlayers();//SUPERCLASS METHOD: when you call a method from a class you're inheriting from
            //Console.ReadLine();


            //Deck deck = new Deck();//we have instantiated an object of datatype (also, of class) Deck that we are storing in a variable called deck...it would be empty until assigned values;
            ////however, we created a constructor method within Deck object that automatically populates an entire deck of cards under its 'Card' property, which is a list. 


            ////deck.Shuffle(3);//we call Shuffle method, which exists in the Deck class, and pass 3 into it: this shuffles the Cards property 3 times
            //deck.Shuffle(3);

            ////The below foreach loop allows us to print the contents of our deck; each list element--each element being of datatype Card, also an object-- of the deck object's property 'Cards'
            ////is printed into the console for inspection. This allows us to see every card as a combination of its Face and Suit in a "Face of Suit" format
            //foreach (Card card in deck.Cards)

            //{
            //    Console.WriteLine(card.Face + " of " + card.Suit);

            //}
            //Console.WriteLine(deck.Cards.Count);
            //Console.Read();



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
 * if it is too confused then it throws an error. For instance you can change the return datatype or the parameters of the method while keeping the name the same: this is Overloading */

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

//OBJECT INITIALIZATION: A FASTER WAY TO CREATE OBJECTS WITH ATTRIBUTE VALUES ASSIGNED AT THE GET GO
/* Card card = new Card() { Face = "King", Suit = "Spades" }; 
 * The above line of code instantiated an object of class Card and initialized it with some values included off the bat
 * Instantiating an object means there is now an object of a given class. Initializing an object means also, at the same time you instantiate it, you assign it values
 * Same concept as with a variable: int x; declares the variable, however int x = 3; declares AND initializes it at the same time
 */

//INHERITANCE: ONE OF THE 3 PILLARS OF OBJECT-ORIENTED PROGRAMMING
/* The ability of a class to inherit other properties (attributes) and methods from another class
 * DRY: Don't Repeat Yourself! 
 * If you can inherit the properties and methods of another class it means you don't have to re-type all that code again--you don't have to repeat yourself
 * If you want a class to inherit from another class, all you'd do when creating the child class is this: class Child : Parent
 (e.g. class TwentyOneGame : Game)
 * SUPERCLASS METHOD: when you call a method from a class you're inheriting from
 
 */

//GENERAL PRINCIPLES
/* Design Towards Abstraction: the more generic you can make your code, the easier it'll be to add features to it later on
 * Example: we created a Game class. If we make this class include only the properties specific to ALL games, not just those specific to the game twentyone, then if in the future
 we are required to create other Games that aren't twentyone we can re-use the game class instead of having to start from scratch
So when we make a class Games we think "What do ALL games have in common?"
 
 
 */

//STOP THE USE OF AN UNFINISHED METHOD
/*You may use this line of code within an unfinished method to stop someone from calling it: throw new NotImplementedException();
 Output: System.NotImplementedException: 'The method or operation is not implemented.'
This is in effect a catch against someone trying to run this method: you've programmed an exception to be triggered if someone tries to call the method.
 */

//POLYMORPHISM: THE SECOND PILLAR OF OBJECT-ORIENTED PROGRAMMING
/*The property of classes to morph into other types of classes
 * EXAMPLE:
    Game game = new TwentyOneGame();//You are creating an object named game of datatype Game by instantiating an object from the TwentyOneGame class--this is polymorphism
    You can also do this to get the same result without polymorphism: 
    TwentyOneGame game = new TwentyOneGame();//instantiates a game object of class TwentyOneGame

    WHY USE POLYMORPHISM IN THIS EXAMPLE ABOVE?
    * Say you have many different game classes: PokerGame, SolitaireGame, etc., and your boss wanted to put all these games into a list
      LISTS can only take one data type...we'd have to choose LIST<PokerGame> or LIST<SolitaireGame>, etc...but with polymorphism we can do List<Game>:
      List<Game> games = new List<Game>();
      Game game = new TwentyOneGame(); ... OR ... TwentyOneGame game = new TwentyOneGame(); ... ... either one works, if you try to add either to list games it will work
      games.Add(game);

 *If you were asked in an interview "What is Polymorphism?" And you answered "It's the ability of a class to morph into its inheriting class that gives certain advantages"

      
 */

//ABSTRACT CLASSES AKA BASE CLASSES
/*An abstract class, also known as a base class, is a class marked with the keyword 'abstract', which means: THIS CLASS CAN NEVER BE INSTANTIATED
 * An abstract class can never be an object; it can only ever be inherited from
 * E.g. our Game class: we will never have an instance of Game--why would we? We will have instances of specific games that derive from Game, such as Solitaire or TwentyOne...
  hence our Game class can be made into an abstract class via the abstract keyword, which prevents anyone from being able to instantiate Game
 * By abstracting a class you essentially lock the code out: you feel so strongly there shouldn't be an instance of a certain class that you make it impossible to do so
 * Code isn't made just for you: other developers may come along, you may expose your code as part of a library, etc. so these keywords like abstract are a way for you as 
   a developer to keep control of your code base and your program
 */

//ABSTRACT METHODS
/*a method that is marked with abstract keyword; can only exist inside an abstract class; contains no implementation; all it does is state:
   any class inheriting this class must inherit this method
   An abstract method is a contract b/w abstract class an inheriting class saying the inheriting class must implement this method; inheriting class must define method somewhere in its class
   and must have exact same name, return type, and parameters
 * When we want an inheriting class to have its own implementation details for the abstract method, we use the override keyword (e.g. TwentyOneGame class):
   EXAMPLE:
    ABSTRACT METHOD OF GAME ABSTRACT CLASS: public abstract void Play()
    TWENTYONEGAME CLASS INHERITING FROM GAME CLASS, WITH ITS OWN IMPLEMENTATION DETAILS FOR PLAY(): public override void Play()
 */

//VIRTUAL METHODS
/*These contain implementation details, unlike abstract methods which do not, but they CAN be overriden
 *Virtual methods exist only inside of abstract classes
* We use the 'virtual' keyword to create a virtual method
 * A virtual method means that this method gets inherited by the inherting class (e.g.TwentyOneGame), but its implementation details can be overriden by the inheriting class
 
 * EXAMPLE OF VIRTUAL METHOD WITHIN GAME ABSTRACT CLASS:
 
public virtual void ListPlayers()
            
        {
            foreach (string player in Players)
            {
                Console.WriteLine(player);
            }
        }

 * EXAMPLE OF TWENTYONEGAME INHERITING CLASS MODIFYING THIS VIRTUAL METHOD:
 * 
        public override void ListPlayers()//this is a virtual method of the Game abstract class. We use the override keyword to add our own implementation details to it.
        {
            Console.WriteLine("21 Players:");//this is code not existing in the Game class' virtual method, but code that we added ourselves for this class specifically
            base.ListPlayers();//this is equivalent to the code that exists within this virtual method in the Game class (it encapsulates the existing logic of this method)
        }

 */

//INTERFACES & MULTIPLE INHERITANCE
/*
 Similar to abstract class in that there are no implementation details in an interface...why not use abstract class then? Due to design if .NET Framework: does not support multiple inheritance...
Multiple Inheritance means a class can inherit from more than 1 class, and .NET Framework does not support this: a class can only inherit from one other class
 * A lack of multiple inheritance in .NET is limiting: if you were instructed to change a base class to meet some small need of a few inheriting classes but not all, that wouldn't work
 * because changes the base class affects all classes that are inheriting from it...if multiple inheritence WAS allowed, you could create another base class and have only the classes you want
 * to change inherit from this new base class as well as from the base class they were originally inheriting from (multiple inheritance)
 
 .NET ONLY SUPPORTS MULTIPLE INHERITANCE FOR INTERFACES, NOT BASE CLASSES
 * You can inherit multiple interfaces, but only a single base class
 * 
 * INTERFACE NAMING CONVENTION: names of interfaces always start with capital 'I', for example with our 'IWalkAway' interface



*/

//DEBUGGING IN VISUAL STUDIO
/*
 * You put breakpoints : by putting in a breakpoint you are telling Visual Studio "When you get to this point, STOP!". Thus it does NOT execute the code at that point: it stops at that point.
 * Using breakpoints, you can proceed step-by-step and see exactly what's happening in your code at each step
 * If you're stepping into a line of code that is highlighted, it will take you to the function code page of that line of code; this is in contrast to stepping over it
 * If you've stepped into a method that has a loop, one way to get past the loop quickly is to put a break point just past the loop's code block and select 'Continue'
 * NEW CODE BASE: it is recommended you debug and set breakpoints to see, step by step, how the code works. If you  don't know how a method works then step into it and see
 * DELETE ALL BREAK POINTS: CTRL + SHIFT + F9
 * 

*/

//OVERLOADING OPERATORS (+ - * /) 
/*
 * Why make your own implementation of + or - ? What's the point?
   The operators would be specific to an object you've created. 
   EXAMPLE: what if you wanted to add two objects together, or what if you wanted to use the + to add a player to a game?
   EXAMPLE: see class Game as we've overloaded + and - operators within that class
   
 */

//GENERICS
/*
 * Means belonging to a group of things but not specific (English Definition)
 * Are a feature of the language that allows you to write generic functions or classes--functions that by nature are more generalized and less specific
 * In reality, in programming you want things to be more generic b/c it has more reusability that way
 * Example: Everytime we've used the List datatype, we've actually been using a generic class (List is innate to C# and comes as a pre-defined class that is generic in nature)
   when you write List<>, whatever goes in b/w <> is the datatype that the list uses (e.g. List<string>)--so the Generic List Class is not restricted to a particular datatype...
   the way that is accomplished is in defining the List class it is defined: List<T> ... the <T> represents the datatype that will be passed in upon object creation...
   when this class, List<T>, is instantiated you pass in the datatype where <T> is and suddently you can have a List that holds a datatype that is unknown to the class
   List<T> is usable for any kind of datatype--otherwise you'd have to make a new class for every single datatype, but with generics you don't need to do this
 * The most common use of generics occurs within the List class
 * Generics refers to the concept that you can pass in a datatype at the moment of instantiation of a class object and it affects the class object
 * It's a way of abstracting code to encompass more situations which leads to more code reuse and better adaptibility
   
 */

//PROTIP: Want to see if your program will run without having to compile it? Do CTRL + Shift + B  ---> this Builds it instead of compiling it and will tell you if build succeeded

//ENUM DATA TYPE
/*
 * An enum allows you to limit the possible values that a variable is going to get 
 * Enums have an underlying datatype, integer, so you can always cast an enum to its underlying datatype
 When you say a piece of data is of type enum, you are saying it is one of a set of named constants
 * Enums limit the possible values that you can receive from a user 
 * E.g. if you have a dropdown list of a set number of items, like days of week, and user has to choose a day and you make it an enum datatype then you know that no value will be assigned
   to that variable unless it is one of those items, which completely eliminates the possibility of user input error on that step 
 *Another advantage of enums if visual studio intellisense (it automatically tells you the possible value options so you don't need to worry about memorising them or forgetten what it is called
 *The best enum candidate in our program right now is the Suit property of our Card class b/c there will only ever be 4 possible suit types
 *Another advandage is say you want to allow users to input a value or have an API they can access, using an enum would elimitate code breaks due to spelling mistakes as it restricts the possible values
 *When defining an enum it is similar to a Class where you have a separate file for it
 *Enums have an underlying datatype of integer: 
  meaning that within a defined enum type listing colors Green, Red, Blue as possible values, the corresponding int values would be: Green=0, Red=1, Blue=2 ... follows an index pattern of a list
  So if you did int underlyingValue = Convert.ToInt32(Colors.Green); and printed this, it would show 0 as the value
  You can customize these default values to anything you'd like...this may be useful in assigning words like 'Cold', 'Medium', 'Hot' numerical values to specifically compare one to another 
 * E.g. create an enum of the days of the week with only 7 possible values:
    public enum DaysOfTheWeek
    {
        Monday,
        Tuesday,
        Wednesday,
        Thursday,
        Friday,
        Saturday,
        Sunday
    }
    The above represents all the possibilities that this datatype can have 
    
    DaysOfTheWeek day = DaysOfTheWeek.Sunday; //create variable named day of datatype DaysOfTheWeek of value Sunday--the value can only be one of those listed within enum DaysOfTheWeek (M-S)

 */

