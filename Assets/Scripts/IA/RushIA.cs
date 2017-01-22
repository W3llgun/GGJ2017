using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RushIA : IA {

    public bool isSuicide = false;
    protected float lastTimeAttack=0;

    protected override void init()
    {
        moveUpdateRate = 0.01f;
        InvokeRepeating("move", 0.1f, moveUpdateRate);
    }

    protected override void attack()
    {
    }
    
    protected override void move()
    {
        if (agent.isOnNavMesh && target && lastTimeAttack + attackSpeed < Time.time)
        {
            agent.SetDestination(target.transform.position);
            agent.Resume();
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.collider.CompareTag(target.tag))
        {
            Debug.Log("fezsfes");
            Destroyable dest = other.collider.GetComponent<Destroyable>();
            if (isSuicide)
            {
                if (dest)
                {
                    dest.takeDamage(damage);
                }
                if (animator) animator.SetTrigger("Attack");
                dead();
            }
            else if (lastTimeAttack + attackSpeed < Time.time)
            {
                if (dest)
                {
                    dest.takeDamage(damage);
                }
                lastTimeAttack = Time.time;
                if(agent && agent.isActiveAndEnabled) agent.Stop();
                if (animator) animator.SetTrigger("Attack");
            }
            
            smallBump();
        }
    }

    void smallBump()
    {
        // add anim
        transform.position = transform.position - (transform.forward*02f);
    }

}
