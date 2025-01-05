using System;

namespace Game.Application.Gameplay
{
    public interface ISettingsWindowView
    {
        public event Action OnCloseButtonClicked, OnSettingsButtonClicked;
        public event Action<float> OnMasterVolumeChanged, OnMusicVolumeChanged, OnSfxVolumeChanged;
        
        public void ShowWindow();
        public void HideWindow();

        public void SetMasterSliderMaxValue(float value);
        public void SetMusicSliderMaxValue(float value);
        public void SetSfxSliderMaxValue(float value);
        public void SetMasterSliderValue(float value);
        public void SetMusicSliderValue(float value);
        public void SetSfxSliderValue(float value);

    }
}