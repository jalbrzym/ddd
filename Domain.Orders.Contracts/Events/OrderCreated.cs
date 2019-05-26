using Domain.Customers.Contracts;
using MediatR;

namespace Domain.Orders.Contracts.Events
{
    public class OrderCreated : INotification
    {
        public OrderCreated(OrderId orderId, CustomerId customerId)
        {
            CustomerId = customerId;
            OrderId = orderId;
        }

        public CustomerId CustomerId { get; private set; }
        public OrderId OrderId { get; private set; }
    }
}