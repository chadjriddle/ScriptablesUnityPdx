using UnityEngine;

namespace Scriptables.Variables
{
    [CreateAssetMenu(menuName = "Variables/Integer")]
    public class IntVariable : GenericRangedVariable<int>
    {
        public override void ApplyChange(int amount)
        {
            SetValue(Value + amount);
        }

        public override void ApplyChange(GenericVariable<int> amount)
        {
            SetValue(Value + amount.Value);
        }

        public override int ClampValue(int value)
        {
            return Mathf.Clamp(value, MinValue, MaxValue);
        }
    }
}