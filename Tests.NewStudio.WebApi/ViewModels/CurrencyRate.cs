using Tests.NewStudio.Interfaces;

namespace Tests.NewStudio.WebApi.ViewModels
{
    public class CurrencyRate
    {
        public string From { get; set; }
        public string To { get; set; }
        public string Rate { get; set; }

        public CurrencyRate(ICurrencyRate rate )
        {
            From = $"{rate.From}";
            To = $"{rate.To}";
            Rate = $"{rate.Rate:n}";
        }
    }
}
