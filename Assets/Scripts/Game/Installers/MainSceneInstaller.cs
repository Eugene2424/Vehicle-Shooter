using Game.Application;
using Game.Infrastructure;
using Game.Application.Commands;
using Game.Application.Gameplay;
using Game.Domain;
using Game.Infrastructure.Configs;
using Game.Infrastructure.Services;
using Game.Presentation;
using Game.Presentation.UI;
using UnityEngine;
using Zenject;

namespace Game.Installers
{
    public class MainSceneInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<StartPlayingCommand>().AsTransient();
            Container.Bind<PlayAgainCommand>().AsTransient();
            Container.Bind<WinCommand>().AsTransient();
            Container.Bind<LoseCommand>().AsTransient();
            
            Container.Bind<ICommandMediator>().To<CommandMediator>().AsSingle();
        }

    }
}