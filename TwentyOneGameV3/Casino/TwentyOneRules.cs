using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//THIS WILL HOUSE THE BUSINESS LOGIC LAYER OF OUR PROGRAM
namespace Casino.TwentyOne
{
    class TwentyOneRules
    {
        //A dictionary of card values--made private b/c this will only be accessed inside of this class (like if it was public and someone later on wanted to use the same name
        //it could cause a conflict)...so it is private b/c only the methods within this Class will ever access our dictionary--it will never be accessed outside of this Class

        private static Dictionary<Face, int> _cardValues = new Dictionary<Face, int>()
        //creating new dictionary and instantiating it all of our objects b/c it'll never change
        //static b/c don't want to have to create a TwentyOneRules object in order to access this ... all these helper methods will be static 
        //this dictionary of cards and their values will allow us to quickly look up, using methods, the values of cards and the total value of a hand 
        {
            [Face.Two] = 2,
            [Face.Three] = 3,
            [Face.Four] = 4,
            [Face.Five] = 5,
            [Face.Six] = 6,
            [Face.Seven] = 7,
            [Face.Eight] = 8,
            [Face.Nine] = 9,
            [Face.Ten] = 10,
            [Face.Jack] = 10,
            [Face.Queen] = 10,
            [Face.King] = 10,
            [Face.Ace] = 1//although Ace can be 1 or 11 in Blackjack, for simplicity we'll assign it a 1 and use logic later on to give it 2 possible values (b/c /w dictionary can only assign 1 value)
            //the player chooses whether Ace is worth 1 or 11, so we'll have to add checks to our logic to see 'how much would the hand be worth if Ace was 1 or if Ace was 11?'

        };

        //Ace problem: will Ace = 1 or 11? How do we determine that?
        /*
         You take a hand, a list of cards, and you generate an array of integers of all possible values of that hand: say you had an Ace and a 3 then that int array would have 2 entries in it with
        one being 14 and the other being four, so we know current hand player has is worth either 14 or 4 and we can do something /w that : we could find max value or min value and if min value is
        > 21 then we know that player busted
         */

        private static int[] GetAllPossibleHandValues(List<Card> Hand)//pass in a Hand and it returns an array of integers that represents all the possible values for a given hand (b/c Ace can be 1 or 11,
            //there exist various possibilities: 2 aces and 1 other card yield 3 possibilities as either of the two Aces can be a 1 or an 11, for example
        {
            //the # of aces there are in a hand will determine the total # of possible values
            int aceCount = Hand.Count(x => x.Face == Face.Ace);//lambda expression checks # card faces in the hand that are Aces
            //the above is a lambda expression and lambda expressions are methods you can perform on lists -- a whole array of functionality that lists have d/t built-in lamba functionality

            //Once we know how many aces there are, we know how many possible values there are and therefore we known the length of our array (b/c we must specify the length before creating an array)
            //Formula: #Aces + 1  = total number of possible values...like 2 aces means 11+11, 1+11, or 1+1 as possible values
            int[] result = new int[aceCount + 1];//aceCount + 1 is the formula to determine how big our array will be i.e. how many possible values it will contain (relevant b/c in C# you must specify how big)

            //Now let's get the value of the hand with Ace = 1 (which is its default value per our _cardValues dictionary)
            int value = Hand.Sum(x => _cardValues[x.Face]);//for each card x in the Hand, the lambda looks up its value in the dictionary based on its key (its Face) and sums it up

            //take first entry in our integer array and assign value to it...if there's no aces then we know there's only 1 possible value
            result[0] = value;

            //This IF is only hit if there's only 1 possible value, i.e. zero aces in a hand
            if (result.Length == 1) return result;//saying if the length of result array is only 1, return result b/c that means there's only 1 possible value

            //below code only executes when above if statement is NOT hit, i.e. more than 1 possible value (>= 1 ace in hand)
            for (int i = 1; i < result.Length; i++)
            {
                value += + (i * 10);
                result[i] = value;
            }
            //Above for logic exemplified:
            /*
             2 aces in a hand = 3 possible values = result.Length being 3 = i will be 0,1,2 each subsequent cycle = [2, 12, 22] as the result array returned by the for loop & capturing all possible values
             */
            return result;

        }



        public static bool CheckForBlackJack(List<Card> Hand)//passing in a list of cards called Hand...this method executes once everyone has been dealt 2 cards
        {
            int[] possibleValues = GetAllPossibleHandValues(Hand);
            int value = possibleValues.Max();//a lambda method that checks an array for max element value in array; impossible that a Min value would be 21
            if (value == 21) return true;//True! This guy has BlackJack
            else return false;

        }

        public static bool IsBusted(List<Card> Hand)
        {
            int value = GetAllPossibleHandValues(Hand).Min();//if minimum value busts, we know all possible values bust as well.
            if (value > 21) return true;
            else return false;
        }

        //This method checks if dealer has any possible hand values between 17 and 22 and if so, returns true and if not, returns false
        public static bool ShouldDealerStay(List<Card> Hand)
        {
            int[] possibleHandValues = GetAllPossibleHandValues(Hand);//if between 17 and 21 (>16 and <22), dealer must stay
            foreach (int value in possibleHandValues)
            {
                if (value > 16 && value < 22)
                {
                    return true;//if one of the possible hand values is between 17 and 21, dealer should stay; return true
                }
            }
            return false;//implies no possible hand values are between 17 and 21, so dealer should not stay
        }

        //This method will return a nullable boolean in order to denote 1 of 3 possible states: player > dealer, player < dealer, player == dealer 
        public static bool? CompareHands(List<Card> PlayerHand, List<Card> DealerHand)
        {
            int[] playerResults = GetAllPossibleHandValues(PlayerHand);
            int[] dealerResults = GetAllPossibleHandValues(DealerHand);

            //we gotta find the value in each of these arrays that is < 21, but the highest value of the values that are < 21 in each array

            int playerScore = playerResults.Where(x => x < 22).Max();//give me a list of playerResults where the value is < 22 (remember, Where() generates a list) AND get me the largest value
            int dealerScore = dealerResults.Where(x => x < 22).Max();//filters for scores < 22 and selects a single score that is the highest in value

            if (playerScore > dealerScore) return true;//player wins
            else if (playerScore < dealerScore) return false;//dealer wins
            else return null;//dealer and player tie; we are using bool? which allows null values (a nullable boolean); so this option implies playerScore == dealerScore
        }



        
        
 }

    
}
