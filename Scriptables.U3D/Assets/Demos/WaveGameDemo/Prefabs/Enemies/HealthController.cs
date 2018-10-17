using System;
using Demos.WaveGameDemo.Models.DamageGroups;
using Demos.WaveGameDemo.Models.DamageTypes;
using Scriptables.GameEvents;
using Scriptables.References;
using UnityEngine;

namespace Demos.WaveGameDemo.Prefabs.Enemies
{
    public class HealthController : MonoBehaviour {

        public FloatReference Health;
        public DamageGroup DamageGroup;

        public bool AllowLessThanZero;
        public bool IsDead;

        public GameEvent OnDeathEvent;
        public Action DamageTaken;

        public float DealDamage(DamageType damageType, float damageAmount)
        {
            Health.ApplyChange(-damageAmount);

            DamageTaken?.Invoke();

            if (Health.Value <= 0)
            { 
                if (AllowLessThanZero == false)
                {
                    Health.SetValue(0);
                }

                if (OnDeathEvent != null && IsDead == false)
                {
                    IsDead = true;
                    OnDeathEvent.Raise();
                }
            }
            else
            {
                IsDead = false;
            }

            return Health.Value;
        }
    }
}
