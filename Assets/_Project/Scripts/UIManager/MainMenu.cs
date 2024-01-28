using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class MainMenu : MonoBehaviour
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
        SettingsRoot.Q<Slider>("VolumeSlider").value = Settings.Volume;
        // Set events
        SettingsRoot.Q<Button>("BackButton").clicked += BackButton_clicked;
        SettingsRoot.Q<Slider>("VolumeSlider").RegisterValueChangedCallback(OnVolumeSliderChangedEvent);
    }

    // Start Screen Buttons
    private void StartButton_clicked()
    {
        // Start the game by loading the correct scene.
        SceneManager.LoadScene(2);
    }

    private void SettingsButton_clicked()
    {
        // Hide the default UI, and show settigns UI.
        StartScreenRoot.style.display = DisplayStyle.None;
        SettingsRoot.style.display = DisplayStyle.Flex;
    }

    // Settings
    private void OnVolumeSliderChangedEvent(ChangeEvent<float> evt)
    {
        // Update Scriptable Object storing volume.
        Settings.Volume = evt.newValue;
    }
    private void BackButton_clicked()
    {
        // Hide Settings, and show start screen buttons.
        SettingsRoot.style.display = DisplayStyle.None;
        StartScreenRoot.style.display = DisplayStyle.Flex;
    }
}
