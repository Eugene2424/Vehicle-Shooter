using Game.Application;
using Game.Application.Abstractions;
using Game.Application.Commands;
using Game.Application.Events;
using Game.Application.GameStates;
using Game.Infrastructure;
using Game.Infrastructure.Services;
using Zenject;

namespace Game.Installers
{
    public class ProjectInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            BindServices();
            BindGameStates();
        }

        private void BindServices()
        {
            Container.Bind<ILoggerService>().To<UnityLogger>().AsSingle();
            Container.Bind<EventBus>().AsSingle();
        }
        
        private void BindGameStates()
        {
            Container.Bind<MainMenuState>().AsTransient();
            Container.Bind<GameplayState>().AsTransient();
            Container.Bind<WinState>().AsTransient();
            Container.Bind<LoseState>().AsTransient();
        }

    }
}

