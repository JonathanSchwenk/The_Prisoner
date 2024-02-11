using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Actions : MonoBehaviour {
    [SerializeField] private Animator animator;


    // Start is called before the first frame update
    void Start() {

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
        animator.SetInteger("WeaponType_int", 12);
        animator.SetInteger("MeleeType_int", 1);
        StartCoroutine(StopAnimation(0.8f));
    }

    // StartCoroutine(KnifeDamageCollider());
    IEnumerator StopAnimation(float time) {
        yield return new WaitForSeconds(time);
        animator.SetInteger("WeaponType_int", 0);
        animator.SetInteger("MeleeType_int", 0);
    }
}
