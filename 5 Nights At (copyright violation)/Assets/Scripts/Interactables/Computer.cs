using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Computer : Interactable
{
    CameraScript cameraScript;
    void Start()
    {
        cameraScript = GameObject.FindWithTag("SecurityCam").GetComponent<CameraScript>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    protected override void Interact()
    {
        cameraScript.CameraActivate();
        Debug.Log("interacted with " + gameObject.name);
    }
}
