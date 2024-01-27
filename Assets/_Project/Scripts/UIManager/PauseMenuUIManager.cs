using System.Collections;
using System.Collections.Generic;
using UnityEngine;
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
        // ToDo fix null reference here.
        //Root.Q<SliderInt>("VolumeSlider").value = Settings.Volume;
        //Root.Q<SliderInt>("TextSpeedSlider").value = Settings.TextSpeed;

        // Set events
        SceneProperties.OnPausedChanged += (paused) => Root.style.display = paused ? DisplayStyle.Flex : DisplayStyle.None;
        Root.Q<Button>("ResumeButton").clicked += ResumeButton_clicked;
        Root.Q<SliderInt>("VolumeSlider").RegisterValueChangedCallback(OnVolumeSliderChangedEvent);
        Root.Q<SliderInt>("TextSpeedSlider").RegisterValueChangedCallback(OnTextSpeedSliderChangedEvent);
        Root.Q<Button>("ReturnToMenuButton").clicked += ReturnToMenuButton_clicked; ;
    }


    private void ResumeButton_clicked()
    {
        Debug.Log("Resume button clicked.");
        SceneProperties.Paused = !SceneProperties.Paused;
    }

    // Settings
    private void OnVolumeSliderChangedEvent(ChangeEvent<int> evt)
    {
        // Update Scriptable Object storing volume.
        Settings.Volume = evt.newValue;
    }
    private void OnTextSpeedSliderChangedEvent(ChangeEvent<int> evt)
    {
        // Update Scriptable Object storing volume.
        Settings.TextSpeed = evt.newValue;
    }
    private void ReturnToMenuButton_clicked()
    {
        // ToDo go back to start screen
    }
}
