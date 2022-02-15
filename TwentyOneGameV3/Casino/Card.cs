using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Casino
{
    public struct Card//public makes this struct accessible to your program. This is in contrast to private keyword.
    {

        public Suit Suit { get; set; }//this line of code says: the card struct has an enum Suit property called Suit and you can get or set it 
        public Face Face { get; set; }

        //A Custom ToString() method enables us to easily call this method and show the player his/her cards
        public override string ToString()//every class in C# has a default ToString() method built into it (even class that you create!); here we override this method and make our own version
        {
            return string.Format("{0} of {1},", Face, Suit);//we make it so if we call this method (e.g. card.ToString()) then it creates a string for us as we've specified (e.g. Ace of Spades)
        }
        

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
    public enum Face
    {
        Two,
        Three,
        Four,
        Five,
        Six,
        Seven,
        Eight,
        Nine,
        Ten,
        Jack,
        King,
        Queen,
        Ace
    }
}