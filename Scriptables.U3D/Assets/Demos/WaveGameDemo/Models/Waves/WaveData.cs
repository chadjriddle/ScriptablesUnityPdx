using System;
using System.Collections.Generic;
using UnityEngine;

namespace Demos.WaveGameDemo.Models.Waves
{
    [CreateAssetMenu(menuName = "Wave Game Data/Wave")]
    public class WaveData : ScriptableObject
    {
        public List<EnemyGroupData> Groups;
    }

    [Serializable]
    public class EnemyGroupData
    {
        public EnemyData Enemy;
        public int Count;
        public float Delay;
        public float SpawnRate;
    }
}