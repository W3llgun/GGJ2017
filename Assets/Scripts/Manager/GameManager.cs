using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
    public static GameManager instance;

    public GameObject bulletPrefab;
    public GameObject bulletHolder;
    public List<Target> targetComponents;
    [HideInInspector]
    public List<Move> moveComponents;
    public List<Weapon> weaponComponents;

    public int wave = 1;
    public int money = 0;
    public static Weapon selectedWeapon = null;
    public static Target selectedTarget = null;
    public static Move selectedMovement = null;

    public static GameObject player;
    Vector3 basePos = Vector3.zero;
    void Awake () {
        instance = this;
        
        player = GameObject.FindGameObjectWithTag("Player");
        basePos = player.transform.position;

        targetComponents = new List<Target>();
        moveComponents = new List<Move>();
        weaponComponents = new List<Weapon>();

        // Target
        targetComponents.Add(new RNDTarget("Random", 0));
        targetComponents.Add(new WeakTarget("Weakest", 2));
        targetComponents.Add(new CloseTarget("Closest", 6));

        // Movement
        moveComponents.Add(new Move("No Move", 0));
        moveComponents.Add(new RandomMove("Random", 1));
        moveComponents.Add(new PatrolMove("Patrol", 2, 2));
        moveComponents.Add(new TargetMove("To Target", 4));

        // Weapon
        weaponComponents.Add(new HandWP("Hand", 0));
        weaponComponents.Add(new SwordWP("Sword", 2));
        weaponComponents.Add(new GunWP("Gun", 4, bulletPrefab));
    }

    public void Reset()
    {
        if(player)
        {
            player.transform.position = basePos;
            player.GetComponent<Player>().init();
        }

        foreach (Transform item in GameManager.instance.bulletHolder.transform)
        {
            Destroy(item.gameObject);
        }
    }
}
