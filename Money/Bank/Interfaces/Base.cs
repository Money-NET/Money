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
    /// - #exchange_with(Money) #=> Money
    ///
    /// See Money::Bank::VariableExchange for a real example.
    ///
    /// Also, you can extend +Money::Bank::VariableExchange+ instead of
    /// +Money.Bank.Base+ if your bank implementation needs to store rates
    /// internally.
    ///
    /// @abstract Subclass and override +#exchange_with+ to implement a custom
    ///  +Money.Bank+ class. You can also override +#setup+ instead of
    ///  +#initialize+ to setup initial variables, etc.
    /// </summary>
    public interface IBank
    {
        decimal Exchange(Currency from, Currency to);
    }
}
