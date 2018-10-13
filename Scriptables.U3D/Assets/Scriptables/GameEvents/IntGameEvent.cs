using System;
using UnityEngine;

namespace Scriptables.GameEvents
{
    [CreateAssetMenu(menuName = "Events/Integer Game Event")]
    [Serializable]
    public class IntGameEvent : GenericGameEvent<int>
    {
    }
}