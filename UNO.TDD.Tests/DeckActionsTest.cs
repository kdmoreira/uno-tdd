using FluentAssertions;
using System.Linq;
using UNO.TDD.Domain;
using Xunit;

namespace UNO.TDD.Tests
{
    public class DeckActionsTest
    {
        [Fact]
        public void ShuffleMustChangePreviousDeckOrder()
        {
            // Arrange
            var deck = new Deck();

            // Act
            var shuffledDeck = deck.Shuffle();

            // Assert
            deck.Cards.Should().NotBeEquivalentTo(shuffledDeck.Cards,
                options => options.WithStrictOrdering());
        }

        [Fact]
        public void DistributeMustResultInDeckWithFourteenLessCards()
        {
            // Arrange
            var deck = new Deck();
            var size = deck.Size;
            Hand playerHand = new();
            Hand pcHand = new();

            // Act
            var deckAfter = deck.Distribute(playerHand, pcHand);

            // Assert
            Assert.Equal(size - 14, deckAfter.Size);
        }

        [Fact]
        public void DistributeMustLeaveEachHandWithSevenCards()
        {
            // Arrange
            var deck = new Deck();
            Hand playerHand = new();
            Hand pcHand = new();

            // Act
            deck.Distribute(playerHand, pcHand);

            // Assert
            Assert.True(playerHand.CardQuantity == pcHand.CardQuantity
                && playerHand.CardQuantity == 7);
        }

        [Fact]
        public void PassCardMustLeaveDeckWithoutGivenCard()
        {
            // Arrange
            var deck = new Deck();
            var card = deck.Cards[0];
            var hand = new Hand();

            // Act
            deck.PassCard(card);

            // Assert
            Assert.DoesNotContain(card, deck.Cards);
        }
    }
}
