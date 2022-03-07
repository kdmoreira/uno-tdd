using System;
using System.Collections.Generic;
using System.Linq;

namespace UNO.TDD.Domain
{
    public class Deck
    {
        public List<Card> Cards { get; private set; }
        public int Size
        {
            get => Cards.Count;
        }

        public Deck()
        {
            Cards = new List<Card>();

            // 1 Zero card for each color
            foreach (Card.CardColorEnum color in Enum.GetValues(typeof(Card.CardColorEnum)))
            {
                if (color != Card.CardColorEnum.None)
                {
                    Cards.Add(new Card(Card.CardNumberEnum.Zero, color));
                }
            }

            // 2 numbered (1-9) cards for each color
            foreach (Card.CardColorEnum color in Enum.GetValues(typeof(Card.CardColorEnum)))
            {
                foreach (Card.CardNumberEnum number in Enum.GetValues(typeof(Card.CardNumberEnum)))
                {
                    if (number != Card.CardNumberEnum.None && number != Card.CardNumberEnum.Zero
                        && color != Card.CardColorEnum.None)
                    {
                        for (int i = 0; i < 2; i++)
                        {
                            Cards.Add(new Card(number, color));
                        }
                    }
                }
            }

            // 2 of each action card for each color
            foreach (Card.CardColorEnum color in Enum.GetValues(typeof(Card.CardColorEnum)))
            {
                foreach (Card.CardActionEnum action in Enum.GetValues(typeof(Card.CardActionEnum)))
                {
                    if (color != Card.CardColorEnum.None && action != Card.CardActionEnum.None)
                    {
                        for (int i = 0; i < 2; i++)
                        {
                            Cards.Add(new Card(color, action));
                        }
                    }
                }
            }

            // 4 of each wild card
            for (int j = 0; j < 4; j++)
            {
                foreach (Card.CardWildEnum wild in Enum.GetValues(typeof(Card.CardWildEnum)))
                {
                    if (wild != Card.CardWildEnum.None)
                    {
                        Cards.Add(new Card(wild));
                    }
                }
            }
        }

        public Deck Shuffle()
        {
            Deck deck = new();
            Random random = new();
            for (int i = deck.Size - 1; i > 0; i--)
            {
                int j = random.Next(i + 1);
                Card temp = deck.Cards[i];
                deck.Cards[i] = deck.Cards[j];
                deck.Cards[j] = temp;
            }
            return deck;
        }

        public void DealInitialCards(Hand playerHand, Hand pcHand)
        {
            var quantity = 7;
            playerHand.TakeCards(DealCards(quantity));
            pcHand.TakeCards(DealCards(quantity));
        }

        public List<Card> DealCards(int quantity)
        {
            List<Card> cards = new();

            if (!(quantity > 0 && quantity <= Size))
                return cards;

            for (int i = 0; i < quantity; i++)
            {
                cards.Add(PassCard(Cards[i]));
            }
            return cards;
        }

        public Card DiscardStarterCard(DiscardPile discardPile)
        {
            var starterCard = PassCard(Cards.FirstOrDefault());
            discardPile.ReceiveCard(starterCard);
            return starterCard;
        }

        // Private Methods

        public Card PassCard(Card card)
        {
            Cards.Remove(card);
            return card;
        }
    }
}
