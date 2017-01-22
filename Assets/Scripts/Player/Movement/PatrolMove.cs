using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PatrolMove : Move
{
    Transform patrol;
    List<Transform> pos = new List<Transform>();
    int index = 0;
    float offset;

    public override void init()
    {
        base.init();
        index = 0;
    }

    public PatrolMove(string pName, int pCost, string t, float offs) : base(pName, pCost, t)
    {
        offset = offs;
        index = 0;
        patrol = GameObject.FindGameObjectWithTag("Patrol").transform;
        foreach (Transform item in patrol)
        {
            pos.Add(item);
        }
    }

    public override bool canMove(Vector3 mypos, GameObject target)
    {
        if (Vector3.Distance(mypos, pos[index].position) < offset)
        {
            index++;
            if (index >= pos.Count) index = 0;
        }
        agent.SetDestination(pos[index].position);
        return true;
    }

    public override void move(GameObject target)
    {
        //agent.SetDestination(pos[index].position);
    }
}
