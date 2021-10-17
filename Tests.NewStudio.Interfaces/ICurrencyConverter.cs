using System;

namespace Tests.NewStudio.Interfaces
{
    /// <summary>
    /// Контракт конвертера валют
    /// </summary>
    interface ICurrencyConverter
    {
        /// <summary>
        /// Конвертировать сумму
        /// </summary>
        /// <param name="from">Из валюты</param>
        /// <param name="to">В валюту</param>
        /// <param name="onDate">На дату/время</param>
        /// <param name="currencyRateProvider">По курсу конкретного параметра или лучший курс, если не указано</param>
        /// <param name="quantity">Сумма операции в исходной валюте</param>
        /// <returns>Результат конверсии с параметрами</returns>
        ICurrencyConversionResult Convert(
            ICurrency from, 
            ICurrency to, 
            DateTime onDate,             
            ICurrencyRateProvider currencyRateProvider,
            int quantity = 1);

        /// <summary>
        /// Получить обменный курс
        /// </summary>
        /// <param name="from">Из валюты</param>
        /// <param name="to">В валюту</param>
        /// <param name="onDate">На дату/время</param>
        /// <param name="currencyRateProvider">По курсу конкретного параметра или лучший курс, если не указано</param>
        /// <returns>Результат конверсии с параметрами</returns>
        ICurrencyConversionResult GetRate(ICurrency from,
            ICurrency to,
            DateTime onDate,
            ICurrencyRateProvider currencyRateProvider);
    }
}
