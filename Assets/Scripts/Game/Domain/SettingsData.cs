using System;

namespace Game.Domain
{
    public class SettingsData
    {
        public event Action<float> OnMasterVolumeChanged, OnMusicVolumeChanged, OnSfxVolumeChanged;
        
        public float MasterVolume { get; private set; }
        public float MusicVolume { get; private set; }
        public float SfxVolume { get; private set; }

        public void SetMasterVolume(float volume)
        {
            MasterVolume = volume;
            OnMasterVolumeChanged?.Invoke(volume);
        }
        
        public void SetMusicVolume(float volume)
        {
            MasterVolume = volume;
            OnMusicVolumeChanged?.Invoke(volume);
        }

        public void SetSfxVolume(float volume)
        {
            SfxVolume = volume;
            OnSfxVolumeChanged?.Invoke(volume);
        }
        
    }
}