using UnityEngine;

namespace Scriptables.Components
{
    public class ActiveByTrigger : MonoBehaviour
    {
        public GameObject Target;
        public SetActiveState OnEntered;
        public SetActiveState OnLeave;


    }

    public enum SetActiveState
    {
        Active,
        InActive,
        NoChange
    }
}