using System;
using Game.Application;
using Game.Application.Gameplay;
using Zenject;

namespace Game.Infrastructure
{
    public class MainSceneAdapter : IInitializable, IDisposable
    {
        private readonly MainMenuPresenter _mainMenu;
        private readonly SettingsWindowPresenter _settingsWindow;
        private readonly CarPresenter _carPresenter;
        private readonly CameraPresenter _cameraPresenter;
        
        public MainSceneAdapter(MainMenuPresenter mainMenu, SettingsWindowPresenter settingsWindow,
            CarPresenter carPresenter, CameraPresenter cameraPresenter)
        {
            _mainMenu = mainMenu;
            _settingsWindow = settingsWindow;
            _carPresenter = carPresenter;
            _cameraPresenter = cameraPresenter;
        }
        
        public void Initialize()
        {
            _mainMenu.Initialize();
            _settingsWindow.Initialize();
            _carPresenter.Initialize();
            _cameraPresenter.Initialize();
        }

        public void Dispose()
        {
            _mainMenu.Dispose();
            _settingsWindow.Dispose();
            _carPresenter.Dispose();
            _cameraPresenter.Dispose();
        }
    }
}