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
        ScenePropertiesScriptableObject.OnSecondsRemainingChanged += SceneProperties_OnSecondsRemainingChanged;
        ScenePropertiesScriptableObject.OnCurrentScoreChanged += SceneProperties_OnCurrentScoreChanged;
        ScenePropertiesScriptableObject.OnRequiredScoreChanged += SceneProperties_OnRequiredScoreChanged;
    }

    private void SceneProperties_OnSecondsRemainingChanged()
    {
        TimerLabel.text = SceneProperties.SecondsRemaining.ToString();
    }
    private void SceneProperties_OnRequiredScoreChanged()
    {
        CurrentScoreLabel.text = SceneProperties.CurrentScore.ToString();
    }
    private void SceneProperties_OnCurrentScoreChanged()
    {
        RequiredScoreLabel.text = SceneProperties.RequiredScore.ToString();
    }
}
