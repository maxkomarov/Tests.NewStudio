using System;

namespace Tests.NewStudio.Interfaces
{
    /// <summary>
    /// Контракт отношения между валютами
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
        /// Соотношение валют
        /// </summary>
        decimal Rate { get; set; }        
        /// <summary>
        /// Метод построителя ключа
        /// </summary>
        /// <returns></returns>
        string BuildKey();
    }
}
