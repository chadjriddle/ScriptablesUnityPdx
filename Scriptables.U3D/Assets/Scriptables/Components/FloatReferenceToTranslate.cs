using System;
using Scriptables.References;
using UnityEngine;

namespace Scriptables.Components
{
    public class FloatReferenceToTranslate : MonoBehaviour
    {
        [SerializeField] private Transform _target;
        [SerializeField] private FloatReference _input;
        [SerializeField] private bool _useRelativeDireciton;
        [SerializeField] private Vector3 _direction;
        [SerializeField] private bool _kinematicOverride;

        private Rigidbody _targetRigidbody;

        public Transform Target
        {
            get { return _target; }
            set
            {
                _target = value;
                TargetUpdated();
            }
        }

        // Use this for initialization
        void Start ()
        {
            TargetUpdated();
        }

        private void TargetUpdated()
        {
            _targetRigidbody = _target.GetComponent<Rigidbody>();
        }
	
        // Update is called once per frame
        void Update () {
            if (_input != null && Math.Abs(_input.Value) > 0.001f)
            {

                var isKinematic = _targetRigidbody?.isKinematic ?? false;
                if (_kinematicOverride && _targetRigidbody != null)
                {
                    _targetRigidbody.isKinematic = true;
                }

                _target?.Translate(_direction * _input * Time.deltaTime, _useRelativeDireciton ? Space.Self : Space.World);

                if (_kinematicOverride && _targetRigidbody != null)
                {
                    _targetRigidbody.isKinematic = isKinematic;
                }
            }
        }
    }
}
