using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Player : Destroyable {

    Animator animator;
    Target target;
    Move movement;
    Weapon weapon;
    Rigidbody rigid;
    public bool ignoreProjectile = false;
    string animatorTriggerName = "";
    public GameObject sword;
    public Transform body;

    public override void Start()
    {
        base.Start();
        animator = GetComponentInChildren<Animator>();
        rigid = GetComponent<Rigidbody>();
        InterfaceController.instance.UpdateLife(life, maxLife);
    }

    public void init()
    {
        target = GameManager.selectedTarget;
        weapon = GameManager.selectedWeapon;
        movement = GameManager.selectedMovement;
        movement.setAgent(GetComponent<NavMeshAgent>());

        target.init();
        weapon.init();
        movement.init();

        if(weapon.componentName == "Shield")
        {
            ignoreProjectile = true;
        }
        else
        {
            ignoreProjectile = false;
        }
        animatorTriggerName = "AttackSword";
        if (weapon.componentName == "Gun")
        {
            animatorTriggerName = "AttackGun";
        }
        else if (weapon.componentName == "Sword")
        {
            sword.SetActive(true);
        }
        else
        {
            sword.SetActive(false);
        }
    }
    
    public void Update()
    {
        if (target == null) return;

        if(target.Exist)
        {
            if (weapon.canAttack(this.gameObject, target.Get))
            {
                weapon.attack(target.Get);
                if (animator)
                {
                    animator.SetTrigger(animatorTriggerName);
                }
                
            }
            transform.LookAt(target.Get.transform);
        }
        else
        {
            movement.targetLost();
            target.UpdateTarget(transform.position);
        }

        if (movement.canMove(transform.position, target.Get))
        {
            movement.move(target.Get);
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
