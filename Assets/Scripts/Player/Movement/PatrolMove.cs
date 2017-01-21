using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PatrolMove : Move
{
    Transform home;
    List<Transform> pos = new List<Transform>();
    int index = 0;
    float offset;

    public override void init()
    {
        base.init();
        index = 0;
    }

    public PatrolMove(string pName, int pCost, float offs) : base(pName, pCost)
    {
        offset = offs;
        index = 0;
        home = GameObject.FindGameObjectWithTag("House").transform;
        foreach (var item in home.GetComponent<House>().patrol)
        {
            pos.Add(item);
        }
    }

    public override bool canMove(Vector3 mypos, GameObject target)
    {
        if (Vector3.Distance(pos[index].position, mypos) < offset)
        {
            index++;
            if (index >= pos.Count) index = 0;
            targetLost();
        }
        return true;
    }

    public override void move(GameObject target)
    {
        agent.SetDestination(pos[index].position);
    }
}
