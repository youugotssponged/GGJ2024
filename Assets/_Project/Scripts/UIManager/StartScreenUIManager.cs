using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class StartScreenUIManager : MonoBehaviour
{

    // UI Elements
    VisualElement Root;
    // Start is called before the first frame update
    void Start()
    {
        Root = GetComponent<UIDocument>().rootVisualElement;
        Root.Q<Button>("StartButton").clicked += StartButton_clicked;
        Root.Q<Button>("SettingsButton").clicked += SettingsButton_clicked;
        Root.Q<Button>("ExitButton").clicked += ExitButton_clicked;
    }

    private void StartButton_clicked()
    {
        // Start the game by loading the correct scene.
    }

    private void SettingsButton_clicked()
    {
        // Hide the default UI, and show settigns UI.
    }

    private void ExitButton_clicked()
    {
        // Close the game
        Application.Quit();
    }
}
