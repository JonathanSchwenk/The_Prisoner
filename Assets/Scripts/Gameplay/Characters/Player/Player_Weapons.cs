using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using Dorkbots.ServiceLocatorTools;

public class Player_Weapons {
    Dictionary<string, Weapon> Player_Weapons_Dic = new Dictionary<string, Weapon> {
        {
            "Human_Sword_Long",
            new Weapon
            {
                name = "Human_Sword_Long",
                damage = 2.5f,
                attackRange = 1.5f,
                weaponType = "Melee_OneHanded",
            }
        },
        {
            "Human_Dagger",
            new Weapon
            {
                name = "Human_Dagger",
                damage = 2f,
                attackRange = 1f,
                weaponType = "Melee_Stab"
            }
        },
        {
            "Human_Lance",
            new Weapon
            {
                name = "Human_Lance",
                damage = 3f,
                attackRange = 3f,
                weaponType = "Melee_TwoHanded"
            }
        },
        {
            "Human_Hammer",
            new Weapon
            {
                name = "Human_Hammer",
                damage = 3,
                attackRange = 2f,
                weaponType = "Melee_TwoHanded"
            }
        },
        {
            "Human_Greatsword",
            new Weapon
            {
                name = "Human_Greatsword",
                damage = 3f,
                attackRange = 2.5f,
                weaponType = "Melee_TwoHanded"
            }
        },
        {
            "Human_Haldberd",
            new Weapon
            {
                name = "Human_Haldberd",
                damage = 2.5f,
                attackRange = 3f,
                weaponType = "Melee_TwoHanded"
            }
        },
        {
            "GreatAxe",
            new Weapon
            {
                name = "GreatAxe",
                damage = 4f,
                attackRange = 3.5f,
                weaponType = "Melee_TwoHanded"
            }
        },
        {
            "Doublesword",
            new Weapon
            {
                name = "Doublesword",
                damage = 4f,
                attackRange = 2f,
                weaponType = "Melee_OnwHanded"
            }
        },
        {
            "BlackSword",
            new Weapon
            {
                name = "BlackSword",
                damage = 5f,
                attackRange = 2f,
                weaponType = "Melee_OneHanded"
            }
        },
        {
            "Claws",
            new Weapon
            {
                name = "Claws",
                damage = 5f,
                attackRange = 1f,
                weaponType = "Melee_Stab"
            }
        },
        {
            "StoneGreatsword",
            new Weapon
            {
                name = "StoneGreatsword",
                damage = 3f,
                attackRange = 3f,
                weaponType = "Melee_TwoHanded"
            }
        },
        {
            "SplitBlade",
            new Weapon
            {
                name = "SplitBlade",
                damage = 5f,
                attackRange = 2f,
                weaponType = "Melee_OneHanded"
            }
        },
        {
            "Scythe",
            new Weapon
            {
                name = "Scythe",
                damage = 3,
                attackRange = 3f,
                weaponType = "Melee_TwoHanded"
            }
        },
        {
            "Rapier",
            new Weapon
            {
                name = "Rapier",
                damage = 5f,
                attackRange = 2f,
                weaponType = "Melee_Stab"
            }
        },
        {
            "Human_Zweihander",
            new Weapon
            {
                name = "Human_Zweihander",
                damage = 5f,
                attackRange = 3f,
                weaponType = "Melee_TwoHanded"
            }
        },
        {
            "Human_Spear",
            new Weapon
            {
                name = "Human_Spear",
                damage = 2.5f,
                attackRange = 4f,
                weaponType = "Melee_Stab"
            }
        },
        {
            "Katana",
            new Weapon
            {
                name = "Katana",
                damage = 3.5f,
                attackRange = 2f,
                weaponType = "Melee_OneHanded"
            }
        },
    };

}
