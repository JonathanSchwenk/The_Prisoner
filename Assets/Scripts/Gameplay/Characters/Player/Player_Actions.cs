using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Dorkbots.ServiceLocatorTools;

public class Player_Actions : MonoBehaviour {
    [SerializeField] private Animator animator;


    private GameManager gameManager;


    // Start is called before the first frame update
    void Start() {
        gameManager = ServiceLocator.Resolve<IGameManager>() as GameManager;
    }

    void Update() {
        // Check for left mouse button click
        if (Input.GetMouseButtonDown(0)) // 0 is the button number for the left mouse button
        {
            Attack();
        }
    }

    private void Attack() {
        // Trigger attack animation or logic
        if (gameManager.player.GetComponent<Player>().activeWeapon.weaponType == "One Handed") {
            // For one handed melee weapons
            animator.SetInteger("WeaponType_int", 12);
            animator.SetInteger("MeleeType_int", 1);
            StartCoroutine(StopAnimation(0.8f));
        } else if (gameManager.player.GetComponent<Player>().activeWeapon.weaponType == "Two Handed") {
            // For two handed melee weapons
            animator.SetInteger("WeaponType_int", 12);
            animator.SetInteger("MeleeType_int", 2);
            StartCoroutine(StopAnimation(0.8f));
        } else if (gameManager.player.GetComponent<Player>().activeWeapon.weaponType == "Stab") {
            // For stabbing melee weapons
            animator.SetInteger("WeaponType_int", 12);
            animator.SetInteger("MeleeType_int", 0);
            StartCoroutine(StopAnimation(0.8f));
        }
    }

    IEnumerator StopAnimation(float time) {
        yield return new WaitForSeconds(time);
        animator.SetInteger("WeaponType_int", 0);
        animator.SetInteger("MeleeType_int", 0);
    }
}
