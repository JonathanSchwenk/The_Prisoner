using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Dorkbots.ServiceLocatorTools;

public class Player : MonoBehaviour
{


    private IStatsManager statsManager;

    public float health {get; private set;}
    public Weapon activeWeapon {get; set;}


    // Start is called before the first frame update
    void Start()
    {
        statsManager = ServiceLocator.Resolve<IStatsManager>();

        activeWeapon = new Weapon {
            name = "Human_Sword_Long",
            damage = 2.5f,
            attackRange = 1.5f,
            weaponType = "Melee_OneHanded",
        };
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.tag == "Enemy_Weapon") {
            print("Enemy hit me");
        }
    }
}
