using Scriptables.References;
using UnityEngine;
using UnityEngine.UI;

namespace Scriptables.Components
{
    public class SetImageColorFromColorReference : MonoBehaviour
    {
        [SerializeField] private ColorReference _color;
        [SerializeField] private Image _image;

        // Use this for initialization
        void Start ()
        {
            UpdateColor();
            _color.ValueChanged += UpdateColor;
        }

        private void UpdateColor()
        {
            if (_image != null && _color != null)
            {
                _image.color = _color;
            }
        }

        void Reset()
        {
            if (_image == null)
            {
                _image = GetComponent<Image>();
            }
        }

        void OnValidate()
        {
            UpdateColor();
        }

        void OnDestroy()
        {
            _color.ValueChanged -= UpdateColor;
        }
    }
}
