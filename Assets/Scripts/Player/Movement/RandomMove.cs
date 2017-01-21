using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class RandomMove : Move
{
    Vector3 position = Vector3.zero;

    public override void init()
    {
        base.init();
        position = Vector3.zero;
    }

    public RandomMove(string pName, int pCost) : base(pName, pCost)
    {
        position = Vector3.zero;
    }

    public override bool canMove(Vector3 mypos, Transform target)
    {
        if(Vector3.Distance(mypos, position) < 2 || position == Vector3.zero)
        {
            position =  new Vector3(Random.Range(-15,15), mypos.y, Random.Range(-15, 15));
            targetLost();
            return true;
        }
        return false;
    }

    public override void move(Transform target)
    {
        agent.SetDestination(position);
    }
}
