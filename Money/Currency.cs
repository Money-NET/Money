using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using Money.Exceptions;

namespace Money
{
    public class Currency : IComparable
    {
        private static readonly ConcurrentDictionary<string, Currency> Currencies = new ConcurrentDictionary<string, Currency>();

        #region Currencies

        public static readonly Currency AED = new Currency("AED", 784, "United Arab Emirates Dirham", "%n %u", "Fils", 100, 25, ".", "," ,new[] { "د.إ.‏", "DH", "Dhs" });
        public static readonly Currency AFN = new Currency("AFN", 971, "Afghan Afghani", "%n %u", "Pul", 100, 100, ".", ",", new[] { "؋", "Af", "Afs" });
        public static readonly Currency ALL = new Currency("ALL", 008, "Albanian Lek", "%n %u", "Qintar", 100, 100, ".", ",", new[] { "Lekë", "Lek" });
        public static readonly Currency AMD = new Currency("AMD", 051, "Armenian Dram", "%n %u", "Luma", 100, 10, ".", ",", new[] { "֏", "dram" });
        public static readonly Currency ANG = new Currency("ANG", 532, "Netherlands Antillean Gulden", "%u %n", "Cent", 100, 1, ",", ".", new [] { "ƒ", "NAƒ", "NAf", "f" }, symbolFirst: true);
        public static readonly Currency AOA = new Currency("AOA", 973, "Angolan Kwanza", "%n %u", "Cêntimo", 100, 10, ".", ",", new [] { "Kz" });
        public static readonly Currency ARS = new Currency("ARS", 032, "Argentine Peso", "%n %u", "Centavo", 100, 1, ",", ".", new [] { "$", "$m/n", "m$n" }, disambiguateSymbol: "$m/n", symbolFirst: true);
        public static readonly Currency AUD = new Currency("AUD", 036, "Australian Dollar", "%u %n", "Cent", 100, 5, ".", ",", new []{ "$", "A$" }, disambiguateSymbol: "A$", priority: 4, symbolFirst: true);
        public static readonly Currency AWG = new Currency("AWG", 533, "Aruban Florin", "%n %u", "Cent", 100, 5, ".", ",", new []{ "ƒ", "Afl" });
        public static readonly Currency AZN = new Currency("AZN", 944, "Azerbaijani Manat", "%u %n", "Qəpik", 100, 1, ".", ",", new [] { "₼", "m", "man" }, symbolFirst: true);

        public static readonly Currency BAM = new Currency("BAM", 977, "Bosnia-Herzegovina Convertible Mark", "%u %n", "Fening", 100, 5, ".", ",", new [] { "КМ", "KM" }, symbolFirst: true);
        public static readonly Currency BBD = new Currency("BBD", 052, "Barbadian Dollar", "%u %n", "Cent", 100, 1, ".", ",", new [] { "$", "Bds$" }, disambiguateSymbol: "Bds$", symbolFirst: true);
        public static readonly Currency BDT = new Currency("BDT", 050, "Bangladeshi Taka", "%u %n", "Paisa", 100, 1, ".", ",", new [] { "৳", "Tk" }, symbolFirst: true);
        public static readonly Currency BGN = new Currency("BGN", 975, "Bulgarian Lev", "%n %u", "Stotinka", 100, 1, ".", ",", new [] { "лв.", "lev", "leva", "лев", "лева" });
        public static readonly Currency BHD = new Currency("BHD", 048, "Bahraini Dinar", "%u %n", "Fils", 1000, 5, ".", ",", new[] { "د.ب", "BD" }, symbolFirst: true);

        public static readonly Currency CHF = new Currency("CHF", 756, "Swiss Franc", "%u%n", "Rappen", 100, 5, ".", "’", new [] { "CHF", "SFr", "Fr" }, symbolFirst: true);

        public static readonly Currency DZD = new Currency("DZD", 012, "Algerian Dinar", "%n %u", "Centime", 100, 100, ".", ",", new[] { "د.ج", "DA" });

        public static readonly Currency EGP = new Currency("EGP", 818, "Egyptian Pound", "%u %n", "Piastre", 100, 25, ".", ",", new[] { "ج.م", "LE", "E£", "L.E." }, symbolFirst: true);
        public static readonly Currency ETB = new Currency("ETB", 230, "Ethiopian Birr", "%n %u", "Santim", 100, 1, ".", ",", new [] { "Br", "ብር" });

