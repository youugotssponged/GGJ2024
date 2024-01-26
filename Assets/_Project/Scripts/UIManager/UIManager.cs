using System.Xml.Serialization;
using UnityEngine;
using UnityEngine.UIElements;

public class UIManager : MonoBehaviour
{
    // UI Elements
    VisualElement Root;
    Label TimerLabel;
    Label CurrentScoreLabel;
    Label RequiredScoreLabel;

    [SerializeField]
    ScenePropertiesScriptableObject SceneProperties;
    // Start is called before the first frame update
    void Start()
    {
        // Get UI elements that will need to be updated.
        Root = GetComponent<UIDocument>().rootVisualElement;
        TimerLabel = Root.Q<Label>("SecondsRemainingLabel");
        CurrentScoreLabel = Root.Q<Label>("CurrentScoreLabel");
        RequiredScoreLabel = Root.Q<Label>("RequiredScoreLabel");

        // Sub to events for when propeties in scriptable object change.
        SceneProperties.OnSecondsRemainingChanged += (timeRemaining) => TimerLabel.text = timeRemaining.ToString();
        SceneProperties.OnCurrentScoreChanged += (currentScore) => RequiredScoreLabel.text = currentScore.ToString();
        SceneProperties.OnRequiredScoreChanged += (requiredScore) => CurrentScoreLabel.text = requiredScore.ToString();
    }
}
