using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class JokeManager : MonoBehaviour
{
    bool OptionSelected = false;
    int SelectedOption = 0;

    [SerializeField]
    ScenePropertiesScriptableObject SceneProperties;
    [SerializeField]
    UIDocument JokeOptionsUIDocument;
    VisualElement Root;
    Label SetupLabel;
    Button Option1Button;
    Button Option2Button;
    Button Option3Button;
    // Start is called before the first frame update
    void Start()
    {
        Root = JokeOptionsUIDocument.rootVisualElement;
        Root.style.display = DisplayStyle.None;

        SetupLabel = Root.Q<Label>("SetupLabel");
        Option1Button = Root.Q<Button>("Option1Button") ;
        Option2Button = Root.Q<Button>("Option2Button") ;
        Option3Button = Root.Q<Button>("Option3Button");

        Option1Button.clicked += Option1Button_clicked;
        Option2Button.clicked += Option2Button_clicked;
        Option3Button.clicked += Option3Button_clicked;
    }

    private void Option1Button_clicked()
    {
        SelectedOption = 1;
        OptionSelected = true;
    }
    private void Option2Button_clicked()
    {
        SelectedOption = 2;
        OptionSelected = true;
    }
    private void Option3Button_clicked()
    {
        SelectedOption = 3;
        OptionSelected = true;
    }

    public IEnumerator StartJokeManager(int numberOfJokes)
    {
        Debug.Log("Showing Joke.");
        bool succeeded = true;
        // Load in number of jokes requried
        string setup = "This is the setup";
        string option1 = "This is option 1.";
        string option2 = "This is option 2.";
        string option3 = "This is option 3.";
        int correctResponse = 2;
        for (int i = 0; i < numberOfJokes; i++)
        {
            Debug.Log("Load Joke");
            SelectedOption = 0;
            OptionSelected = false;
            // Load in setup and options to UI
            SetupLabel.text = setup;
            Option1Button.text = option1;
            Option2Button.text = option2;
            Option3Button.text = option3;

            Root.style.display = DisplayStyle.Flex;

            // wait for selection by the player
            
            while (!OptionSelected)
            {
                yield return new WaitForSeconds(0.1f);
            }

            // Check if the correct option was selected.
            if (SelectedOption == correctResponse)
            {
                // Continue/Succeed if correct
                // ToDo play laughing sound
                Debug.Log("Correct Answer");
                Root.style.display = DisplayStyle.None;
                continue;
            }
            else
            {
                // ToDo play angry sound
                Debug.Log("Wrong asnwer");
                succeeded = false;
                Root.style.display = DisplayStyle.None;
                break;
            }
            // End if wrong
        }

        if (succeeded)
        {
            // Update score
            SceneProperties.CurrentScore++;
        }

        // Hide and reset UI
        // Return control to player
    }
}
