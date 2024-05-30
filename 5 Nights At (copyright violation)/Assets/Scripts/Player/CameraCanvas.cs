using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraCanvas : MonoBehaviour
{
    [SerializeField] Camera securityCamera;
    Canvas canvas;
    void Awake()
    {
        canvas = GetComponent<Canvas>();
        canvas.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (securityCamera.enabled == true)
        {
            canvas.enabled = true;
        }
        else if (securityCamera.enabled == false)
        {
            canvas.enabled = false;
        }
    }
}
