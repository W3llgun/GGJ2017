using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour {

    public Transform player = null;
    public float offset = -1;
    Vector3 posBuffer;
	void Start () {
        if(player == null)
        {
            GameObject obj = GameObject.FindGameObjectWithTag("Player");
            if (obj) player = obj.transform;
        }
    }
	
	
	void Update () {
		if(player)
        {
            posBuffer = transform.position;
            transform.position = new Vector3(posBuffer.x, posBuffer.y, player.position.z + offset);
        }
	}
}
