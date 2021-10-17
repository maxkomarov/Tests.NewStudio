using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests.NewStudio.Interfaces
{
    interface ICurrencyConversionResult
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
        /// Дата-время фиксации отношения
        /// </summary>
        DateTime Dated { get; set; }
        /// <summary>
        /// Провайдер курса
        /// </summary>
        ICurrencyRateProvider CurrencyRateProvider { get; set; }
        /// <summary>
        /// Количество исходной валюты (From)
        /// </summary>
        decimal SourceValue { get; set; }
        /// <summary>
        /// Количество целевой валюты (To)
        /// </summary>
        decimal ConvertedValue { get; set; }
        /// <summary>
        /// Ставка конвертации
        /// </summary>
        decimal UsedRate { get; set; }
    }
}
