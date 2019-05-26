namespace Domain.Customers.Contracts
{
    public class CustomerId
    {
        public CustomerId(long id)
        {
            Id = id;
        }

        public long Id { get; private set; }
    }
}