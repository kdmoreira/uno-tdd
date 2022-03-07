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

        public void TakeCards(List<Card> cards)
        {
            Cards.AddRange(cards);
        }

        public void Discard(Card card, DiscardPile discardPile)
        {
            Cards.Remove(card);
            discardPile.ReceiveCard(card);
        }

        public Card ChooseCard(int position)
        {
            return Cards[position - 1];
        }

        public bool Play(Card card, DiscardPile discardPile)
        {
            if (!card.Matches(discardPile.TopCard))
                return false;

            Discard(card, discardPile);
            return true;
        }
    }
}
