using System;
using UnityEngine;

[CreateAssetMenu(fileName = "SettingsScriptableObject", menuName = "ScriptableObjects/SettingsScriptableObject", order = 1)]
public class SettingsScriptableObject : ScriptableObject
{

    public delegate void VolumeChanged(int volume);
    public event VolumeChanged OnVolumeChanged;
    [SerializeField]
    private int volume = 100;
    public int Volume
    {
        get { return volume; } 
        set
        {
            volume = value;
            OnVolumeChanged?.Invoke(volume);
        }
    }
}
