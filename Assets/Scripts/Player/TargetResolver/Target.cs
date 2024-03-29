﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Target : PlayerComponent
{
    protected GameObject target = null;


    public Target(string n, int c, string t) :base(n,c,t)
    {

    }

    public GameObject Get
    {
        get { return target; }
    }

    public bool Exist
    {
        get { return target != null && target.activeSelf; }
    }

    public abstract void UpdateTarget(Vector3 myPos);
}

