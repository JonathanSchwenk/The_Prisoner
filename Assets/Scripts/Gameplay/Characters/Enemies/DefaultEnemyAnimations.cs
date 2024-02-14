using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Dorkbots.ServiceLocatorTools;
using System;
using UnityEngine.AI;

public class DefaultEnemyAnimations : MonoBehaviour {

    [SerializeField] private Animator animator;
    [SerializeField] private NavMeshAgent agent;

    private GameObject target;
    private float distanceFromTarget;
    private float enemyAttackRange;
    private Vector3 previousPosition;
    private bool isAlive = true;

    private IGameManager gameManager;
    private IStatsManager statsManager;

    // Start is called before the first frame update
    void Start() {

        animator.SetBool("Static_b", true);
        animator.SetInteger("MeleeType_int", 0);
        animator.SetInteger("WeaponType_int", 0);

        gameManager = ServiceLocator.Resolve<IGameManager>();
        statsManager = ServiceLocator.Resolve<IStatsManager>();

        target = gameManager.player;

        previousPosition = transform.position;
        enemyAttackRange = statsManager.enemyAttackRange;

        agent.stoppingDistance = statsManager.enemyAttackRange;
    }

    // Update is called once per frame
    void Update() {
        isAlive = GetComponent<Enemy>().health > 0;

        if (target) {
            distanceFromTarget = (float)Math.Sqrt(Math.Pow(target.transform.position.x - transform.position.x, 2) + Math.Pow(target.transform.position.z - transform.position.z, 2));

            if (distanceFromTarget <= enemyAttackRange && isAlive) {
                animator.SetFloat("Speed_f", 0);
                animator.SetInteger("WeaponType_int", 12);
                animator.SetInteger("MeleeType_int", 1);
                StartCoroutine(StopAnimation(0.8f));
            } else {
                // Calculate the movement direction
                Vector3 movementDirection = transform.position - previousPosition;

                // Normalize the direction vector to get only the direction (without the magnitude)
                movementDirection.Normalize();

                // Update the previous position for the next frame
                previousPosition = transform.position;

                float speedValue = movementDirection.magnitude * statsManager.enemySpeed;
                // Run
                animator.SetFloat("Speed_f", speedValue);
            }
        }
    }

    IEnumerator StopAnimation(float time) {
        yield return new WaitForSeconds(time);
        animator.SetInteger("WeaponType_int", 0);
        animator.SetInteger("MeleeType_int", 0);
    }
}
