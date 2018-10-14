using UnityEngine;
using UnityEngine.Events;

namespace Scriptables.Components
{
    public class EnableDisableTrigger : MonoBehaviour {

        public UnityEvent Enabled = new UnityEvent();
        public UnityEvent Disabled = new UnityEvent();

        private void OnEnable()
        {
            Enabled.Invoke();
        }

        public void OnDisable()
        {
            Disabled.Invoke();
        }
    }
}
