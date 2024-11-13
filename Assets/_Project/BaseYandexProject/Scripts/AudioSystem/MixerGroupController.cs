using UnityEngine;
using UnityEngine.Audio;

public class MixerGroupController : MonoBehaviour
{
    [SerializeField] private AudioMixer _mixer;

    public void SetVolumeOfSFX(float volume)
    {
        _mixer.SetFloat("VolumeOfSFX", Mathf.Log10(volume) * 20);
    }
    
    public void SetVolumeOfMusic(float volume)
    {
        _mixer.SetFloat("VolumeOfMusic", Mathf.Log10(volume) * 20);
    }
}
