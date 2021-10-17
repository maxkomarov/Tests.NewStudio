using System;
using Tests.NewStudio.Interfaces;
using Tests.NewStudio.Models;
using Tests.NewStudio.Services;
using Xunit;

namespace Tests.NewStudio.Tests
{
    public class Test
    {
        /// <summary>
        /// Тест сравнения валют на равенство
        /// </summary>
        [Fact]
        public void CurrenciesEquals()
        {
            Currency currency1 = new Currency("USD");
            Currency currency2 = new Currency("USD");

            Assert.True(currency1 == currency2);
        }

        /// <summary>
        /// Тест сравнения валют на неравенство
        /// </summary>
        [Fact]
        public void CurrenciesNotEquals()
        {
            ICurrency currency1 = new Currency("USD");
            ICurrency currency2 = new Currency("EUR");

            Assert.True(currency1 != currency2);
        }

        /// <summary>
        /// Тест сравнения денежных сумм на равенство 
        /// </summary>
        [Fact]
        public void MoneySumEquals()
        {
            MoneySum moneySum1 = new MoneySum(new Currency("USD"), 10);
            MoneySum moneySum2 = new MoneySum(new Currency("USD"), 10);
            Assert.True(moneySum1 == moneySum2);
        }

        /// <summary>
        /// Тест сравнения денежных сумм на неравенство 1
        /// </summary>
        [Fact]
        public void MoneySumEquals2()
        {
            MoneySum moneySum1 = new MoneySum(new Currency("USD"), 10);
            MoneySum moneySum2 = new MoneySum(new Currency("USD"), 20);

            Assert.True(moneySum1 != moneySum2);
        }

        /// <summary>
        /// Тест сравнения денежных сумм на неравенство 2
        /// </summary>
        [Fact]
        public void MoneySumNotEquals()
        {
            MoneySum moneySum1 = new MoneySum(new Currency("USD"), 10);
            MoneySum moneySum2 = new MoneySum(new Currency("EUR"), 10);

            Assert.True(moneySum1 != moneySum2);
        }

        /// <summary>
        /// Тест добавления фейкового курса в хранилище
        /// </summary>
        [Fact]
        public void Add()
        {
            ICurrencyRateStorage storage = new CurrencyRatesStorage();
            ICurrencyRate rate = CreateFakeCurrencyRate1();
            storage.Add(rate);            
            Assert.True(true);
        }

        /// <summary>
        /// Тест добавления одинаковых фейковых курсов в хранилище
        /// </summary>
        [Fact]
        public void AddDuplicates()
        {
            try
            { 
                ICurrencyRateStorage storage = new CurrencyRatesStorage();
                ICurrencyRate rate1 = CreateFakeCurrencyRate1();
                ICurrencyRate rate2 = CreateFakeCurrencyRate1();
                storage.Add(rate1);
                storage.Add(rate2);
                Assert.True(false);
            }
            catch (ArgumentException)
            {
                Assert.True(true);
            }            
        }

        /// <summary>
        /// Тестируем наличие курса в хранилище
        /// </summary>
        [Fact]
        public void Contains()
        {
            ICurrencyRateStorage storage = new CurrencyRatesStorage();
            ICurrencyRate rate = CreateFakeCurrencyRate1();
            storage.Add(rate);
            bool result = storage.Contains(rate);
            Assert.True(result);
        }

        /// <summary>
        /// Тестируем отсутствие курса в хранилище
        /// </summary>
        [Fact]
        public void NotContains()
        {
            ICurrencyRateStorage storage = new CurrencyRatesStorage();
            ICurrencyRate rate = CreateFakeCurrencyRate1();
            storage.Add(rate);
            bool result = storage.Contains(CreateFakeCurrencyRate2());
            Assert.True(!result);
        }

        /// <summary>
        /// Тестируем удаеление курса из хранилища
        /// </summary>
        [Fact]
        public void Delete()
        {
            ICurrencyRateStorage storage = new CurrencyRatesStorage();
            ICurrencyRate rate = CreateFakeCurrencyRate1();
            storage.Delete(rate);
            Assert.True(true);
        }

