using Scriptables.GameEvents;
using UnityEngine;

namespace Scriptables.Components
{
    public class RaiseGameEvent : MonoBehaviour
    {
        public GameEvent EventToRaise;

        public void Raise()
        {
            EventToRaise?.Raise();
        }
    }
}
