using Domain.Abstractions;
using Domain.Orders.Contracts;
using Domain.Payments.Contracts;
using Domain.Payments.Contracts.Events;
using Domain.ValueTypes;

namespace Domain.Payments
{
    public class Payment : Entity, IAggregateRoot
    {
        private Payment(PaymentId id, OrderId orderId, Money amountToPay)
        {
            Id = id;
            OrderId = orderId;
            AmountToPay = amountToPay;
        }

        public PaymentId Id { get; private set; }
        public OrderId OrderId { get; private set; }
        public Money AmountToPay { get; private set; }

        public static Payment Create(OrderId orderId, Money amountToPay)
        {
            return new Payment(PaymentId.Generate(), orderId, amountToPay);
        }

        public void Start()
        {
            //TODO: Change status etc
            //TODO: Publish should be executed after commiting aggregate to db..
            RaiseEvent(new PaymentStarted(Id, OrderId));
        }

        public void Completed()
        {
            RaiseEvent(new PaymentCompleted(Id, OrderId));
        }
    }
}