using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class StartScreenUIManager : MonoBehaviour
{
    [SerializeField]
    SettingsScriptableObject Settings;

    [SerializeField]
    UIDocument SettingsButtonsUIDocument;
    UIDocument StartButtonsUIDocument;

    VisualElement StartScreenRoot;
    VisualElement SettingsRoot;

    // Start is called before the first frame update
    void Start()
    {
        // Setting up StartScreen button events
        StartButtonsUIDocument = GetComponent<UIDocument>();
        StartScreenRoot = StartButtonsUIDocument.rootVisualElement;
        StartScreenRoot.Q<Button>("StartButton").clicked += StartButton_clicked;
        StartScreenRoot.Q<Button>("SettingsButton").clicked += SettingsButton_clicked;
        StartScreenRoot.Q<Button>("ExitButton").clicked += () => Application.Quit();

        // Setting up Settings menu events.
        SettingsRoot = SettingsButtonsUIDocument.rootVisualElement;
        SettingsRoot.style.display = DisplayStyle.None;
        // Set values
        SettingsRoot.Q<SliderInt>("VolumeSlider").value = Settings.Volume;
        SettingsRoot.Q<SliderInt>("TextSpeedSlider").value = Settings.TextSpeed;
        // Set events
        SettingsRoot.Q<Button>("BackButton").clicked += BackButton_clicked;
        SettingsRoot.Q<SliderInt>("VolumeSlider").RegisterValueChangedCallback(OnVolumeSliderChangedEvent);
        SettingsRoot.Q<SliderInt>("TextSpeedSlider").RegisterValueChangedCallback(OnTextSpeedSliderChangedEvent);
    }

    // Start Screen Buttons
    private void StartButton_clicked()
    {
        // Start the game by loading the correct scene.
        // ToDo load game scene
    }

    private void SettingsButton_clicked()
    {
        // Hide the default UI, and show settigns UI.
        StartScreenRoot.style.display = DisplayStyle.None;
        SettingsRoot.style.display = DisplayStyle.Flex;
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
    private void BackButton_clicked()
    {
        // Hide Settings, and show start screen buttons.
        SettingsRoot.style.display = DisplayStyle.None;
        StartScreenRoot.style.display = DisplayStyle.Flex;
    }
}
