using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Money.Enums;
using Money.Exceptions;

namespace Money
{
    public class Currency : IComparable
    {
        private static readonly ConcurrentDictionary<string, Currency> Currencies = new ConcurrentDictionary<string, Currency>();

        #region Currencies

        public static readonly Currency AED = new Currency("AED", 784, "United Arab Emirates Dirham", new NumberFormatInfo { CurrencyDecimalSeparator = ".", CurrencyGroupSeparator = ",", CurrencyNegativePattern = (int)NegativePosition.Eight, CurrencyPositivePattern = (int)PositivePosition.AfterWithSpace }, "Fils", 100, 25, new[] { "د.إ.‏", "DH", "Dhs" });
        public static readonly Currency AFN = new Currency("AFN", 971, "Afghan Afghani", new NumberFormatInfo { CurrencyDecimalSeparator = ".", CurrencyGroupSeparator = ",", CurrencyNegativePattern = (int)NegativePosition.Eight, CurrencyPositivePattern = (int)PositivePosition.AfterWithSpace }, "Pul", 100, 100, new[] { "؋", "Af", "Afs" });
        public static readonly Currency ALL = new Currency("ALL", 008, "Albanian Lek", new NumberFormatInfo { CurrencyDecimalSeparator = ".", CurrencyGroupSeparator = ",", CurrencyNegativePattern = (int)NegativePosition.Eight, CurrencyPositivePattern = (int)PositivePosition.AfterWithSpace }, "Qintar", 100, 100, new[] { "Lekë", "Lek" });
        public static readonly Currency AMD = new Currency("AMD", 051, "Armenian Dram", new NumberFormatInfo { CurrencyDecimalSeparator = ".", CurrencyGroupSeparator = ",", CurrencyNegativePattern = (int)NegativePosition.Eight, CurrencyPositivePattern = (int)PositivePosition.AfterWithSpace }, "Luma", 100, 10, new[] { "֏", "dram" });
        public static readonly Currency ANG = new Currency("ANG", 532, "Netherlands Antillean Gulden", new NumberFormatInfo { CurrencySymbol = "ƒ", CurrencyDecimalSeparator = ",", CurrencyGroupSeparator = ".", CurrencyNegativePattern = (int)NegativePosition.Nine, CurrencyPositivePattern = (int)PositivePosition.BeforeWithSpace }, "Cent", 100, 1, new[] { "ƒ", "NAƒ", "NAf", "f" });
        public static readonly Currency AOA = new Currency("AOA", 973, "Angolan Kwanza", new NumberFormatInfo { CurrencyDecimalSeparator = ".", CurrencyGroupSeparator = ",", CurrencyNegativePattern = (int)NegativePosition.Eight, CurrencyPositivePattern = (int)PositivePosition.AfterWithSpace }, "Cêntimo", 100, 10, new[] { "Kz" });
        public static readonly Currency ARS = new Currency("ARS", 032, "Argentine Peso", new NumberFormatInfo { CurrencyDecimalSeparator = ",", CurrencyGroupSeparator = ".", CurrencyNegativePattern = (int)NegativePosition.One, CurrencyPositivePattern = (int)PositivePosition.Before }, "Centavo", 100, 1, new[] { "$", "$m/n", "m$n" }, disambiguateSymbol: "$m/n");
        public static readonly Currency AUD = new Currency("AUD", 036, "Australian Dollar", new NumberFormatInfo { CurrencyDecimalSeparator = ".", CurrencyGroupSeparator = ",", CurrencyNegativePattern = (int)NegativePosition.One, CurrencyPositivePattern = (int)PositivePosition.Before }, "Cent", 100, 5, new[] { "$", "A$" }, disambiguateSymbol: "A$", priority: 4);
        public static readonly Currency AWG = new Currency("AWG", 533, "Aruban Florin", new NumberFormatInfo { CurrencyDecimalSeparator = ".", CurrencyGroupSeparator = ",", CurrencyNegativePattern = (int)NegativePosition.Eight, CurrencyPositivePattern = (int)PositivePosition.AfterWithSpace }, "Cent", 100, 5, new[] { "ƒ", "Afl" });
        public static readonly Currency AZN = new Currency("AZN", 944, "Azerbaijani Manat", new NumberFormatInfo { CurrencyDecimalSeparator = ".", CurrencyGroupSeparator = ",", CurrencyNegativePattern = (int)NegativePosition.One, CurrencyPositivePattern = (int)PositivePosition.Before }, "Qəpik", 100, 1, new[] { "₼", "m", "man" });

