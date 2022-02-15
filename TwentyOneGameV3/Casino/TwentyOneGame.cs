using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Casino.TwentyOne
{
    public class TwentyOneGame : Game, Casino.Interfaces.IWalkAway
    {
        public TwentyOneDealer Dealer { get; set; }//dealer is specific to the game 21 and not ALL games, so we add the TwentyOneDealer object as a Dealer property to this class

        //The TwentyOneGame class Play() method is going to play one hand while the while loop is happening (at end of hand we ask player if they want to keep playing)
        public override void Play()//this is an abstract method of the Game abstract class. We mimic the datatype (void) and name/parameters of the abstract method, but use 
                                   //override keyword to allow us to include our own implementation details.
        {
            Dealer = new TwentyOneDealer();//instantiates a new TwentyOneDealer class object
            //since a while loop is going on in Main() and we don't know where we're at in the game exactly, we wanna reset all the players...this play method is going to play 1 hand and 
            //at the end of the hand we'll ask the player if he wants to keep playing and he/she says "Yes" then isActivelyPlaying remains True and if he/she says "No" then we exit loop

            foreach (Player player in Players)//we want to perform the action on ALL players, as this game is capable of being played with more than just a single user and dealer.
                //Players is a list property of the Game class and it is a List of players
            {
                //on the very start of each hand/each round of playing where the dealer deals, we want the player's hand to be blank (no cards) 
                player.Hand = new List<Card>();
                player.Stay = false;//b/c if stay was true at the end of the previous round, we don't want that to carry over into the new round

            }
            Dealer.Hand = new List<Card>();//we also want the dealer's hand to be a new hand as we don't want carry-over from previous round
            Dealer.Stay = false;//don't want dealer stay from last round to carry over into a new round 
            Dealer.Deck = new Deck();//b/c we don't want to end up with a partial deck from the previous round and we don't want each round to have influence over the subsequent round
            Dealer.Deck.Shuffle();


            foreach (Player player in Players)//loop through each player and have them place a bet
            {
                bool validAnswer = false;
                int bet = 0;

                while (!validAnswer)
                {
                    Console.WriteLine("Place your bet!");
                    validAnswer = int.TryParse(Console.ReadLine(), out bet);
                    if (!validAnswer) Console.WriteLine("Please enter digits only: no letters or decimals.");
                }
                if (bet < 0)//throws exception if player attempts to enter a negative bet value
                {
                    throw new FraudException();//this represents an exception that we created for the specific event that a player tries to cheat the Casino by entering negative bet amounts
                }

                
                //even though this console app is being built for only one player, having a foreach loop iterate through a list of players allows for future development of multiplayer functionality
                bool successfullyBet = player.Bet(bet);//if the bet works, this bool value will be true
                if (!successfullyBet)//so if successfullyBet above returns false, !false means true means this if statement will run i.e. if player doesn't have $ to make that bet, this will run
                {
                    return;//even though this is a void method that doesn't return anything, this return is saying "End this method"
                    //so this return exits this method that was called in the Program.cs Main method, specifically within the While loop. But, so long as playerIsActive remains true, the 
                    //while loop will continue and thus hit this same method again. This Play() method will run once more, starting from the top.
                }
                //Below code will execute if successfullyBet returns true
                //How do we track bets, i.e. which player bet how much? Best way is via a dictionary: collection of KVPs where player is the key and the value is the amount they bet 
                //So when we want to pay a player out, we just look up their name in the dictionary and pay out whatever 
                //The dictionary itself will be created within the Game class b/c all games, for our purposes, will have bets 

                //So, if bet was successful let's create a dictionary entry for the player
                Bets[player] = bet;//log the player name as a key and player bet as a value in the dictionary

                //Next step: to DEAL! 
                //Each player starts out with 2 cards and the way you do it is: pass everyone a card, then pass dealer a card, then pass everyone a card, then pass dealer a card
                //Note: most 21 games have both dealer cards face down or one card face down and one card face up, but for simplicity we'll have both cards face up
            }//
            for (int i = 0; i < 2; i++)// < 2 b/c all players and dealers need 2 cards each, so we'll run the foreach twice
            {
                Console.WriteLine("Dealing...");
                foreach (Player player in Players)
                {
                    Console.Write("{0}: ", player.Name);//what Console.Write() does it it writes, but the next thing that comes after it will NOT be on a new line (in contrast to .WriteLine())
                    Dealer.Deal(player.Hand);//passing in the player's hand to the Deal method within the Dealer Class, and this hand comes back with a card added to it from Dealer's deck,
                                             //and this added card is also printed out to the console so the player can see what card was added to their hand
                                             //in 21 players can see each others' cards and are competing vs the Dealer, and the Dealer doesn't get a competitive advantage vs Players by seeing their cards

                    //in blackjack, if you get an ace and a face card then you automatically have Blackjack/win the hand and earn 1.5x your bet--so we must check for this condition as soon as 
                    //you get your 2nd card...we don't want to bake this in to our Play() method as it's already bloated: we'll add it to the Business Logic Layer (a layer is a a separate class
                    //that exists w/o knowledge of other classes and it has a function or feature to it (e.g. you can have a class that added data to the database and you could call it the data
                    //access layer b/c you use that class to add things to the database)

                    //we're gonna have a business logic layer by creating a static Class called TwentyOneRules (i.e. we don't need to create an object to use its methods). It'll have a bunch of 
                    //methods in it we can call that'll contain the logic (e.g. check for blackjack, pass in a hand and return a boolean answering 'is this blackjack?', etc.)

                    //to actually be able to check for blackjack you need to check the value of each card and the total value of the hand at that time...


                    if (i == 1)//if i == 1 that means we're on the 2nd card / it's the second run of the foreach loop
                    {
                        bool blackJack = TwentyOneRules.CheckForBlackJack(player.Hand);//static method so we must preface with class name; passes 
                        if (blackJack)
                        {
                            Console.WriteLine("Blackjack! {0} wins {1}", player.Name, Bets[player]);
                            player.Balance += Convert.ToInt32((Bets[player] * 1.5) + Bets[player]);//in Blackjack you win your bet x 1.5 plus you get your bet back
                            return;
                        }
                    }

                }
                Console.Write("Dealer: ");//if blackjack did not happen we have to deal the dealer 
                Dealer.Deal(Dealer.Hand);
                if (i == 1)//if i == 1 that means we're on the 2nd card / it's the second run of the foreach loop; the follow code now checks to see if dealer got blackjack
                {
                    bool blackJack = TwentyOneRules.CheckForBlackJack(Dealer.Hand);//b/c static method we preface /w class name
                    if (blackJack)
                    {
                        Console.WriteLine("Dealer has BlackJack! Everyone loses!");
                        foreach (KeyValuePair<Player, int> entry in Bets)
                        //if dealer gets blackjack/win they collect all player bets, thus we must iterate through the dictionary and collect all player bets 

                        {
                            Dealer.Balance += entry.Value;
                        }
                        return;
                    }

                }
                //UP TO THIS POINT WE'VE ONLY ADDRESSED INITIAL DEAL (everyone with 2 cards): we haven't gotten to the logic of if a player wants to stay or hit
                //So now we need to go through each player and ask them: do you want to hit or do you want to stay? And we keep giving them cards until they bust or stay
            }//
                    foreach (Player player in Players)
                    {
                        //so we're going to focus on a single player and keep asking them 'hit or stay' until they say stay
                        while (!player.Stay)
                        {
                            Console.WriteLine("Your cards are: ");
                            foreach (Card card in player.Hand)
                            {
                                Console.Write("{0} ", card.ToString());//The ToString() will return a string formatted as FACE of SUIT (e.g. Ace of Spades)

                            }
                            Console.WriteLine("\n\nHit or stay?");
                            string answer = Console.ReadLine().ToLower();
                            if (answer == "stay")
                            {
                                player.Stay = true;//set value of Stay to true
                                break; //breaks loop (ends it right here) and has computer check the loop condition anew...loop will stop after condition check because we just made Stay == true
                            }
                            else if (answer == "hit")
                            {
                                Dealer.Deal(player.Hand);//if player wants a hit, we call the Deal method of the Dealer class and their hand gets passed in, a card is added, their hand is returned
                                //the card is automatically printed to console as this is part of the Deal method (automatically prints card)
                            }
                            bool busted = TwentyOneRules.IsBusted(player.Hand);//calls method to return a true or false re: if they busted; this line runs after each hit/after each card a player is dealt
                            if (busted)
                            {
                                Dealer.Balance += Bets[player];//if player busts, we need to give their money to the dealer; access bets of a given player via the dictionary we created
                                Console.WriteLine("{0} Busted! You lose your bet of {1}. Your balance is now {2}.", player.Name, Bets[player], player.Balance);
                                Console.WriteLine("Do you want to play again?");
                                answer = Console.ReadLine().ToLower();
                                if (answer == "yes" || answer == "yeah")
                                {
                                    player.isActivelyPlaying = true;
                                    return;//ends the void function --> will take us back to Program.cs to the While loop and evaluate the condition for continuing to run the While loop
                                }
                                else
                                {
                                    player.isActivelyPlaying = false;
                                    return;//ends the void function --> will take us back to Program.cs to the While loop and evaluate the condition for continuing to run the While loop
                                }
                                //remember in our Program.cs, this game.Play() is only running while isActivelyPlaying = true
                            }
                        }
                    }


                //}

            //}
            //Now we need to do the logic for the dealer:
            /*
             Dealer advantages in 21: can wait to see if other players bust (if player busts before the dealer, that player still loses). Dealer doesn't get cards until all players get cards
             */
            Dealer.IsBusted = TwentyOneRules.IsBusted(Dealer.Hand);//after deal gets his 2 cards, this checks to see if he's busted
            Dealer.Stay = TwentyOneRules.ShouldDealerStay(Dealer.Hand);//calls method to check if dealer's hand has any possible values between 17 and 22--if so, they should stay
            //so we assume if dealer is NOT staying, we keep giving him/her cards
            while (!Dealer.Stay && !Dealer.IsBusted)//as long as dealer is not buster and so long as he is not staying, we continue to give him cards
            {
                Console.WriteLine("Dealer is hitting...");
                Dealer.Deal(Dealer.Hand);//passing in dealer hand to this Deal method to deal a card to his hand and return said hand with added card in it
                Dealer.IsBusted = TwentyOneRules.IsBusted(Dealer.Hand);//checks if busted and if true, while loop breaks
                Dealer.Stay = TwentyOneRules.ShouldDealerStay(Dealer.Hand);//checks if shouldstay and if true, while loop breaks
            }
            if (Dealer.Stay)
            {
                Console.WriteLine("Dealer is staying.");

            }
            if (Dealer.IsBusted)
            {
                Console.WriteLine("Dealer Busted!");
                foreach (KeyValuePair<Player, int> entry in Bets)//checks Bets dictionary and corresponding player (key) and bet (value) pairs for each player
                {
                    Console.WriteLine("{0} won {1}!", entry.Key.Name, entry.Value);//this prints which player(s) won what bet(s); this demonstrates how to access keys and values in a dictionary
                    //now we need to give the money that each player won to their balance
                    Players.Where(x => x.Name == entry.Key.Name).First().Balance += (entry.Value * 2);//lambda expression
                    //Lambda expression explained:
                    /*
                     We're looping through each KVP in the Bets dictionary as instructed in the foreach loop expression
                     and we're finding the player in the Players list that matches the KVP we're dealing with ( checking Players list for player names that match dictionary key names within Bets dictionary)
                     So Where() produces a list and even though they'll only be one player in that list, we still need to grab the player using First() (first in list) 
                     After grabbing that player, we take that player's Balance and we add what they bet * 2 to their balance (entry.Value * 2)
                     */
                    Dealer.Balance -= entry.Value;//we then deduct the amount a player bet from the dealer's balance
                }
                return; //when a dealer busts it ends the round, so we just return from this Play() method (exit it)
            }

            //What is both dealer and player Stay and neither bust? We need to compare Dealer and Player hand values then. Whover has highest value wins and if they tie, they Push
            //3 possibilities: player hand value > dealer, player hand value < dealer, player hand value == dealer
            //Solution is to use a Boolean with 3 possibilities! =D 
            /*
             Booleans are strucks, meaning they are a value type and thus cannot have a Null value (it is either true or false and that's it)...however, if it could be Null then we'd have 3
            options for the boolean: true, false, null ... 
            How to make a boolean take a value null:
            bool? playerWon =      ... so this turns the boolean datatype into a nullable boolean - this ? at the end of bool (bool?)
             */
            foreach (Player player in Players)//loops through all players in the game and compares their hand to the dealer's hand
            {
                bool? playerWon = TwentyOneRules.CompareHands(player.Hand, Dealer.Hand);
                //outputs: true if player won, false if player lost, null if player and dealer tied

                if (playerWon == null)//so a null signifies a Push which is a tie in Blackjack and no one wins, but everyone gets their bets back
                {
                    Console.WriteLine("Push! No one wins.");
                    player.Balance += Bets[player];//return bets to the player
                }
                else if (playerWon == true)
                {
                    Console.WriteLine("{0} won {1}!", player.Name, Bets[player]);
                    player.Balance += (Bets[player] * 2);//winning means they get double whatever they bet back
                    Dealer.Balance -= Bets[player];//dealer loses whatever the player bet
                }
                else
                {
                    Console.WriteLine("Dealer wins {0}!", Bets[player]);//Bets[player] evaluates to an integer, this is just you passing the key to the integer value within Bets dictionary
                    Dealer.Balance += Bets[player];//add w/e player bet to the dealer's balance (dealer gets this money)                    
                }
                Console.WriteLine("Play again?");
                string answer = Console.ReadLine().ToLower();
                if (answer == "yes" || answer == "yeah")
                {
                    player.isActivelyPlaying = true;
                }
                else
                {
                    player.isActivelyPlaying = false;
                }
            }            
        }
        public override void ListPlayers()//this is a virtual method of the Game abstract class. We use the override keyword to add our own implementation details to it.
        {
            Console.WriteLine("21 Players:");//this is code not existing in the Game class' virtual method, but code that we added ourselves for this class specifically
            base.ListPlayers();//this is equivalent to the code that exists within this virtual method in the Game class (it encapsulates the existing logic of this method)
        }
        public void WalkAway(Player player)//b/c this class inherits from interface IWalkAway, it MUST implement its methods as well
                                           //you must match the interface method's return type, being 'void'. If you tried to make the return type 'int', it wouldn't work.
        {
            throw new NotImplementedException();
        }
    }
}