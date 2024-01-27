using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    private bool Open { get; set; } = false;

    // Start is called before the first frame update
    void Start()
    {
        OpenClose();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            OpenClose();
        }
    }

    private void OpenClose(float rotateSpeed = 2.0f) //0.5f seems like it would be good for slamming
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
            var newVector = new Vector3(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y + 90, transform.rotation.eulerAngles.z);
            transform.DORotate(newVector, rotateSpeed);
        }
        Open = !Open;
    }
}
