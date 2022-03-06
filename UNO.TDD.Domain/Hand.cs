using System.Collections.Generic;
using System.Linq;

namespace UNO.TDD.Domain
{
    public class Hand
    {
        public List<Card> Cards { get; private set; } = new();
        public int CardQuantity
        {
            get => Cards.Count;
        }

        public void DrawCard(Deck deck)
        {
            var card = deck.Cards.First();
            TakeCard(deck.PassCard(card));
        }

        public void TakeCard(Card card)
        {
            Cards.Add(card);
        }
    }
}
