using System;
using Scriptables.References;
using UnityEngine;

namespace Scriptables.Components
{
    public class FloatReferenceToForce : MonoBehaviour
    {

        [SerializeField] private Rigidbody _target;
        [SerializeField] private FloatReference _input;
        [SerializeField] private ForceMode _mode;
        [SerializeField] private bool _useRelativeForce;
        [SerializeField] private Vector3 _direction = Vector3.up;

        // Use this for initialization
        void Start () {
		
        }
	
        // Update is called once per frame
        void Update () {
            if (_input != null && Math.Abs(_input.Value) > 0.001f)
            {
                if (_useRelativeForce)
                {
                    _target?.AddRelativeForce(_direction * _input * Time.deltaTime, _mode);
                }
                else
                {
                    _target?.AddForce(_direction * _input, _mode);
                }
            }

        }
    }
}
