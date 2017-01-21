using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Player : Destroyable {

    Target target;
    Move movement;
    Weapon weapon;
    Rigidbody rigid;
    public override void Start()
    {
        base.Start();
        rigid = GetComponent<Rigidbody>();
        InterfaceController.instance.UpdateLife(life, maxLife);
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

            if (movement.canMove(transform.position, target.Get.transform))
            {
                movement.move(target.Get.transform);
            }
        }
        else
        {
            movement.targetLost();
            target.UpdateTarget(transform.position);
        }
        if (rigid) rigid.velocity = Vector3.zero;
    }

    protected override void dead()
    {
        InterfaceController.instance.endGame(false);
    }

    public override void takeDamage(float dmg)
    {
        base.takeDamage(dmg);
        InterfaceController.instance.UpdateLife(life, maxLife);
    }
}
