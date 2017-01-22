using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedIA : IA {
    [Header("Ranged")]
    public float range = 1;
    public GameObject bullet;
    bool canAttack = true;
    float lastAttackTime = 0;
    protected override void init()
    {
        moveUpdateRate = 1f;
        InvokeRepeating("move", 0.1f, moveUpdateRate);
        canAttack = true;
        InvokeRepeating("attack", 0.2f, 0.1f);
    }

    protected override void attack()
    {
        if (canAttack && lastAttackTime+attackSpeed<Time.time)
        {
            StartCoroutine(shoot());
        }
    }

    protected override void move()
    {
        if (agent.isOnNavMesh && target)
            agent.SetDestination(target.transform.position);
    }

    IEnumerator shoot()
    {
        canAttack = false;
        lastAttackTime = Time.time;
        if (animator) animator.SetTrigger("Attack");
        yield return new WaitForSeconds(2f);
        Vector3 targetDir = target.transform.position - transform.position;
        GameObject obj = (GameObject)Instantiate(bullet, GameManager.instance.bulletHolder.transform);
        obj.transform.position = transform.position;
        obj.GetComponent<Bullet>().init(targetDir, 20, 50, damage, target.tag);
        yield return 0;
        canAttack = true;
        
    }
}
