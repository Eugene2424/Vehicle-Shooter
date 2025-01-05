using System.Collections;
using System.Collections.Generic;
using Game.Application;
using Game.Application.Abstractions;
using UnityEngine;
using UnityEngine.Audio;

namespace Game.Infrastructure.Services
{
    public class AudioManager : MonoBehaviour, IAudioService
    {
        [Header("Audio Mixer (Optional)")]
        [SerializeField] private AudioMixer _audioMixer;

        [Header("Music")]
        [SerializeField] private AudioSource _musicSource;
        [SerializeField] private List<AudioClip> _musicClips; 
        // e.g. a list of known music tracks

        [Header("SFX")]
        [SerializeField] private AudioSource _sfxPrefab; 
        // a prefab or reference for an AudioSource, used for the pool
        
        [SerializeField] private int _sfxPoolSize = 10;
        [SerializeField] private List<AudioClip> _sfxClips;
        // known SFX library

        private List<AudioSource> _sfxPool;
        private Dictionary<string, AudioClip> _musicDict;
        private Dictionary<string, AudioClip> _sfxDict;
        
        // To track the currently playing music for stopping/fading
        private AudioClip _currentMusic;
        
        private const string MASTER_VOLUME_KEY = "MasterVolume";
        private const string MUSIC_VOLUME_KEY = "MusicVolume";
        private const string SFX_VOLUME_KEY = "SFXVolume";

        public float MaxVolume => 1f;

        private void Awake()
        {
            // Build dictionaries for quick lookup
            _musicDict = new Dictionary<string, AudioClip>();
            foreach (var clip in _musicClips)
            {
                if(clip != null) 
                    _musicDict[clip.name] = clip;
            }

            _sfxDict = new Dictionary<string, AudioClip>();
            foreach (var clip in _sfxClips)
            {
                if(clip != null)
                    _sfxDict[clip.name] = clip;
            }

            // Create the SFX pool
            _sfxPool = new List<AudioSource>();
            for (int i = 0; i < _sfxPoolSize; i++)
            {
                var sfxObj = Instantiate(_sfxPrefab, transform);
                sfxObj.gameObject.SetActive(true); 
                _sfxPool.Add(sfxObj);
            }
            
        }

        private void Start()
        {
            float savedMaster = PlayerPrefs.GetFloat(MASTER_VOLUME_KEY, 1.0f);
            float savedMusic = PlayerPrefs.GetFloat(MUSIC_VOLUME_KEY, 1.0f);
            float savedSFX = PlayerPrefs.GetFloat(SFX_VOLUME_KEY, 1.0f);
            
            SetMasterVolume(savedMaster);
            SetMusicVolume(savedMusic);
            SetSFXVolume(savedSFX);
        }

        #region IAudioService Implementation

        // MUSIC
        public void PlayMusic(string trackId, float fadeTime = 0f, bool loop = true)
        {
            if (!_musicDict.TryGetValue(trackId, out var clip))
            {
                Debug.LogWarning($"[AudioManager] Music track '{trackId}' not found.");
                return;
            }

            if (_musicSource.isPlaying && _musicSource.clip == clip)
            {
                // Already playing this track
                return;
            }

            _currentMusic = clip;
            // Optionally handle fade out of old track, fade in new track
            if (fadeTime > 0f)
            {
                // A quick example fade
                StartCoroutine(FadeInMusic(clip, fadeTime, loop));
            }
            else
            {
                _musicSource.clip = clip;
                _musicSource.loop = loop;
                _musicSource.Play();
            }
        }

        public void StopMusic(float fadeTime = 0f)
        {
            if (!_musicSource.isPlaying) return;

            if (fadeTime > 0f)
            {
                StartCoroutine(FadeOutMusic(fadeTime));
            }
            else
            {
                _musicSource.Stop();
                _musicSource.clip = null;
            }
        }

        public void SetMusicVolume(float volume)
        {
            // If using AudioMixer param
            if (_audioMixer)
            {
                _audioMixer.SetFloat("MusicVolume", LinearToDb(volume));
            }
            else
            {
                // direct volume
                _musicSource.volume = Mathf.Clamp01(volume);
            }
        }

        public bool IsMusicPlaying => _musicSource.isPlaying;

        // SFX
        public void PlaySFX(string sfxId, float volume = 1f, float pitch = 1f)
        {
            if (!_sfxDict.TryGetValue(sfxId, out var clip))
            {
                Debug.LogWarning($"[AudioManager] SFX '{sfxId}' not found.");
                return;
            }

            // Find an available AudioSource from the pool
            AudioSource source = GetAvailableSFXSource();
            if (source == null)
            {
                Debug.LogWarning("[AudioManager] No available SFX AudioSources in the pool.");
                return;
            }

            source.volume = volume;
            source.pitch = pitch;
            source.clip = clip;
            source.loop = false;
            source.Play();
        }

        public void SetSFXVolume(float volume)
        {
            if (_audioMixer)
            {
                _audioMixer.SetFloat("SFXVolume", LinearToDb(volume));
            }
            else
            {
                // If not using an AudioMixer, 
                // you might store this globally or set each pool source volume proportionally
                foreach (var src in _sfxPool)
                {
                    src.volume = volume;
                }
            }
        }

        public bool IsSFXPlaying(string sfxId)
        {
            // Check if any source in the pool is playing the given clip
            if (!_sfxDict.TryGetValue(sfxId, out var clip)) return false;

            foreach (var src in _sfxPool)
            {
                if (src.isPlaying && src.clip == clip)
                    return true;
            }
            return false;
        }

        // MASTER
        public void SetMasterVolume(float volume)
        {
            if (_audioMixer)
            {
                _audioMixer.SetFloat("MasterVolume", LinearToDb(volume));
            }
            else
            {
                // If not using AudioMixer, you'd handle a global master multiplier
                // for both musicSource.volume and each sfxSource in the pool
            }
        }

        #endregion

        #region Private Helpers

        private AudioSource GetAvailableSFXSource()
        {
            foreach (var src in _sfxPool)
            {
                if (!src.isPlaying)
                {
                    return src;
                }
            }
            // If all busy, return null (or override the oldest?)
            return null;
        }

        private float LinearToDb(float linear)
        {
            linear = Mathf.Clamp(linear, 0.0001f, 1f);
            return Mathf.Log10(linear) * 20f;
        }

        private IEnumerator FadeInMusic(AudioClip newClip, float fadeTime, bool loop)
        {
            // Simple fade out old music if any
            float startVolume = _musicSource.volume;

            // fade out
            while (_musicSource.volume > 0f)
            {
                _musicSource.volume -= Time.deltaTime * (startVolume / fadeTime);
                yield return null;
            }
            
            _musicSource.Stop();
            _musicSource.clip = newClip;
            _musicSource.loop = loop;
            _musicSource.Play();

            // fade in
            float t = 0f;
            while (t < fadeTime)
            {
                _musicSource.volume = Mathf.Lerp(0f, startVolume, t / fadeTime);
                t += Time.deltaTime;
                yield return null;
            }
            _musicSource.volume = startVolume;
        }

        private IEnumerator FadeOutMusic(float fadeTime)
        {
            float startVolume = _musicSource.volume;

            while (_musicSource.volume > 0f)
            {
                _musicSource.volume -= Time.deltaTime * (startVolume / fadeTime);
                yield return null;
            }

            _musicSource.Stop();
            _musicSource.clip = null;
            _musicSource.volume = startVolume;
        }

        #endregion
    }

}