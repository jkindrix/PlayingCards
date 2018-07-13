using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PlayingCards;

namespace GoFish
{
    class NewGame
    {
        public static void Setup()
        {
            Deck deck = new Deck();
            deck.Print();

            DrawPile draw = new DrawPile();
            DiscardPile discard = new DiscardPile();
            Dealer dealer = new Dealer();
        }
    }
}
