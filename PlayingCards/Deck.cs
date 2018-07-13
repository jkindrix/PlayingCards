using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayingCards
{
    public class Deck
    {
        // A Deck is a container for an array of cards
        // Each card is instantiated and added to an array named 'cards'

        private bool IncludeJokers { get; }
        private int NumberOfCards { get; }

        public Card[] Cards { get; } // This property is an array of card objects

        public Deck(bool includeJokers = false)
        {
            IncludeJokers = includeJokers;

            if (includeJokers == true)
                NumberOfCards = 54;
            else
                NumberOfCards = 52;

            Cards = new Card[NumberOfCards];

            BuildDeck();
            Shuffle();
        }

        public void Shuffle()
        {
            Shuffler shuffler = new Shuffler();
            shuffler.MixUp(Cards);
        }

        private void BuildDeck()
        {
            // Add Hearts
            Cards[0] = new Card(CardColor.Red, CardSuit.Heart, CardRank.Ace, "Ace of Hearts", 1);
            Cards[1] = new Card(CardColor.Red, CardSuit.Heart, CardRank.Two, "Two of Hearts", 2);
            Cards[2] = new Card(CardColor.Red, CardSuit.Heart, CardRank.Three, "Three of Hearts", 3);
            Cards[3] = new Card(CardColor.Red, CardSuit.Heart, CardRank.Four, "Four of Hearts", 4);
            Cards[4] = new Card(CardColor.Red, CardSuit.Heart, CardRank.Five, "Five of Hearts", 5);
            Cards[5] = new Card(CardColor.Red, CardSuit.Heart, CardRank.Six, "Six of Hearts", 6);
            Cards[6] = new Card(CardColor.Red, CardSuit.Heart, CardRank.Seven, "Seven of Hearts", 7);
            Cards[7] = new Card(CardColor.Red, CardSuit.Heart, CardRank.Eight, "Eight of Hearts", 8);
            Cards[8] = new Card(CardColor.Red, CardSuit.Heart, CardRank.Nine, "Nine of Hearts", 9);
            Cards[9] = new Card(CardColor.Red, CardSuit.Heart, CardRank.Ten, "Ten of Hearts", 10);
            Cards[10] = new Card(CardColor.Red, CardSuit.Heart, CardRank.Jack, "Jack of Hearts", 11);
            Cards[11] = new Card(CardColor.Red, CardSuit.Heart, CardRank.Queen, "Queen of Hearts", 12);
            Cards[12] = new Card(CardColor.Red, CardSuit.Heart, CardRank.King, "King of Hearts", 13);

            // Add Diamonds
            Cards[13] = new Card(CardColor.Red, CardSuit.Diamond, CardRank.Ace, "Ace of Diamonds", 1);
            Cards[14] = new Card(CardColor.Red, CardSuit.Diamond, CardRank.Two, "Two of Diamonds", 2);
            Cards[15] = new Card(CardColor.Red, CardSuit.Diamond, CardRank.Three, "Three of Diamonds", 3);
            Cards[16] = new Card(CardColor.Red, CardSuit.Diamond, CardRank.Four, "Four of Diamonds", 4);
            Cards[17] = new Card(CardColor.Red, CardSuit.Diamond, CardRank.Five, "Five of Diamonds", 5);
            Cards[18] = new Card(CardColor.Red, CardSuit.Diamond, CardRank.Six, "Six of Diamonds", 6);
            Cards[19] = new Card(CardColor.Red, CardSuit.Diamond, CardRank.Seven, "Seven of Diamonds", 7);
            Cards[20] = new Card(CardColor.Red, CardSuit.Diamond, CardRank.Eight, "Eight of Diamonds", 8);
            Cards[21] = new Card(CardColor.Red, CardSuit.Diamond, CardRank.Nine, "Nine of Diamonds", 9);
            Cards[22] = new Card(CardColor.Red, CardSuit.Diamond, CardRank.Ten, "Ten of Diamonds", 10);
            Cards[23] = new Card(CardColor.Red, CardSuit.Diamond, CardRank.Jack, "Jack of Diamonds", 11);
            Cards[24] = new Card(CardColor.Red, CardSuit.Diamond, CardRank.Queen, "Queen of Diamonds", 12);
            Cards[25] = new Card(CardColor.Red, CardSuit.Diamond, CardRank.King, "King of Diamonds", 13);

            // Add Clubs
            Cards[26] = new Card(CardColor.Black, CardSuit.Club, CardRank.Ace, "Ace of Clubs", 1);
            Cards[27] = new Card(CardColor.Black, CardSuit.Club, CardRank.Two, "Two of Clubs", 2);
            Cards[28] = new Card(CardColor.Black, CardSuit.Club, CardRank.Three, "Three of Clubs", 3);
            Cards[29] = new Card(CardColor.Black, CardSuit.Club, CardRank.Four, "Four of Clubs", 4);
            Cards[30] = new Card(CardColor.Black, CardSuit.Club, CardRank.Five, "Five of Clubs", 5);
            Cards[31] = new Card(CardColor.Black, CardSuit.Club, CardRank.Six, "Six of Clubs", 6);
            Cards[32] = new Card(CardColor.Black, CardSuit.Club, CardRank.Seven, "Seven of Clubs", 7);
            Cards[33] = new Card(CardColor.Black, CardSuit.Club, CardRank.Eight, "Eight of Clubs", 8);
            Cards[34] = new Card(CardColor.Black, CardSuit.Club, CardRank.Nine, "Nine of Clubs", 9);
            Cards[35] = new Card(CardColor.Black, CardSuit.Club, CardRank.Ten, "Ten of Clubs", 10);
            Cards[36] = new Card(CardColor.Black, CardSuit.Club, CardRank.Jack, "Jack of Clubs", 11);
            Cards[37] = new Card(CardColor.Black, CardSuit.Club, CardRank.Queen, "Queen of Clubs", 12);
            Cards[38] = new Card(CardColor.Black, CardSuit.Club, CardRank.King, "King of Clubs", 13);

            // Add Spades
            Cards[39] = new Card(CardColor.Black, CardSuit.Spade, CardRank.Ace, "Ace of Spades", 1);
            Cards[40] = new Card(CardColor.Black, CardSuit.Spade, CardRank.Two, "Two of Spades", 2);
            Cards[41] = new Card(CardColor.Black, CardSuit.Spade, CardRank.Three, "Three of Spades", 3);
            Cards[42] = new Card(CardColor.Black, CardSuit.Spade, CardRank.Four, "Four of Spades", 4);
            Cards[43] = new Card(CardColor.Black, CardSuit.Spade, CardRank.Five, "Five of Spades", 5);
            Cards[44] = new Card(CardColor.Black, CardSuit.Spade, CardRank.Six, "Six of Spades", 6);
            Cards[45] = new Card(CardColor.Black, CardSuit.Spade, CardRank.Seven, "Seven of Spades", 7);
            Cards[46] = new Card(CardColor.Black, CardSuit.Spade, CardRank.Eight, "Eight of Spades", 8);
            Cards[47] = new Card(CardColor.Black, CardSuit.Spade, CardRank.Nine, "Nine of Spades", 9);
            Cards[48] = new Card(CardColor.Black, CardSuit.Spade, CardRank.Ten, "Ten of Spades", 10);
            Cards[49] = new Card(CardColor.Black, CardSuit.Spade, CardRank.Jack, "Jack of Spades", 11);
            Cards[50] = new Card(CardColor.Black, CardSuit.Spade, CardRank.Queen, "Queen of Spades", 12);
            Cards[51] = new Card(CardColor.Black, CardSuit.Spade, CardRank.King, "King of Spades", 13);

            if (IncludeJokers == true)
            {
                // Add two Joker cards
                Cards[52] = new Card(CardColor.None, CardSuit.None, CardRank.Joker, "Joker");
                Cards[53] = new Card(CardColor.None, CardSuit.None, CardRank.Joker, "Joker");
            }
        }

        // For debugging
        // TODO: Make debugging sections private
        public void Print()
        {
            foreach (Card card in Cards)
            {
                Console.WriteLine(card.Name);
            }
        }
    }
}
