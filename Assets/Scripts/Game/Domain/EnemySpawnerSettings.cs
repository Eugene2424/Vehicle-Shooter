namespace Game.Domain
{
    public class EnemySpawnerSettings
    {
        public float SpawnInterval { get; private set;}
        public float SpawnRadius { get; private set;}
        public int SpawnMaxAmount { get; private set;}

        public EnemySpawnerSettings(float spawnInterval, float spawnRadius, int spawnMaxAmount)
        {
            SpawnInterval = spawnInterval;
            SpawnRadius = spawnRadius;
            SpawnMaxAmount = spawnMaxAmount;
        }
    }
}