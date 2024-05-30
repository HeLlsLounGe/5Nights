using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashScript : MonoBehaviour
{
    private void Awake()
    {
        Invoke("Destroy", 0.1f);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Animatronic")
        {
            other.GetComponent<Aggression>().AggroReset();
        }
    }
    private void Destroy()
    {
        Destroy(gameObject);
    }
}
