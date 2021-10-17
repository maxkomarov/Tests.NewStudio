using Tests.NewStudio.Interfaces;

namespace Tests.NewStudio.Models
{
    public class MoneySum : IMoneySum
    {
        public decimal Value { get; set; }
        public string Currency { get; set; }

        public MoneySum() { }

        public MoneySum(string currency, decimal value)
        {
            Value = value;
            Currency = currency;
        }

        public override string ToString() =>  $"{Currency} {Value:d}";

        public static bool operator ==(MoneySum moneySum1, IMoneySum moneySum2) => moneySum1.Equals(moneySum2);

        public static bool operator !=(MoneySum moneySum1, IMoneySum moneySum2) => !(moneySum1 == moneySum2);

        public override int GetHashCode() => (Currency + Value).GetHashCode();

        public override bool Equals(object obj)
        {
            return obj is IMoneySum moneySum
                && moneySum ?.Currency == Currency
                && moneySum?.Value == Value;
        }
    }
}