using UnityEngine;

namespace Demos.CodeGeneration
{
    [CreateAssetMenu(menuName = "Demo Data/MyScriptable")]
    public class MyScriptable : ScriptableObject
    {
        [SerializeField] private string _name;
        [SerializeField] private int _amount;
    }
}
