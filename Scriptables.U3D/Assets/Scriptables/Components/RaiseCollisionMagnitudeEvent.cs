using Scriptables.GameEvents;
using UnityEngine;

namespace Scriptables.Components
{
    public class RaiseCollisionMagnitudeEvent : MonoBehaviour
    {
        [SerializeField] private FloatGameEvent _magnitudeEvent;
        private void OnCollisionEnter(Collision collision)
        {
            _magnitudeEvent.Raise(collision.relativeVelocity.magnitude);
        }
    }
}