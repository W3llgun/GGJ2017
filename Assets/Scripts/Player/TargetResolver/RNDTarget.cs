using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RNDTarget : Target
{
    public override void UpdateTarget()
    {
        int count = IAManager.instance.listIA.Count;
        if(count > 0)
        target =  IAManager.instance.listIA[UnityEngine.Random.Range(0, count)];
    }
}
