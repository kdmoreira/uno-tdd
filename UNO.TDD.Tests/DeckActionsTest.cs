using FluentAssertions;
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

            // Act
            var deckAfter = deck.Distribute();

            // Assert
            Assert.Equal(deck.Size - 14, deckAfter.Size);
        }
    }
}
