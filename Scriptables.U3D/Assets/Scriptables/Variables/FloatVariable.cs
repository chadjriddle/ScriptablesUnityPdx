using UnityEngine;

namespace Scriptables.Variables
{
    [CreateAssetMenu(menuName = "Variables/Float")]
    public class FloatVariable : GenericRangedVariable<float>
    {
        public override void ApplyChange(float amount)
        {
            SetValue(Value + amount);
        }

        public override void ApplyChange(GenericVariable<float> amount)
        {
            SetValue(Value + amount.Value);
        }

        public override float ClampValue(float value)
        {
            return Mathf.Clamp(value, MinValue, MaxValue);
        }
    }
}