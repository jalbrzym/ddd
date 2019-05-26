using System.Threading;
using System.Threading.Tasks;
using Domain.Orders.Contracts.Events;
using MediatR;

namespace Domain.Customers.EventHandlers
{
    public class OnOrderCreated : INotificationHandler<OrderCreated>

    {
        public Task Handle(OrderCreated notification, CancellationToken cancellationToken)
        {
            //Add OrderId to collection inside Customer object
            return Task.CompletedTask;
        }
    }
}