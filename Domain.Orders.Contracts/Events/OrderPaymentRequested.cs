using Domain.ValueTypes;
using MediatR;

namespace Domain.Orders.Contracts.Events
{
    public class OrderPaymentRequested : INotification
    {
        public OrderPaymentRequested(OrderId orderId, Money amountToPay)
        {
            OrderId = orderId;
            AmountToPay = amountToPay;
        }

        public OrderId OrderId { get; private set; }
        public Money AmountToPay { get; private set; }
    }
}