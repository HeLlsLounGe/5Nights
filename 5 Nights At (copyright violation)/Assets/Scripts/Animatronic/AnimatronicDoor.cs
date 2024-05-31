using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatronicDoor : MonoBehaviour
{
    public Camera cam;
    public bool canEnter = false, doorclosed;
    [SerializeField] float awayRate = 3;
    float awayTimer;
    [SerializeField] GameObject scareZone;
    AnimatronicMovement animMove;
    AnimatronicDoor animDoor;

    void Awake()
    {
        animMove = GetComponent<AnimatronicMovement>();
        animDoor = GetComponent<AnimatronicDoor>();
        awayTimer = awayRate;
    }

    // Update is called once per frame
    void Update()
    {
      EnterCheck();
      DoorClose();
    }

    void EnterCheck()
    {
        if (cam.enabled == false)
        {
            canEnter = true;
        }
        else if (cam.enabled == true && canEnter)
        {
            transform.position = scareZone.transform.position;
            Debug.Log("JumpScare");
        }
    }

    void DoorClose()
    {
        if(Input.GetKeyDown(KeyCode.M) && !doorclosed)
        {
            doorclosed = true;
        }
        else if (Input.GetKeyDown(KeyCode.M) && doorclosed)
        {
            doorclosed = false;
        }
        if (doorclosed && awayTimer > 0)
        {
            awayTimer = awayTimer - Time.deltaTime;
        }
        else if (doorclosed && awayTimer <= 0)
        {
            MoveFromDoor();
        }
    }
    public void DoorInput()
    {
        if (!doorclosed)
        {
            doorclosed = true;
        }
        else if (doorclosed)
        {
            doorclosed = false;
        }
    }

    private void MoveFromDoor()
    {
        awayTimer = awayRate;
        animMove.enabled = true;
        animMove.Relocate();
        animDoor.enabled = false;
    }
}
