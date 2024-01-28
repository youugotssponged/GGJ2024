using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class TimerManager : MonoBehaviour
{
    [SerializeField]
    ScenePropertiesScriptableObject SceneProperties;
    bool ContinueTimer = true;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(ProgressTimer());
    }

    IEnumerator ProgressTimer()
    {
        // Progress the timer every second
        while (ContinueTimer)
        {
            if (SceneProperties.SecondsRemaining <= 0)
            {
                if (SceneProperties.CurrentScore < SceneProperties.RequiredScore)
                {
                    ContinueTimer = false;
                    MouseLook.SetCursorLockState(false);
                    SceneManager.LoadScene(4);
                }
                else
                {
                    // Trigger transition manager to next level/win screen
                    // ToDo
                }
            }
            else
            {
                SceneProperties.SecondsRemaining--;
            }
            yield return new WaitForSeconds(1f);
        }
    }

}
