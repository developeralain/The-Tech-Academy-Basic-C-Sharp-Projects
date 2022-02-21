using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwentyOneGameV2
{
    public class Card//public makes this class accessible to your program. This is in contrast to private keyword.
    {
        //we will make a constructor for the Card class, which assigns default values to the class object upon its instantiation
        public Card()//This is The Constructor. The constructor method name is always the name of the class--this tells C# that it is therefore a constructor and not some other method
        {
            Suit = Suit suit;
            Face = "Two";
            //This constructor will automatically assign these two values to Suit and Face by default if you don't yourself specify them for the object you are instantiating
        }
        public Suit Suit { get; set; }//this line of code says: the card class has a string property called Suit and you can get or set it 
        public string Face { get; set; }

        //Typically, like a Class, an enum should be defined as a separate .cs file : however this enum relates specifically to our Card class so we include its definition here 



        //this Card class has two properties: Suit and Face
        //it is public, meaning it can be accessed throughout the program and by other classes.
        //a class serves as a model/template/design for an object...hence the class does not yet have any values for its properties
        //we will give actual values to objects modeled after this class
        //Analogy: class would be the recipie for food whereas object would be the actual food that was created from that recipie
        //Analogy2: class would be the cookie cutter whereas the object would be the actual cookie itself
    }
    public enum Suit
    {
        Clubs,
        Diamonds,
        Hearts,
        Spades
    }
}
