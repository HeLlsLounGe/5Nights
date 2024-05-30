using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePointScript : MonoBehaviour
{
    [SerializeField] GameObject[] closeCameras;
    [SerializeField] GameObject closetCamera;
    [SerializeField] bool isOn;
    CamPointScript closetCamPoint;
    [SerializeField] CamPointScript[] closeCamPoints;
    void Start()
    {
        closetCamPoint = closetCamera.GetComponent<CamPointScript>();

        for (int i = 0; i < closeCameras.Length; i++)
        {
            closeCamPoints[i] = closeCameras[i].GetComponent<CamPointScript>();
        }
    }
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Animatronic") 
        { 
            closetCamPoint.volumeLevel = closetCamPoint.volumeLevel + 100;


            for (int i = 0; i < closeCameras.Length; i++)
            {
                closeCamPoints[i].volumeLevel = closeCamPoints[i].volumeLevel + 20;
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Animatronic")
        {
            closetCamPoint.volumeLevel = closetCamPoint.volumeLevel - 100;

            for (int i = 0; i < closeCameras.Length; i++)
            {
                closeCamPoints[i].volumeLevel = closeCamPoints[i].volumeLevel - 20;
            }
        }
    }
}
