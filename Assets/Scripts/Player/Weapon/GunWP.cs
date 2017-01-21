using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunWP : Weapon
{
    GameObject bullet;

    public GunWP(string n, int c, GameObject prefabBullet) : base(n, c)
    {
        bullet = prefabBullet;
        range = 40;
        damage = 5;
        attackSpeed = 2f;
    }

    public override void attack(GameObject target)
    {
        Destroyable dest = target.GetComponent<Destroyable>();
        if(dest)
        {
            lastAttackTime = Time.time;
            shoot(target);
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

    void shoot(GameObject target)
    {
        Vector3 targetDir = target.transform.position - GameManager.player.transform.position;
        GameObject obj = (GameObject)GameObject.Instantiate(bullet, GameManager.instance.bulletHolder.transform);
        obj.transform.position = GameManager.player.transform.position;
        obj.GetComponent<Bullet>().init(targetDir, 10, 100, damage, target.tag);
    }

}
