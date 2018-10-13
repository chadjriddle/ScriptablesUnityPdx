using System;
using Scriptables.Variables;

namespace Scriptables.References
{
    [Serializable]
    public class FloatReference : GenericReference<float, FloatVariable>
    {
        public FloatReference() : base()
        {
        }

        public FloatReference(float constant) : base(constant)
        {
        }

        public FloatReference(FloatVariable variable) : base(variable)
        {
        }

        protected override void ApplyChangeToConstant(float amount)
        {
            SetValue(Value + amount);
        }
    }
}