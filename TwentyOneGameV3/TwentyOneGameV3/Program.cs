using System;
using Casino;
using Casino.TwentyOne;
using System.IO;
using System.Data.SqlClient;
using System.Data;

namespace TwentyOneGameV3
{
    class Program
    {
        static void Main(string[] args)
        {
            //IMPORTANCE OF THIS PROGRAM:
            /*If you understand everything in this program then you would have acquired all the C# fundamentals and would possess the minimum skills necessary to get a 
             job as a C# developer. 
            */
            //Main() method is the entrance point for a console application: when we run the application, what is the first thing that we want to have happen?


            Console.WriteLine("Welcome to the Grand Hotel and Casino. Let's start by telling me your name: ");
            string playerName = Console.ReadLine();

            //CODE BLOCK REPRESENTS EXCEPTION HANDLING MEANSURES
            bool validAnswer = false;//b/c false, automatically runs below while loop
            int bank = 0;//bank value initialized as 0; if while loop TryParse fails, bank will remain at 0 (no output parameter will change the value of bank).


            while (!validAnswer)
            {
                Console.WriteLine("And how much money did you bring today?");
                validAnswer = int.TryParse(Console.ReadLine(), out bank);//tryparse is a method of Int32Bit aka int that takes in a string representation of a number and returns a boolean and also has an 
                                                                         //output param of its integer equivalent so if the above code tries to parse the user string into an integer and it fails, it will return 'false' and the while continues.If it succeeds,
                                                                         //it returns true and exits while loop and also outputs bank as an integer version of the user string
                                                                         //TL;DR tryparse casts a string into an int via output parameter and also returns a boolean true or false to indicate if the conversion succeeded

                if (bank < 0)//if user enters a negative value for bank, throws an exception instead of letting them proceed
                {
                    throw new Exception();
                }
                if (!validAnswer) Console.WriteLine("Please enter digits only: no letters or decimals.");//if this line hits, it restarts the while loop from the top


            }

            //END CODE BLOCK





            Console.WriteLine("Hello, {0}. Would you like to join a game of 21 right now?", playerName);
            string answer = Console.ReadLine().ToLower();

            if (answer == "yes" || answer == "yeah" || answer == "y" || answer == "ya")
            {
                Player player = new Player(playerName, bank);//we instantiate a player object with user's name and how much he brought (bank variable above)...we use Player class constructor for this

                player.Id = Guid.NewGuid();//creates a unique ID for the player that is stored 

                using (StreamWriter file = new StreamWriter(@"C:\Users\Alain\TwentyOneLogs\log.txt", true))//creates streamwriter object as file targetting an absolute path (it will write in log.txt)
                                                                                                           //also the 'true' refers to if you want streamWriter to append (add to the end of something)
                                                                                                           //First() is a method available to a list which takes the very first element in the list 
                {
                    file.WriteLine(player.Id);//the .Now is a property of DateTime that gives the exact moment in time that this line of code here is run

                }//once it hits this closing bracket, the memory manager cleans all of this up and disposes of unused memory automatically--that is what the using statement does
                Game game = new TwentyOneGame();//polymorphism by using datatype Game for TwentyOneGame object instead of datatype TwentyOneGame; we do this to expose overloaded methods we created
                                                //within Player class that are of the Game datatype (see Player class' overloaded methods)

                game += player; //we are adding player to the game by leveraging the Player class' overloaded += operator (see Player class)

                player.isActivelyPlaying = true;//we set this property to True b/c we'll create a while loop that says while the player is actively playing, play the game

                while (player.isActivelyPlaying && player.Balance > 0)//while they are still actively playing and have money, the game will run
                {
                    try
                    {
                        game.Play();//we don't define the Play() method here b/c we want things cleaner within our Main method--we'll define Play seperately and elsewhere, only calling it here
                    }
                    catch (FraudException ex)//catches are done in order so if it is this type of exception then this specific catch block would catch and handle it, otherwise it would fall under
                    //generic exception catch block beneath this one (note: this exception is one we custom made as a class that inherits from Exception class)
                    {
                        Console.WriteLine("Security! Kick this person out.");
                        UpdateDbWithException(ex);
                        Console.ReadLine();
                        return;
                    }
                    catch (Exception ex)//This is the most general exception: you always start with specific exceptions at the top and the most general ones below
                    {
                        Console.WriteLine("An error occured. Please contact your System Administration.");
                        UpdateDbWithException(ex);
                        Console.ReadLine();
                        return;//when you type return in a void method, which returns nothing (Main() is a void method), it exits the method right there
                    }
                }

                game -= player;//removes player from the game if they exit the while loop, i.e. if conditions of no more money or no longer actively playing are met
                Console.WriteLine("Thank you for playing!");
            }
            Console.WriteLine("Feel free to look around the casino. Bye for now.");//executes if user enters anything other than yes and its synonyms as define for the if loop above

            Console.Read();//Prevents window from closing automatically

            //HOW TO LEARN A NEW CODE BASE OR PROGRAM YOU DON'T UNDERSTAND:
            /*
             Set breakpoint at beginning of program and run the debugger, then Step Into every line of the program to see exactly what it is doing.
            This is a great way to learn a new code base and learn a lot about C# as well
             */

        }
        //this method below functions like Main(), doesn't return anything and no need to create a new instance of Program to use it and as it is private, only available in 
        //the program class (i.e. this page)
        private static void UpdateDbWithException(Exception ex)//Exception can take ANY exception, so it would include FraudException or any other time: citing the base class
                                                               //covers all possible exceptions (i.e. you don't need to have multiple parameters for multiple exception types)
                                                               //so this is another example of polymorphism
        {
            //We will use ADO.NET, part of the base library that assists in communicating with SQL Database
            //First thing we'll need is a connection string: a long string that contains info re: dB instance you're trying to connect to (e.g. username password location how to access etc.)
            //you always need a connectionString to access dB

            string connectionString = @"Data Source = (localdb)\MSSQLLocalDB; Initial Catalog = TwentyOneGame; Integrated Security = True; Connect Timeout = 30; 
                                        Encrypt = False; TrustServerCertificate = False; ApplicationIntent = ReadWrite; MultiSubnetFailover = False";

            //The next thing we create is a query string that contains the actual SQL query we'll be writing
            string queryString = @"INSERT INTO Table (ExceptionType, ExceptionMessage, TimeStamp) VALUE (@ExceptionType, @ExceptionMessage, @TimeStamp)";

            //NOTE: you don't want a user to be able to directly type something out and have the user string query the database directly. This is because of injection attacks 
            //which can cause irreperable damage to your database; like if the user string was in the proper form to issue sql commands to delete your database, that would be bad
            //Therefore we use parametrized queries to safeguard against injection attacks (@ExceptionType, @Exception, ...)
            //ADO.NET will help us by creating parameters that will map-in exactly using what we typed out (@ExceptionType, ... etc)
            //Basically, these @ type values are placeholders for the actual values that will be entered in when we go to make a query
            //These placeholders must adhere to specified datatypes: if you say it must be a DateTime datatype, then it must be--this helps vs injection attacks

            //USING: is a way of controlling unmanaged code or resources; a was of managing and controlling memory when using external resources
            /*
             When you are inside of a program in the .Net framework in the common language runtime and you go outside of it to get something else, like the file system,
            that is risky b/c you're opening up resources which could use up memory and other things. The CIL is concerned about that and it affects CIL by opening up
            these connections; thus anytime you open up these connections, such as to a database for example, you must always close them and the using code block allows
            for automatic resource/memory management and ensure disposing of unused resources when we're finished with out connection. This resource management/cleanup
            is initiated by the computer hitting the close curly brace }
             */

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);//we've instantiated a SqlCommand class object named command, passing in required arguments
                //now we'll use command to actually add our parameter values : what @ExceptionType, @ExceptionMessage, etc., represent
                //before we add the values, we state the datatypes of the @ values
                command.Parameters.Add("@ExceptionType", SqlDbType.VarChar);
                command.Parameters.Add("@ExceptionMessage", SqlDbType.VarChar);
                command.Parameters.Add("@TimeStamp", SqlDbType.DateTime);

