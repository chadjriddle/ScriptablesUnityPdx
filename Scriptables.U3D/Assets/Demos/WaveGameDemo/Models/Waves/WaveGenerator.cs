using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Demos.WaveGameDemo.Models.Waves
{
    [CreateAssetMenu(menuName = "Wave Game Data/Wave Generator")]
    public class WaveGenerator : ScriptableObject
    {
        public int MinEnemyCount;
        public int MinGroupCount;
        public List<EnemyData> Enemies;

        public WaveData GenerateForLevel(int level)
        {
            var wave = CreateInstance<WaveData>();
            var numberOfGroups = DetermineGroupsForLevel(level);

            wave.Groups = new List<EnemyGroupData>(numberOfGroups);

            for (int i = 0; i < numberOfGroups; i++)
            {
                wave.Groups.Add(GenerateGroupForLevel(level, i));
            }

            return wave;
        }

        private EnemyGroupData GenerateGroupForLevel(int level, int i)
        {
            var group = new EnemyGroupData();
            group.Delay = 3.0f * i;
            group.Count = 5 + level - i * 2;
            group.Enemy = GetEnemyForLevel(level);
            group.SpawnRate = GetSpawnRateForLevel(level);
            return group;
        }

        private float GetSpawnRateForLevel(int level)
        {
            if (level < 17)
            {
                return (7.864f * level * level - 258.51f * level + 3079.4f)/1000.0f;
            }

            return 0.95f;
        }

        private EnemyData GetEnemyForLevel(int level)
        {
            int index = Random.Range(0, Math.Min(level + 6, Enemies.Count - 1));
            return Enemies[index];
        }

        private int DetermineGroupsForLevel(int level)
        {
            return Math.Max(MinGroupCount, level);
        }
    }
}
