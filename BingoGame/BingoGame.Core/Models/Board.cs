using System.Collections.Generic;

namespace BingoGame.Core.Models
{
    public class Board
    {
        private readonly List<Card> _cards;

        public Board()
        {
            _cards = new List<Card>();
        }

        public void AddCard(Card card)
        {
            _cards.Add(card);
        }

        public int GetCardsLength()
        {
            return _cards.Count;
        }

        public Card GetFirstCard()
        {
            return GetCardByIndex(0);
        }

        public Card GetCardByIndex(int index)
        {
            return _cards[index];
        }

        public IEnumerable<Card> GetCards()
        {
            return _cards;
        }
    }
}