        public static readonly Currency BAM = new Currency("BAM", 977, "Bosnia-Herzegovina Convertible Mark", new NumberFormatInfo { CurrencyDecimalSeparator = ".", CurrencyGroupSeparator = ",", CurrencyNegativePattern = (int)NegativePosition.Eight, CurrencyPositivePattern = (int)PositivePosition.AfterWithSpace }, "Fening", 100, 5, new[] { "КМ", "KM" });
        public static readonly Currency BBD = new Currency("BBD", 052, "Barbadian Dollar", new NumberFormatInfo { CurrencyDecimalSeparator = ".", CurrencyGroupSeparator = ",", CurrencyNegativePattern = (int)NegativePosition.One, CurrencyPositivePattern = (int)PositivePosition.Before }, "Cent", 100, 1, new[] { "$", "Bds$" }, disambiguateSymbol: "Bds$");
        public static readonly Currency BDT = new Currency("BDT", 050, "Bangladeshi Taka", new NumberFormatInfo { CurrencyDecimalSeparator = ".", CurrencyGroupSeparator = ",", CurrencyNegativePattern = (int)NegativePosition.One, CurrencyPositivePattern = (int)PositivePosition.Before }, "Paisa", 100, 1, new[] { "৳", "Tk" });
        public static readonly Currency BGN = new Currency("BGN", 975, "Bulgarian Lev", new NumberFormatInfo { CurrencyDecimalSeparator = ".", CurrencyGroupSeparator = ",", CurrencyNegativePattern = (int)NegativePosition.Eight, CurrencyPositivePattern = (int)PositivePosition.AfterWithSpace }, "Stotinka", 100, 1, new[] { "лв.", "lev", "leva", "лев", "лева" });
        public static readonly Currency BHD = new Currency("BHD", 048, "Bahraini Dinar", new NumberFormatInfo { CurrencyDecimalSeparator = ".", CurrencyGroupSeparator = ",", CurrencyNegativePattern = (int)NegativePosition.One, CurrencyPositivePattern = (int)PositivePosition.Before }, "Fils", 1000, 5, new[] { "د.ب", "BD" });
        public static readonly Currency BIF = new Currency("BIF", 108, "Burundian Franc", new NumberFormatInfo { CurrencyDecimalSeparator = ".", CurrencyGroupSeparator = ",", CurrencyNegativePattern = (int)NegativePosition.Eight, CurrencyPositivePattern = (int)PositivePosition.AfterWithSpace }, "Centime", 1, 100, new[] { "Fr", "FBu" });
        public static readonly Currency BMD = new Currency("BMD", 060, "Bermudian Dollar", new NumberFormatInfo { CurrencyDecimalSeparator = ".", CurrencyGroupSeparator = ",", CurrencyNegativePattern = (int)NegativePosition.One, CurrencyPositivePattern = (int)PositivePosition.Before }, "Cent", 100, 1, new[] { "$", "BD$" });
        public static readonly Currency BND = new Currency("BND", 096, "Brunei Dollar", new NumberFormatInfo { CurrencyDecimalSeparator = ".", CurrencyGroupSeparator = ",", CurrencyNegativePattern = (int)NegativePosition.One, CurrencyPositivePattern = (int)PositivePosition.Before }, "Sen", 100, 1, new[] { "$", "B$", "BND" }, disambiguateSymbol: "BND");
        public static readonly Currency BOB = new Currency("BOB", 068, "Bolivian Boliviano", new NumberFormatInfo { CurrencyDecimalSeparator = ".", CurrencyGroupSeparator = ",", CurrencyNegativePattern = (int)NegativePosition.One, CurrencyPositivePattern = (int)PositivePosition.Before }, "Centavo", 100, 10, new[] { "Bs.", "Bs" });
        public static readonly Currency BRL = new Currency("BRL", 986, "Brazilian Real", new NumberFormatInfo { CurrencyDecimalSeparator = ",", CurrencyGroupSeparator = ".", CurrencyNegativePattern = (int)NegativePosition.One, CurrencyPositivePattern = (int)PositivePosition.Before }, "Centavo", 100, 5, new[] { "R$" });
        public static readonly Currency BSD = new Currency("BSD", 044, "Bahamian Dollar", new NumberFormatInfo { CurrencyDecimalSeparator = ".", CurrencyGroupSeparator = ",", CurrencyNegativePattern = (int)NegativePosition.One, CurrencyPositivePattern = (int)PositivePosition.Before }, "Cent", 100, 1, new[] { "$", "B$" }, disambiguateSymbol: "BSD");
        public static readonly Currency BTN = new Currency("BTN", 064, "Bhutanese Ngultrum", new NumberFormatInfo { CurrencyDecimalSeparator = ".", CurrencyGroupSeparator = ",", CurrencyNegativePattern = (int)NegativePosition.Eight, CurrencyPositivePattern = (int)PositivePosition.AfterWithSpace }, "Chertrum", 100, 5, new[] { "Nu.", "Nu" });
        public static readonly Currency BWP = new Currency("BWP", 072, "Botswana Pula", new NumberFormatInfo { CurrencyDecimalSeparator = ".", CurrencyGroupSeparator = ",", CurrencyNegativePattern = (int)NegativePosition.One, CurrencyPositivePattern = (int)PositivePosition.Before }, "Thebe", 100, 5, new[] { "P" });
        public static readonly Currency BYN = new Currency("BYN", 933, "Belarusian Ruble", new NumberFormatInfo { CurrencyDecimalSeparator = ",", CurrencyGroupSeparator = " ", CurrencyNegativePattern = (int)NegativePosition.Eight, CurrencyPositivePattern = (int)PositivePosition.AfterWithSpace }, "Kapeyka", 100, 1, new[] { "Br", "бел. руб.", "б.р.", "руб.", "р." }, disambiguateSymbol: "BYN");
        public static readonly Currency BYR = new Currency("BYR", 974, "Belarusian Ruble", new NumberFormatInfo { CurrencyDecimalSeparator = ",", CurrencyGroupSeparator = " ", CurrencyNegativePattern = (int)NegativePosition.Eight, CurrencyPositivePattern = (int)PositivePosition.AfterWithSpace }, null, 1, 100, new[] { "Br", "бел. руб.", "б.р.", "руб.", "р." }, disambiguateSymbol: "BYR", priority: 50);
        public static readonly Currency BZD = new Currency("BZD", 084, "Belize Dollar", new NumberFormatInfo { CurrencyDecimalSeparator = ".", CurrencyGroupSeparator = ",", CurrencyNegativePattern = (int)NegativePosition.One, CurrencyPositivePattern = (int)PositivePosition.Before }, "Cent", 100, 1, new[] { "$", "BZ$" }, disambiguateSymbol: "BZ$");

