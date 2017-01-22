using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RNDTarget : Target
{
    public RNDTarget(string n, int c, string t) : base(n, c, t)
    {
    }

    public override void UpdateTarget(Vector3 pos)
    {
        int count = IAManager.instance.playingIA.Count;
        if(count > 0)
        target =  IAManager.instance.playingIA[UnityEngine.Random.Range(0, count)];
    }
}