                //now we need to add their values: Parameters is a dictionary--a collection--and has KVPs, with the @ExceptionType, ... etc. as keys and values we define
                command.Parameters["@ExceptionType"].Value = ex.GetType().ToString();//GetType gives you the datatype of what you're working with, and ex is storing
                                                                                     //the exception
                command.Parameters["@ExceptionMessage"].Value = ex.Message;//Message is a property of the exception class
                command.Parameters["@TimeStamp"].Value = DateTime.Now;//passes current datetime

                //we've by now established our parameters and query string: now we need to send all this to the database

                connection.Open();
                command.ExecuteNonQuery();//this isn't a query, it's an INSERT statement
                connection.Close();


            }
        }
    }
}
//CLASSES IN C# ARE ALL REFERENCE TYPES:
/*
 * Every datatype in C# is either a reference type or a value type, and these two types have different behaviors
 * Example:**note: this example was valid when Card was a Class, b/c that's how classes behave. However, we changed Card to a struct and therefore it wouldn't behave as described below
 
Card card1 = new Card();
Card card2 = card1;//we assign to card2 the value of card1
card1.Face = Face.Eight;
card2.Face = Face.King;

Console.Writeline(card1.Face);
OUTPUT: King 

Why was output king? We assigned Eight for card1 and King to card2, so why did card1 print King? Hmm...
Explanation:
When we created card2 you probably thought it was a card object completely independent from card1...this isn't so
What happens behind scenes when we create an object? 
A Class is like a blueprint, and when we instantiate an object all we're doing is allocating a block of memory and configuring it according to that blueprint,
but when we assigned the value of card1 to card2 we didn't actually create a new block of memory (b/c this would be wasteful to have as a feature in C#).
What actually happened when we assigned the value of card1 to card2 then? We gave card2 the address to the memory location of card1 and said 'look here and change the values in this
address if you want to change your own value'. I.E. card2 points to the address of card1 for its own value. Thus, card1 and card2 are connected: if card1's value changes so does card 2's
as card2 is pointing to the memory address of card1 to derive its value. Likewise, if card2 changes its value then the value of card1 is affected and changes as well as both card1 and card2 
point to the same memory address. 

This is how all classes in C# operate: they reference this memory location--this central point--and that is in essence reference types in C#. Both library classes and your own.

(think Google drive two people editing a document: it isn't two copies of the document, in reality both people are editing the exact same document!)

Examples of native classes in C#: strings, lists, etc.

 * Any datatype that stores value by reference--where it's just a central repository where that value is kept and other objects that have the 'same value' are just referencing that 
 * same reference--is called a reference type. This includes ALL CLASSES.
 *      NOTE: since strings are immutable--cannot be changed w/o creating a completely new string--if we tried to do the card1 card2 trick above with a string it wouldn't work because 
 *      it would generate a new string instead of referencing the same memory location
 */

