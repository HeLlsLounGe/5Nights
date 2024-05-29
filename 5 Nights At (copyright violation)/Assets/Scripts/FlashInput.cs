using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashInput : MonoBehaviour
{
    [SerializeField] GameObject[] flashable;
    [SerializeField] GameObject flash;
    bool isActive;

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "SecurityCam")
        {
            isActive = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "SecurityCam")
        {
            isActive = false;
        }
    }

    public void MyInput()
    {
        if (isActive == true)
        {
            Flash();
        }
    }

    void Flash()
    {
        for (int i = 0; i < flashable.Length; i++)
        {
            GameObject currentFlash = Instantiate(flash, flashable[i].transform.position, Quaternion.identity); 
        }
    }
}
