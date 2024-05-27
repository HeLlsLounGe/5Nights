using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CamPointScript : MonoBehaviour
{
    public int volumeLevel;
    public Image minVol;
    public Image midVol;
    public Image maxVol;
    void Awake ()
    {
        volumeLevel = 0;
        minVol = GameObject.Find("audio min").GetComponent<Image>();
        midVol = GameObject.Find("audio mid").GetComponent<Image>();
        maxVol = GameObject.Find("audio max").GetComponent<Image>();
        minVol.enabled = false;
        midVol.enabled = false;
        maxVol.enabled = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.transform.tag == "SecurityCam")
        {
            if (volumeLevel >= 80) 
            { 
            maxVol.enabled = true;
            }
            else if (volumeLevel >= 20)
            { 
            midVol.enabled = true;
            }
            else if (volumeLevel < 20)
            { 
            midVol.enabled = true;
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.transform.tag == "SecurityCam")
        {
            minVol.enabled = false;
            midVol.enabled = false;
            maxVol.enabled = false;

        }
    }
}
