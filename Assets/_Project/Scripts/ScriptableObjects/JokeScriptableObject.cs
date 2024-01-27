using System;
using UnityEngine;

[CreateAssetMenu(fileName = "JokeScriptableObject", menuName = "ScriptableObjects/JokeScriptableObject", order = 1)]
public class JokeScriptableObject : ScriptableObject
{
    public Action OnJokeFinished;
}
