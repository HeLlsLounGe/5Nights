using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorButton : Interactable
{
    [SerializeField] GameObject currentAnimatronic;
    [SerializeField] GameObject door;
    AnimatronicDoor animDoor;
    // Start is called before the first frame update
    void Start()
    {
        animDoor = currentAnimatronic.GetComponent<AnimatronicDoor>();
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
        { door.GetComponent<MeshRenderer>().enabled = true; }
        else if (animDoor.doorclosed == false)
        { door.GetComponent<MeshRenderer>().enabled = false; }
    }
}
