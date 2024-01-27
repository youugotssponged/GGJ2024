using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class AudioClipKeyPair
{
    public string key;
    public AudioClip value;
}

public class SoundContainer : MonoBehaviour
{
    [SerializeField] private List<AudioClipKeyPair> AudioSources;
     
    private static Dictionary<string, AudioClip> soundDict;
    
    private void Awake()
    {
        soundDict = new Dictionary<string, AudioClip>();
        foreach(AudioClipKeyPair entry in AudioSources)
        {
            soundDict.Add(entry.key, entry.value);
        }
    }

    public static AudioClip GetAudioClipInternal(string key)
    {
        soundDict.TryGetValue(key, out var clip);
        return clip;
    }
}
