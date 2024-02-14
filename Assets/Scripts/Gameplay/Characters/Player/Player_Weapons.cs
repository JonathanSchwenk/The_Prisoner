using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using Dorkbots.ServiceLocatorTools;

public class Player_Weapons : MonoBehaviour {

    private IGameManager gameManager;

    private Weapon activeWeapon;

    // Start is called before the first frame update
    void Start() {
        gameManager = ServiceLocator.Resolve<IGameManager>();

        activeWeapon = gameManager.player.GetComponent<Player>().activeWeapon;
    }

    // Update is called once per frame
    void Update() {

    }
}
