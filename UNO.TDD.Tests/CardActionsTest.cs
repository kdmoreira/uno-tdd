using UNO.TDD.Domain;
using Xunit;
using static UNO.TDD.Domain.Card;

namespace UNO.TDD.Tests
{
    public class CardActionsTest
    {
        [Fact]
        public void CardsOfTheSameColorMatch()
        {
            // Arrange
            var oneGreen = new Card(CardNumberEnum.One, CardColorEnum.Green);
            var twoGreen = new Card(CardNumberEnum.Two, CardColorEnum.Green);

            // Act
            var match = oneGreen.Matches(twoGreen);

            // Assert
            Assert.True(match);
        }

        [Fact]
        public void CardsOfTheSameNumberMatch()
        {
            // Arrange
            var oneGreen = new Card(CardNumberEnum.One, CardColorEnum.Green);
            var oneRed = new Card(CardNumberEnum.One, CardColorEnum.Red);

            // Act
            var match = oneGreen.Matches(oneRed);

            // Assert
            Assert.True(match);
        }

        [Fact]
        public void CardsOfTheSameActionMatch()
        {
            // Arrange
            var yellowReverse = new Card(CardColorEnum.Yellow, CardActionEnum.Reverse);
            var blueReverse = new Card(CardColorEnum.Blue, CardActionEnum.Reverse);

            // Act
            var match = yellowReverse.Matches(blueReverse);

            // Assert
            Assert.True(match);
        }

        [Fact]
        public void WildCardsAlwaysMatch()
        {
            // Arrange
            var wild = new Card(CardWildEnum.Wild);
            var blueReverse = new Card(CardColorEnum.Blue, CardActionEnum.Reverse);

            // Act
            var match = wild.Matches(blueReverse);

            // Assert
            Assert.True(match);
        }
    }
}
