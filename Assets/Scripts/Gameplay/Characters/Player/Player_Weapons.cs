using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using Dorkbots.ServiceLocatorTools;

public class Player_Weapons : MonoBehaviour {

    [HideInInspector]
    public Dictionary<string, Weapon> playerWeaponsDict;

    void Awake()
    {
        playerWeaponsDict = new Dictionary<string, Weapon>
        {
            {
            "Long Sword",
            new Weapon
            {
                name = "Long Sword",
                damage = 2.5f,
                attackRange = 1.5f,
                weaponType = "One Handed",
            }
        },
        {
            "Dagger",
            new Weapon
            {
                name = "Dagger",
                damage = 2f,
                attackRange = 1f,
                weaponType = "Stab"
            }
        },
        {
            "Lance",
            new Weapon
            {
                name = "Lance",
                damage = 3f,
                attackRange = 3f,
                weaponType = "Stab"
            }
        },
        {
            "Hammer",
            new Weapon
            {
                name = "Hammer",
                damage = 3,
                attackRange = 2f,
                weaponType = "Two Handed"
            }
        },
        {
            "Greatsword",
            new Weapon
            {
                name = "Greatsword",
                damage = 3f,
                attackRange = 2.5f,
                weaponType = "Two Handed"
            }
        },
        {
            "Haldberd",
            new Weapon
            {
                name = "Haldberd",
                damage = 2.5f,
                attackRange = 3f,
                weaponType = "Two Handed"
            }
        },
        {
            "GreatAxe",
            new Weapon
            {
                name = "GreatAxe",
                damage = 4f,
                attackRange = 3.5f,
                weaponType = "Two Handed"
            }
        },
        {
            "Double Sword",
            new Weapon
            {
                name = "Double Sword",
                damage = 4f,
                attackRange = 2f,
                weaponType = "One Handed"
            }
        },
        {
            "Black Sword",
            new Weapon
            {
                name = "Black Sword",
                damage = 5f,
                attackRange = 2f,
                weaponType = "One Handed"
            }
        },
        {
            "Claws",
            new Weapon
            {
                name = "Claws",
                damage = 5f,
                attackRange = 1f,
                weaponType = "Stab"
            }
        },
        {
            "Stone Greatsword",
            new Weapon
            {
                name = "Stone Greatsword",
                damage = 3f,
                attackRange = 3f,
                weaponType = "Two Handed"
            }
        },
        {
            "Split Blade",
            new Weapon
            {
                name = "Split Blade",
                damage = 5f,
                attackRange = 2f,
                weaponType = "One Handed"
            }
        },
        {
            "Scythe",
            new Weapon
            {
                name = "Scythe",
                damage = 3,
                attackRange = 3f,
                weaponType = "Two Handed"
            }
        },
        {
            "Rapier",
            new Weapon
            {
                name = "Rapier",
                damage = 5f,
                attackRange = 2f,
                weaponType = "Stab"
            }
        },
        {
            "Zweihander",
            new Weapon
            {
                name = "Zweihander",
                damage = 5f,
                attackRange = 3f,
                weaponType = "Two Handed"
            }
        },
        {
            "Spear",
            new Weapon
            {
                name = "Spear",
                damage = 2.5f,
                attackRange = 4f,
                weaponType = "Stab"
            }
        },
        {
            "Katana",
            new Weapon
            {
                name = "Katana",
                damage = 3.5f,
                attackRange = 2f,
                weaponType = "One Handed"
            }
        },
        };
    }

}
