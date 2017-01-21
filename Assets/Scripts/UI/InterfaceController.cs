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
        currentMoney.text = ""+GameManager.instance.money;
    }

    void initialiseTable()
    {
        int index = 0;
        // Weapon
        tables.weaponTab.gameObject.SetActive(true);
        tables.weaponTab.addElement("Weapon", "Cost", -1, false);
        foreach (var wp in GameManager.instance.weaponComponents)
        {
            tables.weaponTab.addElement(wp.Value.componentName, "" + wp.Value.cost, index);
            index++;
        }
        //tables.weaponTab.gameObject.SetActive(false);
        index = 0;
        // Target
        tables.targetTab.gameObject.SetActive(true);
        tables.targetTab.addElement("Target Priority", "Cost", -1, false);
        foreach (var tr in GameManager.instance.targetComponents)
        {
            tables.targetTab.addElement(tr.Value.componentName, "" + tr.Value.cost, index);
        }
        //tables.targetTab.gameObject.SetActive(false);
        index = 0;
        // Target
        tables.movementTab.gameObject.SetActive(true);
        tables.movementTab.addElement("Movement", "Cost", -1, false);
        foreach (var mv in GameManager.instance.moveComponents)
        {
            tables.movementTab.addElement(mv.Value.componentName, "" + mv.Value.cost, index);
        }
        //tables.movementTab.gameObject.SetActive(false);
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

}
