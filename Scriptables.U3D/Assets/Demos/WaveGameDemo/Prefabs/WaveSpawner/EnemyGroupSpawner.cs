using System;
using Demos.WaveGameDemo.Models.Waves;
using UnityEngine;

namespace Demos.WaveGameDemo.Prefabs.WaveSpawner
{
    public class EnemyGroupSpawner
    {
        public bool GroupComplete { get; private set; }

        private readonly EnemyGroupData _data;

        private float _runningTime = 0.0f;
        private float _lastSpawnTime = 0.0f;
        private bool _startedSpawning = false;
        private int _spawnCount = 0;

        public EnemyGroupSpawner(EnemyGroupData data)
        {
            _data = data;
        }

        public void Update(float deltaTime, Action<EnemyData> spawnAction)
        {
            if (GroupComplete)
            {
                return;
            }

            _runningTime += deltaTime;

            // Debug.LogFormat("Last Spanwn Time: {0}   Running Time: {1}", _lastSpawnTime, _runningTime);

            if (_startedSpawning == false)
            {
                if (_lastSpawnTime + _data.Delay <= _runningTime)
                {
                    Debug.Log("Started Spawning");
                    _startedSpawning = true;
                    spawnAction(_data.Enemy);
                    _spawnCount++;
                    _lastSpawnTime += _data.Delay;
                }
                else
                {
                    return;
                }
            }

            if (_spawnCount < _data.Count)
            {
                if (_lastSpawnTime + _data.SpawnRate <= _runningTime)
                {
                    Debug.Log("Spawn");
                    spawnAction(_data.Enemy);
                    _spawnCount++;
                    _lastSpawnTime += _data.SpawnRate;
                }

                return;
            }

            Debug.Log("GroupComplete");
            GroupComplete = true;
        }
    }
}