        public static readonly Currency CAD = new Currency("CAD", 124, "Canadian Dollar", new NumberFormatInfo { CurrencyDecimalSeparator = ".", CurrencyGroupSeparator = ",", CurrencyNegativePattern = (int)NegativePosition.One, CurrencyPositivePattern = (int)PositivePosition.Before }, "Cent", 100, 5, new[] { "$", "C$", "CAD$" }, disambiguateSymbol: "C$");
        public static readonly Currency CDF = new Currency("CDF", 976, "Congolese Franc", new NumberFormatInfo { CurrencyDecimalSeparator = ".", CurrencyGroupSeparator = ",", CurrencyNegativePattern = (int)NegativePosition.Eight, CurrencyPositivePattern = (int)PositivePosition.AfterWithSpace }, "Centime", 100, 1, new[] { "Fr", "FC" }, disambiguateSymbol: "FC");
        public static readonly Currency CHF = new Currency("CHF", 756, "Swiss Franc", new NumberFormatInfo { CurrencyDecimalSeparator = ".", CurrencyGroupSeparator = "’", CurrencyNegativePattern = (int)NegativePosition.One, CurrencyPositivePattern = (int)PositivePosition.Before }, "Rappen", 100, 5, new[] { "CHF", "SFr", "Fr" });
        public static readonly Currency CLF = new Currency("CLF", 990, "Unidad de Fomento", new NumberFormatInfo { CurrencyDecimalSeparator = ",", CurrencyGroupSeparator = ".", CurrencyNegativePattern = (int)NegativePosition.One, CurrencyPositivePattern = (int)PositivePosition.Before }, "Peso", 10000, 1, new[] { "UF" });
        public static readonly Currency CLP = new Currency("CLP", 152, "Chilean Peso", new NumberFormatInfo { CurrencyDecimalSeparator = ",", CurrencyGroupSeparator = ".", CurrencyNegativePattern = (int)NegativePosition.One, CurrencyPositivePattern = (int)PositivePosition.Before }, "Peso", 1, 1, new[] { "$" }, disambiguateSymbol: "CLP");
        public static readonly Currency CNY = new Currency("CNY", 156, "Chinese Renminbi Yuan", new NumberFormatInfo { CurrencyDecimalSeparator = ".", CurrencyGroupSeparator = ",", CurrencyNegativePattern = (int)NegativePosition.One, CurrencyPositivePattern = (int)PositivePosition.Before }, "Fen", 100, 1, new[] { "¥", "CN¥", "元", "CN元" });
        public static readonly Currency COP = new Currency("COP", 170, "Colombian Peso", new NumberFormatInfo { CurrencyDecimalSeparator = ",", CurrencyGroupSeparator = ".", CurrencyNegativePattern = (int)NegativePosition.One, CurrencyPositivePattern = (int)PositivePosition.Before }, "Centavo", 100, 20, new[] { "$", "COL$" }, disambiguateSymbol: "COL$");
        public static readonly Currency CRC = new Currency("CRC", 188, "Costa Rican Colón", new NumberFormatInfo { CurrencyDecimalSeparator = ",", CurrencyGroupSeparator = ".", CurrencyNegativePattern = (int)NegativePosition.One, CurrencyPositivePattern = (int)PositivePosition.Before }, "Céntimo", 100, 500, new[] { "₡", "¢" });
        public static readonly Currency CUC = new Currency("CUC", 931, "Cuban Convertible Peso", new NumberFormatInfo { CurrencyDecimalSeparator = ".", CurrencyGroupSeparator = ",", CurrencyNegativePattern = (int)NegativePosition.Eight, CurrencyPositivePattern = (int)PositivePosition.AfterWithSpace }, "Centavo", 100, 1, new[] { "$", "CUC$" }, disambiguateSymbol: "CUC$");
        public static readonly Currency CUP = new Currency("CUP", 192, "Cuban Peso", new NumberFormatInfo { CurrencyDecimalSeparator = ".", CurrencyGroupSeparator = ",", CurrencyNegativePattern = (int)NegativePosition.One, CurrencyPositivePattern = (int)PositivePosition.Before }, "Centavo", 100, 1, new[] { "$", "$MN" }, disambiguateSymbol: "$MN");
        public static readonly Currency CVE = new Currency("CVE", 132, "Cape Verdean Escudo", new NumberFormatInfo { CurrencyDecimalSeparator = ".", CurrencyGroupSeparator = ",", CurrencyNegativePattern = (int)NegativePosition.Eight, CurrencyPositivePattern = (int)PositivePosition.AfterWithSpace }, "Centavo", 100, 100, new[] { "$", "Esc" });
        public static readonly Currency CZK = new Currency("CZK", 203, "Czech Koruna", new NumberFormatInfo { CurrencyDecimalSeparator = ",", CurrencyGroupSeparator = " ", CurrencyNegativePattern = (int)NegativePosition.Eight, CurrencyPositivePattern = (int)PositivePosition.AfterWithSpace }, "Haléř", 100, 100, new[] { "Kč" });

