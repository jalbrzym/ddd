using Domain.Orders.Contracts;
using Domain.Payments.Contracts;
using Domain.Payments.Contracts.Events;
using Domain.ValueTypes;
using MediatR;

namespace Domain.Payments
{
    public class Payment
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

        public void Start(IMediator mediator)
        {
            //TODO: Change status etc
            //TODO: Publish should be executed after commiting aggregate to db..
            mediator.Publish(new PaymentStarted(Id, OrderId));
        }

        public void Completed(IMediator mediator)
        {
            mediator.Publish(new PaymentCompleted(Id, OrderId));
        }
    }
}