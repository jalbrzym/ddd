namespace Domain.ValueTypes
{
    public class Currency
    {
        public Currency(string isoCode)
        {
            ISOCode = isoCode;
        }

        public string ISOCode { get; private set; }
    }
}