namespace Domain.ValueTypes
{
    public class Money
    {
        public Money(decimal amount, Currency currency)
        {
            Currency = currency;
            Amount = amount;
        }

        public Currency Currency { get; private set; }
        public decimal Amount { get; private set; }
        

        public static Money operator +(Money left, Money right)
        {
            //TODO: verify currencies etc..
            return new Money(left.Amount + right.Amount, left.Currency);
        }
    }
}