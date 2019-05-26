using Domain.Orders.Contracts.Events;
using MediatR;

namespace Domain.Payments.EventHandlers
{
    public class OnPaymentRequested : NotificationHandler<OrderPaymentRequested>
    {
        private readonly IPaymentRepository _paymentRepository;
        private readonly IMediator mediator;

        public OnPaymentRequested(IPaymentRepository paymentRepository, IMediator mediator)
        {
            _paymentRepository = paymentRepository;
            this.mediator = mediator;
        }

        protected override void Handle(OrderPaymentRequested notification)
        {
            var payment = Payment.Create(notification.OrderId, notification.AmountToPay);
            payment.Start(mediator);
            _paymentRepository.SaveAndCommit(payment);
        }
    }
}