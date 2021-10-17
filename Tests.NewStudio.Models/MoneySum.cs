using Tests.NewStudio.Interfaces;

namespace Tests.NewStudio.Models
{
    public class MoneySum : IMoneySum
    {
        public decimal Amount { get; set; }
        public ICurrency Currency { get; set; }

        public MoneySum() { }

        public MoneySum(ICurrency currency, decimal value)
        {
            Amount = value;
            Currency = currency;
        }

        public override string ToString() =>  $"{Currency} {Amount:d}";

        public static bool operator ==(MoneySum moneySum1, IMoneySum moneySum2) => moneySum1.Equals(moneySum2);

        public static bool operator !=(MoneySum moneySum1, IMoneySum moneySum2) => !(moneySum1 == moneySum2);

        public override int GetHashCode() => (Currency.GetKey().ToString() + Amount).GetHashCode();

        public override bool Equals(object obj)
        {
            return obj is IMoneySum moneySum
                && moneySum?.Currency?.GetKey() == Currency?.GetKey()
                && moneySum?.Amount == Amount;
        }
    }
}