using UnityEngine;
using UnityEngine.UI;
using Game.Application;
using Game.Application.Abstractions;
using Zenject;

namespace Game.Presentation.UI
{
    public class SettingsWindow : MonoBehaviour
    {
        [Header("Sliders")] 
        [SerializeField] private Slider _masterVolumeSlider;
        [SerializeField] private Slider _musicVolumeSlider;
        [SerializeField] private Slider _sfxVolumeSlider;

        private IAudioService _audioService;

        // PlayerPrefs keys
        private const string MASTER_VOLUME_KEY = "MasterVolume";
        private const string MUSIC_VOLUME_KEY = "MusicVolume";
        private const string SFX_VOLUME_KEY = "SFXVolume";

        [Inject]
        public void Construct(IAudioService audioService)
        {
            _audioService = audioService;
        }

        private void Start()
        {
            // 1. Load saved settings from PlayerPrefs or use defaults (1.0f).
            float savedMaster = PlayerPrefs.GetFloat(MASTER_VOLUME_KEY, 1.0f);
            float savedMusic = PlayerPrefs.GetFloat(MUSIC_VOLUME_KEY, 1.0f);
            float savedSFX = PlayerPrefs.GetFloat(SFX_VOLUME_KEY, 1.0f);

            // 2. Set slider values to reflect saved volumes.
            _masterVolumeSlider.value = savedMaster;
            _musicVolumeSlider.value = savedMusic;
            _sfxVolumeSlider.value = savedSFX;

            // 3. Listen for slider changes.
            _masterVolumeSlider.onValueChanged.AddListener(OnMasterVolumeChanged);
            _musicVolumeSlider.onValueChanged.AddListener(OnMusicVolumeChanged);
            _sfxVolumeSlider.onValueChanged.AddListener(OnSFXVolumeChanged);
        }

        private void OnDestroy()
        {
            // Remove listeners to avoid leaks if object is destroyed
            _masterVolumeSlider.onValueChanged.RemoveListener(OnMasterVolumeChanged);
            _musicVolumeSlider.onValueChanged.RemoveListener(OnMusicVolumeChanged);
            _sfxVolumeSlider.onValueChanged.RemoveListener(OnSFXVolumeChanged);
        }

        private void OnMasterVolumeChanged(float value)
        {
            _audioService.SetMasterVolume(value);
            PlayerPrefs.SetFloat(MASTER_VOLUME_KEY, value);
            PlayerPrefs.Save();
        }

        private void OnMusicVolumeChanged(float value)
        {
            _audioService.SetMusicVolume(value);
            PlayerPrefs.SetFloat(MUSIC_VOLUME_KEY, value);
            PlayerPrefs.Save();
        }

        private void OnSFXVolumeChanged(float value)
        {
            _audioService.SetSFXVolume(value);
            PlayerPrefs.SetFloat(SFX_VOLUME_KEY, value);
            PlayerPrefs.Save();
        }
    }
}