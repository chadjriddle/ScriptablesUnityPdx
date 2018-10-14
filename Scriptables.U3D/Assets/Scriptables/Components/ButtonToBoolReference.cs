using Scriptables.References;
using UnityEngine;

namespace Scriptables.Components
{
    public class ButtonToBoolReference : MonoBehaviour {

        [SerializeField] private string _inputButton;
        [SerializeField] private BoolReference _value;

        // Update is called once per frame
        void Update () {
            _value.SetValue(Input.GetButton(_inputButton));
        }
    }
}
