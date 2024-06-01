using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorButton : Interactable
{
    //[SerializeField] float doorDrain;
    [SerializeField] GameObject currentAnimatronic;
    [SerializeField] GameObject door;
    AnimatronicDoor animDoor;
    PowerLevel powerLevel;
    // Start is called before the first frame update
    void Start()
    {
        animDoor = currentAnimatronic.GetComponent<AnimatronicDoor>();
        powerLevel = GameObject.FindWithTag("MainCamera").GetComponent<PowerLevel>();
        door.GetComponent<MeshRenderer>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {

    }
    protected override void Interact()
    {
        animDoor.DoorInput();


        if (animDoor.doorclosed == true)
        { 
            door.GetComponent<MeshRenderer>().enabled = true;
            //AddToUseRate();
        }
        else if (animDoor.doorclosed == false)
        { 
            door.GetComponent<MeshRenderer>().enabled = false;
            //LowerUseRate();
        }
    }
    void AddToUseRate()
    {
     //   powerLevel.UpdateUseRate(doorDrain);
    }
    void LowerUseRate()
    {
     //   powerLevel.UpdateUseRate(-doorDrain);
    }
}
