using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Dorkbots.ServiceLocatorTools;

public class Player : MonoBehaviour
{
    [SerializeField] private Player_Weapons weaponDictionary;
    [SerializeField] private GameObject playerWeaponList;

    private IStatsManager statsManager;

    public float health {get; private set;}
    public Weapon activeWeapon {get; set;}


    // Start is called before the first frame update
    void Start()
    {
        statsManager = ServiceLocator.Resolve<IStatsManager>();

        activeWeapon = weaponDictionary.playerWeaponsDict["Long Sword"];
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
    }

    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.tag == "Enemy_Weapon") {
            print("Enemy hit me");
        }
    }
}
