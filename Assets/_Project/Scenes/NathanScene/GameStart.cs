using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStart : MonoBehaviour
{
    [SerializeField]
    ScenePropertiesScriptableObject SceneProperties;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Game start");
        SceneProperties.SecondsRemaining = 200;
        SceneProperties.CurrentScore = 2;
        SceneProperties.RequiredScore = 7;
    }

}