        public static readonly Currency DJF = new Currency("DJF", 262, "Djiboutian Franc", new NumberFormatInfo { CurrencyDecimalSeparator = ".", CurrencyGroupSeparator = ",", CurrencyNegativePattern = (int)NegativePosition.Eight, CurrencyPositivePattern = (int)PositivePosition.AfterWithSpace }, "Centime", 1, 100, new[] { "Fdj" });
        public static readonly Currency DKK = new Currency("DKK", 208, "Danish Krone", new NumberFormatInfo { CurrencyDecimalSeparator = ",", CurrencyGroupSeparator = ".", CurrencyNegativePattern = (int)NegativePosition.Eight, CurrencyPositivePattern = (int)PositivePosition.AfterWithSpace }, "Øre", 100, 50, new[] { "kr.", ",-" }, disambiguateSymbol: "DKK");
        public static readonly Currency DOP = new Currency("DOP", 214, "Dominican Peso", new NumberFormatInfo { CurrencyDecimalSeparator = ".", CurrencyGroupSeparator = ",", CurrencyNegativePattern = (int)NegativePosition.One, CurrencyPositivePattern = (int)PositivePosition.Before }, "Centavo", 100, 100, new[] { "$", "RD$" }, disambiguateSymbol: "RD$");
        public static readonly Currency DZD = new Currency("DZD", 012, "Algerian Dinar", new NumberFormatInfo { CurrencyDecimalSeparator = ".", CurrencyGroupSeparator = ",", CurrencyNegativePattern = (int)NegativePosition.Eight, CurrencyPositivePattern = (int)PositivePosition.AfterWithSpace }, "Centime", 100, 100, new[] { "د.ج", "DA" });

