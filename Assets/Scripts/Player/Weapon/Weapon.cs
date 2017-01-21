using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Weapon : PlayerComponent
{
    public float range = 2;
    public float damage = 1;
    public float attackSpeed = 0.5f;
    protected float lastAttackTime = 0;
    public Weapon(string n , int c):base(n,c)
    {

    }

    public abstract bool canAttack(GameObject attacker, GameObject target);
    public abstract void attack(GameObject target);

    protected bool checkTime()
    {
        if (lastAttackTime + attackSpeed > Time.time) return false;
        return true;
    }
}
