using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aggression : MonoBehaviour
{
    float aggroTimer;
    public float maxAggro;
    bool hasAttacked = false;

    void Update()
    {
        CountDown();
    }

    void CountDown()
    {
        if (aggroTimer < maxAggro)
        {
            aggroTimer += Time.deltaTime;
        }
        else if (aggroTimer >= maxAggro)
        {
            RageAttack();
        }
    }

   void  RageAttack()
    {
        if (hasAttacked == false)
        {
            GetComponent<AnimatronicMovement>().angry = true;
            GetComponent<AnimatronicMovement>().RageAttack();
            hasAttacked = true;
        }
    }

    public void AggroReset()
    {
        aggroTimer = 0;
        hasAttacked = false;
    }
}
