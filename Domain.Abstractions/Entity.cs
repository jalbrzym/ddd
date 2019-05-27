using System.Collections.Generic;
using MediatR;

namespace Domain.Abstractions
{
    public abstract class Entity
    {
        private readonly List<INotification> _domainEvents = new List<INotification>();

        protected void RaiseEvent(INotification domainEvent) => _domainEvents.Add(domainEvent);

        public void DispatchDomainEvents(IDomainEventDispatcher dispatcher)
        {
            foreach (var domainEvent in _domainEvents)
            {
                dispatcher.Dispatch(domainEvent);
            }

            _domainEvents.Clear();
        }
    }
}
