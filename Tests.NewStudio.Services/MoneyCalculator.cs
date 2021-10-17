using Tests.NewStudio.Interfaces;
using Tests.NewStudio.Models;

namespace Tests.NewStudio.Services
{
    public class MoneyCalculator : IMoneyCalc
    {
        private readonly ICurrencyRateStorage _Storage;
        public MoneyCalculator() { }

        public MoneyCalculator(ICurrencyRateStorage storage) 
        {
            _Storage = storage;
        }

        public IMoneySum Add(IMoneySum firstSum, IMoneySum secondSum, ICurrency targetCurrency)
        {
            if (_Storage == null)
                throw new CurrencyRateStorageNotPresentException();

            ICurrencyRate firstRate = new CurrencyRate(firstSum.Currency, targetCurrency, 0);
            ICurrencyRate secondRate = new CurrencyRate(secondSum.Currency, targetCurrency, 0);

            if (_Storage.Find(firstRate) is decimal rate1 && rate1  > 0 
                && _Storage.Find(secondRate) is decimal rate2 && rate2 > 0)
                return new MoneySum(targetCurrency, firstSum.Amount * rate1 + secondSum.Amount * rate2);

            throw new CurrencyRateNotFoundException();
        }
    }
}
