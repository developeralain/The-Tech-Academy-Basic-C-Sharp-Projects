using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;//you need to use System.IO to access StreamWriter, which we use below.

namespace Casino
{
    public class Dealer
    {
        public string Name { get; set; }
        public Deck Deck { get; set; }
        public int Balance { get; set; }

        public void Deal(List<Card> Hand)//dealer takes in a Hand (list of cards) from a player and adds a card to that hand from the Dealer's Deck
        {
            Hand.Add(Deck.Cards.First());//we take the first card in the Deck and add it to the player's hand that is passed in to deal; Cards is a property of Deck and is a list.
            string card = string.Format(Deck.Cards.First().ToString() + "\n");
            Console.WriteLine(card);//writing to console the card I am about to put into the hand--the card that was dealt
            using (StreamWriter file = new StreamWriter(@"C:\Users\Alain\TwentyOneLogs\log.txt", true))//creates streamwriter object as file targetting an absolute path (it will write in log.txt)
                                                                                                        //also the 'true' refers to if you want streamWriter to append (add to the end of something)
            //First() is a method available to a list which takes the very first element in the list 
            {
                file.WriteLine(DateTime.Now);//the .Now is a property of DateTime that gives the exact moment in time that this line of code here is run
                file.WriteLine(card);//we will write the card string value to the file
            }//once it hits this closing bracket, the memory manager cleans all of this up and disposes of unused memory automatically--that is what the using statement does
            Deck.Cards.RemoveAt(0);//Removes the first card from the Dealer's Deck at index 0, as we just dealt that card to the player's hand 
        }
    }
}
//TWENTYONEDEALER CLASS THAT INHERITS FROM DEALER:
/*We create a TwentyOneDealer class that inherits from dealer because the game 21 has dealer behaviors / properties that are specific to 21 and just just to ALL dealers*/


