namespace DeckOfCards
{
    public class Card 
    {
        public string stringVal;
        public string suit;
        public int val;
        public Card(string cardSuit, int cardVal)
        {
            suit = cardSuit;
            val = cardVal;
            if (cardVal > 1 && cardVal < 11)
            {
                stringVal = cardVal.ToString();
            }
            else if (cardVal == 1)
            {
                stringVal = "Ace";
            }
            else if (cardVal == 11)
            {
                stringVal = "Jack";
            }
            else if (cardVal == 12)
            {
                stringVal = "Queen";
            }
            else if (cardVal == 13)
            {
                stringVal = "King";
            }
        }
    }
}