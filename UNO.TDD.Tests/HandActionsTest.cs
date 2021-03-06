using System.Linq;
using UNO.TDD.Domain;
using Xunit;
using static UNO.TDD.Domain.Card;

namespace UNO.TDD.Tests
{
    public class HandActionsTest
    {
        [Fact]
        public void TakeCardAddsCardToOwnCards()
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
        public void DrawCardAddsGivenCardToOwnCards()
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
        public void DrawCardLeavesDeckWithoutGivenCard()
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

        [Fact]
        public void DiscardLeavesHandWithoutDiscardedCard()
        {
            // Arrange
            var discardPile = new DiscardPile();
            var card = new Card(CardNumberEnum.One, CardColorEnum.Green);
            var hand = new Hand();
            hand.TakeCard(card);

            // Act
            hand.Discard(card, discardPile);

            // Assert
            Assert.DoesNotContain(card, hand.Cards);
        }

        [Fact]
        public void DiscardLeavesCardOnDiscardPile()
        {
            // Arrange
            var discardPile = new DiscardPile();
            var card = new Card(CardNumberEnum.One, CardColorEnum.Green);
            var hand = new Hand();
            hand.TakeCard(card);            

            // Act
            hand.Discard(card, discardPile);

            // Assert
            Assert.Contains(card, discardPile.Cards);
        }

        [Fact]
        public void ChooseCardHandlesOneBasedIndexing()
        {
            // Arrange
            var deck = new Deck();
            var playerHand = new Hand();
            playerHand.TakeCards(deck.DealCards(7));

            // Act
            var chosenCard = playerHand.ChooseCard(3);

            // Assert
            Assert.Equal(chosenCard, playerHand.Cards[2]);
        }

        [Fact]
        public void HandPlaysCardWhenChosenCardMatchesTopCard()
        {
            // Arrange
            HandTakesCardThatMatchesDiscardPilesTopCard(out Hand hand, out Card handsCard, 
                out DiscardPile discardPile);

            // Act
            var played = hand.Play(handsCard, discardPile);

            // Assert
            Assert.True(played);
        }

        [Fact]
        public void HandPlaysCardAndItBecomesTopCard()
        {
            // Arrange
            HandTakesCardThatMatchesDiscardPilesTopCard(out Hand hand, out Card handsCard,
                out DiscardPile discardPile);

            // Act
            hand.Play(handsCard, discardPile);

            // Assert
            Assert.Equal(handsCard, discardPile.TopCard);
        }

        [Fact]
        public void PlayLeavesHandWithoutGivenCard()
        {
            // Arrange
            HandTakesCardThatMatchesDiscardPilesTopCard(out Hand hand, out Card handsCard,
                out DiscardPile discardPile);

            // Act
            hand.Play(handsCard, discardPile);

            // Assert
            Assert.DoesNotContain(handsCard, hand.Cards);
        }

        // Common Arrangements
        private static void HandTakesCardThatMatchesDiscardPilesTopCard(out Hand hand, 
            out Card handsCard, out DiscardPile discardPile)
        {
            discardPile = new DiscardPile();
            hand = new Hand();
            handsCard = new Card(CardNumberEnum.One, CardColorEnum.Green);
            var discardedCart = new Card(CardNumberEnum.Two, CardColorEnum.Green);

            hand.TakeCard(handsCard);
            discardPile.ReceiveCard(discardedCart);
        }
    }
}
