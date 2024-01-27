using System;
using UnityEngine;

[CreateAssetMenu(fileName = "JokeScriptableObject", menuName = "ScriptableObjects/JokeScriptableObject", order = 1)]
public class JokeScriptableObject : ScriptableObject
{
    [SerializeField]
    private string setup = string.Empty;
    public string Setup
    {
        get { return setup; }
        set
        {
            setup = value;
        }
    }

    [SerializeField]
    private string option1 = string.Empty;
    public string Option1
    {
        get { return option1; }
        set
        {
            option1 = value;
        }
    }

    [SerializeField]
    private string option2 = string.Empty;
    public string Option2
    {
        get { return option2; }
        set
        {
            option2 = value;
        }
    }

    [SerializeField]
    private string option3 = string.Empty;
    public string Option3
    {
        get { return option3; }
        set
        {
            option3 = value;
        }
    }

    [SerializeField]
    private int correctOption = -1;
    public int CorrectOption
    {
        get { return correctOption; }
        set
        {
            correctOption = value;
        }
    }

    [SerializeField]
    private string correctResponse = string.Empty;
    public string CorrectResponse
    {
        get { return correctResponse; }
        set
        {
            correctResponse = value;
        }
    }

    [SerializeField]
    private string incorrectResponse = string.Empty;
    public string IncorrectResponse
    {
        get { return incorrectResponse; }
        set
        {
            incorrectResponse = value;
        }
    }
}