        public static readonly Currency EGP = new Currency("EGP", 818, "Egyptian Pound", new NumberFormatInfo { CurrencyDecimalSeparator = ".", CurrencyGroupSeparator = ",", CurrencyNegativePattern = (int)NegativePosition.One, CurrencyPositivePattern = (int)PositivePosition.Before }, "Piastre", 100, 25, new[] { "ج.م", "LE", "E£", "L.E." });
        public static readonly Currency ERN = new Currency("ERN", 232, "Eritrean Nakfa", new NumberFormatInfo { CurrencyDecimalSeparator = ".", CurrencyGroupSeparator = ",", CurrencyNegativePattern = (int)NegativePosition.Eight, CurrencyPositivePattern = (int)PositivePosition.AfterWithSpace }, "Cent", 100, 1, new[] { "Nfk" });
        public static readonly Currency ETB = new Currency("ETB", 230, "Ethiopian Birr", new NumberFormatInfo { CurrencyDecimalSeparator = ".", CurrencyGroupSeparator = ",", CurrencyNegativePattern = (int)NegativePosition.Eight, CurrencyPositivePattern = (int)PositivePosition.AfterWithSpace }, "Santim", 100, 1, new[] { "Br", "ብር" });
        public static readonly Currency EUR = new Currency("EUR", 978, "Euro", new NumberFormatInfo { CurrencyDecimalSeparator = ",", CurrencyGroupSeparator = ".", CurrencyNegativePattern = (int)NegativePosition.One, CurrencyPositivePattern = (int)PositivePosition.Before }, "Cent", 100, 1, new[] { "€" });

        public static readonly Currency FJD = new Currency("FJD", 242, "Fijian Dollar", new NumberFormatInfo { CurrencyDecimalSeparator = ".", CurrencyGroupSeparator = ",", CurrencyNegativePattern = (int)NegativePosition.Eight, CurrencyPositivePattern = (int)PositivePosition.AfterWithSpace }, "Cent", 100, 5, new[] { "$", "FJ$" });
        public static readonly Currency FKP = new Currency("FKP", 238, "Falkland Pound", new NumberFormatInfo { CurrencyDecimalSeparator = ".", CurrencyGroupSeparator = ",", CurrencyNegativePattern = (int)NegativePosition.Eight, CurrencyPositivePattern = (int)PositivePosition.AfterWithSpace }, "Penny", 100, 1, new[] { "£", "FK£" });

