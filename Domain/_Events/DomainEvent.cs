using System;
using System.Collections.Generic;

namespace Domain.Events
{
    public class DomainEvent<TEvent>
        where TEvent : IDomainEvent
    {
        // Collection is een Singleton Pattern
        [ThreadStatic]
        private static List<Action<TEvent>> _actions;

        private DomainEvent() { }

        public static void Register(Action<TEvent> callback)
        {
            if (_actions == null)
                _actions = new List<Action<TEvent>>();

            _actions.Add(callback);
        }

        public static void ClearCallbacks()
        {
            _actions = null;
        }

        public static void Raise(TEvent eventInstance)

        {
            if (_actions == null) return;

            foreach (var action in _actions)
            {
                action.Invoke(eventInstance);
            }
        }
    }
}
