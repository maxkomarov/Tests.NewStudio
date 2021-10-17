using System;
using Tests.NewStudio.Interfaces;

namespace Tests.NewStudio.Implementation
{
    public class MoneyCalc : IMoneyCalc
    {
        public IMoneySum Add(IMoneySum firstSum, IMoneySum secondSum, ICurrency targetCurrency = null)
        {
            throw new NotImplementedException();
        }
    }
}
