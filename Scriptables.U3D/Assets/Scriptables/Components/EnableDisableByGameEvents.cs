using Scriptables.GameEvents;
using UnityEngine;

namespace Scriptables.Components
{
    public class EnableDisableByGameEvents : MonoBehaviour
    {
        public Behaviour Target;
        public GameEvent EnableEvent;
        public GameEvent DisableEvent;

        public bool EnabledOnStart = true;

        private void Start()
        {
            if (Target != null)
            {
                Target.enabled = EnabledOnStart;
            }
        }

        // Use this for initialization
        private void OnEnable()
        {
            if (EnableEvent != null)
            {
                EnableEvent.RegisterListener(EnableEventHandler);
            }

            if (DisableEvent != null)
            {
                DisableEvent.RegisterListener(DisableEventHandler);
            }
        }

        private void OnDisable()
        {
            if (EnableEvent != null)
            {
                EnableEvent.UnregisterListener(EnableEventHandler);
            }

            if (DisableEvent != null)
            {
                DisableEvent.UnregisterListener(DisableEventHandler);
            }
        }

        private void DisableEventHandler()
        {
            if (Target != null)
            {
                Target.enabled = false;
            }
        }

        private void EnableEventHandler()
        {
            if (Target != null)
            {
                Target.enabled = true;
            }
        }
    }
}
