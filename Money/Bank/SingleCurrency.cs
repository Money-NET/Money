﻿using System.Collections.Concurrent;
using Money.Bank.Exceptions;
using Money.Bank.Interfaces;

namespace Money.Bank
{
    /// <summary>
    /// Class to ensure client code is operating in a single currency
    /// by raising if an exchange attempts to happen.
    ///
    /// This is useful when an application uses multiple currencies but
    /// it usually deals with only one currency at a time so any arithmetic
    /// where exchanges happen are erroneous. Using this as the default bank
    /// means that that these mistakes don't silently do the wrong thing.
    /// </summary>
    public class SingleCurrency : IBank
    {
        private static readonly ConcurrentDictionary<string, Rate> Items = new ConcurrentDictionary<string, Rate>();


        #region Methods

        public ConcurrentDictionary<string, Rate> Rates => Items;

        public void AddRate(Currency from, Currency to, decimal value)
        {
            throw new System.NotImplementedException();
        }

        public void AddRate(Currency from, Currency to, double value)
        {
            throw new System.NotImplementedException();
        }

        public void SetRate(Rate rate)
        {
            throw new System.NotImplementedException();
        }

        public Rate Get(Currency @from, Currency to)
        {
            throw new System.NotImplementedException();
        }

        #endregion

        public Money Exchange(Money from, Currency to)
        {
            throw new DifferentCurrencyException(from.Currency, to);
        }
    }
}
