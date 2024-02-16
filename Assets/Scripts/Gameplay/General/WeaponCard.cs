using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Dorkbots.ServiceLocatorTools;
using TMPro;
using UnityEngine.UI;

public class WeaponCard : MonoBehaviour
{
    [SerializeField] private GameObject selectedBackground;
    [SerializeField] private GameObject selectedShadow;
    [SerializeField] private GameObject unselectedBackground;
    [SerializeField] private GameObject unselectedShadow;
    [SerializeField] TextMeshProUGUI weaponName;
    [SerializeField] private Player_Weapons weaponDictionary;

    [SerializeField] private GameObject lockedBackground;
    [SerializeField] private GameObject unlockedBackground;

    private IGameManager gameManager;
    private IStatsManager statsManager;

    // Start is called before the first frame update
    void Start() {
        gameManager = ServiceLocator.Resolve<IGameManager>();
        statsManager = ServiceLocator.Resolve<IStatsManager>();

        weaponName.text = gameObject.name;
    }

    // Update is called once per frame
    void Update()
    {
        if (statsManager.playerUnlockedWeapons.ContainsKey(gameObject.name)) {
            lockedBackground.SetActive(false);
            unlockedBackground.SetActive(true);
        } else {
            lockedBackground.SetActive(true);
            unlockedBackground.SetActive(false);
        }

        if (gameManager.player.GetComponent<Player>().activeWeapon.name == gameObject.name) {
            selectedBackground.SetActive(true);
            selectedShadow.SetActive(true);
            unselectedBackground.SetActive(false);
            unselectedShadow.SetActive(false);
        } else {
            selectedBackground.SetActive(false);
            selectedShadow.SetActive(false);
            unselectedBackground.SetActive(true);
            unselectedShadow.SetActive(true);
        }
    }

    public void SelectWeapon() {
        if (statsManager.playerUnlockedWeapons.ContainsKey(gameObject.name)) {
            gameManager.player.GetComponent<Player>().activeWeapon = weaponDictionary.playerWeaponsDict[gameObject.name];
        }
    }
}
