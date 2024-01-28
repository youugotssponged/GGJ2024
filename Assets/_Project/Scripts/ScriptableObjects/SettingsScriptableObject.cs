using System;
using UnityEngine;

[CreateAssetMenu(fileName = "SettingsScriptableObject", menuName = "ScriptableObjects/SettingsScriptableObject", order = 1)]
public class SettingsScriptableObject : ScriptableObject
{

    public delegate void VolumeChanged(float volume);
    public event VolumeChanged OnVolumeChanged;
    [SerializeField]
    private float volume = 1;
    public float Volume
    {
        get { return volume; } 
        set
        {
            volume = value;
            OnVolumeChanged?.Invoke(volume);
        }
    }
}
