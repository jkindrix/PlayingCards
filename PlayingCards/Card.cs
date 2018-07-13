using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayingCards
{
    public enum CardColor { None, Black, Red }
    public enum CardSuit { None, Heart, Diamond, Club, Spade }
    public enum CardRank { Joker, Ace, Two, Three, Four, Five, Six, Seven, Eight, Nine, Ten, Jack, Queen, King }

    public class Card
    {
        public CardColor Color { get;}
        public CardSuit Suit { get; }
        public CardRank Rank { get; }
        public string Name { get; }
        public int Value { get; }
        //public bool InDrawPile { get; set; }
        //public bool InDiscardPile { get; set; }

        public Card(CardColor color, CardSuit suit, CardRank rank, string name, int value = 0)
        {
            Color = color;
            Suit = suit;
            Rank = rank;
            Name = name;
            Value = value;
        }
    }
}
