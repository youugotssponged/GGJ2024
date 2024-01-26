using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
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
            yield return new WaitForSeconds(1f);
            SceneProperties.SecondsRemaining--;
            Debug.Log(SceneProperties.SecondsRemaining);
        }
    }

}
