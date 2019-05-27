using MediatR;

namespace Domain.Abstractions
{
    public interface IDomainEventDispatcher
    {
        void Dispatch(INotification domainEvent);
    }
}