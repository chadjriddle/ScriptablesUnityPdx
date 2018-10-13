using UnityEngine;
using UnityEngine.Events;

namespace Scriptables.GameEvents
{
    public abstract class GenericGameEventListener<T, TE, UE> :
        MonoBehaviour, IHasEventRaised<T> 
        where TE : GenericGameEvent<T> where UE : UnityEvent<T>
    {
        [Tooltip("Event to register with.")]
        public TE Event;

        [Tooltip("Response to invoke when Event is raised.")]
        public UE Response;

        private void OnEnable()
        {
            Event.RegisterListener(this);
        }

        private void OnDisable()
        {
            Event.UnregisterListener(this);
        }

        public void OnEventRaised(T value)
        {
            Response.Invoke(value);
        }
    }
}