using System;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static Action<DoorColours> DoorInteractionEvent;
    private Movement movement;
    public JokeManager jokeManager;

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
            if (door != null && Input.GetKeyDown(KeyCode.E))
            {
                door.OpenClose();
                movement.StopMovement();
                SignalJokeManagerEvent(door.SelfColour);
                
            }
        }
    }

    public void DoorCallBack(IDoorInteractable door)
    {
        movement.StartMovement();
        door.OpenClose();
    }
    
    
    
    private void SignalJokeManagerEvent(DoorColours doorColour)
    {
        DoorInteractionEvent?.Invoke(doorColour);
    }
}
