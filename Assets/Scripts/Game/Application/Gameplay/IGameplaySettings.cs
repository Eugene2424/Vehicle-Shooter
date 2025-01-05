using Game.Domain;

namespace Game.Application.Gameplay
{
    public interface IGameplaySettings
    {
        public CarSettings CarSettings { get; }
        public TurretSettings TurretSettings { get; }
        public EnemySettings EnemySettings { get; }
        public EnemySpawnerSettings EnemySpawnerSettings{ get; }
    }
}