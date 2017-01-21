using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum IAType
{
    Rush,
    Ranged
}

[System.Serializable]
public class Unit
{
    [HideInInspector]
    public string Name = "Unit";
    public IAType type;
    public int Number = 1;
    
    public Unit()
    {
        Name = "Unit";
        Number = 1;
    }
}

[System.Serializable]
public class WaveProperty
{
    [HideInInspector]
    public string Name = "Wave";
    public float spawnTime = 1f;
    public List<Unit> units;
    public WaveProperty(WaveProperty wave)
    {
        spawnTime = wave.spawnTime;
        units = new List<Unit>(wave.units);
    }
}

public class IAManager : MonoBehaviour {
    public static IAManager instance;
    [HideInInspector]
    public List<GameObject> playingIA;

    [Header("Prefabs")]
    public GameObject rushUnit;
    public GameObject rangedUnit;

    [Header("Property")]
    public List<Transform> spawns;
    public List<WaveProperty> waves;

    WaveProperty currentWave = null;

    void Awake () {
        instance = this;        
    }
    

    public void startWave()
    {
        playingIA = new List<GameObject>();
        if (waves.Count>0)
        {
            WaveProperty wave = waves[0];
            currentWave = new WaveProperty(wave);
            waves.RemoveAt(0);
            StartCoroutine(playWave(wave));
        }
    }

    IEnumerator playWave(WaveProperty wave)
    {
        
        while(wave.units.Count > 0)
        {
            int rndIndex = Random.Range(0, wave.units.Count);
            IAType type = wave.units[rndIndex].type;
            wave.units[rndIndex].Number -= 1;
            if (wave.units[rndIndex].Number <= 0)
                wave.units.RemoveAt(rndIndex);
            selectUnit(type);
            yield return new WaitForSeconds(wave.spawnTime);
        }
        StartCoroutine(endWave());
    }

    void selectUnit(IAType t)
    {
        switch (t)
        {
            case IAType.Rush:
                spawnUnit(rushUnit);
                break;
            case IAType.Ranged:
                spawnUnit(rangedUnit);
                break;
            default:
                break;
        }
    }

    void spawnUnit(GameObject prefab)
    {
        Vector3 pos = spawns[Random.Range(0, spawns.Count)].position;

        GameObject obj = (GameObject)Instantiate(prefab, pos, Quaternion.identity);
        obj.transform.SetParent(transform);
        playingIA.Add(obj);
    }

    IEnumerator endWave()
    {
        while(playingIA.Count != 0)
        {
            for (int i = 0; i < playingIA.Count; i++)
            {
                if (playingIA[i] == null)
                    playingIA.RemoveAt(i);
            }
            yield return new WaitForSeconds(1);
        }

        // END WAVE
        if (waves.Count > 0)
        {
            GameManager.instance.money += getMoney();
            GameManager.instance.wave++;
            InterfaceController.instance.openChoice(true);
        }
        else
            InterfaceController.instance.endGame(true);
    }

    public void Restart()
    {
        StopAllCoroutines();
        for (int i = 0; i < playingIA.Count; i++)
        {
            if (playingIA[i] != null)
            {
                Destroy(playingIA[i]);
            }
            playingIA.RemoveAt(i);
        }
        waves.Insert(0, currentWave);
        GameObject[] bullets = GameObject.FindGameObjectsWithTag("Bullet");
        foreach (var b in bullets)
        {
            Destroy(b);
        }
    }

    int getMoney()
    {
        int num = 0;
        foreach (var item in currentWave.units)
        {
            num += item.Number;
        }
        return num;
    }
}
