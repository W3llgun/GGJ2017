using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
    public static GameManager instance;

    public GameObject bulletHolder;

    public List<Target> targetComponents;
    public List<Move> moveComponents;
    public List<Weapon> weaponComponents;

    public static int wave = 0;
    public static int money = 0;
    public static Weapon selectedWeapon = null;
    public static Target selectedTarget = null;
    public static Move selectedMovement = null;

    void Awake () {
        instance = this;
        wave = 0;
        money = 10;

        targetComponents = new List<Target>();
        moveComponents = new List<Move>();
        weaponComponents = new List<Weapon>();

        // Target
        targetComponents.Add(new RNDTarget("Random", 0));
        targetComponents.Add(new CloseTarget("Closest", 2));

        // Movement
        moveComponents.Add(new Move("No Move", 0));
        moveComponents.Add(new TargetMove("To Target", 1));

        // Weapon
        weaponComponents.Add(new HandWP("Hand", 0));
        weaponComponents.Add(new SwordWP("Sword", 2));
    }


}