//VALUE TYPES 
/*
 Sending someone a copy of a paper/essay would be sending something by value: you've created a separate, indepenent instance. You're not pointing to an external storage location, you are sending
the actual value to the person. So if a teacher opened that copy and made edits, it wouldn't show up on your end. 
Examples: booleans, integers, enums, datetime
 *So what are value types if not classes? What is an int? An int is a struct called Int32 and 'int' is just an alias for Int32 (you can use both interchangeably)
 *
 //STRUCT: What is a struct?
 *A struct is almost the same as a class except that it is a value type and that it cannot be inherited, whereas a class is a reference type that can inherit or be inherited
 *Structs are naturally value types as value types are structs
 *Examples of structs: int, bool, datetype -- all three of which are also value types as structs are value types
 *WE DECIDED TO CHANGE Card from a Class to a Struct b/c it is a perfect candidate: cards cannot be inherited and their  values do not change once set
 *VALUE TYPES & STRUCTS CANNOT HAVE A VALUE OF NULL:
 *
 Why? Because Null is not a value, it's just Null; value types and structs must have a value which Null is not.
NON-NULLABLE DATA TYPES: structs, booleans, integers, datetype--anything that is a value type cannot be assigned null

//WE CHANGE CARD CLASS TO A STRUCT INSTEAD OF A CLASS: WHAT CHANGES?
Look at this code we used in an above example:
Card card1 = new Card();
Card card2 = card1;//we assign to card2 the value of card1
card1.Face = Face.Eight;
card2.Face = Face.King;

Console.Writeline(card1.Face);
OUTPUT: Eight

The output is now Eight and not King because by changing Card to a struct, card1 is now its own separate instance unrelated to card2: card2 and card1 are now completely separate
So now when we make King the value of card2 it does not influence value of card1 whereas when Card was a Class, it did and thus printing Face for card1 printed King 


 */

