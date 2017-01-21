using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class TableauComponent
{
    public Tableau weaponTab;
    public Tableau targetTab;
    public Tableau movementTab;
}

public class InterfaceController : MonoBehaviour {
    public static InterfaceController instance;

    public GameObject panelPause;
    public GameObject panelChoice;
    public TableauComponent tables;
    public Text currentMoney;

    void Awake () {
        instance = this;
        initialiseTable();
        currentMoney.text = ""+GameManager.money;
    }

    void initialiseTable()
    {
        openChoice(true);
        int index = 0;
        // Weapon
        tables.weaponTab.gameObject.SetActive(true);
        tables.weaponTab.addElement("Weapon", "Cost",ComponentType.None, -1, false);
        foreach (var wp in GameManager.instance.weaponComponents)
        {
            tables.weaponTab.addElement(wp.componentName, "" + wp.cost, ComponentType.Weapon, index);
            index++;
        }
        index = 0;
        // Target
        tables.targetTab.gameObject.SetActive(true);
        tables.targetTab.addElement("Target Priority", "Cost", ComponentType.None, -1, false);
        foreach (var tr in GameManager.instance.targetComponents)
        {
            tables.targetTab.addElement(tr.componentName, "" + tr.cost, ComponentType.Target, index);
            index++;
        }
        index = 0;
        // Target
        tables.movementTab.gameObject.SetActive(true);
        tables.movementTab.addElement("Movement", "Cost", ComponentType.None, -1, false);
        foreach (var mv in GameManager.instance.moveComponents)
        {
            tables.movementTab.addElement(mv.componentName, "" + mv.cost, ComponentType.Movement, index);
            index++;
        }
        //openChoice(false);
    }

    public void Pause(bool value)
    {
        if (value)
            Time.timeScale = 0;
        else
            Time.timeScale = 1;
        panelPause.SetActive(value);
    }

    public void loadMenu()
    {
        SceneLoader.loadSceneName("Menu");
    }

    public void endGame(bool isWin)
    {
        if(isWin)
        {

        }
        else
        {

        }
    }

    public void openChoice(bool value)
    {
        if (value)
            Time.timeScale = 0;
        else
            Time.timeScale = 1;
        panelChoice.SetActive(value);
    }

    public void UpdateMoney()
    {
        int realMoney = GameManager.money;
        if (GameManager.selectedMovement != null) realMoney -= GameManager.selectedMovement.cost;
        if (GameManager.selectedTarget != null) realMoney -= GameManager.selectedTarget.cost;
        if (GameManager.selectedWeapon != null) realMoney -= GameManager.selectedWeapon.cost;

        currentMoney.text = "" + realMoney;
        if(realMoney < 0)
        {
            currentMoney.color = Color.red;
        }
        else
        {
            currentMoney.color = Color.white;
        }
    }
}
