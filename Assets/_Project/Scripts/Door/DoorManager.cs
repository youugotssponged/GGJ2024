using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using UnityEngine;

public class DoorManager : MonoBehaviour
{
    private static List<Door> DoorsInScene;
    
    void Awake()
    {
        DoorsInScene = FindObjectsOfType<Door>().ToList();
    }

    public static void SetDoorColours(int quota)
    {
        List<int> assignedIndexes = new List<int>();
        // Randomly set difficuly doors - minimum
        for (int i = 0; i < quota; i++)
        {
            int doorNum = RandomNumberGenerator.GetInt32(0, DoorsInScene.Count);
            if (!assignedIndexes.Contains(doorNum))
            {
                int randomColour = RandomNumberGenerator.GetInt32(1, (int)DoorColours.RED + 1);
                DoorsInScene[doorNum].SetColour((DoorColours)randomColour);
                assignedIndexes.Add(doorNum);
            }
            else
            {
                i--;
            }
        }
        
        foreach (var door in DoorsInScene)
        {
            if (!assignedIndexes.Contains(DoorsInScene.IndexOf(door)))
            {
                int randomColour = RandomNumberGenerator.GetInt32(0, (int)DoorColours.RED + 1);
                door.SetColour((DoorColours)randomColour);
            }
        }
    }

    public static void SetAllUnvisited()
    {
        foreach (var door in DoorsInScene)
        {
            door.SetUnVisited();
        }
    } 
}
