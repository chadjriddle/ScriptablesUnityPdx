using Scriptables.References;
using UnityEngine;

namespace Scriptables.Components
{
    public class ToggleBoolReference : MonoBehaviour
    {
        [SerializeField]
        private BoolReference _value;

        public void Toggle()
        {
            _value?.SetValue(!_value.Value);
        }
    }
}
