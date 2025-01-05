using System;
using System.Collections.Generic;

namespace Game.Application.Events
{
    public class EventBus
    {
        private readonly Dictionary<Type, Action<object>> _eventHandlers = new();

        public void Subscribe<T>(Action<T> listener) where T : class
        {
            var type = typeof(T);
            if (!_eventHandlers.ContainsKey(type))
            {
                _eventHandlers[type] = null;
            }

            _eventHandlers[type] += (e) => listener(e as T);
        }

        public void Unsubscribe<T>(Action<T> listener) where T : class
        {
            var type = typeof(T);
            if (_eventHandlers.ContainsKey(type))
            {
                _eventHandlers[type] -= (e) => listener(e as T);
                if (_eventHandlers[type] == null)
                {
                    _eventHandlers.Remove(type);
                }
            }
        }

        public void Publish<T>(T eventArgs) where T : class
        {
            var type = typeof(T);
            if (_eventHandlers.ContainsKey(type))
            {
                _eventHandlers[type]?.Invoke(eventArgs);
            }
        }

        public void ClearAllSubscriptions()
        {
            _eventHandlers.Clear();
        }
    }
}