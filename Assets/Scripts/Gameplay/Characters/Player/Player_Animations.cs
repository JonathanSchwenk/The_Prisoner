using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Animations : MonoBehaviour
{
    [SerializeField] private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        animator.SetBool("Static_b", true);
        animator.SetInteger("MeleeType_int", 0);
        animator.SetInteger("WeaponType_int", 0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
