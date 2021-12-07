using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Security.Cryptography;
using Money.Bank.Exceptions;
using Money.Bank.Interfaces;

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
    /// Exchange rates are stored in memory using +Money::RatesStore::Memory+ by default.
    /// Pass custom rates stores for other types of storage (file, database, etc)
    ///
    /// @example
    ///   bank = new Money.Bank.VariableExchange()
    ///   bank.AddRate("USD", "CAD", 1.24515)
    ///   bank.AddRate("CAD", "USD", 0.803115)
    ///
    ///   c1 = new Money(100_00, "USD")
    ///   c2 = new Money(100_00, "CAD")
    ///
    ///   # Exchange 100 USD to CAD:
    ///   bank.Exchange(c1, "CAD") #=> #<Money Fractional:12451 Currency:CAD>
    ///
    ///   # Exchange 100 CAD to USD:
    ///   bank.Exchange(c2, "USD") #=> #<Money Fractional:8031 Currency:USD>
    ///
    ///   # With custom exchange rates storage
    ///   redis_store = MyCustomRedisStore.new(host: 'localhost:6379')
    ///   bank = Money::Bank::VariableExchange.new(redis_store)
    ///   # Store rates in redis
    ///   bank.AddRate 'USD', 'CAD', 0.98
    ///   # Get rate from redis
    ///   bank.GetRate 'USD', 'CAD'
    public class VariableExchange : IBank
    {
        private static readonly ConcurrentDictionary<string, Rate> Rates = new ConcurrentDictionary<string, Rate>();

        public Money Exchange(Currency from, Currency to)
        {
            var rate = GetRate(from, to);

            if (rate == null)
                throw new UnknownRateException(from, to);

            var fractional = Fractional(from, to);

            return new Money(fractional, to);
        }

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
            Rates.AddOrUpdate(rate.ToString(), rate, (k, v) => rate);
        }

        /// <summary>
        /// TODO
        /// </summary>
        /// <param name="from"></param>
        /// <param name="to"></param>
        /// <returns></returns>
        public Rate GetRate(Currency from, Currency to)
        {
            Rates.TryGetValue($"{from.Code}_{to.Code}", out var rate);

            return rate;
        }

        public IEnumerable<Rate> GetRates()
        {
            return Rates.Values;
        }

        public decimal Fractional(Currency from, Currency to)
        {
            //BigDecimal(from.fractional.to_s) / (
            //    BigDecimal(from.currency.subunit_to_unit.to_s) /
            //    BigDecimal(to_currency.subunit_to_unit.to_s)
            //)
            return (decimal)((decimal)from.CentesimalConversion / (decimal)to.CentesimalConversion);
        }
    }
}
