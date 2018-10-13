using UnityEngine;

namespace Scriptables.Variables
{
    [CreateAssetMenu(menuName = "Variables/Color")]
    public class ColorVariable : GenericVariable<Color>
    {
        public override void ApplyChange(Color amount)
        {
            SetValue(amount);
        }

        public override void ApplyChange(GenericVariable<Color> amount)
        {
            SetValue(amount.Value);
        }
    }
}