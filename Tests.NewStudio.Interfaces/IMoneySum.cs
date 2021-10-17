using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests.NewStudio.Interfaces
{
    /// <summary>
    /// Контракт денежной суммы в некоей валюте
    /// </summary>
    public interface IMoneySum
    {
        /// <summary>
        /// Сумма
        /// </summary>
        decimal Value { get; set; }
        /// <summary>
        /// Валюта суммы
        /// </summary>
        ICurrency Currency { get; set; }
    }
}
