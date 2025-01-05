using System;
using Game.Application.Abstractions;

namespace Game.Application.Gameplay
{
    public class SettingsWindowPresenter : IPresenter
    {
        private readonly ISettingsWindowView _view;
        private readonly IAudioService _audioService;

        public SettingsWindowPresenter(ISettingsWindowView view, IAudioService audioService)
        {
            _view = view;
            _audioService = audioService;
        }

        public void Initialize()
        {
            _view.OnSettingsButtonClicked += HandleSettingsButtonClicked;
            _view.OnCloseButtonClicked += HandleCloseButtonClicked;
            _view.OnMasterVolumeChanged += HandleMasterVolumeChanged;
            _view.OnMusicVolumeChanged += HandleMusicVolumeChanged;
            _view.OnSfxVolumeChanged += HandleSfxVolumeChanged;
            
            _view.SetMasterSliderMaxValue(_audioService.MaxVolume);
            _view.SetMusicSliderMaxValue(_audioService.MaxVolume);
            _view.SetSfxSliderMaxValue(_audioService.MaxVolume);
        }
    
        public void Dispose()
        {
            _view.OnSettingsButtonClicked -= HandleSettingsButtonClicked;
            _view.OnCloseButtonClicked -= HandleCloseButtonClicked;
            _view.OnMasterVolumeChanged -= HandleMasterVolumeChanged;
            _view.OnMusicVolumeChanged -= HandleMusicVolumeChanged;
            _view.OnSfxVolumeChanged -= HandleSfxVolumeChanged;
        }

        public void HandleSettingsButtonClicked()
        {
            _view.ShowWindow();
        }

        public void HandleCloseButtonClicked()
        {
            _view.HideWindow();
        }

        public void HandleMasterVolumeChanged(float volume)
        {
            _audioService.SetMasterVolume(volume);
        }
        
        public void HandleMusicVolumeChanged(float volume)
        {
            _audioService.SetMusicVolume(volume);
        }
        
        public void HandleSfxVolumeChanged(float volume)
        {
            _audioService.SetSFXVolume(volume);
        }
    }
}