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
        SceneProperties.SecondsRemaining = 90;
        SceneProperties.CurrentScore = 0;
        SceneProperties.RequiredScore = 5;
        SceneProperties.OnPausedChanged += OnPausedChanged;
    }

    private void OnPausedChanged(bool paused)
    {
        if (SceneProperties.Paused)
            Time.timeScale = 0;
        else
            Time.timeScale = 1;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneProperties.Paused = !SceneProperties.Paused;
        }
    }

}
