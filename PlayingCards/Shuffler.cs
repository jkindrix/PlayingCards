using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayingCards
{
    // The Shuffler class has methods which accept an array of cards and re-organize them or split them into groups
    // TODO: Potentially modify or refactor the Shuffler Split() and different xShuffle() methods to better mix the cards
    public class Shuffler
    {
        // The Split() method splits a set of cards in half and returns the 2 stacks as a jagged array.
        // I was going to make this method split at a random location somewhere in the middle of the deck instead of the halfway point,
        // but I decided not to since it would actually make RiffleShuffle() less effective.
        
        private Card[][] Split(Card[] cards)
        {
            // Count the number of cards in the set.
            int numOfCards = cards.Length;

            // Find the index at half of the cards.
            int splitIndex = (numOfCards / 2);

            // The size of the first stack is half of the cards rounded down.
            Card[] cardstack1 = new Card[splitIndex];

            // The size of the second stack is everything left over.
            Card[] cardstack2 = new Card[(numOfCards - cardstack1.Length)];

            // Move the first half of the given cards into the first stack.
            for (int i = 0; i < splitIndex; i++)
                cardstack1[i] = cards[i];

            // Move the remaining cards into a second stack.
            for (int i = splitIndex; i < cards.Length; i++)
                cardstack2[(i - splitIndex)] = cards[i];

            // Return both stacks of cards to the method caller.
            return new Card[][] { cardstack1, cardstack2 };
        }

        // The Cut() method splits a set of cards in half, and places the second stack on top of the first.
        public void Cut(Card[] cards)
        {
            // Use the Split() method to get 2 stacks of cards.
            Card[][] cardsAfterCutting = Split(cards);

            // If the number of cards is uneven, the second stack will be larger.
            Card[] cardstack1 = cardsAfterCutting[0];
            Card[] cardstack2 = cardsAfterCutting[1]; 

            // Place the top stack where the bottom stack used to be
            for (int i = 0; i < cardstack2.Length; i++)
                cards[i] = cardstack2[i];

            // Place the bottom stack where the top stack used to be
            for (int i = 0, j = cardstack1.Length; i < cardstack1.Length; i++, j++)
                cards[j] = cardstack1[i];
        }

        // The RiffleShuffle() method attempts to simulate a riffle shuffle
        public void RiffleShuffle(Card[] cards, int shuffleAmount = 1)
        {
            // Repeat the shuffle for the number of times requested
            for (int shuffleNumber = 0; shuffleNumber < shuffleAmount; shuffleNumber++)
            {
                // Use the Split() method to get 2 stacks of cards.
                Card[][] cardsAfterCutting = Split(cards);

                // If the number of cards is uneven, the second stack will be larger.
                Card[] cardstack1 = cardsAfterCutting[0];
                Card[] cardstack2 = cardsAfterCutting[1];

                // Create a counter used later for looping through the indexes of the two stacks.
                int indexA = 0;

                // Create a counter used later for looping through the indexes of the final card stack (counts even numbers by 2s).
                int indexB = 0;

                // Create a counter used later for looping through the indexes of the final card stack (counts odd numbers by 2s).
                int indexC = 1;

                // Shuffle the two stacks of cards back together into a single stack.
                while (indexA < cardstack1.Length)
                {
                    cards[indexB] = cardstack1[indexA];
                    cards[indexC] = cardstack2[indexA];

                    indexA++;
                    indexB += 2;
                    indexC += 2;
                }

                // If the 2nd stack is larger than the first stack, there will be an extra card leftover.
                // Place the extra card on top of the final stack.
                // // This means 2 cards that were touching in the original stack will still be touching in the final stack,
                // // but a second riffle shuffle would take care of this.
                if (cardstack2.Length > cardstack1.Length)
                {
                    cards[indexB] = cardstack2[indexA];
                }
            }
        }

        // The OverhandShuffle() method attempts to simulate an overhand shuffle
        public void OverhandShuffle(Card[] cards, int shuffleAmount = 1)
        {
            // Repeat the shuffle for the number of times requested
            for (int shuffleNumber = 0; shuffleNumber < shuffleAmount; shuffleNumber++)
            {
                // Use the Split() method to get 2 stacks of cards.
                Card[][] cardsAfterCutting = Split(cards);

                // If the number of cards is uneven, the second stack will be larger.
                Card[] cardstack1 = cardsAfterCutting[0];
                Card[] cardstack2 = cardsAfterCutting[1];

                // Simulate an overhand shuffle
                //
                // First, use the Split() method on the second stack of cards to break it down further
                // Of the two new stacks, one will be moved to the front of the deck, one to the back
                Card[][] cardsAfterCutting2 = Split(cardstack2);
                Card[] cardstack3 = cardsAfterCutting2[0];
                Card[] cardstack4 = cardsAfterCutting2[1]; // Second stack of cards (will have 1 more than cardstack3 if 'cardstack4.Length' was odd)

                // Add all the cards in stack 3 to the beginning of the array, then stack 1, then stack 4

                int indexA = 0;

                for (int i = 0; i < cardstack3.Length; i++)
                {
                    cards[indexA] = cardstack3[i];
                    indexA++;
                }
                for (int i = 0; i < cardstack1.Length; i++)
                {
                    cards[indexA] = cardstack1[i];
                    indexA++;
                }
                for (int i = 0; i < cardstack4.Length; i++)
                {
                    cards[indexA] = cardstack4[i];
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
