using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
    public static GameManager instance;

    public GameObject bulletHolder;

    public SortedList<int, Target> targetComponents;
    public SortedList<int, Move> moveComponents;
    public SortedList<int, Weapon> weaponComponents;

    public int money = 10;
    public static Weapon selectedWeapon;
    public static Target selectedTarget;
    public static Move selectedMovement;

    void Awake () {
        instance = this;

        targetComponents = new SortedList<int, Target>();
        moveComponents = new SortedList<int, Move>();
        weaponComponents = new SortedList<int, Weapon>();

        // Target
        targetComponents.Add(0, new RNDTarget("Random", 0));

        // Movement
        moveComponents.Add(0, new Move("No Move", 0));
        moveComponents.Add(1, new TargetMove("To Target", 1));

        // Weapon
        weaponComponents.Add(0, new HandWP("Hand", 0));
    }


}
