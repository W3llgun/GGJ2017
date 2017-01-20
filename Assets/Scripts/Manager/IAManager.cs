using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IAManager : MonoBehaviour {
    public static IAManager instance;
    public List<GameObject> listIA;

    void Awake () {
        instance = this;
        listIA = new List<GameObject>(GameObject.FindGameObjectsWithTag("IA"));
    }
    
}
