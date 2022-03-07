using System.Linq;
using UNO.TDD.Domain;
using Xunit;
using static UNO.TDD.Domain.Card;

namespace UNO.TDD.Tests
{
    public class DeckCompositionTest
    {
        [Fact]
        public void DeckHasOneZeroCardThatIsRed()
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
        public void DeckHasOneZeroCardThatIsBlue()
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
        public void DeckHasOneZeroCardThatIsGreen()
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
        public void DeckHasOneZeroCardThatIsYellow()
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
        public void DeckHasNineteenNumberedCardsThatAreRed()
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
        public void DeckHasNineteenNumberedCardsThatAreBlue()
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
        public void DeckHasNineteenNumberedCardsThatAreGreen()
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
        public void DeckHasNineteenNumberedCardsThatAreYellow()
        {
            // Arrange
            var deck = new Deck();

            // Act
            var yellows = deck.Cards.Where(x => x.Type == CardTypeEnum.NumberedCard &&
            x.Color == CardColorEnum.Yellow).Count();

            // Assert
            Assert.Equal(19, yellows);
        }

        [Fact]
        public void DeckHasTwoSkipCardsThatAreRed()
        {
            // Arrange
            var deck = new Deck();

            // Act
            var redSkips = deck.Cards.Where(x => x.Action == CardActionEnum.Skip &&
            x.Color == CardColorEnum.Red).Count();

            // Assert
            Assert.Equal(2, redSkips);
        }

        [Fact]
        public void DeckHasTwoSkipCardsThatAreBlue()
        {
            // Arrange
            var deck = new Deck();

            // Act
            var blueSkips = deck.Cards.Where(x => x.Action == CardActionEnum.Skip &&
            x.Color == CardColorEnum.Blue).Count();

            // Assert
            Assert.Equal(2, blueSkips);
        }

        [Fact]
        public void DeckHasTwoSkipCardsThatAreGreen()
        {
            // Arrange
            var deck = new Deck();

            // Act
            var greenSkips = deck.Cards.Where(x => x.Action == CardActionEnum.Skip &&
            x.Color == CardColorEnum.Green).Count();

            // Assert
            Assert.Equal(2, greenSkips);
        }

        [Fact]
        public void DeckHasTwoSkipCardsThatAreYellow()
        {
            // Arrange
            var deck = new Deck();

            // Act
            var yellowSkips = deck.Cards.Where(x => x.Action == CardActionEnum.Skip &&
            x.Color == CardColorEnum.Yellow).Count();

            // Assert
            Assert.Equal(2, yellowSkips);
        }

        [Fact]
        public void DeckHasTwoReverseCardsThatAreRed()
        {
            // Arrange
            var deck = new Deck();

            // Act
            var redReverses = deck.Cards.Where(x => x.Action == CardActionEnum.Reverse &&
            x.Color == CardColorEnum.Red).Count();

            // Assert
            Assert.Equal(2, redReverses);
        }

        [Fact]
        public void DeckHasTwoReverseCardsThatAreBlue()
        {
            // Arrange
            var deck = new Deck();

            // Act
            var blueReverses = deck.Cards.Where(x => x.Action == CardActionEnum.Reverse &&
            x.Color == CardColorEnum.Blue).Count();

            // Assert
            Assert.Equal(2, blueReverses);
        }

        [Fact]
        public void DeckHasTwoReverseCardsThatAreGreen()
        {
            // Arrange
            var deck = new Deck();

            // Act
            var greenReverses = deck.Cards.Where(x => x.Action == CardActionEnum.Reverse &&
            x.Color == CardColorEnum.Green).Count();

            // Assert
            Assert.Equal(2, greenReverses);
        }

        [Fact]
        public void DeckHasTwoReverseCardsThatAreYellow()
        {
            // Arrange
            var deck = new Deck();

            // Act
            var yellowReverses = deck.Cards.Where(x => x.Action == CardActionEnum.Reverse &&
            x.Color == CardColorEnum.Yellow).Count();

            // Assert
            Assert.Equal(2, yellowReverses);
        }

        [Fact]
        public void DeckHasTwoDraw2CardsThatAreRed()
        {
            // Arrange
            var deck = new Deck();

            // Act
            var redDraw2s = deck.Cards.Where(x => x.Action == CardActionEnum.Draw2 &&
            x.Color == CardColorEnum.Red).Count();

            // Assert
            Assert.Equal(2, redDraw2s);
        }

        [Fact]
        public void DeckHasTwoDraw2CardsThatAreBlue()
        {
            // Arrange
            var deck = new Deck();

            // Act
            var blueDraw2s = deck.Cards.Where(x => x.Action == CardActionEnum.Draw2 &&
            x.Color == CardColorEnum.Blue).Count();

            // Assert
            Assert.Equal(2, blueDraw2s);
        }

        [Fact]
        public void DeckHasTwoDraw2CardsThatAreGreen()
        {
            // Arrange
            var deck = new Deck();

            // Act
            var greenDraw2s = deck.Cards.Where(x => x.Action == CardActionEnum.Draw2 &&
            x.Color == CardColorEnum.Green).Count();

            // Assert
            Assert.Equal(2, greenDraw2s);
        }

        [Fact]
        public void DeckHasTwoDraw2CardsThatAreYellow()
        {
            // Arrange
            var deck = new Deck();

            // Act
            var yellowDraw2s = deck.Cards.Where(x => x.Action == CardActionEnum.Draw2 &&
            x.Color == CardColorEnum.Yellow).Count();

            // Assert
            Assert.Equal(2, yellowDraw2s);
        }

        [Fact]
        public void DeckHasFourWildCards()
        {
            // Arrange
            var deck = new Deck();

            // Act
            var wilds = deck.Cards.Where(x => x.Wild == CardWildEnum.Wild).Count();

            // Assert
            Assert.Equal(4, wilds);
        }

        [Fact]
        public void DeckHasFourWildDraw4Cards()
        {
            // Arrange
            var deck = new Deck();

            // Act
            var wildDraw4s = deck.Cards.Where(x => x.Wild == CardWildEnum.WildDraw4).Count();

            // Assert
            Assert.Equal(4, wildDraw4s);
        }
    }
}
