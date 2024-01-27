using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTempScript : MonoBehaviour
{
    [SerializeField]
    JokeManager JokeManager;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            StartCoroutine(JokeManager.StartJokeManager(3));
        }
    }
}
