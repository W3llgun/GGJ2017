using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public abstract class IA : MonoBehaviour {
    protected NavMeshAgent agent;
    

	// Use this for initialization
	void Awake () {
        agent = GetComponent<NavMeshAgent>();

    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
