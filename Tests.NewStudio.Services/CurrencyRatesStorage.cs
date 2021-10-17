using System;
using System.Collections.Generic;
using Tests.NewStudio.Interfaces;

namespace Tests.NewStudio.Services
{
    public class CurrencyRatesStorage : ICurrencyRateStorage
    {
        private readonly SortedDictionary<string, decimal> _Storage = new();

        public void Add(ICurrencyRate currencyRate)
        {
            string key = currencyRate.BuildKey();
            _Storage.Add(key, currencyRate.Rate);
        }

        public bool Contains(ICurrencyRate currencyRate)
        {
            string key = currencyRate.BuildKey();
            return _Storage.ContainsKey(key);
        }    

        public void Delete(ICurrencyRate currencyRate)
        {
            string key = currencyRate.BuildKey();
            _Storage.Remove(key);
        }

        public decimal Find(ICurrencyRate rateParameters)
        {
            string key = rateParameters.BuildKey();
            return _Storage.GetValueOrDefault(key, 0); 
        }
    }
}
