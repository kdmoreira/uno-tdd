using System;
using System.Collections.Generic;

namespace UNO.TDD.Domain
{
    public class Deck
    {
        public List<Card> Cards { get; set; }

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
        }
    }
}
