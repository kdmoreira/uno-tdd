using UNO.TDD.Domain;
using Xunit;
using static UNO.TDD.Domain.Card;

namespace UNO.TDD.Tests
{
    public class DiscardPileActionsTest
    {
        [Fact]
        public void TopCardIsTheMostRecentDiscardedCard()
        {
            // Arrange
            var discardPile = new DiscardPile();
            var firstCard = new Card(CardColorEnum.Yellow, CardActionEnum.Reverse);
            var secondCard = new Card(CardColorEnum.Yellow, CardActionEnum.Skip);

            var hand = new Hand();
            hand.TakeCard(firstCard);
            hand.TakeCard(secondCard);

            hand.Discard(firstCard, discardPile);

            // Act
            hand.Discard(secondCard, discardPile);

            // Assert
            Assert.Equal(secondCard, discardPile.TopCard);
        }

        [Fact]
        public void ReceiveCardAddsCardToOwnCards()
        {
            // Arrange
            var discardPile = new DiscardPile();
            var card = new Card(CardColorEnum.Red, CardActionEnum.Skip);

            // Act
            discardPile.ReceiveCard(card);

            // Assert
            Assert.Contains(card, discardPile.Cards);
        }
    }
}
