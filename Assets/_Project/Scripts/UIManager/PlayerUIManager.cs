using System.Xml.Serialization;
using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerUIManager : MonoBehaviour
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

        // Sub to events for when propeties in scriptable object change.
        SceneProperties.OnSecondsRemainingChanged += (timeRemaining) => TimerLabel.text = timeRemaining.ToString();
        SceneProperties.OnCurrentScoreChanged += (currentScore) => CurrentScoreLabel.text = currentScore.ToString();
        SceneProperties.OnRequiredScoreChanged += (requiredScore) => RequiredScoreLabel.text = requiredScore.ToString();
        SceneProperties.OnPausedChanged += (paused) => Root.style.display = paused ? DisplayStyle.None : DisplayStyle.Flex;
    }
}
