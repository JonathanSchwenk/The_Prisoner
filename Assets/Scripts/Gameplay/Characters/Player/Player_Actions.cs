using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Dorkbots.ServiceLocatorTools;

public class Player_Actions : MonoBehaviour {
    [SerializeField] private Animator animator;


    private IGameManager gameManager;
    private IAudioManager audioManager;


    private void GameManagerOnRoundNumChanged(int newRoundNum) {
        if (gameObject.activeSelf) {
            StartCoroutine(StopAnimation(0.8f));
        }
    }


    // Start is called before the first frame update
    void Start() {
        gameManager = ServiceLocator.Resolve<IGameManager>();
        audioManager = ServiceLocator.Resolve<IAudioManager>();

        if (gameManager != null) {
            gameManager.OnRoundChanged += GameManagerOnRoundNumChanged;
        }
    }

    void OnDestroy() {
        if (gameManager != null) {
            gameManager.OnRoundChanged -= GameManagerOnRoundNumChanged;
        }
    }

    void Update() {
        // Check for left mouse button click
        if (Input.GetMouseButtonDown(0)) // 0 is the button number for the left mouse button
        {
            if (gameManager.player.GetComponent<Player>().playerIsDead == false) {
                Attack();
                StartCoroutine(DelaySound(0.25f));
            }
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

    IEnumerator DelaySound(float time) {
        yield return new WaitForSeconds(time);
        if (gameManager.player.GetComponent<Player>().activeWeapon.weaponType == "One Handed" || gameManager.player.GetComponent<Player>().activeWeapon.weaponType == "Two Handed") {
            audioManager.PlaySFX("PlayerAttack");
        } else {
            audioManager.PlaySFX("PlayerStab");
        }
    }
}
