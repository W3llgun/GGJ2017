using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeakTarget : Target
{
    public WeakTarget(string n, int c) : base(n, c)
    {
    }

    public override void UpdateTarget(Vector3 pos)
    {
        int count = IAManager.instance.playingIA.Count;
        float buffLife = 99;
        GameObject best = null;
        foreach (var obj in IAManager.instance.playingIA)
        {
            IA en = obj.GetComponent<IA>();
            if(en.life < buffLife)
            {
                buffLife = en.life;
                best = obj;
            }
        }
        target = best;
    }
}
