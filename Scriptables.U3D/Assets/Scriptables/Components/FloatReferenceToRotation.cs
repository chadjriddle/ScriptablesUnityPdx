using System;
using Scriptables.References;
using UnityEngine;

namespace Scriptables.Components
{
    public class FloatReferenceToRotation : MonoBehaviour {

        [SerializeField] private Transform _target;
        [SerializeField] private FloatReference _input;
        [SerializeField] private bool _useRelativeDireciton;
        [SerializeField] private Vector3 _direction;


        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            if (_input != null && Math.Abs(_input.Value) > 0.001f)
            {
                if (_useRelativeDireciton)
                {
                    _target?.Rotate(_direction, _input * Time.deltaTime, Space.Self);
                }
                else
                {
                    _target?.Rotate(_direction, _input * Time.deltaTime, Space.World);
                }
            }
        }
    }
}
