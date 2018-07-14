using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PlayingCards;

namespace GoFish
{
    class Game
    {
        // Boolean property defining if the game is over
        public bool IsOver { get; set; }

        public Game()
        {
            Deck deck = new Deck();
            deck.Print();
            DrawPile drawPile = new DrawPile(deck);
            drawPile.Draw(5);

            DiscardPile discard = new DiscardPile();
            Dealer dealer = new Dealer();
        }
    }
}
