using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandWP : Weapon
{

    public override void attack(GameObject target)
    {
        Destroyable dest = target.GetComponent<Destroyable>();
        if(dest)
        {
            dest.takeDamage(damage);
        }
    }

    public override bool canAttack(GameObject attacker, GameObject target)
    {
        if(Vector3.Distance(attacker.transform.position, target.transform.position) <= range)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
