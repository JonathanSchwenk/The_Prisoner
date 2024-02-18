using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuCharacte : MonoBehaviour
{
    [SerializeField] private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        animator.SetInteger("Animation_int", 1);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
