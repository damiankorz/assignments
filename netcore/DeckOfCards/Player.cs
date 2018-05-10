using System;
using System.Collections.Generic;

namespace DeckOfCards
{
    public class Player 
    {
        public string name;
        public List<Card> hand = new List<Card>();
        public Card DrawCard(Deck deckInPlay)
        {
            Card drawnCard = deckInPlay.Deal();
            hand.Add(drawnCard);
            return drawnCard;
        }
        public Card DiscardCard(int idx)
        {
            if (hand.Count > 0 && idx < hand.Count)
            {
                Card discCard = hand[idx];
                hand.RemoveAt(idx);
                return discCard; 
            }
            else
            {
                Console.WriteLine("Can't discard a card that you dont have!");
                return null;
            }
        }
        public void DisplayPlayerHand()
        {
            foreach (Card card in hand)
            {
                Console.WriteLine($"{card.stringVal} of {card.suit}");
            }
            Console.WriteLine($"Total cards in hand: {hand.Count}");
        }
        public Player(string playerName)
        {
            name = playerName;
        }
    }
}