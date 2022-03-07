using System.Collections.Generic;
using System.Linq;

namespace UNO.TDD.Domain
{
    public class DiscardPile
    {
        public List<Card> Cards { get; private set; } = new();
        public Card TopCard
        {
            get => Cards.LastOrDefault();
        }

        public void ReceiveCard(Card card)
        {
            Cards.Add(card);
        }
    }
}
