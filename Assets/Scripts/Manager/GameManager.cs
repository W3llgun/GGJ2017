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
        targetComponents.Add(new RNDTarget("Random", 0, "Roll a dice before chosing a target"));
        targetComponents.Add(new WeakTarget("Weakest", 2, "Kill children and women first ! (Low life)"));
        targetComponents.Add(new StrongTarget("Strongest", 3, "Target based on most damage"));
        targetComponents.Add(new CloseTarget("Closest", 6, "Don't get close scoundrel !"));

        // Movement
        moveComponents.Add(new Move("No Move", 0, "You can't move"));
        moveComponents.Add(new RandomMove("Random", 1,"You can move"));
        moveComponents.Add(new PatrolMove("Patrol", 2, "Turn around", 2));
        moveComponents.Add(new TargetMove("To Target", 4, "Yeaaaaaaah !"));

        // Weapon
        weaponComponents.Add(new HandWP("Hand", 0, "Fight like a man"));
        weaponComponents.Add(new SwordWP("Sword", 2, "More range, More damage"));
        weaponComponents.Add(new ShieldWP("Shield", 3, "Low damage, Ignore projectile damage"));
        weaponComponents.Add(new GunWP("Gun", 4, "Ranged and powerfull", bulletPrefab));
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
