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
        }
    }
}
