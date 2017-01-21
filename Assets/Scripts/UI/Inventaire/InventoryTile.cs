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
    ComponentType type;
    Tableau tableau;
    Button button;
    bool actived;
    public int index
    {
        get;set;
    }

    public void setTile(string pLabel, string pCost, ComponentType comp, int pIndex, Tableau tab ,bool pActive)
    {
        actived = pActive;
        tableau = tab;
        button = GetComponent<Button>();
        button.enabled = actived;
        label.text = pLabel;
        cost.text = pCost;
        index = pIndex;
        type = comp;
        if (!actived)
        {
            setColor(Color.gray);
        }
    }
    
    public void mouseClick()
    {
        tableau.resetTile();
        setColor(Color.green);

        switch (type)
        {
            case ComponentType.Movement:
                GameManager.selectedMovement = GameManager.instance.moveComponents[index];
                break;
            case ComponentType.Target:
                GameManager.selectedTarget = GameManager.instance.targetComponents[index];
                break;
            case ComponentType.Weapon:
                GameManager.selectedWeapon = GameManager.instance.weaponComponents[index];
                break;
            default:
                break;
        }
        InterfaceController.instance.UpdateMoney();
    }

    void setColor(Color col)
    {
        ColorBlock c = button.colors;
        c.normalColor = col;
        c.highlightedColor = col;
        button.colors = c;
    }

    public void Reset()
    {
        if (actived)
        setColor(Color.white);
    }
}
