using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatronicMovement : MonoBehaviour
{
    [SerializeField] float moveRate = 3f;
    float moveTimer;
    [SerializeField] int Aggression;
    int currentPoint = 0;
    public bool angry;
    [SerializeField] GameObject[] movePoint;
    AnimatronicDoor animDoor;
    AnimatronicMovement animMove;
    GameObject sCam;
    PowerLevel powerLevel;
    void Awake()
    {
        moveTimer = moveRate;
        animDoor = GetComponent<AnimatronicDoor>();
        animMove= GetComponent<AnimatronicMovement>();
        powerLevel = GameObject.FindWithTag("MainCamera").GetComponent<PowerLevel>();
        sCam = GameObject.FindWithTag("SecurityCam");


        transform.position = movePoint[0].transform.position;
        transform.rotation = movePoint[0].transform.rotation;
    }

    void Update()
    {
        CountDown();
    }

    void CountDown()
    {
        if (moveTimer > 0)
            moveTimer = moveTimer - Time.deltaTime;

        else if (moveTimer <= 0)
        {
            Move();
        }
    }


    void Move()
    {
        int wander = Random.Range(1, 12);
        moveTimer = moveRate;
        if (Aggression > Random.Range(0, 20))
        {
            if (wander > 3)
            {
                currentPoint++;
                Position();
            }
            else if (wander <= 3)
            {
                currentPoint--;
                Position();
            }
            sCam.GetComponent<CameraScript>().MoveToGlitchPoint();
        }
    }
    public void Relocate()
    {
        if (angry == true)
        {
            powerLevel.powerLevel = powerLevel.powerLevel - 10;
            GetComponent<Aggression>().AggroReset();
            angry = false;
        }
        currentPoint = Random.Range(0, movePoint.Length - 2);
        transform.position = movePoint[currentPoint].transform.position;
        sCam.GetComponent<CameraScript>().MoveToGlitchPoint();
    }
    void Position()
    {
        if (currentPoint >= movePoint.Length - 1)
        {
           animDoor.enabled= true;
           animMove.enabled = false;
                
        }
        if (currentPoint < 0)
        {
            currentPoint = 0;
            transform.position = movePoint[currentPoint].transform.position;
            transform.rotation = movePoint[currentPoint].transform.rotation;
        }
        else
        {
            transform.position = movePoint[currentPoint].transform.position;
            transform.rotation = movePoint[currentPoint].transform.rotation;
        }
    }
    public void RageAttack()
    {
        currentPoint = movePoint.Length - 1;
        transform.position = movePoint[currentPoint].transform.position;
        transform.rotation = movePoint[currentPoint].transform.rotation;
        Position();
        sCam.GetComponent<CameraScript>().MoveToGlitchPoint();
    }
}
