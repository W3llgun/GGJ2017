using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedIA : IA {
    [Header("Ranged")]
    public float range = 1;
    public GameObject bullet;

    protected override void init()
    {
        moveUpdateRate = 1f;
        InvokeRepeating("move", 0.1f, moveUpdateRate);
    }

    protected override void attack()
    {
        shoot();
    }

    protected override void move()
    {
        if (agent.isOnNavMesh && target)
            agent.SetDestination(target.transform.position);
    }

    void shoot()
    {
        Vector3 targetDir = target.transform.position - transform.position;
        GameObject obj = (GameObject)Instantiate(bullet, GameManager.instance.bulletHolder.transform);
        obj.transform.position = transform.position;
        obj.GetComponent<Bullet>().init(targetDir, 5, 10, damage, target.tag);
    }
}
