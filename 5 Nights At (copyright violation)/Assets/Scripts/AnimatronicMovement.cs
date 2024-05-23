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
    void Awake()
    {
        moveTimer = moveRate;
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
        int wander = Random.Range(0, 10);
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
    void Position()
    {
        if (currentPoint > movePoint.Length)
        {
            currentPoint = Random.Range(0, movePoint.Length - 1);
        }
        transform.position = movePoint[currentPoint].transform.position;
    }
}
