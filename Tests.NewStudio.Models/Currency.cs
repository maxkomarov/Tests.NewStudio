using Tests.NewStudio.Interfaces;

namespace Tests.NewStudio.Models
{
    public class Currency : ICurrency
    {
        public string CharCodeISO4217 { get; set; }

        public int NumCodeISO4217 { get; set; }

        public object GetKey() => CharCodeISO4217;

        public Currency(string charCodeISO4217)
        {
            if (charCodeISO4217?.Length != 3)
                throw new WrongISO4217CharCodeException();

            CharCodeISO4217 = charCodeISO4217;
        }

        public override string ToString() => $"{GetKey()}";

        public static bool operator ==(Currency currency1, ICurrency currency2) => currency1.Equals(currency2);

        public static bool operator !=(Currency currency1, ICurrency currency2) => !(currency1 == currency2);

        public override int GetHashCode() => GetKey().GetHashCode();

        public override bool Equals(object obj)
        {
            return
                obj is ICurrency currency
                && currency.GetKey() == GetKey();
        }
    }
}
