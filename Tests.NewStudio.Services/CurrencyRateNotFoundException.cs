using System;

namespace Tests.NewStudio.Services
{
    [Serializable]
    public class CurrencyRateNotFoundException : Exception
    {
        public CurrencyRateNotFoundException()
        {
        }

        public CurrencyRateNotFoundException(string message) : base(message)
        {
        }        
    }
}