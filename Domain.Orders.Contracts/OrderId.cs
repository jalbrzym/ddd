namespace Domain.Orders.Contracts
{
    public class OrderId
    {
        public OrderId(long id)
        {
            Id = id;
        }

        public long Id { get; private set; }

        public static OrderId Generate()
        {
            return new OrderId(-1);
        }
    }
}