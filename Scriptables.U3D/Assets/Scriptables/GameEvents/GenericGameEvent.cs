using System.Collections.Generic;
using UnityEngine;

namespace Scriptables.GameEvents
{
    public class GenericGameEvent<T> : ScriptableObject
    {
        /// <summary>
        /// The list of listeners that this event will notify if it is raised.
        /// </summary>
        private readonly List<IHasEventRaised<T>> _eventListeners =
            new List<IHasEventRaised<T>>();

        public void Raise(T value)
        {
            for (int i = _eventListeners.Count - 1; i >= 0; i--)
                _eventListeners[i].OnEventRaised(value);
        }

        public void RegisterListener(IHasEventRaised<T> listener)
        {
            if (!_eventListeners.Contains(listener))
                _eventListeners.Add(listener);
        }

        public void UnregisterListener(IHasEventRaised<T> listener)
        {
            if (_eventListeners.Contains(listener))
                _eventListeners.Remove(listener);
        }
    }
}