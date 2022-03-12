namespace UNO.TDD.Domain
{
    public class Player
    {
        public Hand Hand { get; private set; } = new();
        public bool UNO { get; private set; } = false;

        public void YellUNO()
        {
            UNO = true;
        }

        public void PickCard(DiscardPile discardPile, Deck deck, int position)
        {
            var played = Hand.Play(Hand.ChooseCard(position), discardPile);

            if (!played)
            {
                Hand.DrawCard(deck);
            }
        }
    }
}
