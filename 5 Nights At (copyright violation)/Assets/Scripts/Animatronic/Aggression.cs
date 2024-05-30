using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aggression : MonoBehaviour
{
    float aggroTimer;
    public float maxAggro;
    void Start()
    {
        
    }

    // Update is called once per frame
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
        GetComponent<AnimatronicMovement>().RageAttack();
    }

    public void AggroReset()
    {
        aggroTimer = 0;
    }
}
