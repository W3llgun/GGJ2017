using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[System.Serializable]
public class Move : PlayerComponent
{
    protected NavMeshAgent agent;

    public Move(string pName, int pCost, string tooltip) : base(pName, pCost, tooltip)
    {
        
    }

    public void setAgent(NavMeshAgent a)
    {
        agent = a;
    }

    public virtual bool canMove(Vector3 mypos, GameObject target) { return false; }

    public virtual void move(GameObject target) { }

    public virtual void targetLost()
    {
        agent.Stop();
        agent.ResetPath();
        init();
    }
}