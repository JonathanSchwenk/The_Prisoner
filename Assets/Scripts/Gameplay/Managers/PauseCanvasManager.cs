using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Dorkbots.ServiceLocatorTools;
using TMPro;
using UnityEngine.UI;

public class PauseCanvasManager : MonoBehaviour {
    [SerializeField] private TextMeshProUGUI weaponName;
    [SerializeField] private Slider weaponDamage;
    [SerializeField] private TextMeshProUGUI weaponType;
    [SerializeField] private Image weaponImage;
    [SerializeField] private GameObject weaponList;


    private IGameManager gameManager;

    // Start is called before the first frame update
    void Start() {
        gameManager = ServiceLocator.Resolve<IGameManager>();
    }

    // Update is called once per frame
    void Update() {
        weaponName.text = gameManager.player.GetComponent<Player>().activeWeapon.name;
        weaponDamage.value = gameManager.player.GetComponent<Player>().activeWeapon.damage;
        weaponType.text = gameManager.player.GetComponent<Player>().activeWeapon.weaponType;
        for (int i = 0; i < weaponList.transform.childCount; i++) {
            if (weaponList.transform.GetChild(i).name == gameManager.player.GetComponent<Player>().activeWeapon.name) {
                weaponImage.sprite = weaponList.transform.GetChild(i).transform.GetChild(2).GetComponent<Image>().sprite;
            }
        }
    }
}
