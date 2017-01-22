using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Death : MonoBehaviour
{
    public List<Transform> rigidbodyList;
    public ParticleSystem ps1;
    public ParticleSystem ps2;

	public void LaunchDeath ()
    {
        StartCoroutine(startFall());	
	}

    IEnumerator startFall()
    {
        yield return new WaitForSeconds(0.9f);
        foreach (Transform itemToDrop in rigidbodyList)
        {
            itemToDrop.parent = transform.root;
            Rigidbody rb = itemToDrop.gameObject.AddComponent<Rigidbody>();
        }

        yield return new WaitForSeconds(1.35f);
        this.gameObject.AddComponent<Rigidbody>();
    }
}
