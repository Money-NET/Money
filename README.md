# Money.NET
A .NET implementation of the famous Ruby Library Money for dealing with money and currency conversion.

![Nuget](https://img.shields.io/nuget/v/Money.NET)
![Nuget](https://img.shields.io/nuget/dt/Money.NET)

## Contributing
See the [Contribution Guidelines](https://github.com/RubyMoney/money/blob/master/CONTRIBUTING.md)

## Introduction
A .NET Library for dealing with money and currency conversion.

### Features
- Provides a `Money` class which encapsulates all information about a certain amount of money, such as its value and its currency.
- Provides a `Money.Currency` constant class which encapsulates all information about a monetary unit.
- Represents monetary values as integers, in cents. This avoids floating point rounding errors.
- Represents currency as `Money.Currency` instances providing a high level of flexibility.
- Provides APIs for exchanging money from one currency to another.

### Resources
_TODO_

## Downloading
Install stable releases with the following command:

    dotnet add package Money.NET

The development version (hosted on Github) can be installed with:

    git clone git://github.com/gonace/Money.git

## Usage
``` c#
using Money;

# 10.00 USD
var money = new Money(1000, Currency.USD)
money.Cents     #=> 1000
money.Currency  #=> {USD}
    Code: "USD"
    DisambiguateSymbol: "US$"
    Exponent: 2
    Format: {System.Globalization.NumberFormatInfo}
    HtmlEntity: null
    IsIso: true
    Name: "United States Dollar"
    Number: 840
    Priority: 100
    SmallestDenomination: 1
    SubUnit: "Cent"
    SubUnitToUnit: 100
    Symbol: "$"
    Symbols: {string[2]}

# Comparisons
new Money(1000, Currency.USD) == new Money(1000, Currency.USD)   #=> true
new Money(1000, Currency.USD) == new Money(100, Currency.USD)    #=> false
new Money(1000, Currency.USD) == new Money(1000, Currency.EUR)   #=> false
new Money(1000, Currency.USD) != new Money(1000, Currency.EUR)   #=> true

# Arithmetic
new Money(1000, Currency.USD) + new Money(500, "USD") == new Money(1500, Currency.USD)
new Money(1000, Currency.USD) - new Money(200, "USD") == new Money(800, Currency.USD)
new Money(1000, Currency.USD) / 5                     == new Money(200, Currency.USD)
new Money(1000, Currency.USD) * 5                     == new Money(5000, Currency.USD)

# Unit to subunit conversions
Money.FromAmount(5, Currency.USD) == Money.FromCents(500, Currency.USD)  # 5 USD
Money.FromAmount(5, Currency.JPY) == Money.FromCents(5, Currency.JPY)    # 5 JPY
Money.FromAmount(5, Currency.TND) == Money.FromCents(5000, Currency.TND) # 5 TND

# Currency conversions
some_code_to_setup_exchange_rates
Money.FromCents(1000, Currency.USD).Exchange("EUR") == new Money(some_value, "EUR")

# Formatting (see Formatting section for more options)
new Money(100, Currency.USD).ToString() #=> "$1.00"
new Money(100, Currency.GBP).ToString() #=> "£1.00"
new Money(100, Currency.EUR).ToString() #=> "€1.00"
```

## Currency
Currencies are consistently represented as instances of `Money.Currency`.
The most part of `Money` APIs allows you to supply either a `String` or a `Money.Currency`.

``` c#
new Money(1000, Currency.USD) == new Money(1000, Currency.USD)
new Money(1000, "EUR").Currency == Currency.EUR
```

A `Money.Currency` instance holds all the information about the currency,
including the currency symbol, name and much more.

``` c#
currency = new Money(1000, "USD").Currency
currency.Code     #=> "USD"
currency.Number   #=> 840
currency.Name     #=> "United States Dollar"
```

The pre-defined set of attributes includes:

- `Priority` a numerical value you can use to sort/group the currency list
- `Code` the international 3-letter code as defined by the ISO 4217 standard
- `Number` the international 3-digit code as defined by the ISO 4217 standard
- `Name` the currency name
- `Symbol` the currency symbol (UTF-8 encoded)
- `Format` the currency format (https://docs.microsoft.com/en-us/dotnet/api/system.globalization.numberformatinfo?view=net-6.0)
- `Subunit` the name of the fractional monetary unit
- `SubUnitToUnit` the proportion between the unit and the subunit
- `SmallestDenomination` the _TODO_

### Priority
The priority attribute is an arbitrary numerical value you can assign to the
`Money.Currency` and use in sorting/grouping operation.

For instance, let's assume your .NET application needs to render a currency
selector like the one available [here](https://finance.yahoo.com/currency-converter/). 
You can create a couple of custom methods to return the list of major currencies and 
all currencies as follows:

``` c#
  _TODO_
```

### Default Currency
By default `Money` has no defaults to USD as its currency. This can be overwritten
using

### Currency Exponent

The exponent of a money value is the number of digits after the decimal
separator (which separates the major unit from the minor unit). See e.g.
[ISO 4217](https://www.currency-iso.org/en/shared/amendments/iso-4217-amendment.html) for more
information. You can find the exponent (as an `Integer`) by

``` c#
Currency.USD.Exponent  # => 2
Currency.JPY.Exponent  # => 0
Currency.MGA.Exponent  # => 1
```

### Currency Lookup
To find a given currency by ISO 4217 numeric code (three digits) you can do

``` c#
Currency.Find(978) #=> #<Money.Currency Code: EUR ...>
```

## Currency Exchange

Exchanging money is performed through an exchange bank object. The default
exchange bank object requires one to manually specify the exchange rate. Here's
an example of how it works:

``` c#
Money.AddRate(Currency.USD, Currency.CAD, 1.24515);
Money.AddRate(Currency.CAD, Currency.USD, 0.803115);

Money.FromAmount(100, Currency.USD).Exchange(Currency.CAD);  # => new Money(124, Currency.CAD)
Money.FromAmount(100, Currency.CAD).Exchange(Currency.USD);  # => new Money(80, Currency.USD)
```

Comparison and arithmetic operations work as expected:

``` c#
new Money(1000, Currency.USD) <=> new Money(900, Currency.USD)   # => 1; 9.00 USD is smaller
new Money(1000, Currency.EUR) + new Money(10, Currency.EUR) == new Money(1010, Currency.EUR)

Money.AddRate(Currency.USD, "EUR", 0.5)
new Money(1000, "EUR") + new Money(1000, Currency.USD) == new Money(1500, Currency.EUR)
```

### Exchange rate stores
_TODO_

### Implementations
The following is a list of Money.nuget compatible currency exchange rate
implementations.

_TODO_

## Formatting
_TODO_

## Rounding
_TODO_

## Localization
_TODO_

### Deprecation
_TODO_

## Collection
_TODO_

### Troubleshooting
_TODO_
