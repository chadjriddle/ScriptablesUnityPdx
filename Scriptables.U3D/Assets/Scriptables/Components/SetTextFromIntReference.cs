using Scriptables.References;
using UnityEngine;
using UnityEngine.UI;

namespace Scriptables.Components
{
    public class SetTextFromIntReference : MonoBehaviour
    {
        [SerializeField] private IntReference _value;
        [SerializeField] private Text _text;
        [SerializeField] private string _format = "{0}";

        private int _lastValue = int.MinValue;

        // Update is called once per frame
        void Update ()
        {
            if (_text != null && _value != null && _lastValue != _value.Value)
            {
                _lastValue = _value.Value;
                _text.text = string.Format(_format, _lastValue);
            }
        }

        void Reset()
        {
            if (_text == null)
            {
                _text = GetComponent<Text>();
            }
        }
    }
}
