using UnityEngine;

namespace Demos.MeterGame.Models.Level.Scriptables
{
    [CreateAssetMenu(menuName = "Meter Game/Level Complete State")]
    public class LevelCompleteState : ScriptableObject
    {
        [SerializeField] public string Name;

        public override string ToString()
        {
            return Name;
        }
    }
}