        public static readonly Currency GBP = new Currency("GBP", 826, "British Pound", new NumberFormatInfo { CurrencyDecimalSeparator = ".", CurrencyGroupSeparator = ",", CurrencyNegativePattern = (int)NegativePosition.One, CurrencyPositivePattern = (int)PositivePosition.Before }, "Penny", 100, 1, new[] { "£" }, priority: 3);
        public static readonly Currency GEL = new Currency("GEL", 981, "Georgian Lari", new NumberFormatInfo { CurrencyDecimalSeparator = ".", CurrencyGroupSeparator = ",", CurrencyNegativePattern = (int)NegativePosition.Eight, CurrencyPositivePattern = (int)PositivePosition.AfterWithSpace }, "Tetri", 100, 1, new[] { "ლ", "lari" });
        public static readonly Currency GHS = new Currency("GHS", 936, "Ghanaian Cedi", new NumberFormatInfo { CurrencyDecimalSeparator = ".", CurrencyGroupSeparator = ",", CurrencyNegativePattern = (int)NegativePosition.One, CurrencyPositivePattern = (int)PositivePosition.Before }, "Pesewa", 100, 1, new[] { "₵", "GH¢", "GH₵" });
        public static readonly Currency GIP = new Currency("GIP", 292, "Gibraltar Pound", new NumberFormatInfo { CurrencyDecimalSeparator = ".", CurrencyGroupSeparator = ",", CurrencyNegativePattern = (int)NegativePosition.One, CurrencyPositivePattern = (int)PositivePosition.Before }, "Penny", 100, 1, new[] { "£" }, disambiguateSymbol: "GIP");
        public static readonly Currency GMD = new Currency("GMD", 270, "Gambian Dalasi", new NumberFormatInfo { CurrencyDecimalSeparator = ".", CurrencyGroupSeparator = ",", CurrencyNegativePattern = (int)NegativePosition.Eight, CurrencyPositivePattern = (int)PositivePosition.AfterWithSpace }, "Butut", 100, 1, new[] { "D" });
        public static readonly Currency GNF = new Currency("GNF", 324, "Guinean Franc", new NumberFormatInfo { CurrencyDecimalSeparator = ".", CurrencyGroupSeparator = ",", CurrencyNegativePattern = (int)NegativePosition.Eight, CurrencyPositivePattern = (int)PositivePosition.AfterWithSpace }, "Centime", 1, 100, new[] { "Fr", "FG", "GFr" }, disambiguateSymbol: "FG");
        public static readonly Currency GTQ = new Currency("GTQ", 320, "Guatemalan Quetzal", new NumberFormatInfo { CurrencyDecimalSeparator = ".", CurrencyGroupSeparator = ",", CurrencyNegativePattern = (int)NegativePosition.One, CurrencyPositivePattern = (int)PositivePosition.Before }, "Centavo", 100, 1, new[] { "Q" });
        public static readonly Currency GYD = new Currency("GYD", 328, "Guyanese Dollar", new NumberFormatInfo { CurrencyDecimalSeparator = ".", CurrencyGroupSeparator = ",", CurrencyNegativePattern = (int)NegativePosition.Eight, CurrencyPositivePattern = (int)PositivePosition.AfterWithSpace }, "Cent", 100, 100, new[] { "$", "G$" }, disambiguateSymbol: "G$");

