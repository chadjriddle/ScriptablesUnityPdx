using System;
using UnityEngine;

namespace Scriptables.GameEvents
{
    [CreateAssetMenu(menuName = "Events/Float Game Event")]
    [Serializable]
    public class FloatGameEvent : GenericGameEvent<float>
    {
    }
}