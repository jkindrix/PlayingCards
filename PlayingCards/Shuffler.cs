using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayingCards
{
    public class Shuffler
    {
        // Splits an array of cards into 2 arrays and returns a jagged array
        public Card[][] Split(Card[] cards) 
        {
            Card[] cardPile1 = new Card[cards.Length / 2];
            Card[] cardPile2 = new Card[cards.Length - cardPile1.Length];

            for (int i = 0; i < (cards.Length / 2); i++)
                cardPile1[i] = cards[i];

            for (int i = (cards.Length / 2); i < cards.Length; i++)
                cardPile2[i - (cards.Length / 2)] = cards[i];

            return new Card[][] { cardPile1, cardPile2 };
        }

        public void Cut(Card[] cards)
        {
            Card[][] cardsAfterCutting = Split(cards);
            Card[] cardPile1 = cardsAfterCutting[0]; // First pile of cards
            Card[] cardPile2 = cardsAfterCutting[1]; // Second pile of cards (will have 1 more than cardPile1 if 'cards.Length' was odd)

            for (int i = 0; i < cardPile2.Length; i++)
                cards[i] = cardPile2[i];

            for (int i = 0, j = cardPile1.Length; i < cardPile1.Length; i++, j++)
                cards[j] = cardPile1[i];
        }

        public void RiffleShuffle(Card[] cards, int shuffleAmount = 1)
        {
            for (int shuffleNumber = 0; shuffleNumber < shuffleAmount; shuffleNumber++)
            {
                // The Cut() method cuts the cards into 2 arrays and returns a jagged array of the 2 piles it made
                Card[][] cardsAfterCutting = Split(cards); // A jagged array stores both piles after the cut
                Card[] cardPile1 = cardsAfterCutting[0]; // First pile of cards
                Card[] cardPile2 = cardsAfterCutting[1]; // Second pile of cards (will have 1 more than cardPile1 if 'cards.Length' was odd)

                // Simulate a riffle shuffle
                int indexA = 0; // Counts through the temp card arrays
                int indexB = 0; // Counts through even numbers
                int indexC = 1; // Counts through odd numbers

                while (indexA < cardPile1.Length)
                {
                    cards[indexB] = cardPile1[indexA];
                    cards[indexC] = cardPile2[indexA]; // This pile will have 1 extra card if the number of cards given were odd

                    indexA++;
                    indexB += 2;
                    indexC += 2;
                }

                if (cardPile2.Length > cardPile1.Length) // If the 2nd pile is larger than the first pile, there should be one extra card
                {
                    cards[indexB] = cardPile2[indexA]; // Place the extra card in the next slot of the array
                }
            }
        }

        public void OverhandShuffle(Card[] cards, int shuffleAmount = 1)
        {
            for (int shuffleNumber = 0; shuffleNumber < shuffleAmount; shuffleNumber++)
            {
                // The Cut() method cuts the cards into 2 arrays and returns a jagged array of the 2 piles it made
                Card[][] cardsAfterCutting = Split(cards); // A jagged array stores both piles after the cut
                Card[] cardPile1 = cardsAfterCutting[0]; // First pile of cards
                Card[] cardPile2 = cardsAfterCutting[1]; // Second pile of cards (will have 1 more than cardPile1 if 'cards.Length' was odd)

                // Simulate an overhand shuffle
                // First, cut the second pile of cards into two more piles (One goes to the front of the deck, one to the back)
                Card[][] cardsAfterCutting2 = Split(cardPile2);
                Card[] cardPile3 = cardsAfterCutting2[0];
                Card[] cardPile4 = cardsAfterCutting2[1];// Second pile of cards (will have 1 more than cardPile3 if 'cardPile4.Length' was odd)

                // Add all the cards in pile 3 to the beginning of the array, then pile 1, then pile 4

                int indexA = 0;

                for (int i = 0; i < cardPile3.Length; i++)
                {
                    cards[indexA] = cardPile3[i];
                    indexA++;
                }
                for (int i = 0; i < cardPile1.Length; i++)
                {
                    cards[indexA] = cardPile1[i];
                    indexA++;
                }
                for (int i = 0; i < cardPile4.Length; i++)
                {
                    cards[indexA] = cardPile4[i];
                    indexA++;
                }
            }
        }

        public void HinduShuffle(Card[] cards, int shuffleAmount = 1)
        {
            for (int shuffleNumber = 0; shuffleNumber < shuffleAmount; shuffleNumber++)
            {
                // Crate a copy of the 'cards' array
                Card[] tempCardArray = new Card[cards.Length];

                // Copy all values over from 'cards' to 'tempCardArray'
                for (int i = 0; i < cards.Length; i++)
                {
                    tempCardArray[i] = cards[i];
                }

                Random rand = new Random();
                int randNum = rand.Next(3, 8); // Get the next random number of cards to take

                int indexA = 0; // Keep track of the index of tempCardArray which is in the left hand

                // Keep track of the number of cards in the right hand
                int indexB = ((cards.Length) - (randNum)); // Initial value is the amount of cards that 'will' exist at the end of the array

                while (true)
                {
                    for (int i = 0; i < randNum; i++)
                    {
                        cards[indexB] = tempCardArray[indexA];
                        indexA++;
                        indexB++;
                    }

                    indexB -= (randNum + 1); // Next position that cards are placed in the right hand

                    randNum = rand.Next(3, 8); // Get the next random number and restart the loop

                    if (indexB - (randNum - 1) <= 0)
                        break;
                    else
                        indexB -= (randNum - 1);
                }

                int indexC = 0;

                for (int i = 0; i <= indexB; i++)
                {
                    cards[indexC] = tempCardArray[indexA];
                    indexA++;
                    indexC++;
                }
            }
        }

        public void MixUp(Card[] cards, int shuffleAmount = 25)
        {
            for (int shuffleNumber = 0; shuffleNumber < shuffleAmount; shuffleNumber++)
            {
                OverhandShuffle(cards);
                for (int shuffleNumber1 = 0; shuffleNumber1 < shuffleAmount; shuffleNumber1++)
                {
                    HinduShuffle(cards);
                    for (int shuffleNumber2 = 0; shuffleNumber2 < shuffleAmount; shuffleNumber2++)
                    {
                        Cut(cards);
                        for (int shuffleNumber3 = 0; shuffleNumber3 < shuffleAmount; shuffleNumber3++)
                        {
                            RiffleShuffle(cards);
                        }
                    }
                }
            }
        }
    }
}