        public static readonly Currency HKD = new Currency("HKD", 344, "Hong Kong Dollar", new NumberFormatInfo { CurrencyDecimalSeparator = ".", CurrencyGroupSeparator = ",", CurrencyNegativePattern = (int)NegativePosition.One, CurrencyPositivePattern = (int)PositivePosition.Before }, "Cent", 100, 10, new[] { "$", "HK$" }, disambiguateSymbol: "HK$");
        public static readonly Currency HNL = new Currency("HNL", 340, "Honduran Lempira", new NumberFormatInfo { CurrencyDecimalSeparator = ".", CurrencyGroupSeparator = ",", CurrencyNegativePattern = (int)NegativePosition.One, CurrencyPositivePattern = (int)PositivePosition.Before }, "Centavo", 100, 5, new[] { "L" }, disambiguateSymbol: "HNL");
        public static readonly Currency HRK = new Currency("HRK", 191, "Croatian Kuna", new NumberFormatInfo { CurrencyDecimalSeparator = ",", CurrencyGroupSeparator = ".", CurrencyNegativePattern = (int)NegativePosition.Eight, CurrencyPositivePattern = (int)PositivePosition.AfterWithSpace }, "Lipa", 100, 1, new[] { "kn" });
        public static readonly Currency HTG = new Currency("HTG", 332, "Haitian Gourde", new NumberFormatInfo { CurrencyDecimalSeparator = ".", CurrencyGroupSeparator = ",", CurrencyNegativePattern = (int)NegativePosition.Eight, CurrencyPositivePattern = (int)PositivePosition.AfterWithSpace }, "Centime", 100, 5, new[] { "G" });
        public static readonly Currency HUF = new Currency("HUF", 348, "Hungarian Forint", new NumberFormatInfo { CurrencyDecimalSeparator = ",", CurrencyGroupSeparator = " ", CurrencyNegativePattern = (int)NegativePosition.Eight, CurrencyPositivePattern = (int)PositivePosition.AfterWithSpace }, string.Empty, 1, 5, new[] { "Ft" });

        public static readonly Currency IDR = new Currency("IDR", 360, "Indonesian Rupiah", new NumberFormatInfo { CurrencyDecimalSeparator = ",", CurrencyGroupSeparator = ".", CurrencyNegativePattern = (int)NegativePosition.One, CurrencyPositivePattern = (int)PositivePosition.Before }, "Sen", 100, 5000, new[] { "Rp" });
        public static readonly Currency ILS = new Currency("ILS", 376, "Israeli New Sheqel", new NumberFormatInfo { CurrencyDecimalSeparator = ".", CurrencyGroupSeparator = ",", CurrencyNegativePattern = (int)NegativePosition.Eight, CurrencyPositivePattern = (int)PositivePosition.AfterWithSpace }, "Agora", 100, 10, new[] { "₪", "ש״ח", "NIS" });
        public static readonly Currency INR = new Currency("INR", 356, "Indian Rupee", new NumberFormatInfo { CurrencyDecimalSeparator = ".", CurrencyGroupSeparator = ",", CurrencyNegativePattern = (int)NegativePosition.One, CurrencyPositivePattern = (int)PositivePosition.Before }, "Paisa", 100, 50, new[] { "₹", "Rs", "৳", "૱", "௹", "रु", "₨" });
        public static readonly Currency IRR = new Currency("IRR", 364, "Iranian Rial", new NumberFormatInfo { CurrencyDecimalSeparator = ".", CurrencyGroupSeparator = ",", CurrencyNegativePattern = (int)NegativePosition.Eight, CurrencyPositivePattern = (int)PositivePosition.AfterWithSpace }, string.Empty, 100, 5000, new[] { "﷼" });
        public static readonly Currency ISK = new Currency("ISK", 352, "Icelandic Króna", new NumberFormatInfo { CurrencyDecimalSeparator = ",", CurrencyGroupSeparator = ".", CurrencyNegativePattern = (int)NegativePosition.Eight, CurrencyPositivePattern = (int)PositivePosition.AfterWithSpace }, string.Empty, 1, 1, new[] { "kr.", "Íkr" });
        public static readonly Currency IQD = new Currency("IQD", 368, "Iraqi Dinar", new NumberFormatInfo { CurrencyDecimalSeparator = ".", CurrencyGroupSeparator = ",", CurrencyNegativePattern = (int)NegativePosition.Eight, CurrencyPositivePattern = (int)PositivePosition.AfterWithSpace }, "Fils", 1000, 50000, new[] { "ع.د" });

