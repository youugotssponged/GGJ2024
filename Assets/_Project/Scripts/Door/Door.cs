using DG.Tweening;
using System.Linq;
using UnityEngine;
using Debug = UnityEngine.Debug;

public enum DoorColours
{
    BROWN = 0,
    GREEN = 1,
    YELLOW = 2,
    RED = 3,
}

public interface IDoorInteractable
{
    public bool Visited { get; }
    public void SetVisited();
    public DoorColours SelfColour { get; }
    public void SetColour(DoorColours doorColour);
    public void OpenClose(float rotateSpeed = 2.0f);
}

public class Door : MonoBehaviour, IDoorInteractable
{
    private DoorColours _selfColour;
    public DoorColours SelfColour => _selfColour; // Public getter

    private bool _visited;
    public bool Visited => _visited;

    public void SetVisited() => _visited = true;

    private bool Open { get; set; } = false;

    public void SetColour(DoorColours doorColour)
    {
        Color color = (doorColour) switch
        {
            DoorColours.YELLOW => Color.yellow,
            DoorColours.GREEN => Color.green,
            DoorColours.RED => Color.red,
            DoorColours.BROWN => new Color(160,82,45),
            _ => new Color(160,82,45)
        };
        
        _selfColour = doorColour;
        ChangeColour(color);
    }

    public void OpenClose(float rotateSpeed = 2.0f) //0.5f seems like it would be good for slamming
    {
        if (Open)
        {
            //close
            var newVector = new Vector3(0, 0, 90);
            transform.DOLocalRotate(newVector, rotateSpeed);
        } else
        {
            //open
            var children = GetComponentsInChildren<Transform>();
            var handle = children.FirstOrDefault(x => x.gameObject.name == "Handle");
            if (handle != null)
            {
                Debug.Log(handle.gameObject.name);
                handle.transform.DOLocalRotate(new Vector3(0, -30, 0), 0.33f).OnComplete(() =>
                {
                    handle.transform.DOLocalRotate(new Vector3(0, 0, 0), 0.33f);
                });
            }
            var newVector = new Vector3(0, 90, 90);
            transform.DOLocalRotate(newVector, rotateSpeed);
        }
        Open = !Open;
    }

    private void ChangeColour(Color colour)
    {
        var material = GetComponent<Renderer>().material;
        if (material != null)
            material.color = colour;
    }
}
