using System;
using System.Collections.Generic;

namespace UNO.TDD.Domain
{
    public class Deck
    {
        public List<Card> Cards { get; set; }
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
            Random random = new Random();
            for (int i = deck.Cards.Count - 1; i > 0; i--)
            {
                int j = random.Next(i + 1);
                Card temp = deck.Cards[i];
                deck.Cards[i] = deck.Cards[j];
                deck.Cards[j] = temp;
            }
            return deck;
        }

        public Deck Distribute()
        {
            Deck deck = new();            
            for (int i = 0; i < 14; i++)
            {
                deck.Cards.RemoveAt(i);
            }
            return deck;
        }
    }
}
