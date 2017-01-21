using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseTarget : Target
{
    public CloseTarget(string n, int c) : base(n, c)
    {
    }

    public override void UpdateTarget(Vector3 pos)
    {
        int count = IAManager.instance.listIA.Count;
        if(count > 0)
        {
            float bestDist = 9999;
            GameObject bestObj = null;
            foreach (var ia in IAManager.instance.listIA)
            {
                float dist = Vector3.Distance(ia.transform.position, pos);
                if(dist < bestDist)
                {
                    bestDist = dist;
                    bestObj = ia;
                }
            }
            target = bestObj;
        }
        
    }
}
