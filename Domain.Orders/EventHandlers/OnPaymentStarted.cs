using System.Threading;
using System.Threading.Tasks;
using Domain.Payments.Contracts.Events;
using MediatR;

namespace Domain.Orders.EventHandlers
{
    public class OnPaymentStarted : INotificationHandler<PaymentStarted>
    {
        private readonly IOrderRepository _orderRepository;

        public OnPaymentStarted(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async Task Handle(PaymentStarted notification, CancellationToken cancellationToken)
        {
            var order = _orderRepository.Get(notification.OrderId);
            order.PaymentStarted();
            await _orderRepository.SaveAndCommit(order);
        }
    }
}