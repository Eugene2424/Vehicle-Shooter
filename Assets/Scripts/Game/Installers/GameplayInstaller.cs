using Zenject;
using Game.Application.Gameplay;
using Game.Application.Abstractions;
using Game.Domain;
using Game.Infrastructure;
using Game.Presentation;
using Game.Presentation.UI;
using Game.Infrastructure.Configs;
using Game.Infrastructure.Services;
using UnityEngine;


namespace Game.Installers
{
    public class GameplayInstaller : MonoInstaller
    {
        
        [SerializeField] private CameraView cameraView;
        [SerializeField] private CarView carView;
        [SerializeField] private TurretView turret;
        [Header("Enemy")]
        [SerializeField] private GameObject enemyPrefab;
        [SerializeField] private EnemySpawner enemySpawner;
        [Header("Configs")]
        [SerializeField] private CarConfig carConfig;
        [SerializeField] private TurretConfig turretConfig;
        [SerializeField] private EnemiesConfig enemiesConfig;
        [SerializeField] private EnemySpawnerConfig enemySpawnerConfig;
        
        public override void InstallBindings()
        {
            Container.Bind<IGameplaySettings>()
                .To<GameplaySettings>()
                .AsSingle()
                .WithArguments(carConfig, turretConfig, enemiesConfig, enemySpawnerConfig);
            
            Container.Bind<ICameraView>().To<CameraView>().FromInstance(cameraView).AsSingle();
            Container.BindInterfacesAndSelfTo<CameraPresenter>().AsSingle();
            
            Container.BindInterfacesTo<CarView>().FromInstance(carView).AsSingle();
            Container.BindInterfacesAndSelfTo<CarPresenter>().AsSingle();
            
            Container.Bind<ITurretView>().To<TurretView>().FromInstance(turret).AsSingle();
            Container.BindInterfacesAndSelfTo<TurretPresenter>().AsSingle();
            
            Container.Bind<IEnemyFactory>().To<EnemyFactory>().AsSingle().WithArguments(enemyPrefab);
            
            Container.Bind<IEnemySpawner>().To<EnemySpawner>().FromInstance(enemySpawner).AsSingle();
            Container.BindInterfacesAndSelfTo<EnemySpawnerPresenter>().AsSingle();

        }
    }
}