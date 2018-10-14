using Scriptables.References;
using UnityEngine;

namespace Scriptables.Components
{
    public class AxisToFloatReference : MonoBehaviour
    {
        [SerializeField] private string _inputAxis;
        [SerializeField] private FloatReference _value;
        [SerializeField] private FloatReference _multiplier = new FloatReference(1);
    
        void Update ()
        {
            _value.SetValue(Input.GetAxis(_inputAxis) * _multiplier?.Value ?? 1);
        }
    }
}
