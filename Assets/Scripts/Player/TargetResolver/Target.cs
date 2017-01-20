using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Target{
    protected GameObject target = null;
    
	public GameObject Get
    {
        get { return target; }
    }

    public bool Exist
    {
        get { return target != null && target.activeSelf; }
    }

    public abstract void UpdateTarget();
}

