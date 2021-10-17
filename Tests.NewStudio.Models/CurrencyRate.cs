using Tests.NewStudio.Interfaces;

namespace Tests.NewStudio.Models
{
    public class CurrencyRate : ICurrencyRate
    {
        public ICurrency From { get; set; }
        public ICurrency To { get; set; }
        public decimal Rate { get; set; }

        public CurrencyRate() { }

        public CurrencyRate(ICurrency from, ICurrency to, decimal rate)
        {
            From = from;
            To = to;
            Rate = rate;            
        }

        public virtual string BuildKey() => $"{From.GetKey()}{To.GetKey()}";

        public override string ToString() => $"{From}/{To}={ Rate:d}";
    }
}
