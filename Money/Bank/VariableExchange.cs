using Money.Bank.Exceptions;
using Money.Bank.Interfaces;
using System.Collections.Concurrent;

namespace Money.Bank
{
    /// Class for aiding in exchanging money between different currencies. By
    /// default, the +Money+ class uses an object of this class (accessible
    /// through +Money#bank+) for performing currency exchanges.
    ///
    /// By default, +Money.Bank.VariableExchange+ has no knowledge about
    /// conversion rates. One must manually specify them with +add_rate+, after
    /// which one can perform exchanges with +#exchange_with+.
    ///
    /// Exchange rates are stored in memory using ConcurrentDictionary<string, Rate>.
    /// Pass custom rates stores for other types of storage (file, database, etc)
    ///
    /// @example
    ///   bank = new Money.Bank.VariableExchange()
    ///   bank.AddRate(Currency.USD, Currency.CAD, 1.24515)
    ///   bank.AddRate(Currency.CAD, Currency.USD, 0.803115)
    ///
    ///   c1 = new Money(100_00, "USD")
    ///   c2 = new Money(100_00, "CAD")
    ///
    ///   # Exchange 100 USD to CAD:
    ///   bank.Exchange(c1, Currency.CAD) => {Money} Fractional = 12451, Currency = CAD}
    ///
    ///   # Exchange 100 CAD to USD:
    ///   bank.Exchange(c2, Currency.USD) => {Money} Fractional = 8031, Currency = USD>
    ///
    ///   # With custom exchange rates storage
    ///   redis_store = MyCustomRedisStore.new(host: 'localhost:6379')
    ///   bank = Money.Bank.VariableExchange.new(redis_store)
    ///   # Store rates in redis
    ///   bank.AddRate(Currency.USD, Currency.CAD, 0.98)
    ///   # Get rate from redis
    ///   bank.GetRate(Currency.USD', Currency.CAD)
    public class VariableExchange : IBank
    {
        private static readonly ConcurrentDictionary<string, Rate> Items = new ConcurrentDictionary<string, Rate>();

        public Money Exchange(Money from, Currency to)
        {
            var rate = Get(from.Currency, to);

            if (rate == null)
                throw new UnknownRateException(from.Currency, to);

            var fractional = Fractional(from, to);
            var value = (long)(fractional * rate.Value);

            return Money.FromCents(value, to);
        }

        #region Methods

        public ConcurrentDictionary<string, Rate> Rates => Items;

        /// <summary>
        /// Registers a conversion rate
        /// </summary>
        /// <param name="from">Currency</param>
        /// <param name="to">Currency</param>
        /// <param name="value">decimal</param>
        public void AddRate(Currency from, Currency to, decimal value)
        {
            var rate = new Rate(from, to, value);

            SetRate(rate);
        }

        /// <summary>
        /// Registers a conversion rate
        /// </summary>
        /// <param name="from">Currency</param>
        /// <param name="to">Currency</param>
        /// <param name="value">double</param>
        public void AddRate(Currency from, Currency to, double value)
        {
            AddRate(from, to, (decimal)value);
        }

        /// <summary>
        /// Set the rate for the given currencies.
        /// </summary>
        /// <param name="rate"></param>
        public void SetRate(Rate rate)
        {
            Items.AddOrUpdate(rate.ToString(), rate, (k, current) => rate);
        }

        /// <summary>
        /// TODO
        /// </summary>
        /// <param name="from"></param>
        /// <param name="to"></param>
        /// <returns></returns>
        public Rate Get(Currency from, Currency to)
        {
            Items.TryGetValue($"{from.Code}_{to.Code}", out var rate);

            return rate;
        }

        public decimal Fractional(Money from, Currency to)
        {
            //BigDecimal(from.fractional.to_s) / (
            //    BigDecimal(from.currency.subunit_to_unit.to_s) /
            //    BigDecimal(to_currency.subunit_to_unit.to_s)
            //)
            //return (decimal)((decimal)from.Currency.SubUnitToUnit / (decimal)to.SubUnitToUnit);

            return (decimal)from.Fractional / (
                (decimal)from.Currency.SubUnitToUnit /
                (decimal)to.SubUnitToUnit
            );
        }

        #endregion
    }
}
