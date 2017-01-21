using UnityEngine;
using UnityEngine.UI;
using System.Collections;

/// <summary>
/// Classe représentant une case de l'inventaire du joueur.
/// </summary>
/// <remarks>La case d'inventaire peut être du texte, une image ou du son.</remarks>
public class InventoryTile : MonoBehaviour
{
    public Text label, cost;
    Button button;
    public int index
    {
        get;set;
    }

    public void setTile(string pLabel, string pCost, int pIndex, bool active)
    {
        button = GetComponent<Button>();
        button.enabled = active;
        label.text = pLabel;
        cost.text = pCost;
        index = pIndex;

        if(!active)
        {
            setColor(Color.gray);
        }
    }
    
    public void mouseClick()
    {
        // Select
    }

    public void select(bool value)
    {
        
    }

    void setColor(Color col)
    {
        ColorBlock c = button.colors;
        c.normalColor = col;
        button.colors = c;
    }
}
