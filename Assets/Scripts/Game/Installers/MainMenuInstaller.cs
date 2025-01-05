using Zenject;
using Game.Application.Gameplay;
using Game.Presentation.UI;
using UnityEngine;

namespace Game.Installers
{
    
    public class MainMenuInstaller : MonoInstaller
    {
        [SerializeField] private MainMenuView mainMenuView;
        [SerializeField] private SettingsWindowView settingsWindowView;
        
        public override void InstallBindings()
        {
            Container.Bind<IMainMenuView>().To<MainMenuView>().FromInstance(mainMenuView).AsSingle();
            Container.BindInterfacesAndSelfTo<MainMenuPresenter>().AsSingle();
            
            Container.Bind<ISettingsWindowView>().To<SettingsWindowView>().FromInstance(settingsWindowView).AsSingle();
            Container.BindInterfacesAndSelfTo<SettingsWindowPresenter>().AsSingle();
        }
    }
}