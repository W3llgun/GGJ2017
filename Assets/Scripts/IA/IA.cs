using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;



public abstract class IA : Destroyable {
    protected NavMeshAgent agent;
    protected GameObject target;
    protected float moveUpdateRate = 1;

    [Header("BaseIA")]
    public float damage = 1;
    public float attackSpeed;

	public override void Start() {
        base.Start();
        agent = GetComponent<NavMeshAgent>();
        target = GameObject.FindGameObjectWithTag("Player");
        init();

        InvokeRepeating("attack", attackSpeed, attackSpeed);
    }
    

    protected abstract void init();
    protected abstract void attack();
    protected abstract void move();

    protected override void dead()
    {
        IAManager.instance.playingIA.Remove(this.gameObject);
        GameManager.money++;
        base.dead();
    }
}
