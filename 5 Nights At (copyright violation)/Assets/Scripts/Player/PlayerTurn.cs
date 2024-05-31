using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTurn : MonoBehaviour
{
    [SerializeField] Transform mainCameraTransform;
    [SerializeField] float mouseSensitivity;
    Vector2 look;
    Camera securityCam;
    
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        securityCam = GameObject.FindWithTag("SecurityCam").GetComponent<Camera>();
    }

    
    void Update()
    {
        UpdateActive();
        UpdateLook();
    }


    void UpdateActive()
    {
        if (securityCam.enabled == false)
        {
            Cursor.lockState = CursorLockMode.Locked;
        }
        else if (securityCam.enabled == true)
        {
            Cursor.lockState = CursorLockMode.None;
        }
    }

    void UpdateLook()
    {
        if (Cursor.lockState == CursorLockMode.Locked)
        {
            look.x += Input.GetAxis("Mouse X") * mouseSensitivity;
            look.y += Input.GetAxis("Mouse Y") * mouseSensitivity;

            look.y = Mathf.Clamp(look.y, -89f, 89f);
            mainCameraTransform.localRotation = Quaternion.Euler(-look.y, 0, 0);
            transform.localRotation = Quaternion.Euler(0, look.x, 0);
        }
    }
}
