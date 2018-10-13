using UnityEngine;
using UnityEngine.Events;

namespace Scriptables.GameEvents
{
    public class GameEventListener : MonoBehaviour
    {
        [Tooltip("Event to register with.")]
        public GameEvent Event;

        [Tooltip("Response to invoke when Event is raised.")]
        public UnityEvent Response;

        private void OnEnable()
        {
            Event.RegisterListener(OnEventRaised);
        }

        private void OnDisable()
        {
            Event.UnregisterListener(OnEventRaised);
        }

        public void OnEventRaised()
        {
            Response.Invoke();
        }

        public string DebugInfo()
        {
            return gameObject.name;
        }
    }
}