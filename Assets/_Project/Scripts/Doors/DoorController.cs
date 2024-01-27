using DG.Tweening;
using DG.Tweening.Plugins.Options;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    private bool Open { get; set; } = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            OpenClose();
            ChangeColour(Color.yellow);
        }
    }

    public void OpenClose(float rotateSpeed = 2.0f) //0.5f seems like it would be good for slamming
    {
        if (transform.rotation.eulerAngles.y % 90 != 0) return; //only opens/closes if not already
        if (Open)
        {
            //close
            var newVector = new Vector3(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y - 90, transform.rotation.eulerAngles.z);
            transform.DORotate(newVector, rotateSpeed);
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
            var newVector = new Vector3(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y + 90, transform.rotation.eulerAngles.z);
            transform.DORotate(newVector, rotateSpeed);
        }
        Open = !Open;
    }

    public void ChangeColour(Color colour)
    {
        var material = GetComponent<Renderer>().material;
        if (material != null)
            material.color = colour;
    }
}
