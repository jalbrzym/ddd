using Domain.Orders.Contracts.Events;
using MediatR;

namespace Domain.Payments.EventHandlers
{
    public class OnPaymentRequested : NotificationHandler<OrderPaymentRequested>
    {
        private readonly IPaymentRepository _paymentRepository;

        public OnPaymentRequested(IPaymentRepository paymentRepository)
        {
            _paymentRepository = paymentRepository;
        }

        protected override void Handle(OrderPaymentRequested notification)
        {
            var payment = Payment.Create(notification.OrderId, notification.AmountToPay);
            payment.Start();
            _paymentRepository.SaveAndCommit(payment);
        }
    }
}