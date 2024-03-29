﻿using System.Collections.Concurrent;

namespace Money.Bank.Interfaces
{
    /// <summary>
    /// Money.Bank.Base is the basic interface for creating a money exchange
    /// object, also called Bank.
    ///
    /// A Bank is responsible for storing exchange rates, take a Money object as
    /// input and returns the corresponding Money object converted into an other
    /// currency.
    ///
    /// This class exists for aiding in the creating of other classes to exchange
    /// money between different currencies. When creating a subclass you will
    /// need to implement the following methods to exchange money between
    /// currencies:
    ///
    /// - Exchange(Money, Currency) #=> Money
    ///
    /// See Money.Bank.VariableExchange for a real example.
    ///
    /// Also, you can extend +Money.Bank.VariableExchange+ instead of
    /// +Money.Bank.Base+ if your bank implementation needs to store rates
    /// internally.
    ///
    /// @abstract Subclass and override +#Exchange+ to implement a custom
    ///  +Money.Bank+ class. You can also override +#setup+ instead of
    ///  +#initialize+ to setup initial variables, etc.
    /// </summary>
    public interface IBank
    {
        ConcurrentDictionary<string, Rate> Rates { get; }

        void AddRate(Currency from, Currency to, decimal value);
        void AddRate(Currency from, Currency to, double value);
        void SetRate(Rate rate);

        Rate Get(Currency from, Currency to);
        Money Exchange(Money from, Currency to);
    }
}
