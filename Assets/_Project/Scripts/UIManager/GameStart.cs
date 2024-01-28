using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;

public class GameStart : MonoBehaviour
{
    [SerializeField]
    ScenePropertiesScriptableObject SceneProperties;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Game start");
        SceneProperties.OnPausedChanged += OnPausedChanged;
        SceneProperties.Paused = false;
    }

    private void OnPausedChanged(bool paused)
    {
        if (SceneProperties.Paused)
        {
            Time.timeScale = 0;
            MouseLook.SetCursorLockState(false);
            Movement.StopMovement();
            MouseLook.SetMouseMovementOff();
        }
        else
        {
            Time.timeScale = 1;
            MouseLook.SetCursorLockState(true);
            Movement.StartMovement();
            MouseLook.SetMouseMovementOn();
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneProperties.Paused = !SceneProperties.Paused;
        }
    }

}
