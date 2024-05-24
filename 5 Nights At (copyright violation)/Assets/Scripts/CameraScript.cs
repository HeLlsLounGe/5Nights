using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    Camera cam;
    bool active = false;
   [SerializeField] GameObject[] camPoint;
    int currentCam = 0;
    void Awake()
    {
        cam = GetComponent<Camera>();
        cam.enabled = false;
        transform.position = camPoint[0].transform.position;
        transform.rotation = camPoint[0].transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        CameraOn();
        CameraMove();
    }

    void CameraOn()
    {
        if (Input.GetButtonDown("Jump") && !active)
        {
            cam.enabled = true;
            active = true;
        }
        else if (Input.GetButtonDown("Jump") && active)
        {
            cam.enabled = false;
            active = false;
        }
    }

    void CameraMove()
    {
        if(Input.GetKeyDown(KeyCode.RightArrow) && active)
        {
            currentCam++;
            if (currentCam >= camPoint.Length)
            {
                currentCam = 0;
            }
            transform.position = camPoint[currentCam].transform.position;
            transform.rotation = camPoint[currentCam].transform.rotation;
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow) && active)
        {
            currentCam--;
            if (currentCam < 0)
            {
                currentCam = camPoint.Length - 1;
            }
            transform.position = camPoint[currentCam].transform.position;
            transform.rotation = camPoint[currentCam].transform.rotation;
        }
    }
    public void UseCameraButton (int camNumber)
    {
        currentCam = camNumber;
        transform.position = camPoint[currentCam].transform.position;
        transform.rotation = camPoint[currentCam].transform.rotation;
    }
}
