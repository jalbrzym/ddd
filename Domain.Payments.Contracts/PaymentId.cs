namespace Domain.Payments.Contracts
{
    public class PaymentId
    {
        private PaymentId() { }

        public PaymentId(long id)
        {
            Id = id;
        }

        public long Id { get; private set; }

        public static PaymentId Generate()
        {
            return new PaymentId(-1);
        }
    }
}