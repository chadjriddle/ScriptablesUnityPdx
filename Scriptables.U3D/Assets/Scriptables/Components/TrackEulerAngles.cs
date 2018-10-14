using Scriptables.References;
using UnityEngine;

namespace Scriptables.Components
{
    public class TrackEulerAngles : MonoBehaviour
    {
        [SerializeField] private Vector3Reference _value;

        // Use this for initialization
        void Start()
        {
            UpdateValue();
        }

        // Update is called once per frame
        void Update()
        {
            UpdateValue();
        }

        private void UpdateValue()
        {
            _value?.SetValue(transform.eulerAngles);
        }
    }
}