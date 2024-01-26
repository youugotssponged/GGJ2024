using System;
using UnityEngine;

[CreateAssetMenu(fileName = "ScenePropertiesScriptableObject", menuName = "ScriptableObjects/ScenePropertiesScriptableObject", order = 1)]
public class ScenePropertiesScriptableObject : ScriptableObject
{
    public delegate void SecondsRemainingChanged();
    public static event SecondsRemainingChanged OnSecondsRemainingChanged;
    [SerializeField]
    private int secondsRemaining = 0;
    public int SecondsRemaining
    {
        get { return secondsRemaining; }
        set 
        { 
            secondsRemaining = value;
            OnSecondsRemainingChanged.Invoke();
        }
    }

    public delegate void CurrentScoreChanged();
    public static event SecondsRemainingChanged OnCurrentScoreChanged;
    [SerializeField]
    private int currentScore = 0;
    public int CurrentScore
    {
        get { return currentScore; }
        set
        {
            currentScore = value;
            OnCurrentScoreChanged.Invoke();
        }
    }

    public delegate void RequiredScoreChanged();
    public static event SecondsRemainingChanged OnRequiredScoreChanged;
    [SerializeField]
    private int requiredScore = 0;
    public int RequiredScore
    {
        get { return requiredScore; }
        set
        {
            requiredScore = value;
            OnRequiredScoreChanged.Invoke();
        }
    }
}
