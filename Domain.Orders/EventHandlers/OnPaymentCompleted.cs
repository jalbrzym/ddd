using System.Threading;
using System.Threading.Tasks;
using Domain.Payments.Contracts.Events;
using MediatR;

namespace Domain.Orders.EventHandlers
{
    public class OnPaymentCompleted : INotificationHandler<PaymentCompleted>
    {
        private IOrderRepository _orderRepository;

        public OnPaymentCompleted(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async Task Handle(PaymentCompleted notification, CancellationToken cancellationToken)
        {
            var order = _orderRepository.Get(notification.OrderId);
            order.SuccessfullyPaid();
            await _orderRepository.SaveAndCommit(order);
        }
    }
}