        [Fact]
        public void Find()
        {
            ICurrencyRateStorage storage = new CurrencyRatesStorage();
            ICurrencyRate rate = CreateFakeCurrencyRate2();
            storage.Add(rate);

            ICurrency usdCurrency = new Currency("USD");
            ICurrency eurCurrency = new Currency("EUR");

            decimal result = storage.Find(new CurrencyRate(eurCurrency, usdCurrency, 0));
            Assert.True(result == 1.12m);
        }

        /// <summary>
        /// Тест сложения
        /// </summary>
        [Fact]
        public void Sum()
        {
            ICurrency usdCurrency = new Currency("USD");
            ICurrency eurCurrency = new Currency("EUR");
            ICurrency rurCurrency = new Currency("RUR");

            ICurrencyRateStorage storage = new CurrencyRatesStorage();
            storage.Add(new CurrencyRate(usdCurrency, rurCurrency, 70.0m));
            storage.Add(new CurrencyRate(eurCurrency, rurCurrency, 80.0m));

            storage.Add(CreateFakeCurrencyRate2());

            IMoneySum moneySum1 = new MoneySum(usdCurrency, 2);
            IMoneySum moneySum2 = new MoneySum(eurCurrency, 1);

            IMoneyCalc calc = new MoneyCalculator(storage);
            IMoneySum res = calc.Add(moneySum1, moneySum2, rurCurrency);

            Assert.True(res.Amount == 220 && res.Currency == rurCurrency);
        }

        /// <summary>
        /// Тест вычитания
        /// </summary>
        [Fact]
        public void SumWithNegative()
        {
            ICurrency usdCurrency = new Currency("USD");
            ICurrency eurCurrency = new Currency("EUR");
            ICurrency rurCurrency = new Currency("RUR");

            ICurrencyRateStorage storage = new CurrencyRatesStorage();
            storage.Add(new CurrencyRate(usdCurrency, rurCurrency, 70.0m));
            storage.Add(new CurrencyRate(eurCurrency, rurCurrency, 80.0m));

            storage.Add(CreateFakeCurrencyRate2());

            IMoneySum moneySum1 = new MoneySum(usdCurrency, 2);
            IMoneySum moneySum2 = new MoneySum(eurCurrency, -1);

            IMoneyCalc calc = new MoneyCalculator(storage);
            IMoneySum res = calc.Add(moneySum1, moneySum2, rurCurrency);

            Assert.True(res.Amount == 60 && res.Currency  == rurCurrency);
        }

        /// <summary>
        /// Тест сложения отсутствующих курсов
        /// </summary>
        [Fact]
        public void SumWithoutRates()
        {
            try
            {
                ICurrency usdCurrency = new Currency("USD");
                ICurrency eurCurrency = new Currency("EUR");
                ICurrency rurCurrency = new Currency("RUR");
                ICurrency chfCurrency = new Currency("CHF");

                ICurrencyRateStorage storage = new CurrencyRatesStorage();
                storage.Add(new CurrencyRate(usdCurrency, rurCurrency, 70.0m));
                storage.Add(new CurrencyRate(eurCurrency, rurCurrency, 80.0m));

                storage.Add(CreateFakeCurrencyRate2());

                IMoneySum moneySum1 = new MoneySum(chfCurrency, 3);
                IMoneySum moneySum2 = new MoneySum(eurCurrency, 1);

                IMoneyCalc calc = new MoneyCalculator(storage);
                IMoneySum res = calc.Add(moneySum1, moneySum2, chfCurrency);

                Assert.True(false);
            }
            catch (CurrencyRateNotFoundException)
            {
                Assert.True(true, "CurrencyRateNotFoundException исключение выброшено корректно");
            }                
        }


        #region Fake rate creators

        private ICurrencyRate CreateFakeCurrencyRate1()
        {
            return new CurrencyRate()
            {
                From = new Currency("RUR"),
                To = new Currency("USD"),
                Rate = 72.32m
            };
        }

        private ICurrencyRate CreateFakeCurrencyRate2()
        {
            return new CurrencyRate()
            {
                From = new Currency("EUR"),
                To = new Currency("USD"),
                Rate = 1.12m
            };
        }

        #endregion
    }
}
