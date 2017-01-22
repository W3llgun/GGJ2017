using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {
    static float lifeTime = 5;

    Rigidbody rigid;
    bool launched = false;
    Vector3 direction;
    float maxSpeed = 1;
    float damage = 1;
    string targetTag = "aaa";
    float acceleration = 10;
    Vector3 velBuffer;

    public void init(Vector3 dir, float mSpeed, float accel, float dmg, string pTtag)
    {
        rigid = GetComponent<Rigidbody>();
        
        targetTag = pTtag;
        damage = dmg;
        maxSpeed = mSpeed;
        acceleration = accel;
        direction = dir.normalized;
        Destroy(this.gameObject, lifeTime);
        launched = true;
    }

    private void Update()
    {
        if(rigid !=null && launched)
        {
            move();
        }
    }

    private void move()
    {
        velBuffer = rigid.velocity;
        velBuffer += acceleration * direction * Time.deltaTime;
        velBuffer.y = 0;

        velBuffer = Vector3.ClampMagnitude(velBuffer, maxSpeed);

        rigid.velocity = velBuffer;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag(targetTag))
        {
            Destroyable dest = other.GetComponent<Destroyable>();
            if (dest)
            {
                if (other.GetComponent<Player>() && other.GetComponent<Player>().ignoreProjectile)
                {
                    Destroy(this.gameObject);
                }
                else
                {
                    dest.takeDamage(damage);
                }
            }
            Destroy(this.gameObject);
        }
        else if(other.gameObject.layer == LayerMask.NameToLayer("Props"))
        {
            Destroy(this.gameObject);
        }
    }

}
