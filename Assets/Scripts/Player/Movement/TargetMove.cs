using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class TargetMove : Move
{
    public TargetMove(string pName, int pCost) : base(pName, pCost)
    {
    }

    public override bool canMove(Vector3 mypos, GameObject target)
    {
        return target != null;
    }

    public override void move(GameObject target)
    {
        agent.SetDestination(target.transform.position);
    }
}