//LAMBDA FUNCTIONS
/*
 These special functions come from an offshoot of math called Lambda Calculus, which was invented in 1930s
 They expose lists to a variety of useful methods that make life infinitely easier!
EXAMPLE:

Deck deck = new Deck();//this Deck class has a property called Cards which is a list of Card objects from the Card class

What if we wanted to find out how many aces exist in the deck, say because this deck has had cards removed and we want to know how many remain...
We COULD use a loop:
int counter = 0;
foreach (Card card in deck.Cards)
{
    if (card.Face == Face.Ace)
    {
        counter++;
    }
}
Console.Writeline(counter)
OUTPUT: 4

NOW, LET'S WRITE THE ABOVE NESTED LOOP FUNCTION USING A LAMBDA FUNCTION INSTEAD:
int count = deck.Cards.Count(x => x.Face == Face.Ace);//this is counting each element in the list Cards, represented by x, where the card's face value is Ace (note: Count() is a lambda method)
Console.Writeline(count);
//OUTPUT: 4

The lambda function accomplishes the same outcome but with far less code involved: it is far more concise!

You can look through other lambda methods that can be used on the deck property Cards (a list) as follows: deck.Cards. 

What does => mean? It means map the expression on the right of the symbol to each item (each item in the above lambda function being represented by 'x')

EXAMPLE 2: take deck object, filter out all Kings, and place these Kings in a new list using a lamba function and lambda methods
List<Card> newList = deck.Cards.Where(x => x.Face == Face.King).ToList();//takes deck (full deck of cards) and creates newList where the only cards present are Kings
NOTE: 'Where()' is a lambda method similar to a SQL 'WHERE' where you can filter your list for specific features...so here we filter our list of card by taking each item (as x) and applying
this function to each item. Where creates a new list, but as we already instantiated list newList we use ToList() to append these 4 King cards to that specific list
NOTE: ToList() is needed to append to a list where these King cards we're filtering out will be added to (will append to newList)
Now, what is this lambda function saying?
It is saying "Take the list of cards and find out where the face == king and map that to a new list 

To verify this worked we use a foreach loop:
Deck deck = new Deck();
List<Card> newList = deck.Cards.Where(x => x.Face == Face.King).ToList();
foreach (Card card in newList)
{
    Console.WriteLine(card.Face);
}
//OUTPUT: King, King, King, King 

EXAMPLE 3: 

List<int> numberList = new List<int>() { 1,2,3,535,342,23 };
int sum = numberList.Sum();
Console.WriteLine(sum);
//OUTPUT: 906

EXAMPLE 4:

List<int> numberList = new List<int>() { 1,2,3,535,342,23 };
int sum = numberList.Sum(x => x + 5);//says for each item in the list, add 5 to it
Console.WriteLine(sum);
//OUTPUT: 936

Other methods are Max(), Min(), etc...


EXAMPLE 5: We can 'chain' methods together as well...
List<int> numberList = new List<int>() { 1,2,3,535,342,23 };
int sum = numberList.Where(x => x > 20).Sum(); //Where creates a new list for you--let's create a new list where items > 20 and let's sum that list
Console.WriteLine(sum);
//OUTPUT: 900

SUMMARY: what could take 50 lines of code to achieve normally, you could achieve with just 1 line of code using Lambda Functions--it is a GIANT leap forward for speed of programming and
makes programming much more enjoyable. As a note, lambda functions are actually executed more speedily than for loops are--so that's another benefit!

CAUTIONS: 
 * Lambda expressions are very hard to debug (you can't 'look inside' like with a foreach loop and see what's happening)...if an error is thrown inside of a lambda function then you're 
   on your own in figuring out why a piece of data caused it to break (this is even more the case if you start chaining them together)
 * Too much logic in one long lambda expression makes it hard to read (like chaining too many lambda expressions aren't very readable)
 */

