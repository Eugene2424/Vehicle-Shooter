using Game.Application;
using UnityEngine;
using UnityEngine.UI;
using System;
using Game.Application.Gameplay;

namespace Game.Presentation.UI
{
    public class SettingsWindowView : MonoBehaviour, ISettingsWindowView
    {
        public event Action OnCloseButtonClicked, OnSettingsButtonClicked;
        public event Action<float> OnMasterVolumeChanged, OnMusicVolumeChanged, OnSfxVolumeChanged;
        
        [SerializeField] private GameObject window;
        [SerializeField] private Button closeButton, settingsButton;
        
        [Header("Sliders")] 
        [SerializeField] private Slider _masterVolumeSlider;
        [SerializeField] private Slider _musicVolumeSlider;
        [SerializeField] private Slider _sfxVolumeSlider;
        

        private void Start()
        {
            closeButton.onClick.AddListener(() => { OnCloseButtonClicked?.Invoke(); });
            settingsButton.onClick.AddListener(() => { OnSettingsButtonClicked?.Invoke(); });
            
            _masterVolumeSlider.onValueChanged.AddListener(OnMasterSliderValueChanged);
            _musicVolumeSlider.onValueChanged.AddListener(OnMusicSliderValueChanged);
            _sfxVolumeSlider.onValueChanged.AddListener(OnSfxSliderValueChanged);
        }

        private void OnDestroy()
        {
            closeButton.onClick.RemoveListener(() => { OnCloseButtonClicked?.Invoke(); });
            settingsButton.onClick.RemoveListener(() => { OnSettingsButtonClicked?.Invoke(); });
            
            _masterVolumeSlider.onValueChanged.RemoveListener(OnMasterSliderValueChanged);
            _musicVolumeSlider.onValueChanged.RemoveListener(OnMusicSliderValueChanged);
            _sfxVolumeSlider.onValueChanged.RemoveListener(OnSfxSliderValueChanged);
        }

        public void ShowWindow()
        {
            window.SetActive(true);
        }
        
        public void HideWindow()
        {
            window.SetActive(false);
        }
        
        public void SetMasterSliderMaxValue(float value)
        {
            _masterVolumeSlider.maxValue = value;
            SetMasterSliderValue(value);
        }
        
        public void SetMusicSliderMaxValue(float value)
        {
            _musicVolumeSlider.maxValue = value;
            SetMusicSliderValue(value);
        }
        
        public void SetSfxSliderMaxValue(float value)
        {
            _sfxVolumeSlider.maxValue = value;
            SetSfxSliderValue(value);
        }
        
        public void SetMasterSliderValue(float value)
        {
            _masterVolumeSlider.value = value;
        }
        
        public void SetMusicSliderValue(float value)
        {
            _musicVolumeSlider.value = value;
        }
        
        public void SetSfxSliderValue(float value)
        {
            _sfxVolumeSlider.value = value;
        }
        
        private void OnMasterSliderValueChanged(float value)
        {
            OnMasterVolumeChanged?.Invoke(value);
        }

        private void OnMusicSliderValueChanged(float value)
        {   
            OnMusicVolumeChanged?.Invoke(value);
        }

        private void OnSfxSliderValueChanged(float value)
        {
            OnSfxVolumeChanged?.Invoke(value);
        }
    }
}