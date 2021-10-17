using System;

namespace Tests.NewStudio.Interfaces
{
    /// <summary>
    /// Контракт отношения между валютами Z = X/Y
    /// </summary>
    public interface ICurrencyRate
    {
        /// <summary>
        /// Валюта-делимое (X)
        /// </summary>
        ICurrency From { get; set; }
        /// <summary>
        /// Валюта - делитель (Y)
        /// </summary>
        ICurrency To { get; set; }
        /// <summary>
        /// Количественный лимит
        /// </summary>
        decimal Limit { get; set; }
        /// <summary>
        /// Соотношение для покупки (Z)
        /// </summary>
        decimal BuyRate { get; set; }
        /// <summary>
        /// Соотношение для продажи (Z)
        /// </summary>
        decimal SellRate { get; set; }
        /// <summary>
        /// Дата-время фиксации отношения
        /// </summary>
        DateTime Dated { get; set; }
        /// <summary>
        /// Провайдер курса
        /// </summary>
        ICurrencyRateProvider CurrencyRateProvider { get; set; }
    }
}
