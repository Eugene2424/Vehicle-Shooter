using System.ComponentModel;
using UnityEngine;
using Zenject;
using Game.Application;
using Game.Application.Abstractions;
using Game.Application.GameStates;
using Game.Infrastructure;
using Game.Infrastructure.Services;
using Game.Presentation.UI;

namespace Game.Installers
{
    public class BootstrapInstaller : MonoInstaller
    {
        [SerializeField] private LoadingScreen loadingScreen;
        [SerializeField] private SceneLoader sceneLoader;
        [SerializeField] private AudioManager audioManager;
        
        public override void InstallBindings()
        {
            Container.Bind<IGameStateFactory>().To<GameStateFactory>().AsSingle();
            Container.Bind<GameStateManager>().AsSingle();
            
            Container.Bind<ILoadingScreen>().FromInstance(loadingScreen).AsSingle();
            Container.Bind<ISceneLoader>().FromInstance(sceneLoader).AsSingle();
            
            Container.Bind<IAudioService>().FromInstance(audioManager).AsSingle();
        }
    }
}