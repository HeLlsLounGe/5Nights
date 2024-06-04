using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    Camera cam;
    bool active = false;
    public bool poweredOff;
    [SerializeField] GameObject[] camPoint;
    [SerializeField] GameObject glitchPoint;
    [SerializeField] FlashInput[] fInput;
    int currentCam = 0;
    void Awake()
    {
        cam = GetComponent<Camera>();
        cam.enabled = false;
        transform.position = camPoint[0].transform.position;
        transform.rotation = camPoint[0].transform.rotation;

        for (int i = 0; i < camPoint.Length; i++)
        {
            fInput[i] = camPoint[i].GetComponent<FlashInput>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        CameraOn();
        CameraMove();
    }

    void CameraOn()
    {
        /*if (Input.GetButtonDown("Jump") && !active)
        {
            cam.enabled = true;
            active = true;
        } */
         if (Input.GetButtonDown("Jump") && active || Input.GetKeyDown(KeyCode.Escape) && active)
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
       /* if (Input.GetKeyDown(KeyCode.K) && active)
        {
            for (int i = 0; i < fInput.Length; i++)
            {
                fInput[i].MyInput();
            }
        } */
    }
    public void UseCameraButton (int camNumber)
    {
        currentCam = camNumber;
        transform.position = camPoint[currentCam].transform.position;
        transform.rotation = camPoint[currentCam].transform.rotation;
    }

    public void UseFlashButton()
    {
        for (int i = 0; i < fInput.Length; i++)
        {
            fInput[i].MyInput();
        }
    }
    public void MoveToGlitchPoint()
    {

        transform.position = glitchPoint.transform.position;
        transform.rotation = glitchPoint.transform.rotation;
        Invoke("MoveBack", 0.3f);
    }

    void MoveBack()
    {
        transform.position = camPoint[currentCam].transform.position;
        transform.rotation = camPoint[currentCam].transform.rotation;
    }
    public void CameraActivate()
    {
        if (poweredOff == false)
        {
            cam.enabled = true;
            active = true;
        }
    }
}
