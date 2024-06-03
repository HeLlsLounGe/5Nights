using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OtherDoor : MonoBehaviour
{
    [SerializeField] float doorDrain;
    MeshRenderer meshRenderer;
    PowerLevel powerLevel;
    // Start is called before the first frame update
    void Start()
    {
        meshRenderer = GetComponent<MeshRenderer>();
        powerLevel = GameObject.FindWithTag("MainCamera").GetComponent<PowerLevel>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangePowerUsage()
    {
        if (meshRenderer.enabled == true)
        {
            powerLevel.UpdateUseRate(doorDrain);
        }
        else if (meshRenderer.enabled == false)
        {
            powerLevel.UpdateUseRate(-doorDrain);
        }
    }
}
