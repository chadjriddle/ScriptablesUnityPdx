using System;
using Scriptables.Variables;
using UnityEngine;

namespace Scriptables.References
{
    [Serializable]
    public class Vector3Reference : GenericReference<Vector3, Vector3Variable>
    {
        public Vector3Reference() : base()
        {
        }

        public Vector3Reference(Vector3 constant) : base(constant)
        {
        }

        public Vector3Reference(Vector3Variable variable) : base(variable)
        {
        }

        protected override void ApplyChangeToConstant(Vector3 amount)
        {
            SetValue(Value + amount);
        }
    }
}