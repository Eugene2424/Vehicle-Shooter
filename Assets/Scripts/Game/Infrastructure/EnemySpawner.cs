using System.Collections;
using Game.Application.Gameplay;
using Game.Domain;
using Game.Infrastructure.Configs;
using UnityEngine;
using Zenject;

namespace Game.Infrastructure
{
    public class EnemySpawner : MonoBehaviour, IEnemySpawner
    {
        [SerializeField] private Transform spawnPoint;
        
        private IEnemyFactory _factory;
        private EnemySpawnerSettings _settings;
        private bool _isSpawning;
    
        [Inject]
        private void Construct(IEnemyFactory factory, IGameplaySettings settings)
        {
            _factory = factory;
            _settings = settings.EnemySpawnerSettings;
        }
        
        public void StartSpawning()
        {
            _isSpawning = true;
            StartCoroutine(SpawnEnemyRoutine());
        }

        public void StopSpawning()
        {
            _isSpawning = false;
        }

        private IEnumerator SpawnEnemyRoutine()
        {
            while (_isSpawning)
            {
                for (int i = 0; i <= _settings.SpawnMaxAmount; i++)
                    SpawnInRadius(_settings.SpawnRadius);
                yield return new WaitForSeconds(_settings.SpawnInterval);
            }
            
        }

        private void SpawnInRadius(float radius)
        {
            float randomX = Random.Range(spawnPoint.position.x - radius, spawnPoint.position.x + radius);
            float randomZ = Random.Range(spawnPoint.position.z - radius, spawnPoint.position.z + radius);
            
            _factory.CreateEnemy(randomX, spawnPoint.position.y, randomZ);
        }
        
    }
}