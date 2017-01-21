using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
    public static GameManager instance;

    public GameObject bulletHolder;

    public List<Target> targetComponents;
    public List<Move> moveComponents;
    public List<Weapon> weaponComponents;

    public static int money = 10;
    public static Weapon selectedWeapon = null;
    public static Target selectedTarget = null;
    public static Move selectedMovement = null;

    void Awake () {
        instance = this;

        targetComponents = new List<Target>();
        moveComponents = new List<Move>();
        weaponComponents = new List<Weapon>();

        // Target
        targetComponents.Add(new RNDTarget("Random", 0));

        // Movement
        moveComponents.Add(new Move("No Move", 0));
        moveComponents.Add(new TargetMove("To Target", 1));

        // Weapon
        weaponComponents.Add(new HandWP("Hand", 0));
    }


}
