using System;
using System.Collections.Generic;

namespace DeckOfCards
{
    public class Deck
    {
        public List<Card> cards;
        public List<Card> Reset()
        {
            cards = new List<Card>();
            string[] suits = new string[4] {"Clubs", "Spades", "Hearts", "Diamonds"};
            foreach (string suit in suits)
            {
                for(int i = 1; i < 14; i++)
                {
                    Card uniqueCard = new Card(suit, i);
                    cards.Add(uniqueCard);
                }
            }
            return cards;
        }
        public void Shuffle()
        {
            Random rand = new Random();
            for (int idx=0; idx < cards.Count-1; idx++)
            {
                int randIdx = rand.Next(idx+1, cards.Count-1);
                Card temp = cards[idx];
                cards[idx] = cards[randIdx];
                cards[randIdx] = temp;
            }
        }
        public Card Deal()
        {
            if (cards.Count > 0)
            {
                Card topCard = cards[0];
                cards.Remove(topCard);
                return topCard;
            }
            else 
            {
                Console.WriteLine("Ran out of cards...Collecting cards...Shuffling...Dealing new card...");
                Reset();
                Shuffle();
                return Deal();
            }
        }
        public void DisplayDeck()
        {
            foreach (var card in cards)
            {
                Console.WriteLine($" {card.stringVal} of {card.suit}");
            }
            Console.WriteLine($"Remaining cards in deck: {cards.Count}");
        }
        public Deck()
        {
            Reset();
            Shuffle();
        }
    }
}