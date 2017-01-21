using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandWP : Weapon
{
    public HandWP(string n, int c) : base(n, c)
    {
        range = 1.5f;
        damage = 2;
        attackSpeed = 0.4f;
    }

    public override void attack(GameObject target)
    {
        Destroyable dest = target.GetComponent<Destroyable>();
        if(dest)
        {
            lastAttackTime = Time.time;
            dest.takeDamage(damage);
        }
    }

    public override bool canAttack(GameObject attacker, GameObject target)
    {
        if(Vector3.Distance(attacker.transform.position, target.transform.position) <= range)
        {
            return checkTime();
        }
        else
        {
            return false;
        }
    }
}
