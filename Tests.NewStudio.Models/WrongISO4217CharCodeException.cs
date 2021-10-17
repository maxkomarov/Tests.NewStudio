using System;
using System.Runtime.Serialization;

namespace Tests.NewStudio.Models
{
    [Serializable]
    internal class WrongISO4217CharCodeException : Exception
    {
        public WrongISO4217CharCodeException()
        {
        }

        public WrongISO4217CharCodeException(string message) : base(message)
        {
        }

        public WrongISO4217CharCodeException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected WrongISO4217CharCodeException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}