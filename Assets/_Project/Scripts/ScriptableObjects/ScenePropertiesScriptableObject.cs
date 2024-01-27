using System;
using UnityEngine;

[CreateAssetMenu(fileName = "ScenePropertiesScriptableObject", menuName = "ScriptableObjects/ScenePropertiesScriptableObject", order = 1)]
public class ScenePropertiesScriptableObject : ScriptableObject
{
    public delegate void PausedChanged(bool paused);
    public event PausedChanged OnPausedChanged;
    [SerializeField]
    private bool paused = false;
    public bool Paused
    {
        get { return paused; }
        set
        {
            paused = value;
            OnPausedChanged?.Invoke(paused);
        }
    }

    public delegate void SecondsRemainingChanged(int timeRemaining);
    public event SecondsRemainingChanged OnSecondsRemainingChanged;
    [SerializeField]
    private int secondsRemaining = 0;
    public int SecondsRemaining
    {
        get { return secondsRemaining; }
        set 
        { 
            secondsRemaining = value;
            OnSecondsRemainingChanged?.Invoke(secondsRemaining);
        }
    }

    public delegate void CurrentScoreChanged(int currentScore);
    public event CurrentScoreChanged OnCurrentScoreChanged;
    [SerializeField]
    private int currentScore = 0;
    public int CurrentScore
    {
        get { return currentScore; }
        set
        {
            currentScore = value;
            OnCurrentScoreChanged?.Invoke(currentScore);
        }
    }

    public delegate void RequiredScoreChanged(int requiredScore);
    public event RequiredScoreChanged OnRequiredScoreChanged;
    [SerializeField]
    private int requiredScore = 0;
    public int RequiredScore
    {
        get { return requiredScore; }
        set
        {
            requiredScore = value;
            OnRequiredScoreChanged?.Invoke(requiredScore);
        }
    }
}
