using System;

namespace Tests.NewStudio.Interfaces
{
    /// <summary>
    /// Контракт хранилища курсов
    /// </summary>
    public interface ICurrencyRateStorage
    {
        /// <summary>
        /// Добавить курс
        /// </summary>
        /// <param name="currencyRate"></param>
        void Add(ICurrencyRate currencyRate);
        /// <summary>
        /// Найти курс
        /// </summary>
        ICurrencyRate Get(
            ICurrency from,
            ICurrency to,
            DateTime dated,
            decimal sum,
            ICurrencyRateProvider currencyRateProvider);
    }
}
