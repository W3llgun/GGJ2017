using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lookAtCam : MonoBehaviour {

    Transform cam;

	void Start () {
        cam = Camera.main.transform;
        InvokeRepeating("refresh", 0.01f, 0.2f);
    }

    void refresh()
    {
        transform.LookAt(cam);
    }
}
