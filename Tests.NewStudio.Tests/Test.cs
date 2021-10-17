using Tests.NewStudio.Interfaces;
using Tests.NewStudio.Models;
using Tests.NewStudio.Services;
using Xunit;

namespace Tests.NewStudio.Tests
{
    public class Test
    {
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

            decimal result = storage.Find(new CurrencyRate("EUR", "USD", 0));
            Assert.True(result == 1.12m);
        }

        /// <summary>
        /// Тест сложения
        /// </summary>
        [Fact]
        public void Sum()
        {
            ICurrencyRateStorage storage = new CurrencyRatesStorage();
            storage.Add(new CurrencyRate("USD", "RUR", 70.0m));
            storage.Add(new CurrencyRate("EUR", "RUR", 80.0m));

            storage.Add(CreateFakeCurrencyRate2());

            IMoneySum moneySum1 = new MoneySum("USD", 2);
            IMoneySum moneySum2 = new MoneySum( "EUR", 1);

            IMoneyCalc calc = new MoneyCalculator(storage);
            IMoneySum res = calc.Add(moneySum1, moneySum2, "RUR");

            Assert.True(res.Value == 220 && res.Currency == "RUR");
        }

        /// <summary>
        /// Тест вычитания
        /// </summary>
        [Fact]
        public void SumWithNegative()
        {
            ICurrencyRateStorage storage = new CurrencyRatesStorage();
            storage.Add(new CurrencyRate("USD", "RUR", 70.0m));
            storage.Add(new CurrencyRate("EUR", "RUR", 80.0m));

            storage.Add(CreateFakeCurrencyRate2());

            IMoneySum moneySum1 = new MoneySum("USD", 2);
            IMoneySum moneySum2 = new MoneySum("EUR", -1);

            IMoneyCalc calc = new MoneyCalculator(storage);
            IMoneySum res = calc.Add(moneySum1, moneySum2, "RUR");

            Assert.True(res.Value == 60 && res.Currency == "RUR");
        }

        /// <summary>
        /// Тест сложения отсутствующих курсов
        /// </summary>
        [Fact]
        public void SumWithoutRates()
        {
            try
            {
                ICurrencyRateStorage storage = new CurrencyRatesStorage();
                storage.Add(new CurrencyRate("USD", "RUR", 70.0m));
                storage.Add(new CurrencyRate("EUR", "RUR", 80.0m));

                storage.Add(CreateFakeCurrencyRate2());

                IMoneySum moneySum1 = new MoneySum("CHF", 3);
                IMoneySum moneySum2 = new MoneySum("EUR", 1);

                IMoneyCalc calc = new MoneyCalculator(storage);
                IMoneySum res = calc.Add(moneySum1, moneySum2, "CHF");

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
                From = "RUR",
                To = "USD",
                Rate = 72.32m
            };
        }

        private ICurrencyRate CreateFakeCurrencyRate2()
        {
            return new CurrencyRate()
            {
                From = "EUR",
                To = "USD",
                Rate = 1.12m
            };
        }

        #endregion
    }
}
