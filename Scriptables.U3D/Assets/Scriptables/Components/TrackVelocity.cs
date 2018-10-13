using Scriptables.References;
using UnityEngine;

namespace Scriptables.Components
{
    [RequireComponent(typeof(Rigidbody))]
    public class TrackVelocity: MonoBehaviour
    {
        [SerializeField] private Vector3Reference _value;

        private Rigidbody _rigidbody;

        // Use this for initialization
        void Start()
        {
            _rigidbody = GetComponent<Rigidbody>();
            UpdateValue();
        }

        // Update is called once per frame
        void Update()
        {
            UpdateValue();
        }

        private void UpdateValue()
        {
            _value?.SetValue(_rigidbody.velocity);
        }
    }
}