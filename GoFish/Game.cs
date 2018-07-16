using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PlayingCards;

namespace GoFish
{
    // The Game class is responsible for creating and tracking all the objects that make up a game
    class Game
    {
        // Boolean property defining if the game is over
        public bool IsOver { get; set; }

        // Create an array of players
        public Player[] Players { get; set; }

        // Integer for how many players there will be
        public int NumberOfPlayers { get; set; }

        public int StartingHandSize { get; set; }

        public Game(int numberOfPlayers = 2)
        {
            // Set the number of players
            NumberOfPlayers = numberOfPlayers;

            // Create the players
            AddPlayers(numberOfPlayers);

            // Build a new deck
            Deck deck = new Deck();
            //deck.Print();
            
            // Add the shuffled deck to the drawpile
            DrawPile drawPile = new DrawPile(deck);
            //drawPile.Draw(5);

            // Create a new Dealer
            Dealer dealer = new Dealer();

            // Deal the starting hands to each player
            dealer.Deal(drawPile, Players);

            // Loop through the turns of the game until someone wins
            Loop();
        }

        private void AddPlayers(int numberOfPlayers)
        {
            // TODO: Ask the player how many players there are
            // Create the correct number of Players
            Players = new Player[numberOfPlayers];

            // Set the starting hand size
            if (NumberOfPlayers > 2)
                StartingHandSize = 5;
            else
                StartingHandSize = 7;

            // Create all players with a hand size of 7
            for (int i = 0; i < NumberOfPlayers; i++)
                Players[i] = new Player(StartingHandSize);
        }

        public void Loop()
        {
            // If the win condition is not met, start or continue the game
            while (IsOver == false)
            {
                foreach (Player player in Players)
                {
                    player.IsTurn = true;
                    player.TakeTurn();

                    if (CheckWin())
                        IsOver = false;
                    else
                        player.IsTurn = false;
                }
            }
        }

        // TODO: Set win condition
        private bool CheckWin()
        {
            return false;
        }
    }
}
