using System;
using UnityEngine;
using UnityEngine.Audio;

namespace AudioSystem
{
    [Serializable]
    public class SoundData
    {
        public AudioClip Clip;
        public AudioMixerGroup MixerGroup;
        public bool Loop;
        public bool PlayOnAwake;
        public bool FrequentSound;

        public bool Mute;
        public bool BypassEffects;
        public bool BypassListenerEffects;
        public bool BypassReverbZones;

        public int Priority = 128;
        public float Volume = 1f;
        public float Pitch = 1f;
        public float PanStereo;
        public float SpatialBlend;
        public float ReverbZoneMix = 1f;
        public float DopplerLevel = 1f;
        public float Spread;

        public float MinDistance = 1f;
        public float MaxDistance = 500f;

        public bool IgnoreListenerVolume;
        public bool IgnoreListenerPause;

        public AudioRolloffMode RolloffMode = AudioRolloffMode.Logarithmic;
    }
}