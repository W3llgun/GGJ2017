using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Player : Destroyable {

    Target target;
    Move movement;
    Weapon weapon;
    
    public override void Awake()
    {
        base.Awake();

        target = new RNDTarget();
        weapon = new HandWP();
        movement = new TargetMove(GetComponent<NavMeshAgent>());
    }
    
    public void Update()
    {
        if(target.Exist)
        {
            if (weapon.canAttack(this.gameObject, target.Get))
            {
                weapon.attack(target.Get);
            }

            if (movement.canMove(target.Get.transform))
            {
                movement.move(target.Get.transform);
            }
        }
        else
        {
            movement.targetLost();
            target.UpdateTarget();
        }
    }

    protected override void dead()
    {
        print("P Dead");
        // LOST
    }


}
