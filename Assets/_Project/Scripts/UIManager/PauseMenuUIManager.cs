using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class PauseMenuUIManager : MonoBehaviour
{
    [SerializeField]
    ScenePropertiesScriptableObject SceneProperties;
    [SerializeField]
    SettingsScriptableObject Settings;

    VisualElement Root;

    // Start is called before the first frame update
    void Start()
    {
        Root = GetComponent<UIDocument>().rootVisualElement;
        Root.style.display = DisplayStyle.None;

        // Set values
        Root.Q<Slider>("VolumeSlider").value = Settings.Volume;

        // Set events
        SceneProperties.OnPausedChanged += (paused) => Root.style.display = paused ? DisplayStyle.Flex : DisplayStyle.None;
        Root.Q<Button>("ResumeButton").clicked += ResumeButton_clicked;
        Root.Q<Slider>("VolumeSlider").RegisterValueChangedCallback(OnVolumeSliderChangedEvent);
        Root.Q<Button>("ReturnToMenuButton").clicked += ReturnToMenuButton_clicked; ;
    }


    private void ResumeButton_clicked()
    {
        Debug.Log("Resume button clicked.");
        SceneProperties.Paused = !SceneProperties.Paused;
        MouseLook.SetCursorLockState(true);
    }

    // Settings
    private void OnVolumeSliderChangedEvent(ChangeEvent<float> evt)
    {
        // Update Scriptable Object storing volume.
        Debug.Log(evt.newValue);
        Settings.Volume = evt.newValue;
    }
    private void ReturnToMenuButton_clicked()
    {
        SceneManager.LoadScene(1);
    }
}
