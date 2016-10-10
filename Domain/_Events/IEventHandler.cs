using System;

namespace Domain.Events
{
    public interface IEventHandler<in TEvent>
        where TEvent : IDomainEvent
    {
        void HandleEvent(TEvent eventInstance);
    }
}
