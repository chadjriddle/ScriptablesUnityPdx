using System;
using System.Collections.Generic;
using UnityEngine;

namespace Scriptables.GameEvents
{ 
    [CreateAssetMenu(menuName = "Events/Game Event")]
    public class GameEvent : ScriptableObject
    {
        private readonly List<Action> _eventListeners = new List<Action>();

        public void Raise()
        {
            for (var i = _eventListeners.Count - 1; i >= 0; i--)
            {
                _eventListeners[i]();
            }
        }

        public void RegisterListener(Action listener)
        {
            if (!_eventListeners.Contains(listener))
            {
                _eventListeners.Add(listener);
            }
        }

        public void UnregisterListener(Action listener)
        {
            if (_eventListeners.Contains(listener))
            {
                _eventListeners.Remove(listener);
            }
        }
    }
}