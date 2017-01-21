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
    }

    public void init()
    {
        target = GameManager.selectedTarget;
        weapon = GameManager.selectedWeapon;
        movement = GameManager.selectedMovement;
        movement.setAgent(GetComponent<NavMeshAgent>());
    }
    
    public void Update()
    {
        if (target == null) return;

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
            target.UpdateTarget(transform.position);
        }
    }

    protected override void dead()
    {
        InterfaceController.instance.endGame(false);
    }


}
