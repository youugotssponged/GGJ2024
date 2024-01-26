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
    private void Awake()
    {
        // Get UI elements that will need to be updated.
        Root = GetComponent<UIDocument>().rootVisualElement;
        TimerLabel = Root.Q<Label>("SecondsRemainingLabel");
        CurrentScoreLabel = Root.Q<Label>("CurrentScoreLabel");
        RequiredScoreLabel = Root.Q<Label>("RequiredScoreLabel");

        Debug.Log("Subscribing");
        // Sub to events for when propeties in scriptable object change.
        SceneProperties.OnSecondsRemainingChanged += (timeRemaining) => { TimerLabel.text = timeRemaining.ToString(); Debug.Log("Timer Triggered"); };
        SceneProperties.OnCurrentScoreChanged += (currentScore) => { RequiredScoreLabel.text = currentScore.ToString(); Debug.Log("Score Triggered"); };
        SceneProperties.OnRequiredScoreChanged += (requiredScore) => { CurrentScoreLabel.text = requiredScore.ToString(); Debug.Log("Quota Triggered"); };
    }
    void Start()
    {
        
    }
}
