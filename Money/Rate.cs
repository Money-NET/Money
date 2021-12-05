namespace Money
{
    public class Rate
    {
        public Currency From { get; set; }
        public Currency To { get; set; }
        public decimal Value { get; set; }

        public Rate(Currency from, Currency to, decimal value)
        {
            From = from;
            To = to;
            Value = value;
        }

        public override string ToString()
        {
            return $"{From.Code}_{To.Code}";
        }
    }
}
