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
            Card[] cardStack1 = new Card[splitIndex];

            // The size of the second stack is everything left over.
            Card[] cardStack2 = new Card[(numOfCards - cardStack1.Length)];

            // Move the first half of the given cards into the first stack.
            for (int i = 0; i < splitIndex; i++)
                cardStack1[i] = cards[i];

            // Move the remaining cards into a second stack.
            for (int i = splitIndex; i < cards.Length; i++)
                cardStack2[(i - splitIndex)] = cards[i];

            // Return both stacks of cards to the method caller.
            return new Card[][] { cardStack1, cardStack2 };
        }

        // The Cut() method splits a set of cards in half, and places the second stack on top of the first.
        public void Cut(Card[] cards)
        {
            // Use the Split() method to get 2 stacks of cards.
            Card[][] cardsAfterCutting = Split(cards);

            // If the number of cards is uneven, the second stack will be larger.
            Card[] cardStack1 = cardsAfterCutting[0];
            Card[] cardStack2 = cardsAfterCutting[1]; 

            // Place the top stack where the bottom stack used to be
            for (int i = 0; i < cardStack2.Length; i++)
                cards[i] = cardStack2[i];

            // Place the bottom stack where the top stack used to be
            for (int i = 0, j = cardStack1.Length; i < cardStack1.Length; i++, j++)
                cards[j] = cardStack1[i];
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
                Card[] cardStack1 = cardsAfterCutting[0];
                Card[] cardStack2 = cardsAfterCutting[1];

                // Create a counter used later for looping through the indexes of the two stacks.
                int indexA = 0;

                // Create a counter used later for looping through the indexes of the final card stack (counts even numbers by 2s).
                int indexB = 0;

                // Create a counter used later for looping through the indexes of the final card stack (counts odd numbers by 2s).
                int indexC = 1;

                // Shuffle the two stacks of cards back together into a single stack.
                while (indexA < cardStack1.Length)
                {
                    cards[indexB] = cardStack1[indexA];
                    cards[indexC] = cardStack2[indexA];

                    indexA++;
                    indexB += 2;
                    indexC += 2;
                }

                // If the 2nd stack is larger than the first stack, there will be an extra card leftover.
                // Place the extra card on top of the final stack.
                // // This means 2 cards that were touching in the original stack will still be touching in the final stack,
                // // but a second riffle shuffle would take care of this.
                if (cardStack2.Length > cardStack1.Length)
                {
                    cards[indexB] = cardStack2[indexA];
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
                Card[] cardStack1 = cardsAfterCutting[0];
                Card[] cardStack2 = cardsAfterCutting[1];

                // Simulate an overhand shuffle
                //
                // First, use the Split() method on the second stack of cards to break it down further
                Card[][] cardsAfterCutting2 = Split(cardStack2);

                // Of the two new stacks, one will be moved to the front of the deck, one to the back
                // The stack cardStack4 will have one more card than cardStack3 if cardStack4.Length2 was odd.
                Card[] cardStack3 = cardsAfterCutting2[0];
                Card[] cardStack4 = cardsAfterCutting2[1];

                // There are now three stacks

                // Create a counter for adding cards into the final array
                int indexA = 0;

                // The first to be added into the final array is cardStack3 
                for (int i = 0; i < cardStack3.Length; i++)
                {
                    cards[indexA] = cardStack3[i];
                    indexA++;
                }

                // Next, move the cards in cardStack1 on top of cardStackS3
                for (int i = 0; i < cardStack1.Length; i++)
                {
                    cards[indexA] = cardStack1[i];
                    indexA++;
                }

                // Last, move the cards in cardStack4 on top of cardStack1
                for (int i = 0; i < cardStack4.Length; i++)
                {
                    cards[indexA] = cardStack4[i];
                    indexA++;
                }
            }
        }

        public void HinduShuffle(Card[] cards, int shuffleAmount = 1)
        {
            for (int shuffleNumber = 0; shuffleNumber < shuffleAmount; shuffleNumber++)
            {
                // This shuffle requires some cards in the left hand and right hand,
                // so 2 arrays are required to represent the state of each hand

                // Crate a copy of the 'cards' array (This will represent the cards in the left hand)
                Card[] tempCardArray = new Card[cards.Length];

                // Copy all values over from 'cards' to 'tempCardArray'
                // (Move all cards from the right hand to the left hand)
                for (int i = 0; i < cards.Length; i++)
                {
                    tempCardArray[i] = cards[i];
                }

                Random rand = new Random();
                int randNum = rand.Next(3, 8); 

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
