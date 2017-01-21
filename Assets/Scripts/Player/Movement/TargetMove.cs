using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class TargetMove : Move
{
    public TargetMove(string pName, int pCost) : base(pName, pCost)
    {
    }

    public override bool canMove(Vector3 mypos, Transform target)
    {
        return target != null;
    }

    public override void move(Transform target)
    {
        agent.SetDestination(target.position);
    }
}
