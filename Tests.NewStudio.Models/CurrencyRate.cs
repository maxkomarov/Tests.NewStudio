using System;
using System.Text;
using Tests.NewStudio.Interfaces;

namespace Tests.NewStudio.Models
{
    public class CurrencyRate : ICurrencyRate
    {
        public string From { get; set; }
        public string To { get; set; }
        public decimal Rate { get; set; }

        public CurrencyRate() { }

        public CurrencyRate(string from, string to, decimal rate)
        {
            From = from;
            To = to;
            Rate = rate;            
        }

        public virtual string BuildKey()
        {
            return $"{From}{To}";
        }
    }
}
