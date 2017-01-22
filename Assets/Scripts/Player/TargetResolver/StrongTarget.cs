using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StrongTarget : Target
{
    public StrongTarget(string n, int c, string t) : base(n, c, t)
    {
    }

    public override void UpdateTarget(Vector3 pos)
    {
        float bufferDamage = 99;
        GameObject best = null;
        foreach (var obj in IAManager.instance.playingIA)
        {
            IA en = obj.GetComponent<IA>();
            if(en.damage < bufferDamage)
            {
                bufferDamage = en.damage;
                best = obj;
            }
        }
        target = best;
    }
}
