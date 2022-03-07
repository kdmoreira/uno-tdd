using System.Linq;
using static UNO.TDD.Domain.Card;

namespace UNO.TDD.Domain
{
    public class ComputerPlayer
    {
        public Hand Hand { get; private set; } = new();

        public Card PickBestCard(DiscardPile discardPile)
        {
            var matchingCards = Hand.Cards
                .Where(x => x.Matches(discardPile.TopCard));

            Card chosen;
            var bestChoice = matchingCards.FirstOrDefault(x => x.Type == CardTypeEnum.NumberedCard);
            var secondChoice = matchingCards.FirstOrDefault(x => x.Type == CardTypeEnum.ActionCard);
            var leastChoice = matchingCards.FirstOrDefault(x => x.Type == CardTypeEnum.WildCard);                      

            chosen = bestChoice ?? secondChoice;
            chosen ??= leastChoice;

            return chosen;
        }
    }
}
