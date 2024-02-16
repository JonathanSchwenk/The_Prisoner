using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorCharacters : MonoBehaviour
{
    [SerializeField] private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        animator.SetInteger("MeleeType_int", 0);
        animator.SetInteger("WeaponType_int", 0);

        animator.SetInteger("Animation_int", Random.Range(1, 8));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
