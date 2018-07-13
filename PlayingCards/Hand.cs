using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayingCards
{
    public class Hand
    {
        public Card[] Cards { get; set; }

        public Hand(int size)
        {
            Cards = new Card[size];
        }
    }
}
