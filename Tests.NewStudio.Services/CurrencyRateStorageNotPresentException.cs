using System;
using System.Runtime.Serialization;

namespace Tests.NewStudio.Services
{
    [Serializable]
    public class CurrencyRateStorageNotPresentException : Exception
    {
        public CurrencyRateStorageNotPresentException()
        {
        }

        public CurrencyRateStorageNotPresentException(string message) : base(message)
        {
        }        
    }
}