namespace Game.Application.Abstractions
{
    public interface IAudioService
    {
        public float MaxVolume { get; }
        // MUSIC
        void PlayMusic(string trackId, float fadeTime = 0f, bool loop = true);
        void StopMusic(float fadeTime = 0f);
        void SetMusicVolume(float volume);     // volume in [0..1] or in decibels
    
        // SFX
        void PlaySFX(string sfxId, float volume = 1f, float pitch = 1f);
        void SetSFXVolume(float volume);
    
        // MASTER
        void SetMasterVolume(float volume);
    
        // Additional optional features
        bool IsMusicPlaying { get; }
        bool IsSFXPlaying(string sfxId);
    }

}