        public static readonly Currency JOD = new Currency("JOD", 400, "Jordanian Dinar", new NumberFormatInfo { CurrencyDecimalSeparator = ".", CurrencyGroupSeparator = ",", CurrencyNegativePattern = (int)NegativePosition.One, CurrencyPositivePattern = (int)PositivePosition.Before }, "Fils", 1000, 5,  new[] { "د.ا", "JD" });
        public static readonly Currency KWD = new Currency("KWD", 414, "Kuwaiti Dinar", new NumberFormatInfo { CurrencyDecimalSeparator = ".", CurrencyGroupSeparator = ",", CurrencyNegativePattern = (int)NegativePosition.One, CurrencyPositivePattern = (int)PositivePosition.Before }, "Fils", 1000, 5, new[] { "د.ك", "K.D." });

        public static readonly Currency LBP = new Currency("LBP", 422, "Lebanese Pound", new NumberFormatInfo { CurrencyDecimalSeparator = ".", CurrencyGroupSeparator = ",", CurrencyNegativePattern = (int)NegativePosition.One, CurrencyPositivePattern = (int)PositivePosition.Before }, "Piastre", 100, 25000, new[] { "ل.ل", "£", "L£" });

        public static readonly Currency SEK = new Currency("SEK", 752, "Swedish Krona", new NumberFormatInfo { CurrencyDecimalSeparator = ",", CurrencyGroupSeparator = " ", CurrencyNegativePattern = (int)NegativePosition.Eight, CurrencyPositivePattern = (int)PositivePosition.AfterWithSpace }, "Öre", 100, 100, new[] { "kr", ":-" }, disambiguateSymbol: "SEK");

        public static readonly Currency USD = new Currency("USD", 840, "United States Dollar", new NumberFormatInfo { CurrencyDecimalSeparator = ".", CurrencyGroupSeparator = ",", CurrencyNegativePattern = (int)NegativePosition.One, CurrencyPositivePattern = (int)PositivePosition.Before }, "Cent", 100, 1,  new[] { "$", "US$" }, disambiguateSymbol: "US$");

        public static readonly Currency ZAR = new Currency("ZAR", 710, "South African Rand", new NumberFormatInfo { CurrencyDecimalSeparator = ".", CurrencyGroupSeparator = ",", CurrencyNegativePattern = (int)NegativePosition.One, CurrencyPositivePattern = (int)PositivePosition.Before }, "Cent", 100, 10, new[] { "R" });

        #endregion


        #region Properties

        public int Priority { get; }
        public string Code { get; }
        public decimal? Number { get; }
        public string Name { get; }
        /// <summary>
        /// Value    Associated pattern
        /// 0                $n
        /// 1                n$
        /// 2                $ n
        /// 3                n $
        /// </summary>
        public NumberFormatInfo Format { get; set; }

        public string Symbol => Symbols.First();
        public string[] Symbols { get; }
        public string DisambiguateSymbol { get; }
        public string HtmlEntity { get; }

        public string SubUnit { get; }
        public int SubUnitToUnit { get; }
        public int SmallestDenomination { get; }

        #endregion

        #region Constructors

        private Currency(
            string code,
            decimal number,
            string name,
            NumberFormatInfo format,
            string subUnit,
            int subUnitToUnit,
            int smallestDenomination,
            IEnumerable<string> symbols,
            string disambiguateSymbol = null,
            int priority = 100,
            string htmlEntity = null)
        {

            Priority = priority;
            Code = code;
            Number = number;
            Name = name;
            Format = format;

            Symbols = symbols.ToArray();
            DisambiguateSymbol = disambiguateSymbol;
            HtmlEntity = htmlEntity;

            SubUnit = subUnit;
            SubUnitToUnit = subUnitToUnit;
            SmallestDenomination = smallestDenomination;

            Format.CurrencyDecimalDigits = 2;
            Format.CurrencySymbol = symbols.First();

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
            return string.CompareOrdinal(Code, currency.Code);
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
