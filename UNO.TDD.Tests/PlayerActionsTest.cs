using UNO.TDD.Domain;
using Xunit;
using static UNO.TDD.Domain.Card;

namespace UNO.TDD.Tests
{
    public class PlayerActionsTest
    {
        [Fact]
        public void PlayerYellsUNO()
        {
            // Arrange
            var player = new Player();
            var pcPlayer = new ComputerPlayer();
            var deck = new Deck();
            deck.DealInitialCards(player.Hand, pcPlayer.Hand);

            // Act
            player.YellUNO();

            // Assert
            Assert.True(player.UNO);
        }

        [Fact]
        public void PlayerDrawsCardFromDeckAfterPlayingNonMatchingCard()
        {
            // Arrange            
            var topCard = new Card(CardColorEnum.Yellow, CardActionEnum.Skip);
            PlayerHasSingleNumberedCard(topCard, out Player player,
                out DiscardPile discardPile, out Deck deck);
            var deckSize = deck.Size;
            var position = 1;

            // Act
            player.PickCard(discardPile, deck, position);

            // Assert
            Assert.NotEqual(deckSize, deck.Size);
        }

        // Common Arrangements
        private static void PlayerHasSingleNumberedCard(Card card,
        out Player player, out DiscardPile discardPile, out Deck deck)
        {
            deck = new Deck();
            player = new Player();
            discardPile = new DiscardPile();
            discardPile.ReceiveCard(card);

            var numbered = new Card(CardNumberEnum.One, CardColorEnum.Green);
            player.Hand.TakeCard(numbered);
        }
    }
}
