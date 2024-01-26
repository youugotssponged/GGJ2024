using System;
using UnityEngine;

[CreateAssetMenu(fileName = "SettingsScriptableObjects", menuName = "ScriptableObjects/SettingsScriptableObjects", order = 1)]
public class SettingsScriptableObjects : ScriptableObject
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
            OnVolumeChanged.Invoke(volume);
        }
    }

    public delegate void TextSpeedChanged(int textSpeed);
    public event TextSpeedChanged OnTextSpeedChanged;
    [SerializeField]
    private int textSpeed = 10;
    public int TextSpeed
    {
        get { return textSpeed; }
        set
        {
            textSpeed = value;
            OnTextSpeedChanged.Invoke(textSpeed);
        }
    }

}
