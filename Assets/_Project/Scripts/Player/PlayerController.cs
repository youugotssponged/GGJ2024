using System;
using System.Security.Cryptography;
using UnityEngine;
using Random = System.Random;

public class PlayerController : MonoBehaviour
{
    public static Action<DoorColours> DoorInteractionEvent;
    private Movement movement;
    public JokeManager jokeManager;
    public JokeScriptableObject jokeSO;
    private bool inJokeSession = false;
    private IDoorInteractable CurrentDoor = null;

    private void Start()
    {
        if (movement == null)
        {
            movement = GetComponent<Movement>();
        }
    }
    
    private void Update()
    {
        Debug.DrawRay(transform.position, Vector3.forward, Color.red);
        if(Physics.Raycast(transform.position, transform.forward, out RaycastHit hit, 60.0f))
        {
            var door = hit.collider.GetComponent<IDoorInteractable>();
            if (door != null && Input.GetKeyDown(KeyCode.E) 
                             && !inJokeSession 
                             && !door.Visited
                             && CurrentDoor == null
                             && door.SelfColour != DoorColours.GRAY)
            {

                int knockSoundSelection = RandomNumberGenerator.GetInt32(1, 4);

                switch (knockSoundSelection)
                {
                    case 1:
                        SoundManager.PlaySoundAt("Knock", transform.position);
                        break;
                    case 2:
                        SoundManager.PlaySoundAt("Doorbell", transform.position);
                        break;
                    case 3:
                        SoundManager.PlaySoundAt("Doorbell2", transform.position);
                        break;
                }
                
                door.OpenClose();
                Movement.StopMovement();
                MouseLook.SetMouseMovementOff();
                inJokeSession = true;
                StartCoroutine(jokeManager.StartJokeManager((int)door.SelfColour));
                jokeSO.OnJokeFinished += ResumePlayer;
                CurrentDoor = door;
                MouseLook.SetCursorLockState(false);
            }
        }
    }

    private void ResumePlayer()
    {
        MouseLook.SetCursorLockState(true);
        MouseLook.SetMouseMovementOn();
        Movement.StartMovement();
        CurrentDoor.OpenClose();
        CurrentDoor.SetVisited();
        jokeSO.OnJokeFinished -= ResumePlayer;
        
        inJokeSession = false;
        CurrentDoor = null;
    }
}

