using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class StartScreenUIManager : MonoBehaviour
{
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
        StartScreenRoot.Q<Button>("ExitButton").clicked += ExitButton_clicked;

        // Setting up Settings menu events.
        SettingsRoot = SettingsButtonsUIDocument.rootVisualElement;
        SettingsRoot.style.display = DisplayStyle.None;
        SettingsRoot.Q<Button>("BackButton").clicked += BackButton_clicked;
    }


    private void StartButton_clicked()
    {
        // Start the game by loading the correct scene.
    }

    private void SettingsButton_clicked()
    {
        // Hide the default UI, and show settigns UI.
        StartScreenRoot.style.display = DisplayStyle.None;
        SettingsRoot.style.display = DisplayStyle.Flex;
    }

    private void ExitButton_clicked()
    {
        // Close the game
        Application.Quit();
    }
    private void BackButton_clicked()
    {
        // Hide Settings, and show start screen buttons.
        SettingsRoot.style.display = DisplayStyle.None;
        StartScreenRoot.style.display = DisplayStyle.Flex;
    }
}
