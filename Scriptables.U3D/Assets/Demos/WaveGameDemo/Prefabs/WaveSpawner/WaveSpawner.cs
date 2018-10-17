using System.Collections.Generic;
using Demos.WaveGameDemo.Components;
using Demos.WaveGameDemo.Models.Waves;
using Scriptables.GameEvents;
using Scriptables.References;
using UnityEngine;

namespace Demos.WaveGameDemo.Prefabs.WaveSpawner
{
    public class WaveSpawner : MonoBehaviour
    {
        [SerializeField] private GameEvent _allEnemiesKilledEvent;

        [SerializeField] private GameObject _enemyPrefab;

        [SerializeField] private TargetArea _spawnArea;

        [SerializeField] private WaveGenerator _waveGenerator;

        [SerializeField] private BoolReference _waveRunning;

        [SerializeField] private IntReference _currentLevel;

        private WaveData _waveData;

        private readonly List<EnemyGroupSpawner> _groupSpawners = new List<EnemyGroupSpawner>();

        private readonly List<EnemyController> _enemiesSpawned = new List<EnemyController>();

        // Use this for initialization
        void Start()
        {
            _waveRunning.SetValue(false);
        }

        // Update is called once per frame
        void Update()
        {
            if (_waveRunning)
            {
                foreach (var enemyGroupSpawner in _groupSpawners)
                {
                    enemyGroupSpawner.Update(Time.deltaTime, SpawnEnemy);
                }
            }
        }

        public void ClearAllEnemies()
        {
            foreach (var enemyController in _enemiesSpawned)
            {
                Destroy(enemyController.gameObject);
            }

            _enemiesSpawned.Clear();
        }

        public void StartWave()
        {
            if (_waveRunning)
            {
                Debug.LogError("Wave Already Running!");
                return;
            }

            _waveData = _waveGenerator.GenerateForLevel(_currentLevel);

            _groupSpawners.Clear();
            ClearAllEnemies();

            foreach (var enemyGroupData in _waveData.Groups)
            {
                _groupSpawners.Add(new EnemyGroupSpawner(enemyGroupData));
            }

            _waveRunning.SetValue(true);
        }

        public void StopWave()
        {
            _waveRunning.SetValue(false);
        }

        private void SpawnEnemy(EnemyData data)
        {
            var location = _spawnArea.GetRandomWorldLocation();

            var go = Instantiate(_enemyPrefab);
            go.transform.position = location;
            go.transform.rotation = Quaternion.Euler(0, 180, 0);

            var enemy = go.GetComponent<EnemyController>();
            enemy.Initialize(data, EnemyKilled);
            _enemiesSpawned.Add(enemy);
        }

        private void EnemyKilled(EnemyController enemy)
        {
            _enemiesSpawned.Remove(enemy);

            if (_enemiesSpawned.Count == 0 && _groupSpawners.TrueForAll(t => t.GroupComplete))
            {
                _waveRunning.SetValue(false);
                _currentLevel.ApplyChange(1);
                _allEnemiesKilledEvent.Raise();
            }
        }
    }
}