using Demos.WaveGameDemo.Models.DamageTypes;
using UnityEngine;

namespace Demos.WaveGameDemo.Models.Weapons
{
    [CreateAssetMenu(menuName = "Wave Game Data/Weapon Function")]
    public class WeaponFunction : ScriptableObject
    {
        public int MaxLevel = 20;
        public DamageType DamageType;
        public AnimationCurve Cooldown;
        public AnimationCurve MaxDamage;
        public AnimationCurve MaxTargets;
        public AnimationCurve MaxDamagePerTarget;
        public AnimationCurve DamageRadius;
        public AnimationCurve Velocity;

        public WeaponData GetDataForLevel(int level)
        {
            var data = CreateInstance<WeaponData>();

            data.Level = level;
            data.DamageType = DamageType;
            data.Cooldown = Cooldown?.Evaluate(level) ?? 0;
            data.MaxDamage = MaxDamage?.Evaluate(level) ?? 0;
            data.MaxTargets = Mathf.RoundToInt(MaxTargets?.Evaluate(level) ?? 0);
            data.MaxDamagePerTarget = MaxDamagePerTarget?.Evaluate(level) ?? 0;
            data.DamageRadius = DamageRadius?.Evaluate(level) ?? 09;
            data.Velocity = Velocity?.Evaluate(level) ?? 0;

            return data;
        }

    }
}