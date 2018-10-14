using Scriptables.References;
using UnityEngine;

namespace Scriptables.Components
{
    public class SetColorFromBoolReference : MonoBehaviour
    {

        [SerializeField] private Renderer _renderer;
        [SerializeField] private BoolReference _value;
        [SerializeField] private ColorReference _trueColor;
        [SerializeField] private ColorReference _falseColor;

        // Use this for initialization
        void Awake ()
        {
            _value.ValueChanged += UpdateColor;
            _trueColor.ValueChanged += UpdateColor;
            _falseColor.ValueChanged += UpdateColor;
            UpdateColor();
        }

        private void UpdateColor()
        {
            if (_renderer)
            {
                _renderer.material.color = _value ? _trueColor : _falseColor;
            }
        }

        void Reset()
        {
            if (_renderer == null)
            {
                _renderer = GetComponent<Renderer>();
            }
        }
    }
}
