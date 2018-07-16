using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayingCards
{
    public class DrawPile
    {
        public Card[] Cards { get; set; }

        // The DrawPile constructor takes the array of cards in a deck
        public DrawPile(Deck deck)
        {
            Cards = deck.Cards;
        }

        // TODO: Implement a DrawPile constuctor to accept a Deck[] array and make a larger combined draw pile 

        // The Draw() method removes a number of cards from the top of the draw pile and returns them to the method caller
        public Card[] Draw(int numberOfCards)
        {
            // Create an array to hold a group of card that will be handed back to the method caller
            Card[] returnCards = new Card[numberOfCards];

            // If the number of cards requested is more than the draw pile, return the entire draw pile,
            // else return the requested number of cards
            if (numberOfCards > Cards.Length)
                return Draw(Cards.Length);
            else
            {
                // Add x number of cards from the top of the draw pile to the returnCards array
                for (int i = 0; i < numberOfCards; i++)
                {
                    returnCards[i] = Cards[(Cards.Length - (i + 1))];
                }

                // Remove the cards that were drawn from the draw pile by calling the ShrinkDrawPile() method
                ShrinkDrawPile(numberOfCards);

                // Send the drawn cards back to the method caller.
                return returnCards;
            }
        }

        // The ShrinkDrawPile() method shrinks the draw pile
        private void ShrinkDrawPile(int numberOfCards)
        {
            // Create a Card[] array to hold a copy of all the cards in the current draw pile.
            Card[] copyCards = new Card[Cards.Length];

            // Copy the draw pile into the copyCards array
            for (int i = 0; i < Cards.Length; i++)
                copyCards[i] = Cards[i];

            // Shrink the draw pile by the given number of cards.
            Cards = new Card[(Cards.Length - numberOfCards)];

            // Copy the old card values back into the draw pile
            for (int i = 0; i < Cards.Length; i++)
                Cards[i] = copyCards[i];
        }

        // TODO: May need to implement a GrowDrawPile() method which accepts a Card[] arrayS
    }
}
