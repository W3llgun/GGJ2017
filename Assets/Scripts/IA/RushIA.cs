using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RushIA : IA {
    

    protected override void init()
    {

    }

    protected override void attack()
    {
    }
    
    protected override void move()
    {
        if(agent.isOnNavMesh && target)
        agent.SetDestination(target.transform.position);
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.collider.CompareTag(target.tag))
        {
            Destroyable dest = other.collider.GetComponent<Destroyable>();
            if (dest)
            {
                dest.takeDamage(damage);
            }
            Destroy(this.gameObject);
        }
    }

}
