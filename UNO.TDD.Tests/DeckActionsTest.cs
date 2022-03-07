using FluentAssertions;
using System.Linq;
using UNO.TDD.Domain;
using Xunit;

namespace UNO.TDD.Tests
{
    public class DeckActionsTest
    {
        [Fact]
        public void ShuffleChangesPreviousDeckOrder()
        {
            // Arrange
            var deck = new Deck();

            // Act
            var shuffledDeck = deck.Shuffle();

            // Assert
            deck.Cards.Should().NotBeEquivalentTo(shuffledDeck.Cards,
                options => options.WithStrictOrdering());
        }

        [Theory]
        [InlineData(999)]
        [InlineData(0)]
        [InlineData(-1)]
        public void DealCardsHandlesInvalidQuantity(int quantity)
        {
            // Arrange
            var deck = new Deck();
            var size = deck.Size;

            // Act
            deck.DealCards(quantity);

            // Assert
            Assert.Equal(size, deck.Size);
        }

        [Theory]
        [InlineData(1)]
        [InlineData(7)]
        public void DealCardsResultstInDeckWithGivenQuantityLessCards(int quantity)
        {
            // Arrange
            var deck = new Deck();
            var size = deck.Size;

            // Act
            deck.DealCards(quantity);

            // Assert
            Assert.Equal(size - quantity, deck.Size);
        }

        [Fact]
        public void DealInitialCardsGivesEachHandSevenCards()
        {
            // Arrange
            var deck = new Deck();
            Hand playerHand = new();
            Hand pcHand = new();
            var initialCards = 7;

            // Act
            deck.DealInitialCards(playerHand, pcHand);

            // Assert
            Assert.True(playerHand.CardQuantity == pcHand.CardQuantity
                && playerHand.CardQuantity == initialCards);
        }

        [Fact]
        public void PassCardLeavesDeckWithoutGivenCard()
        {
            // Arrange
            var deck = new Deck();
            var card = deck.Cards.FirstOrDefault();

            // Act
            deck.PassCard(card);

            // Assert
            Assert.DoesNotContain(card, deck.Cards);
        }

        [Fact]
        public void DiscardStarterCardTransfersCardToDiscardPilesTopCard()
        {
            // Arrage
            var deck = new Deck();
            var discardPile = new DiscardPile();

            // Act
            var discarded = deck.DiscardStarterCard(discardPile);

            // Assert
            Assert.True(discarded == discardPile.TopCard);
        }
    }
}
