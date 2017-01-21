using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PatrolMove : Move
{
    Transform home;
    Vector3[] pos = new Vector3[4];
    int index = 0;
    public PatrolMove(string pName, int pCost, float offset) : base(pName, pCost)
    {
        index = 0;
        home = GameObject.FindGameObjectWithTag("House").transform;
        pos[0] = home.position;
        pos[1] = home.position;
        pos[2] = home.position;
        pos[3] = home.position;

        pos[0].x += offset;
        pos[1].z += offset;
        pos[2].x -= offset;
        pos[3].z -= offset;
    }

    public override bool canMove(Vector3 mypos, Transform target)
    {
        if (Vector3.Distance(pos[index], mypos) < 1)
        {
            index++;
            if (index >= pos.Length) index = 0;
            targetLost();
        }
        return true;
    }

    public override void move(Transform target)
    {
        agent.SetDestination(pos[index]);
    }
}
