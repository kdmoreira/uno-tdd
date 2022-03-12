using FluentAssertions;
using System.Collections.Generic;
using UNO.TDD.Domain;
using Xunit;
using static UNO.TDD.Domain.Card;

namespace UNO.TDD.Tests
{
    public class ComputerPlayerActionsTest
    {
        [Fact]
        public void PickBestCardPrioritizesNumberedCards()
        {
            // Arrange
            var topCard = new Card(CardNumberEnum.Three, CardColorEnum.Blue);
            ComputerPlayerHasCardsOfEachType(topCard, out ComputerPlayer pcPlayer,
                out DiscardPile discardPile, out Deck deck);

            // Act
            var picked = pcPlayer.PickBestCard(discardPile, deck);

            // Assert
            Assert.True(picked.Type == CardTypeEnum.NumberedCard);
        }

        [Fact]
        public void PickBestCardPrioritizesActionCardsOverWildCards()
        {
            // Arrange
            var topCard = new Card(CardColorEnum.Yellow, CardActionEnum.Reverse);
            ComputerPlayerHasCardsOfEachType(topCard, out ComputerPlayer pcPlayer,
                out DiscardPile discardPile, out Deck deck);

            // Act
            var picked = pcPlayer.PickBestCard(discardPile, deck);

            // Assert
            Assert.True(picked.Type == CardTypeEnum.ActionCard);
        }

        [Fact]
        public void PickBestCardChoosesWildCardsWhenItsTheOnlyMatchingType()
        {
            // Arrange
            var topCard = new Card(CardColorEnum.Yellow, CardActionEnum.Skip);
            ComputerPlayerHasCardsOfEachType(topCard, out ComputerPlayer pcPlayer,
                out DiscardPile discardPile, out Deck deck);

            // Act
            var picked = pcPlayer.PickBestCard(discardPile, deck);

            // Assert
            Assert.True(picked.Type == CardTypeEnum.WildCard);
        }

        [Fact]
        public void ComputerPlayerDrawsCardFromDeckWhenThereIsNoMatchingCard()
        {
            // Arrange            
            var topCard = new Card(CardColorEnum.Yellow, CardActionEnum.Skip);
            ComputerPlayerHasSingleNumberedCard(topCard, out ComputerPlayer pcPlayer,
                out DiscardPile discardPile, out Deck deck);
            var deckSize = deck.Size;

            // Act
            pcPlayer.PickBestCard(discardPile, deck);

            // Assert
            Assert.NotEqual(deckSize, deck.Size);
        }

        // Common Arrangements

        private static void ComputerPlayerHasCardsOfEachType(Card card, 
            out ComputerPlayer pcPlayer, out DiscardPile discardPile, out Deck deck)
        {
            deck = new Deck();
            pcPlayer = new ComputerPlayer();
            discardPile = new DiscardPile();
            discardPile.ReceiveCard(card);

            var wild = new Card(CardWildEnum.Wild);
            var action = new Card(CardColorEnum.Blue, CardActionEnum.Reverse);
            var numbered = new Card(CardNumberEnum.Three, CardColorEnum.Green);
            pcPlayer.Hand.TakeCards(new List<Card> { wild, action, numbered });
        }

        private static void ComputerPlayerHasSingleNumberedCard(Card card,
            out ComputerPlayer pcPlayer, out DiscardPile discardPile, out Deck deck)
        {
            deck = new Deck();
            pcPlayer = new ComputerPlayer();
            discardPile = new DiscardPile();
            discardPile.ReceiveCard(card);

            var numbered = new Card(CardNumberEnum.One, CardColorEnum.Green);
            pcPlayer.Hand.TakeCard(numbered);
        }
    }
}
