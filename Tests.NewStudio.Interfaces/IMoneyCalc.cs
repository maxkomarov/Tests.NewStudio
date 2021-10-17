using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests.NewStudio.Interfaces
{
    /// <summary>
    /// Контракт арифмометра сумм валют
    /// </summary>
    public interface IMoneyCalc
    {
        /// <summary>
        /// Сложение сумм валют
        /// Если вторая валюта с минусовым знаком - вычитание.
        /// Если первая валюта меньше второй - исключение.
        /// </summary>
        /// <param name="firstSum">Первое слагаемое или уменьшаемое</param>
        /// <param name="secondSum">Второе слагаемое или вычитаемое</param>
        /// <param name="targetCurrency">Валюта результата операции. 
        /// Если не указано - приводится к валюте параметра firstSum</param>
        /// <returns>Сумма в валюте</returns>
        IMoneySum Add(IMoneySum firstSum, IMoneySum secondSum, ICurrency targetCurrency = null);
    }
}
