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
                out DiscardPile discardPile);

            // Act
            var picked = pcPlayer.PickBestCard(discardPile);

            // Assert
            Assert.True(picked.Type == CardTypeEnum.NumberedCard);
        }

        [Fact]
        public void PickBestCardPrioritizesActionCardsOverWildCards()
        {
            // Arrange
            var topCard = new Card(CardColorEnum.Yellow, CardActionEnum.Reverse);
            ComputerPlayerHasCardsOfEachType(topCard, out ComputerPlayer pcPlayer,
                out DiscardPile discardPile);

            // Act
            var picked = pcPlayer.PickBestCard(discardPile);

            // Assert
            Assert.True(picked.Type == CardTypeEnum.ActionCard);
        }

        [Fact]
        public void PickBestCardChoosesWildCardsWhenItsTheOnlyMatchingType()
        {
            // Arrange
            var topCard = new Card(CardColorEnum.Yellow, CardActionEnum.Skip);
            ComputerPlayerHasCardsOfEachType(topCard, out ComputerPlayer pcPlayer,
                out DiscardPile discardPile);

            // Act
            var picked = pcPlayer.PickBestCard(discardPile);

            // Assert
            Assert.True(picked.Type == CardTypeEnum.WildCard);
        }

        // Common Arrangements
        private static void ComputerPlayerHasCardsOfEachType(Card card, 
            out ComputerPlayer pcPlayer, out DiscardPile discardPile)
        {
            pcPlayer = new ComputerPlayer();
            discardPile = new DiscardPile();
            discardPile.ReceiveCard(card);

            var wild = new Card(CardWildEnum.Wild);
            var action = new Card(CardColorEnum.Blue, CardActionEnum.Reverse);
            var numbered = new Card(CardNumberEnum.Three, CardColorEnum.Green);
            pcPlayer.Hand.TakeCards(new List<Card> { wild, action, numbered });
        }
    }
}