        public static readonly Currency IQD = new Currency("IQD", 368, "Iraqi Dinar", "%n %u", "Fils", 1000, 50000, ".", ",", new [] { "ع.د" });

        public static readonly Currency JOD = new Currency("JOD", 400, "Jordanian Dinar", "%u %n", "Fils", 1000, 5, ".", ",", new[] { "د.ا", "JD" });
        public static readonly Currency KWD = new Currency("KWD", 414, "Kuwaiti Dinar", "%u %n", "Fils", 1000, 5, ".", ",", new[] { "د.ك", "K.D." }, symbolFirst: true);

        public static readonly Currency LBP = new Currency("LBP", 422, "Lebanese Pound", "%u %n", "Piastre", 100, 25000, ".", ",", new[] { "ل.ل", "£", "L£" }, symbolFirst: true);

        public static readonly Currency SEK = new Currency("SEK", 752, "Swedish Krona", "%n %u", "Öre", 100, 100, ",", " ", new [] { "kr", ":-" });

        public static readonly Currency USD = new Currency("USD", 840, "United States Dollar", "%u %n", "Cent", 100, 1, ".", ",", new []{ "$", "US$" }, symbolFirst: true);

        public static readonly Currency ZAR = new Currency("ZAR", 710, "South African Rand", "%u %n", "Cent", 100, 10, ".", ",", new [] { "R" }, symbolFirst: true);

        #endregion


        #region Properties

        public int Priority { get; }
        public string Code { get; }
        public decimal? Number { get; }
        public string Name { get; }
        public string Format { get; set; }

        public string Symbol => Symbols.First();
        public string[] Symbols { get; }
        public bool SymbolFirst { get; }
        public string DisambiguateSymbol { get; }
        public string HtmlEntity { get; }

        public string SubUnit { get; }
        public int SubUnitToUnit { get; }

        public string DecimalMark { get; }
        public string ThousandsSeparator { get; }
        public int SmallestDenomination { get; }

        #endregion

        #region Constructors
        //private Currency(
        //    CultureInfo culture,
        //    decimal number,
        //    string subUnit,
        //    int subUnitToUnit,
        //    int smallestDenomination,
        //    IEnumerable<string> alternateSymbols = null,
        //    string disambiguateSymbol = null,
        //    string format = null,
        //    string htmlEntity = null,
        //    int priority = 100,
        //    bool symbolFirst = false)
        //{
        //    var region = new RegionInfo(culture.Name);
        //    var symbols = new List<string> { culture.NumberFormat.CurrencySymbol };

        //    if (alternateSymbols != null && alternateSymbols.Any())
        //        symbols.AddRange(alternateSymbols);

        //    Priority = priority;
        //    Code = region.ISOCurrencySymbol;
        //    Number = number;
        //    Name = region.CurrencyEnglishName;
        //    Format = string.IsNullOrWhiteSpace(format) ? symbolFirst ? "%u %n" : "%n %u" : format;

        //    Symbols = symbols.ToArray();
        //    SymbolFirst = symbolFirst;
        //    DisambiguateSymbol = disambiguateSymbol;
        //    HtmlEntity = htmlEntity;

        //    SubUnit = subUnit;
        //    SubUnitToUnit = subUnitToUnit;

        //    DecimalMark = culture.NumberFormat.CurrencyDecimalSeparator;
        //    ThousandsSeparator = culture.NumberFormat.CurrencyGroupSeparator;
        //    SmallestDenomination = smallestDenomination;

        //    Currencies.AddOrUpdate(Code, this, (k, v) => v);
        //}

        private Currency(
            string code,
            decimal number,
            string name,
            string format,
            string subUnit,
            int subUnitToUnit,
            int smallestDenomination,
            string decimalMark,
            string thousandsSeparator,
            IEnumerable<string> symbols,
            string disambiguateSymbol = null,
            bool symbolFirst = false,
            int priority = 100,
            string htmlEntity = null)
        {

            Priority = priority;
            Code = code;
            Number = number;
            Name = name;
            Format = format;

            Symbols = symbols.ToArray();
            SymbolFirst = symbolFirst;
            DisambiguateSymbol = disambiguateSymbol;
            HtmlEntity = htmlEntity;

            SubUnit = subUnit;
            SubUnitToUnit = subUnitToUnit;

            DecimalMark = decimalMark;
            ThousandsSeparator = thousandsSeparator;
            SmallestDenomination = smallestDenomination;

            Currencies.AddOrUpdate(Code, this, (k, v) => v);
        }
        #endregion

