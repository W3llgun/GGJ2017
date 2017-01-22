using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

    public GameObject credit;

	void Awake () {
		
	}
	
	public void startGame()
    {
        SceneManager.LoadScene("Level");
    }

    public void openCredit(bool value)
    {
        if (!credit) return;

        credit.SetActive(value);
    }

    public void quitGame()
    {
        Application.Quit();
    }
}
