using Game.Application.Gameplay;
using Game.Domain;
using Game.Infrastructure.Configs;
using UnityEngine;

namespace Game.Infrastructure.Services
{
    public class GameplaySettings : IGameplaySettings
    {
        public CarSettings CarSettings { get; private set; }
        public TurretSettings TurretSettings { get; private set; }
        public EnemySettings EnemySettings { get; private set; }
        public EnemySpawnerSettings EnemySpawnerSettings{ get; private set; }
        
        public GameplaySettings(CarConfig car, TurretConfig turret, EnemiesConfig enemies, EnemySpawnerConfig enemySpawner)
        {
            CarSettings = new CarSettings(car.initialHealth, car.maxHealth, car.damage,
                car.initialSpeed, car.distanceToFinish);
            
            TurretSettings = new TurretSettings(turret.fireRate, turret.bulletSpeed, 
                turret.bulletDamage, turret.turretRotationSpeed);

            EnemySettings = new EnemySettings(enemies.health, enemies.health, enemies.damage,
                enemies.speed);

            EnemySpawnerSettings = new EnemySpawnerSettings(enemySpawner.spawnInterval,
                enemySpawner.spawnRadius, enemySpawner.spawnMaxAmount);
        }
    }
}