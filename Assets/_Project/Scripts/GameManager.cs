using System;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public ScenePropertiesScriptableObject ScenePropertiesSO;
    public GameObject TransitionCanvas; // For enabling / Disabling
    public Image TransitionPanel; // For fading in and out of black
    public TMP_Text WhiteboardQuotaText;
    public TMP_Text WhiteboardDayText;
    
    public GameObject Player;
    public Transform SpawnPointForPlayer;
    
    private int CurrentDay = 1;
    
    private void Start()
    {
        WhiteboardDayText.text = CurrentDay.ToString();
        TransitionPanel.color = new Color(0, 0, 0, 255);
        ScenePropertiesSO.OnZeroSecondsReached += CheckConditions;
        StartDay1();
    }

    public async void CheckConditions()
    {
        if (ScenePropertiesSO.CurrentScore >= ScenePropertiesSO.RequiredScore &&
            ScenePropertiesSO.SecondsRemaining == 0)
        {
            await FadeOut();
            CurrentDay++;
            switch (CurrentDay)
            {
                case 2:
                {
                    StartDay2();
                    break;
                }
                case 3:
                {
                    StartDay3();
                    break;
                }
                case 4:
                {
                    StartDay4();
                    break;
                }
                default:
                {
                    MouseLook.SetCursorLockState(false);
                    SceneManager.LoadScene(3);
                    break;
                }
            }
        }
    }
    
    private void LevelChange(int newQuota, int newSeconds)
    {
        DoorManager.SetAllUnvisited();
        DoorManager.SetDoorColours(newQuota);
        ScenePropertiesSO.CurrentScore = 0;
        ScenePropertiesSO.RequiredScore = newQuota;
        ScenePropertiesSO.SecondsRemaining = newSeconds;
        Player.transform.position = SpawnPointForPlayer.position;
        WhiteboardQuotaText.text = newQuota.ToString();
        WhiteboardDayText.text = CurrentDay.ToString();
    }
    
    public void StartDay1()
    {
        LevelChange(5, 55);
        SoundManager.PlayTheme("LevelTheme1", true);
        FadeInVoid();
    }

    public async void StartDay2()
    {
        LevelChange(5, 55);
        SoundManager.PlayTheme("LevelTheme2", true);
        await FadeIn();
    }

    public async void StartDay3()
    {
        LevelChange(5, 55);
        SoundManager.PlayTheme("LevelTheme3", true);
        await FadeIn();
    }

    public async void StartDay4()
    { 
        LevelChange(5, 40);
        SoundManager.PlayTheme("LevelTheme4", true);
        await FadeIn();
    }

    public async Task FadeIn() // Alpha --
    {
        for (float i = 1f; i >= 0f; i -= Time.deltaTime)
        {
            if (TransitionPanel != null)
            {
                TransitionPanel.color = new Color(0, 0, 0, i);
            }

            await Task.Delay(10);
        }
        TransitionCanvas.SetActive(false);
    }
    
    public async void FadeInVoid() // Alpha --
    {
        for (float i = 1f; i >= 0f; i -= Time.deltaTime)
        {
            if (TransitionPanel != null)
            {
                TransitionPanel.color = new Color(0, 0, 0, i);
            }

            await Task.Delay(10);
        }
        TransitionCanvas.SetActive(false);
    }

    public async Task FadeOut() // Alpha ++
    {
        TransitionCanvas.SetActive(true);
        for (float i = 0f; i <= 1f; i += Time.deltaTime)
        {
            if (TransitionPanel != null)
            {
                TransitionPanel.color = new Color(0, 0, 0, i);
            }

            await Task.Delay(10);
        }
    }

    public void OnDestroy()
    {
        ScenePropertiesSO.OnZeroSecondsReached -= CheckConditions;
    }
}
