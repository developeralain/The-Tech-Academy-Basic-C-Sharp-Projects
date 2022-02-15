using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Casino.TwentyOne
{
    public class TwentyOneDealer : Dealer
    {
        private List<Card> _hand = new List<Card>();
        public List<Card> Hand { get { return _hand; } set { _hand = value; } }//a dealer has his/her own hand
        
        public bool Stay { get; set; }//if you feel you've reached close enough to 21, you can Stay b/c you don't want to risk taking a card and going over 21 b/c then you Bust
        public bool IsBusted { get; set; }//dealer went > 21 
    }
}
