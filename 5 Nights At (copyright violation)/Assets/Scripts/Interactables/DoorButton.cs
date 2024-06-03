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
    OtherDoor otherDoor;
    // Start is called before the first frame update
    void Start()
    {
        otherDoor = GetComponentInChildren<OtherDoor>();
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
            door.GetComponent<OtherDoor>().ChangePowerUsage();
        }
        else if (animDoor.doorclosed == false)
        { 
            door.GetComponent<MeshRenderer>().enabled = false;
            door.GetComponent<OtherDoor>().ChangePowerUsage();
        }
    }
}