//DEALING WITH COLLECTIONS (LISTS, DICTIONARIES, etc.)
/*
 Only way to truly protect yourself against having a user add a value to a null list/dictionary, etc. , is via code list so : 

        private List<Card> _hand = new List<Card>();
        public List<Card> Hand { get { return _hand; } set { _hand = value; } }

 */

//HOW TO WRITE AND READ TEXT TO AND FROM A TEXT FILE: LOGGING 
/*
 Most common reason to do this is logging
Logging: putting in a meaningful entry into a file or database based on an action of the program
* Some programs will log every method call whereas others will log just the errors so you can go back and look at the log 
            string text = "Here is some text.";
            File.WriteAllText(@"C:\Users\Alain\TwentyOneLogs\log.txt", text);//file class method that takes in absolute path argument and string and creates new .txt or overwrites existing
            string readText = File.ReadAllText(@"C:\Users\Alain\TwentyOneLogs\log.txt");//reads the text in a file
* To append text to a file, you have to open up a stream. A stream is used when the final size of something is unknown, like if you have bytes flowing in and you're unsure how many will flow in.
* Streams are often used with images for example
* Logging, really, is appending a message to the end of an exisiting file
* We will log each card that is dealt in this game by building in a log to our dealer deal method as every time a card is dealt the deal method is called 
 */

//DATETIME: a value type
/*
 A struct, meaning it is not nullable (cannot go DateTime dateTime = null;)
 DateTime dateTime = new DateTime(1995, 5, 23, 8, 32, 45); //has 12 different constructors available...
 * TimeSpan:
 * A TimeSpan compares two datetime values and calculates the difference in time b/w them ...
 * E.g. 
DateTime birthDate = new DateTime(1995, 5, 23, 8, 32, 45);
DateTime graduationDate = new DateTime(2015, 8, 23, 1, 13, 33);
TimeSpan ageAtGraduation = yearOfGraduation - yearOfBirth;//it will give you a result in days (the difference b/w these two dates in days)
Implementing DateTime in our game: what if we put a timestamp in for each log entry? See the Dealer Class for this

 */

//ASSEMBLY : HOW IT WORKS 
/*
 * An assembly in essence is what you get after you'e compiled your source code into CIL : this takes the form of either a .exe or .dll file
 Any code you write will end up being compiled twice: 
 1. C# compiler first compiles your source code (code your write) into CIL (common intermediate language); this compiled code will be in the form of a .exe (if meant to be executed) 
or .dll file (if library file). The .exe or .dll files are an assembly. 
 2. The next step is for that assembly (.exe or .dll file) to be compiled into whatever kind of machine code is being used by that computer (whether Linux, Mac, or PC, for example)
EXAMPLE:
List is a class that is part of the framework class library, and it itself is an assembly in the form of a .ddl file (it's a library file).
 */

//NAMESPACES 
/*
 A way of organizing your code. You're able to divide your code so that you can have multiple identical class names and know which you're referring to based on its namespace
EXAMPLE:
A giant online retailer, like WalMart, would have trouble if it could only make a single class called 'Chair'...w/o namespaces, how could you distinguish multiple chair types? 

* USING STATEMENTS:
* Using statements, like 'using System;', listed at the top of a page refer to a namespace from which we can make use of classes and methods under that namespace...
* We don't HAVE to use using statements: for example we can write out the full path such as 'System.Console.WriteLine();', using statements merely make it easier to use namespace objects and methods
* 
* NAMESPACES AND SUBNAMESPACES:
* When you get to a larger application, you want to use these.
* Example: our 'IWalkAway' interface could be under the namespace 'TwentyOne.Interfaces' instead of just being under 'TwentyOne'
* Sometimes you have two classes that are the same but belong to different namespaces: the trick is to preface the class with the namespace it belongs to to distinguish both classes
* Example:
* There already exists a class Console under the System namespace. You create a class Console under the TwentyOne namespace. An error will occur as C# won't know which class you're referring to.
  You can solve this error by explicitly writing out the paths of each class: System.Console and TwentyOne.Console

 */

