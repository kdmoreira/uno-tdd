using System.Linq;
using UNO.TDD.Domain;
using Xunit;
using static UNO.TDD.Domain.Card;

namespace UNO.TDD.Tests
{
    public class DeckTest
    {
        [Fact]
        public void DeckMustHaveOneZeroCardThatIsRed()
        {
            // Arrange
            var deck = new Deck();

            // Act
            var redCount = deck.Cards.Where(x => x.Number == CardNumberEnum.Zero &&
            x.Color == CardColorEnum.Red).Count();

            // Assert
            Assert.Equal(1, redCount);
        }

        [Fact]
        public void DeckMustHaveOneZeroCardThatIsBlue()
        {
            // Arrange
            var deck = new Deck();

            // Act
            var blueCount = deck.Cards.Where(x => x.Number == CardNumberEnum.Zero &&
            x.Color == CardColorEnum.Blue).Count();

            // Assert
            Assert.Equal(1, blueCount);
        }

        [Fact]
        public void DeckMustHaveOneZeroCardThatIsGreen()
        {
            // Arrange
            var deck = new Deck();

            // Act
            var greenCount = deck.Cards.Where(x => x.Number == CardNumberEnum.Zero &&
            x.Color == CardColorEnum.Green).Count();

            // Assert
            Assert.Equal(1, greenCount);
        }

        [Fact]
        public void DeckMustHaveOneZeroCardThatIsYellow()
        {
            // Arrange
            var deck = new Deck();

            // Act
            var yellowCount = deck.Cards.Where(x => x.Number == CardNumberEnum.Zero &&
            x.Color == CardColorEnum.Yellow).Count();

            // Assert
            Assert.Equal(1, yellowCount);
        }

        [Fact]
        public void DeckMustHaveNineteenNumberedCardsThatAreRed()
        {
            // Arrange
            var deck = new Deck();

            // Act
            var reds = deck.Cards.Where(x => x.Type == CardTypeEnum.NumberedCard &&
            x.Color == CardColorEnum.Red).Count();

            // Assert
            Assert.Equal(19, reds);
        }

        [Fact]
        public void DeckMustHaveNineteenNumberedCardsThatAreBlue()
        {
            // Arrange
            var deck = new Deck();

            // Act
            var blues = deck.Cards.Where(x => x.Type == CardTypeEnum.NumberedCard &&
            x.Color == CardColorEnum.Blue).Count();

            // Assert
            Assert.Equal(19, blues);
        }

        [Fact]
        public void DeckMustHaveNineteenNumberedCardsThatAreGreen()
        {
            // Arrange
            var deck = new Deck();

            // Act
            var greens = deck.Cards.Where(x => x.Type == CardTypeEnum.NumberedCard &&
            x.Color == CardColorEnum.Green).Count();

            // Assert
            Assert.Equal(19, greens);
        }

        [Fact]
        public void DeckMustHaveNineteenNumberedCardsThatAreYellow()
        {
            // Arrange
            var deck = new Deck();

            // Act
            var yellows = deck.Cards.Where(x => x.Type == CardTypeEnum.NumberedCard &&
            x.Color == CardColorEnum.Yellow).Count();

            // Assert
            Assert.Equal(19, yellows);
        }
    }
}
