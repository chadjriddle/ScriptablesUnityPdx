using Demos.WaveGameDemo.Models.DamageTypes;
using UnityEngine;

namespace Demos.WaveGameDemo.Models.Weapons
{
    [CreateAssetMenu(menuName = "Wave Game Data/Weapon")]
    public class WeaponData : ScriptableObject
    {
        public int Level = 1;
        public float Cooldown = 0.5f;
        public float MaxDamage = 5;
        public int MaxTargets = 1;
        public float MaxDamagePerTarget = 5;
        public float DamageRadius = 0.2f;
        public float Velocity = 0.0f;
        public DamageType DamageType;

        public float MaxDps => MaxDamage / Cooldown;
    }
}