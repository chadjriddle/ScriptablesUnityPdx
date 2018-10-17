using System;
using System.Collections.Generic;
using Demos.WaveGameDemo.Models.DamageGroups;
using Demos.WaveGameDemo.Models.Weapons;
using UnityEngine;

namespace Demos.WaveGameDemo.Prefabs.Enemies
{
    public class WeaponController : MonoBehaviour
    {
        public SphereCollider Collider;
        public List<DamageGroup> GroupsToDamage;
        public Action Attacking;

        [SerializeField]
        private WeaponData _data;

        [SerializeField]
        private float _cooldownRemaining;

        private void Update()
        {
            _cooldownRemaining -= Time.deltaTime;
            if (_cooldownRemaining <= 0 && _data != null)
            {
                Collider.enabled = true;
                _cooldownRemaining = _data.Cooldown - _cooldownRemaining;
            }
            else
            {
                Collider.enabled = false;
            }
        }

        public void Initialize(WeaponData data)
        {
            _data = data;
            Collider.radius = _data.DamageRadius;
        }

        void OnTriggerEnter(Collider other)
        {
            var healthContoller = other.GetComponent<HealthController>();
            if (healthContoller != null && GroupsToDamage.Contains(healthContoller.DamageGroup))
            {
                healthContoller.DealDamage(_data.DamageType, _data.MaxDamagePerTarget);
                Attacking?.Invoke();
            }
        }
    }
}
