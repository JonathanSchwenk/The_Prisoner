using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Dorkbots.ServiceLocatorTools;

public class Player : MonoBehaviour
{
    [SerializeField] private Player_Weapons weaponDictionary;
    [SerializeField] private GameObject playerWeaponList;

    private IStatsManager statsManager;

    public float health {get; set;}
    public Weapon activeWeapon {get; set;}

    public float maxHealth {get; private set;}

    private float healthRecoveryRate;
    private float healthRecoveryCounter;
    private float timeToWaitBeforeRecovery;
    private float timeToWaitBeforeRecoveryCounter;


    // Start is called before the first frame update
    void Start()
    {
        statsManager = ServiceLocator.Resolve<IStatsManager>();
        maxHealth = 100;

        activeWeapon = weaponDictionary.playerWeaponsDict["Long Sword"];
        health = maxHealth;

        // Health recovery active timer init (1 is kinda fast, maybe try 2)
        healthRecoveryRate = 0.1f; 
        healthRecoveryCounter = healthRecoveryRate;

        // Health Recovery time to wait before you start getting health back (2 is a bit too fast, maybe try 4-5)
        timeToWaitBeforeRecovery = 2.0f; 
        timeToWaitBeforeRecoveryCounter = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        // Bad practice and I should make an action for this subscribed to when the active weapon changes
        for (int i = 0; i < playerWeaponList.transform.childCount; i++) {
            if (playerWeaponList.transform.GetChild(i).name == activeWeapon.name) {
                playerWeaponList.transform.GetChild(i).gameObject.SetActive(true);
            } else {
                playerWeaponList.transform.GetChild(i).gameObject.SetActive(false);
            }
        }

        if (health < maxHealth) {
            timeToWaitBeforeRecoveryCounter += 1 * Time.deltaTime;
            if (timeToWaitBeforeRecoveryCounter >= timeToWaitBeforeRecovery) {
                RecoverHealth();
            }
        }
    }

    private void RecoverHealth() {

        healthRecoveryCounter += 1 * Time.deltaTime;

        if (healthRecoveryCounter >= healthRecoveryRate) {
            if (health < maxHealth) {
                health += 0.1f;
                healthRecoveryCounter = 0;
            }
        }
    }

    private void OnTriggerEnter(Collider other) {
        print("Player hit by: " + other.gameObject.tag);
        if (other.gameObject.tag == "Enemy_Weapon") {
            health -= statsManager.enemyAttackDamage;
            timeToWaitBeforeRecoveryCounter = 0;
            print("Player health: " + health);
        }
    }
}
