using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayingCards
{
    public class Player
    {
        public int Score { get; set; }
        public Hand Hand { get; set; }
        public bool IsTurn { get; set; }

        public Player(int handSize)
        {
            Hand hand = new Hand(handSize);
        }

        public void TakeTurn()
        {

        }

    }
}
