using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Xml.Serialization;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

[XmlRoot(ElementName = "Joke")]
public class Joke
{
    public string Setup;
    public string Option1;
    public string Option2;
    public string Option3;
    public int CorrectAnswer;
}

public class JokeManager : MonoBehaviour
{
    public JokeScriptableObject JokeSO;
    
    bool OptionSelected = false;
    int SelectedOption = 0;
    List<Joke> JokeList;

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

        LoadJokes();
    }
    void LoadJokes()
    {
        string jokesXmlPath = $@"{Application.streamingAssetsPath}\Jokes.xml";
        XmlSerializer serializer = new XmlSerializer(typeof(List<Joke>));

        using (FileStream fs = new FileStream(jokesXmlPath, FileMode.Open))
        {
            JokeList = (List<Joke>)serializer.Deserialize(fs);
        }
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
        List<Joke> jokesToShow = new List<Joke>();

        for (int i = 0; i < numberOfJokes; i++)
        {
            // Get random joke from full Joke List
            int randomNumber = Random.Range(0, JokeList.Count - 1);
            Debug.Log(randomNumber);
            Joke joke = JokeList[randomNumber];

            // Check the joke is not already selected
            if (jokesToShow.Contains(joke))
            {
                // The joke is already selected to be shown, repeat and pick another
                i--;
                continue;
            }
            jokesToShow.Add(joke);
        }

        for (int i = 0; i < numberOfJokes; i++)
        {
            Debug.Log("Load Joke");
            SelectedOption = 0;
            OptionSelected = false;
            // Load in setup and options to UI
            SetupLabel.text = jokesToShow[i].Setup;
            Option1Button.text = jokesToShow[i].Option1;
            Option2Button.text = jokesToShow[i].Option2;
            Option3Button.text = jokesToShow[i].Option3;

            Root.style.display = DisplayStyle.Flex;

            // wait for selection by the player
            
            while (!OptionSelected)
            {
                yield return new WaitForSeconds(0.1f);
            }

            // Check if the correct option was selected.
            if (SelectedOption == jokesToShow[i].CorrectAnswer)
            {
                // Continue/Succeed if correct
                Debug.Log("Correct Answer");
                continue;
            }
            else
            {
                Debug.Log("Wrong asnwer");
                succeeded = false;
                break;
            }
            // End if wrong
        }

        if (succeeded)
        {
            int happyPersonSelection = RandomNumberGenerator.GetInt32(1, 5);

            switch (happyPersonSelection)
            {
                case 1:
                    SoundManager.PlaySoundAt("Laugh", transform.position);
                    break;
                case 2:
                    SoundManager.PlaySoundAt("Laugh2", transform.position);
                    break;
                case 3:
                    SoundManager.PlaySoundAt("Laugh3", transform.position);
                    break;
                case 4:
                    SoundManager.PlaySoundAt("Laugh4", transform.position);
                    break;
            }
            
            // Update score
            SceneProperties.CurrentScore++;
        }
        else
        {
            int angrySound = RandomNumberGenerator.GetInt32(1, 3);
            switch (angrySound)
            {
                case 1:
                    SoundManager.PlaySoundAt("AngryPerson", transform.position);
                    break;
                case 2:
                    SoundManager.PlaySoundAt("AngryPerson2", transform.position);
                    break;
            }
        }

        // Hide and reset UI
        Root.style.display = DisplayStyle.None;
        // Return control to player
        JokeSO.OnJokeFinished?.Invoke();
    }
}
