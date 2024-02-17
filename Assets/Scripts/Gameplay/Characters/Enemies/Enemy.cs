using System.Collections;
using System.Collections.Generic;
using Dorkbots.ServiceLocatorTools;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour {

    [SerializeField] private Animator animator;
    [SerializeField] private NavMeshAgent agent;


    private IGameManager gameManager;
    private ISpawnManager spawnManager;
    private IStatsManager statsManager;
    private IAudioManager audioManager;

    public float health { get; set; }
    public Weapon activeWeapon { get; set; }

    private GameObject activeSkin;


    // Start is called before the first frame update
    void Start() {
        gameManager = ServiceLocator.Resolve<IGameManager>();
        spawnManager = ServiceLocator.Resolve<ISpawnManager>();
        statsManager = ServiceLocator.Resolve<IStatsManager>();
        audioManager = ServiceLocator.Resolve<IAudioManager>();

        health = statsManager.enemyHealth;

        for (int i = 0; i < transform.childCount; i++) {
            // Get the i-th child.
            GameObject child = transform.GetChild(i).gameObject;

            // Check if this child is active.
            if (child.activeSelf) {
                activeSkin = child;
            }
        }
    }

    // Update is called once per frame
    void Update() {
        if (gameManager.State == GameState.GameOver) {
            gameObject.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.tag == "Player_Weapon") {
            audioManager.PlaySFX("EnemyHit");

            activeSkin.GetComponent<SkinnedMeshRenderer>().material.color = Color.red;
            StartCoroutine(ChangeColorBack(0.2f));
            health -= gameManager.player.GetComponent<Player>().activeWeapon.damage;
            if (health <= 0) {
                animator.SetBool("Death_b", true);
                animator.SetInteger("DeathType_int", 1);

                animator.SetInteger("MeleeType_int", 0);
                animator.SetInteger("WeaponType_int", 0);

                agent.isStopped = true;

                gameObject.GetComponent<Collider>().enabled = false;

                spawnManager.numEnemies -= 1;

                StartCoroutine(RemovedDead(5.0f));
            }
        }
    }

    IEnumerator ChangeColorBack(float time) {
        yield return new WaitForSeconds(time);
        activeSkin.GetComponent<SkinnedMeshRenderer>().material.color = Color.white;
    }

    IEnumerator RemovedDead(float time) {
        yield return new WaitForSeconds(time);
        gameObject.SetActive(false);
    }
}
