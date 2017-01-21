using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class SceneLoader  {
    
    public static void loadSceneName(string name)
    {
        SceneManager.LoadScene(name);
    }

    public static void loadSceneIndex(int index)
    {
        SceneManager.LoadScene(index);
    }

    public static int activeSceneIndex()
    {
        return SceneManager.GetActiveScene().buildIndex;
    }
}
