using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerComponent {

    public string componentName;
    public string tooltip;
    public int cost;


    public PlayerComponent(string pName, int pCost, string pTooltip)
    {
        tooltip = pTooltip;
        componentName = pName;
        cost = pCost;
    }

    public virtual void init() { }
}
