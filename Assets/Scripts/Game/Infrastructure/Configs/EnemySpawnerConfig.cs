using UnityEngine;

namespace Game.Infrastructure.Configs
{
    [CreateAssetMenu(menuName = "Game/EnemySpawnerConfig", fileName = "EnemySpawnerConfig")] 
    public class EnemySpawnerConfig : ScriptableObject
    {
        public float spawnInterval;
        public float spawnRadius;
        public int spawnMaxAmount;
    }
}