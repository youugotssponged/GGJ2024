using System;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class SoundManager : MonoBehaviour
{
    private static AudioSource audioSource;
    [SerializeField] private SettingsScriptableObject settingsSO;

    public void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        settingsSO.OnVolumeChanged += AdjustVolume;
        if (settingsSO != null)
        {
            audioSource.volume = settingsSO.Volume;
        }
    }
    
    public void StopPlaying() => audioSource.Stop();

    private void AdjustVolume(float currentVolume)
    {
        audioSource.volume = currentVolume;
    }

    public void StopPlayingAndRemoveClip()
    {
        audioSource.Stop();
        audioSource.clip = null;
    }
    
    public static void PlayTheme(string key, bool shouldLoop)
    {
        audioSource.Stop(); // Stop current playing clip on this Audio Source
        audioSource.clip = SoundContainer.GetAudioClipInternal(key);
        audioSource.loop = shouldLoop;
        audioSource.Play();
    }

    public static void PlaySound(string key)
    {
        var clip = SoundContainer.GetAudioClipInternal(key);
        if (clip != null)
        {
            audioSource.PlayOneShot(clip);
        }
    }

    public static void PlaySoundAt(string key, Vector3 position)
    {
        var clip = SoundContainer.GetAudioClipInternal(key);
        if (clip != null)
        {
            AudioSource.PlayClipAtPoint(clip, position);
        }
    }

    public void OnDestroy()
    {
        settingsSO.OnVolumeChanged -= AdjustVolume;
    }
}
