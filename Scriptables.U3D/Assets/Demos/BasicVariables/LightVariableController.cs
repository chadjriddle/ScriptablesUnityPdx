using Scriptables.References;
using Scriptables.Variables;
using UnityEngine;

namespace Demos.BasicVariables
{
    [RequireComponent(typeof(Renderer))]
    public class LightVariableController : MonoBehaviour
    {
        [SerializeField] private BoolReference _isOn;
        [SerializeField] private MaterialReference _offMaterial;
        [SerializeField] private MaterialReference _onMaterial;

        private Renderer _renderer;

        // Use this for initialization
        void Start ()
        {
            _renderer = GetComponent<Renderer>();
            UpdateMaterial();
            _isOn.ValueChanged += UpdateMaterial;
        }

        private void UpdateMaterial()
        {
            _renderer.material = _isOn ? _onMaterial : _offMaterial;
        }
    }
}
