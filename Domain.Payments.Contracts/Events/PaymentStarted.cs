using Domain.Orders.Contracts;
using MediatR;

namespace Domain.Payments.Contracts.Events
{
    public class PaymentStarted : INotification
    {
        public PaymentStarted(PaymentId paymentId, OrderId orderId)
        {
            PaymentId = paymentId;
            OrderId = orderId;
        }

        public PaymentId PaymentId { get; private set; }
        public OrderId OrderId { get; private set; }
    }
}