//CREATING A LIBRARY .DLL FILE THAT WE CAN THEN SHARE AND DISTRIBUTE (e.g. GitHub, Microsoft Libraries, etc.)
/*
 First right click on your solution, select add and new project --> go through the list and select 'C# .Net Framework Class Library', or something to that effect
 A new project is created within your solution, of a name of your own choosing. It will automatically create a .cs file which you may delete from this new project
 Drag and drop all your classes and interfaces from your current project to the new project you created to serve as a class library. Then, delete all those same files from your original project.
 Now, only this library project should have classes and interfaces, while your original project should only have Program.cs within it.
 Go through all classes and interfaces and modify their namespaces as you wish: keeping things organized and grouped. You'll have one overarching namespace for all (in this case we chose 'Casino'),
 but some namespaces will be more specific (e.g. Casino.Interfaces or Casino.TwentyOne)
 Right click your library project, with all classes now inside of it, and select 'Build' (make sure Build is set to 'This Project' and not ALL projects within the solution)
 Go to your Solution, to the library project folder, to the debug folder, and seek out the .dll file of the same name as your library project 
 Having confirmed it is present, right click on References under your original project and select Add ... browse and find the .dll file you just created and add it
 You will have to add appropriate using statements to the top of your Program.cs file within your original project so that classes you refer to are recognized. 
 Test and make sure everything still works! 

NOTE: anytime you change something in that library you will need to right click it and select 'rebuild' to re-create the .dll file inclusive of the new code changes

 */

//ACCESSIBILITY MODIFIERS : not just Private and Public!
/*
 Public: accessible everywhere 
 Private: an attribute, method, enum, dictionary, etc.  that is only accessible inside of its class
 Protected: limited to just that class as well as any classes that derive from it
 Internal: can only be accessed by those things of the same assembly...for example, Casino.dll IS an assembly--specifically a .dll library file. Thus something that is marked Internal, like a class,
 can only be accessed by other classes within that same .dll file (within same library) 
 example: if you made a class that Program.cs references internal--Program.cs being outside of the Casino.dll assembly--then it would throw and error
 
 * The purpose of accessibility modifiers is to control access to your classes and methods and only expose what you want to expose. If you don't need to expose something then don't!
 Example: helper methods are typically not meant to be accessed outside of a given class and thus should be restricted in some way...
 * If you make EVERYTHING accessible, then you may confuse a developer who is trying to work with your library: accessibility modifiers improve usability of your library

 */

