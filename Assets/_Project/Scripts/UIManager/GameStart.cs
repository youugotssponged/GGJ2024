using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;

public class GameStart : MonoBehaviour
{
    [SerializeField]
    ScenePropertiesScriptableObject SceneProperties;

    CursorLockMode PrePause_CursorLockState = CursorLockMode.None;
    bool PrePause_AllowedToMove = true;
    bool PrePause_StopMouseMovement = false;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Game start");
        SceneProperties.OnPausedChanged += OnPausedChanged;
        SceneProperties.Paused = false;
    }

    private void OnPausedChanged(bool paused)
    {
        Debug.Log("Pause Changed in game start");
        if (SceneProperties.Paused)
        {
            Time.timeScale = 0;
            PrePause_CursorLockState = Cursor.lockState;
            PrePause_AllowedToMove = Movement.AllowedToMove;
            PrePause_StopMouseMovement = MouseLook.StopMouseMovement;

            MouseLook.SetCursorLockState(false);
            Movement.StopMovement();
            MouseLook.SetMouseMovementOff();
        }
        else
        {
            Time.timeScale = 1;
            if (PrePause_CursorLockState == CursorLockMode.Locked)
            {
                MouseLook.SetCursorLockState(true);
            }
            else
            {
                MouseLook.SetCursorLockState(false);
            }

            if (PrePause_AllowedToMove)
            {
                Movement.StartMovement();
            }
            else
            {
                Movement.StopMovement();
            }

            if (PrePause_StopMouseMovement)
            {
                MouseLook.SetMouseMovementOff();
            }
            else
            {
                MouseLook.SetMouseMovementOn();
            }
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
