using System.Linq;
using UNO.TDD.Domain;
using Xunit;
using static UNO.TDD.Domain.Card;

namespace UNO.TDD.Tests
{
    public class HandActionsTest
    {
        [Fact]
        public void TakeCardMustLeaveHandWithGivenCard()
        {
            // Arrange
            var card = new Card(CardWildEnum.Wild);
            var hand = new Hand();

            // Act
            hand.TakeCard(card);

            // Assert
            Assert.Contains(card, hand.Cards);
        }

        [Fact]
        public void DrawCardMustLeaveHandWithGivenCard()
        {
            // Arrange
            var deck = new Deck();
            var card = deck.Cards.First();
            var hand = new Hand();

            // Act
            hand.DrawCard(deck);

            // Assert
            Assert.Contains(card, hand.Cards);
        }

        [Fact]
        public void DrawCardMustLeaveDeckWithoutGivenCard()
        {
            // Arrange
            var deck = new Deck();
            var card = deck.Cards.First();
            var hand = new Hand();

            // Act
            hand.DrawCard(deck);

            // Assert
            Assert.DoesNotContain(card, deck.Cards);
        }
    }
}
