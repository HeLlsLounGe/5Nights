using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatronicMovement : MonoBehaviour
{
    [SerializeField] float moveRate = 3f;
    float moveTimer;
    [SerializeField] int Aggression;
    int currentPoint = 0;
    [SerializeField] GameObject[] movePoint;
    AnimatronicDoor animDoor;
    AnimatronicMovement animMove;
    void Awake()
    {
        moveTimer = moveRate;
        animDoor = GetComponent<AnimatronicDoor>();
        animMove= GetComponent<AnimatronicMovement>();
        
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
        int wander = Random.Range(1, 10);
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
        }
    }
    public void Relocate()
    {
        currentPoint = Random.Range(0, movePoint.Length - 2);
        transform.position = movePoint[currentPoint].transform.position;
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
        }
        else
        {
            transform.position = movePoint[currentPoint].transform.position;
        }
    }
}