//ADDITIONAL C# FEATURES
/*
 * Constructor Call Chain aka 'Constructor Chaining'
 
 Refers to the reuse of constructors within a class
 You can define multiple constructors and utilize an earlier constructor; helps in preventing writing things more than once 
 This is useful if you end up with many constructors as it makes your code more concise 
 EXAMPLE:

 //Below we have a constructor for the Player class that takes 2 parameters, but what if we wanted a constructor that only takes 1 parameter?

public Player(string name, int beginningBalance)//our constructor that automatically executes upon instantiating a Player class object
        {
            Hand = new List<Card>();//we instantiate the hand property as an empty list object
            Balance = beginningBalance;//assigns second argument beginningBalance to the Balance property of the class
            Name = name;//assigns first argument name to the Name property of the class

        }
//We would do the follow to have this new constructor that only takes 1 parameter inherit from the constructor above:

public Player(string name) : this(name, 100); //here we have name as the first parameter, but for the second parameter he have set beginningBalance to 100 by default
{
}

//so what this above constructor is saying is "assign name to name, but if they don't put a beginning balance then automatically assign 100 to that property...this increases code reuse as we don't
need to re-type all the implementation details of the prior Player constructor that took 2 parameters.

So continuing with this example, if we went to Program.cs and typed in this code: Player newPlayer = new Player("Jesse"); 
It would trigger the single parameter constructor we just built and automatically assign its Balance property a value of 100 (as we had specified in our new constructor)


* Implicitly define datatype using var keyword
  You can use var ahead of a variable name or class name, etc, to implicitly define its datatype
EXAMPLE:
var newPlayer = new Player("Jesse"); //it automatically can figure out newPlayer is of Player datatype!

  You don't want to abuse this as it worsens code readability: if var is used everywhere it can be hard to tell what's going on when another developer tries to read it 
  But it CAN save you time, especially when declaring things like dictionaries.
EXAMPLE:
//without var
Dictionary<string, string> newDictionary = new Dictionary<string, string>(); 
//with var
var newDictionary = new Dictionary<string, string>(); 


* Declaring constants
  You can declare constants and once that constant is compiled, its value cannot change (it is constant in value)
EXAMPLE:
const string casinoName = "Grand Hotel and Casino";//the benefit of this is, if this is referenced several times in the program and you leave it a constant, it can never accidentally be changed

* GUID (Global Unique Identifier)
  A class in C# that allows you to create a unique ID for something
  The odds of getting a duplicate GUID are extraordinarily low and nearly impossible
EXAMPLE:
If you have a user with a GUID, you can access that and look it up in a table to get their name

Guid identifier = new Guid.NewGuid();//creates a GUID

 
* Exceptional Handling - Advanced
  An exception is an event which occurs during the execution of a program that disrupts the normal flow of a program's instructions

  In visual studio, by default any application you run from inside of VS is in debugging mode and reacts differently when being run than if you had run this as a .exe outside of VS: meaning,
  if your .exe threw exceptions it would simply crash, whereas if you run it from within VS it 'crashes' but it is in debugging mode and tells you what went wrong and allows you to handle exceptions

  So when exceptions occur they can be handled with either better code or with a try/catch block. It depends on the situation which is the best approach.
EXAMPLE: we will demonstrate how better code can handle faulty user input to avoid exceptions 

bool validAnswer = false;
int bank = 0;
while (!validAnswer)
{
    Console.WriteLine("And how much money did you bring today?");
    validAnswer = int.TryParse(Console.ReadLine(), out bank)//tryparse is a method of Int32Bit aka int that takes in a string representation of a number and returns a boolean and also has an 
    output param of its integer equivalent so if the above code tries to parse the user string into an integer and it fails, it will return 'false' and the while continues. If it succeeds,
    it returns true and exits while loop and also outputs bank as an integer version of the user string
    //TL;DR tryparse casts a string into an int via output parameter and also returns a boolean true or false to indicate if the conversion succeeded
 */

//DATABASE ACCESS
/*
 * SQL and C# are not the same language: when you get down to the bits and bytes a C# string is not a SQL string, a C# boolean is not a SQL boolean
 * The closest thing SQL has to a string is a varchar, and the closest thing it has to a boolean is a bit
 * When you want to insert a C# string into a SQL database or pull a record from a SQL database and map it to a C# object you need some help
 * Thankfully there's a portion of the base class library called ADO.NET that is very helpful with such operations 
 * ADO.NET: an abstraction layer for communication with a database; you can use it to write actual SQL queries inside of your C# code and execute them inside the dB you are targetting and 
   return results back to your application

EXAMPLE: we exemplify this within our current TwentyOne game by adding SQL database functionality --> logging any exception to our database
This is a very common feature in any large application such that you'd find in the database a table called 'Log' or 'Logger' or something similar to catch any and all exceptions that occur, so that
if a customer complains of a bug you can check the log and do something about it
 
 * VisualStudio has a widget called SQLServer Object Explorer which allows us to access dB info without opening SQLSERVERMANAGEMENT STUDIO 
   You access this like so: VIEW --> SQL SERVER OBJECT EXPLORER --> pick a localdB to use (if you have 2) --> right click on Databases under your localdb --> add new database --> TwentyOneGame

 */