using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Destroyable : MonoBehaviour {
    [Header("Destroyable")]
    public float maxLife = 5;
    public float life = 0;
    public Slider lifebar;

    public virtual void Start()
    {
        reset();
    }

    public virtual void takeDamage(float dmg)
    {
        life -= dmg;
        if (life <= 0)
            dead();
        else if(lifebar != null)
            lifebar.value = life / maxLife;
    }

    protected virtual void dead()
    {
        Destroy(this.gameObject);
    }

    public void reset()
    {
        life = maxLife;
        if (lifebar != null)
            lifebar.value = life / maxLife;
    }
}
