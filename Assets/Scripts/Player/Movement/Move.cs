using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[System.Serializable]
public class Move{
    protected NavMeshAgent agent;

    public Move(NavMeshAgent a)
    {
        agent = a;
    }

    public virtual bool canMove(Transform target) { return false; }

    public virtual void move(Transform target) { }

    public virtual void targetLost()
    {
        agent.Stop();
        agent.ResetPath();
    }
}