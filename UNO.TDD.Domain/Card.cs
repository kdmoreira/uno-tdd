namespace UNO.TDD.Domain
{
    public class Card
    {
        public CardNumberEnum Number { get; set; }
        public CardColorEnum Color { get; set; }
        public CardActionEnum Action { get; set; }
        public CardWildEnum Wild { get; set; }
        public CardTypeEnum Type { get; set; }

        public enum CardNumberEnum
        {
            None,
            Zero,
            One,
            Two,
            Three,
            Four,
            Five,
            Six,
            Seven,
            Eight,
            Nine
        }

        public enum CardColorEnum
        {
            None,
            Blue,
            Green,
            Red,
            Yellow
        }

        public enum CardActionEnum
        {
            None,
            Skip,
            Reverse,
            Draw2
        }

        public enum CardWildEnum
        {
            None,
            Wild,
            WildDraw4
        }

        public enum CardTypeEnum
        {
            NumberedCard,
            ActionCard,
            WildCard
        }

        public Card(CardNumberEnum number, CardColorEnum color)
        {
            Number = number;
            Color = color;
            Type = CardTypeEnum.NumberedCard;
        }

        public Card(CardColorEnum color, CardActionEnum action)
        {
            Color = color;
            Action = action;
            Type = CardTypeEnum.ActionCard;
        }

        public Card(CardWildEnum wild)
        {
            Wild = wild;
            Type = CardTypeEnum.WildCard;
        }

        public bool Matches(Card card)
        {
            if ((Number == card.Number && Number != CardNumberEnum.None) ||
                (Color == card.Color && Color != CardColorEnum.None) ||
                (Action == card.Action && Action != CardActionEnum.None) ||
                Wild != CardWildEnum.None)
            {
                return true;
            }
            return false;
        }

        public override string ToString()
        {
            if (Type == CardTypeEnum.NumberedCard)
            {
                return Number + " " + Color;
            }
            else if (Type == CardTypeEnum.ActionCard)
            {
                return Action + " " + Color;
            }
            else
            {
                return " " + Wild + " ";
            }
        }
    }
}
