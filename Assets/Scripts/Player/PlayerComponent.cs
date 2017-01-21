using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerComponent {

    public string componentName;
    public int cost;

    public PlayerComponent(string pName, int pCost)
    {
        componentName = pName;
        cost = pCost;
    }
}
