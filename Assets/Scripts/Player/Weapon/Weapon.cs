using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Weapon {
    public float range = 2;
    public float damage = 1;
    public float attackSpeed = 0.5f;

    public abstract bool canAttack(GameObject attacker, GameObject target);
    public abstract void attack(GameObject target);
}
