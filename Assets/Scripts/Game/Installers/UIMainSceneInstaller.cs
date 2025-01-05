using Zenject;
using Game.Application.Gameplay;
using Game.Presentation.UI;
using UnityEngine;

namespace Game.Installers
{
    public class UIMainSceneInstaller : MonoInstaller
    {
        [SerializeField] private MainMenuView mainMenuView;
        [SerializeField] private SettingsWindowView settingsWindowView;
        
        [SerializeField] private GameplayUIView gameplayUI;
        [SerializeField] private ResultScreenView resultScreen;
        
        public override void InstallBindings()
        {
            Container.Bind<IMainMenuView>().To<MainMenuView>().FromInstance(mainMenuView).AsSingle();
            Container.BindInterfacesAndSelfTo<MainMenuPresenter>().AsSingle();
            
            Container.Bind<ISettingsWindowView>().To<SettingsWindowView>().FromInstance(settingsWindowView).AsSingle();
            Container.BindInterfacesAndSelfTo<SettingsWindowPresenter>().AsSingle();
            
            Container.Bind<IGameplayUIView>().To<GameplayUIView>().FromInstance(gameplayUI).AsSingle();
            Container.BindInterfacesAndSelfTo<GameplayUIPresenter>().AsSingle();
            
            Container.Bind<IResultScreenView>().To<ResultScreenView>().FromInstance(resultScreen).AsSingle();
            Container.BindInterfacesAndSelfTo<ResultScreenPresenter>().AsSingle();
        }
    }
}