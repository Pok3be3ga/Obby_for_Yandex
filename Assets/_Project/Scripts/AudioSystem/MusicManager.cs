using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

namespace AudioSystem
{
    [RequireComponent(typeof(MusicManager))]
    public class MusicManager : PersistentSingleton<MonoBehaviour>
    {
        private const float _crossFadeTime = 1.0f;
        private float _fading;
        private AudioSource _current;
        private AudioSource _previous;
        private readonly Queue<AudioClip> _playlist = new();

        [SerializeField] private List<AudioClip> _initialPlaylist;
        [SerializeField] private AudioMixerGroup _musicMixerGroup;

        void Start()
        {
            foreach (var clip in _initialPlaylist)
            {
                AddToPlaylist(clip);
            }
        }

        public void AddToPlaylist(AudioClip clip)
        {
            _playlist.Enqueue(clip);
            if (_current == null && _previous == null)
            {
                PlayNextTrack();
            }
        }

        public void Clear() => _playlist.Clear();

        public void PlayNextTrack()
        {
            if (_playlist.TryDequeue(out AudioClip nextTrack))
            {
                Play(nextTrack);
            }
        }

        public void Play(AudioClip clip)
        {
            if (_current && _current.clip == clip) return;

            if (_previous)
            {
                Destroy(_previous);
                _previous = null;
            }

            _previous = _current;

            _current = gameObject.GetOrAdd<AudioSource>();
            _current.clip = clip;
            _current.outputAudioMixerGroup = _musicMixerGroup; // Set mixer group
            _current.loop = false; // For playlist functionality, we want tracks to play once
            _current.volume = 0;
            _current.bypassListenerEffects = true;
            _current.Play();

            _fading = 0.001f;
        }

        void Update()
        {
            HandleCrossFade();

            if (_current && !_current.isPlaying && _playlist.Count > 0)
            {
                PlayNextTrack();
            }
        }

        void HandleCrossFade()
        {
            if (_fading <= 0f) return;

            _fading += Time.deltaTime;

            float fraction = Mathf.Clamp01(_fading / _crossFadeTime);

            // Logarithmic fade
            float logFraction = fraction.ToLogarithmicFraction();

            if (_previous) _previous.volume = 1.0f - logFraction;
            if (_current) _current.volume = logFraction;

            if (fraction >= 1)
            {
                _fading = 0.0f;
                if (_previous)
                {
                    Destroy(_previous);
                    _previous = null;
                }
            }
        }
    }
}
