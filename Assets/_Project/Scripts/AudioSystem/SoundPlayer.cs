using UnityEngine;

namespace AudioSystem
{
    public class SoundPlayer : MonoBehaviour
    {
        [SerializeField] private SoundData soundData;
        [SerializeField] private Vector3 soundPosition;
        [SerializeField] private bool _playSoundInUpdate = false;

        private float _timeSinceLastPlay = 0f;
        private float _playInterval = 0.12f;

        void Start()
        {
            PlaySound();
        }

        private void Update()
        {
            if (_playSoundInUpdate)
            {
                _timeSinceLastPlay += Time.deltaTime;

                if (_timeSinceLastPlay >= _playInterval)
                {
                    PlaySound();
                    _timeSinceLastPlay = 0f;
                }
            }
        }

        public void PlaySound()
        {
            if (SoundManager.Instance != null && soundData != null)
            {
                SoundBuilder soundBuilder = SoundManager.Instance.CreateSoundBuilder();
                soundBuilder.WithPosition(soundPosition)
                             .WithRandomPitch()
                             .Play(soundData);
            }
            else
            {
                Debug.LogWarning("SoundManager или SoundData не установлены!");
            }
        }

        [ContextMenu("Play Sound")]
        public void PlaySoundFromInspector()
        {
            PlaySound();
        }
    }
}