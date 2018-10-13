using System;
using Scriptables.Variables;
using UnityEngine;

namespace Scriptables.References
{
    [Serializable]
    public class QuaternionReference : GenericReference<Quaternion, QuaternionVariable>
    {
        public QuaternionReference() : base()
        {
        }

        public QuaternionReference(Quaternion constant) : base(constant)
        {
        }

        public QuaternionReference(QuaternionVariable variable) : base(variable)
        {
        }
    }
}