        #region Methods
        /// <summary>
        ///  TODO
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public static Currency Get(string code)
        {
            if (string.IsNullOrWhiteSpace(code))
                throw new UnknownCurrencyException(code);

            if (!Currencies.ContainsKey(code))
                throw new UnknownCurrencyException(code);

            Currencies.TryGetValue(code, out var currency);

            return currency;
        }

        /// <summary>
        /// Lookup a currency with given +id+ an returns a +Currency+ instance on
        /// success, +null+ otherwise.
        ///
        /// @param [String, Symbol, #to_s] id Used to look into +table+ and
        /// retrieve the applicable attributes.
        ///
        /// @return [Money::Currency]
        ///
        /// @example
        ///   Money.Currency.Find("eur") #=> #<Money.Currency Id: "eur" ...>
        ///   Money.Currency.Find("foo") #=> null
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public static Currency Find(string code)
        {
            try
            {
                return Get(code);
            }
            catch (UnknownCurrencyException)
            {
                return null;
            }
        }

        /// <summary>
        /// Lookup a currency with given +num+ as an ISO 4217 numeric and returns an
        /// +Currency+ instance on success, +null+ otherwise.
        ///
        /// @param [#to_s] num used to look into +table+ in +iso_numeric+ and find
        /// the right currency id.
        ///
        /// @return [Money.Currency]
        ///
        /// @example
        ///   Money.Currency.Find(978) #=> #<Money.Currency Id: "eur" ...>
        ///   Money.Currency.Find(51) #=> #<Money.Currency Id: "amd" ...>
        ///   Money.Currency.Find('001') #=> nil
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        public static Currency Find(int number)
        {
            try
            {
                var currency = Currencies.Values.FirstOrDefault(x => x.Number == number);

                if (currency == null)
                    throw new UnknownCurrencyException(number);

                return currency;
            }
            catch (UnknownCurrencyException)
            {
                return null;
            }
        }

        public static IEnumerable<Currency> All()
        {
            return Currencies.Values;
        }

        public int CompareTo(object obj)
        {
            var currency = (Currency)obj;
            return String.CompareOrdinal(Code, currency.Code);
        }

        /// <summary>
        /// Returns the relation between subunit and unit as a base 10 exponent.
        ///
        ///  Note that MGA and MRU are exceptions and are rounded to 1
        ///  @see https://en.wikipedia.org/wiki/ISO_4217#Active_codes
        /// </summary>
        /// <returns>[Integer]</returns>
        public int Exponent => (int)Math.Round(Math.Log10(SubUnitToUnit), MidpointRounding.ToEven);

        /// <summary>
        /// Returns if a code currency is ISO.
        /// </summary>
        public bool IsIso => Number != null;
        #endregion

        #region Overrides
        public override int GetHashCode()
        {
            return Code.GetHashCode();
        }

        /// <summary>
        /// Compares +self+ with +other_currency+ and returns +true+ if the are the
        /// same or if their +id+ attributes match.
        /// </summary>
        /// <param name="obj"></param>
        /// <returns>[Boolean]</returns>
        public override bool Equals(object obj)
        {
            if (!(obj is Currency))
            {
                return false;
            }

            if (ReferenceEquals(obj, this))
            {
                return true;
            }

            var rhs = (Currency)obj;

            return Code.Equals(rhs.Code);
        }

        /// <summary>
        /// Returns a string representation corresponding to the upcase +id+
        /// attribute. Useful in cases where only implicit conversions are made.
        /// </summary>
        /// <returns>[String]</returns>
        public override string ToString()
        {
            return Code;
        }

        #endregion

        #region Operators
        /// <summary>
        /// Compares +self+ with +other_currency+ and returns +true+ if the are the
        /// same or if their +id+ attributes match.
        /// </summary>
        /// <param name="obj"></param>
        /// <returns>[Boolean]</returns>
        public static bool operator ==(Currency lhs, Currency rhs)
        {
            if (ReferenceEquals(lhs, null))
            {
                return ReferenceEquals(rhs, null);
            }
            return lhs.Equals(rhs);
        }

        /// <summary>
        /// Compares +self+ with +other_currency+ and returns +true+ if the are the
        /// same or if their +id+ attributes match.
        /// </summary>
        /// <param name="obj"></param>
        /// <returns>[Boolean]</returns>
        public static bool operator !=(Currency lhs, Currency rhs)
        {
            return !(lhs == rhs);
        }
        #endregion
    }
}
