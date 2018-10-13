using UnityEngine;
using UnityEngine.UI;

namespace Scriptables.Components
{
    public class SetTextFromObject : MonoBehaviour
    {

        [SerializeField] private Object _value;
        [SerializeField] private Text _text;

        private string _lastValue = string.Empty;

        // Use this for initialization
        void Start () {
		
        }
	
        // Update is called once per frame
        void Update () {
            if (_text != null && _value != null && _lastValue != _value.ToString())
            {
                _lastValue = _value.ToString();
                _text.text = _lastValue;
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
