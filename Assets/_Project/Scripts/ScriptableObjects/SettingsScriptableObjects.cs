using System;
using UnityEngine;

[CreateAssetMenu(fileName = "SettingsScriptableObjects", menuName = "ScriptableObjects/SettingsScriptableObjects", order = 1)]
public class SettingsScriptableObjects : ScriptableObject
{

    public delegate void VolumeChanged();
    public static event VolumeChanged OnVolumeChanged;
    [SerializeField]
    private int volume = 100;
    public int Volume
    {
        get { return volume; } 
        set
        {
            volume = value;
            OnVolumeChanged.Invoke();
        }
    }

    public delegate void TextSpeedChanged();
    public static event TextSpeedChanged OnTextSpeedChanged;
    [SerializeField]
    private int textSpeed = 10;
    public int TextSpeed
    {
        get { return textSpeed; }
        set
        {
            textSpeed = value;
            OnTextSpeedChanged.Invoke();
        }
    }

}
