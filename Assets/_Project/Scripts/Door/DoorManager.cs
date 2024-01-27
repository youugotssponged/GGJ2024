using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class DoorManager : MonoBehaviour
{
    private List<Door> DoorsInScene;
    
    void Start()
    {
        DoorsInScene = FindObjectsOfType<Door>().ToList();
        SetDoorColours();
    }

    public void SetDoorColours()
    {
        foreach (var door in DoorsInScene)
        {
            door.SetColour(DoorColours.YELLOW);
        }
    }
}
