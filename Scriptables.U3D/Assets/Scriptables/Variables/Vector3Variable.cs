using UnityEngine;

namespace Scriptables.Variables
{
    [CreateAssetMenu(menuName = "Variables/Vector3")]
    public class Vector3Variable : GenericVariable<Vector3>
    {
        public override void ApplyChange(Vector3 amount)
        {
            SetValue(Value + amount);
        }

        public override void ApplyChange(GenericVariable<Vector3> amount)
        {
            SetValue(Value + amount.Value);
        }
    }
}