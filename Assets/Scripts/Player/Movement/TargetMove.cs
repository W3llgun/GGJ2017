using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class TargetMove : Move
{
    public TargetMove(NavMeshAgent a) : base(a)
    {
    }

    public override bool canMove(Transform target)
    {
        return !agent.hasPath;
    }

    public override void move(Transform target)
    {
        agent.SetDestination(target.position);
    }
}
