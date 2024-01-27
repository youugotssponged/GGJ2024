using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class SplashScreenTransitionHandler : MonoBehaviour
{
    public RawImage SplashScreenVideo;
    public int MainMenuSceneIndex;
    public int SplashScreenEndingInSeconds;
    
    // Start is called before the first frame update
    void Start()
    {
        if (SplashScreenVideo == null)
        {
            SplashScreenVideo = GetComponent<RawImage>();
        }
        
        StartCoroutine(WaitForVideoToEnd());
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            SkipScene();
        }
    }

    private void SkipScene()
    {
        SceneManager.LoadScene(MainMenuSceneIndex, LoadSceneMode.Single);
    }

    private IEnumerator WaitForVideoToEnd()
    {
        yield return new WaitForSeconds(SplashScreenEndingInSeconds);
        SkipScene();
    }
}
