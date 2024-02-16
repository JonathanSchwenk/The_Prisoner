using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Dorkbots.ServiceLocatorTools;

public class EnemySpawner : MonoBehaviour {

    private IObjectPooler objectPooler;
    private ISpawnManager spawnManager;

    private float spawnDelayMin = 2.0f;
    private float spawnDelayMax = 4.0f;
    private float spawnDelayCounter;
    private float spawnDelayRate;

    private int maxEnemies = 20;

    // Start is called before the first frame update
    void Start() {
        objectPooler = ServiceLocator.Resolve<IObjectPooler>();
        spawnManager = ServiceLocator.Resolve<ISpawnManager>();

        spawnDelayCounter = 0;
    }

    // Update is called once per frame
    void Update() {
        if (spawnManager.canSpawn) {
            spawnDelayCounter += 1 * Time.deltaTime;
            if (spawnManager.numEnemies < maxEnemies && spawnManager.bankValue > 0) {
                if (spawnDelayCounter >= spawnDelayRate) {
                    SpawnEnemy();

                    spawnDelayRate = Random.Range(spawnDelayMin, spawnDelayMax);
                    spawnDelayCounter = 0;
                }
            }
        }
    }
    private void SpawnEnemy() {
        GameObject enemy;

        // Goblin
        if (gameObject.tag == "Goblin_Spawner") {
            if (spawnManager.enemyToSpawn == "Goblins") {
                int enemyToSpawn = Random.Range(0, 6);
                if (enemyToSpawn == 0) {
                    enemy = objectPooler.SpawnFromPool("Goblin_Male", transform.position, Quaternion.identity);
                    enemy.GetComponent<DefaultEnemyAnimations>().enemyType = "One Handed";
                } else if (enemyToSpawn == 1) {
                    enemy = objectPooler.SpawnFromPool("Goblin_Warrior", transform.position, Quaternion.identity);
                    enemy.GetComponent<DefaultEnemyAnimations>().enemyType = "One Handed";
                } else if (enemyToSpawn == 2) {
                    enemy = objectPooler.SpawnFromPool("Goblin_King", transform.position, Quaternion.identity);
                    enemy.GetComponent<DefaultEnemyAnimations>().enemyType = "Two Handed";
                } else if (enemyToSpawn == 3) {
                    enemy = objectPooler.SpawnFromPool("Goblin_WitchDoctor", transform.position, Quaternion.identity);
                    enemy.GetComponent<DefaultEnemyAnimations>().enemyType = "Two Handed";
                } else if (enemyToSpawn == 4) {
                    enemy = objectPooler.SpawnFromPool("Goblin_Female", transform.position, Quaternion.identity);
                    enemy.GetComponent<DefaultEnemyAnimations>().enemyType = "Stab";
                } else if (enemyToSpawn == 5) {
                    enemy = objectPooler.SpawnFromPool("Goblin_Hunter", transform.position, Quaternion.identity);
                    enemy.GetComponent<DefaultEnemyAnimations>().enemyType = "Stab";
                }
                spawnManager.numEnemies += 1;
                spawnManager.bankValue -= 1;
            }
        }

        //Human
        if (gameObject.tag == "Human_Spawner") {
            if (spawnManager.enemyToSpawn == "Humans") {
                int enemyToSpawn = Random.Range(0, 6);
                if (enemyToSpawn == 0) {
                    enemy = objectPooler.SpawnFromPool("Human_Knight_Dark", transform.position, Quaternion.identity);
                    enemy.GetComponent<DefaultEnemyAnimations>().enemyType = "One Handed";
                } else if (enemyToSpawn == 1) {
                    enemy = objectPooler.SpawnFromPool("Human_Knight_Tin", transform.position, Quaternion.identity);
                    enemy.GetComponent<DefaultEnemyAnimations>().enemyType = "One Handed";
                } else if (enemyToSpawn == 2) {
                    enemy = objectPooler.SpawnFromPool("Human_Knight_Heavy_1", transform.position, Quaternion.identity);
                    enemy.GetComponent<DefaultEnemyAnimations>().enemyType = "Two Handed";
                } else if (enemyToSpawn == 3) {
                    enemy = objectPooler.SpawnFromPool("Human_Knight_Heavy_2", transform.position, Quaternion.identity);
                    enemy.GetComponent<DefaultEnemyAnimations>().enemyType = "Two Handed";
                } else if (enemyToSpawn == 4) {
                    enemy = objectPooler.SpawnFromPool("Human_Knight_1", transform.position, Quaternion.identity);
                    enemy.GetComponent<DefaultEnemyAnimations>().enemyType = "Stab";
                } else if (enemyToSpawn == 5) {
                    enemy = objectPooler.SpawnFromPool("Human_Knight_2", transform.position, Quaternion.identity);
                    enemy.GetComponent<DefaultEnemyAnimations>().enemyType = "Stab";
                }
                spawnManager.numEnemies += 1;
                spawnManager.bankValue -= 1;
            }
        }

        // Elf
        if (gameObject.tag == "Elf_Spawner") {
            if (spawnManager.enemyToSpawn == "Elves") {
                int enemyToSpawn = Random.Range(0, 5);
                if (enemyToSpawn == 0) {
                    enemy = objectPooler.SpawnFromPool("Elf_Male", transform.position, Quaternion.identity);
                    enemy.GetComponent<DefaultEnemyAnimations>().enemyType = "One Handed";
                } else if (enemyToSpawn == 1) {
                    enemy = objectPooler.SpawnFromPool("Elf_Female", transform.position, Quaternion.identity);
                    enemy.GetComponent<DefaultEnemyAnimations>().enemyType = "One Handed";
                } else if (enemyToSpawn == 2) {
                    enemy = objectPooler.SpawnFromPool("Elf_King", transform.position, Quaternion.identity);
                    enemy.GetComponent<DefaultEnemyAnimations>().enemyType = "Two Handed";
                } else if (enemyToSpawn == 3) {
                    enemy = objectPooler.SpawnFromPool("Elf_Knight", transform.position, Quaternion.identity);
                    enemy.GetComponent<DefaultEnemyAnimations>().enemyType = "Two Handed";
                } else if (enemyToSpawn == 4) {
                    enemy = objectPooler.SpawnFromPool("Elf_Assassin", transform.position, Quaternion.identity);
                    enemy.GetComponent<DefaultEnemyAnimations>().enemyType = "Stab";
                }
                spawnManager.numEnemies += 1;
                spawnManager.bankValue -= 1;
            }
        }

        // Undead
        if (gameObject.tag == "Undead_Spawner") {
            if (spawnManager.enemyToSpawn == "Undead") {
                int enemyToSpawn = Random.Range(0, 6);
                if (enemyToSpawn == 0) {
                    enemy = objectPooler.SpawnFromPool("Undead_King", transform.position, Quaternion.identity);
                    enemy.GetComponent<DefaultEnemyAnimations>().enemyType = "One Handed";
                } else if (enemyToSpawn == 1) {
                    enemy = objectPooler.SpawnFromPool("Undead_Footman_02", transform.position, Quaternion.identity);
                    enemy.GetComponent<DefaultEnemyAnimations>().enemyType = "One Handed";
                } else if (enemyToSpawn == 2) {
                    enemy = objectPooler.SpawnFromPool("Undead_Heavy", transform.position, Quaternion.identity);
                    enemy.GetComponent<DefaultEnemyAnimations>().enemyType = "Two Handed";
                } else if (enemyToSpawn == 3) {
                    enemy = objectPooler.SpawnFromPool("Undead_Footman_01", transform.position, Quaternion.identity);
                    enemy.GetComponent<DefaultEnemyAnimations>().enemyType = "Two Handed";
                } else if (enemyToSpawn == 4) {
                    enemy = objectPooler.SpawnFromPool("Undead_Skeleton", transform.position, Quaternion.identity);
                    enemy.GetComponent<DefaultEnemyAnimations>().enemyType = "Stab";
                } else if (enemyToSpawn == 5) {
                    enemy = objectPooler.SpawnFromPool("Undead_Rogue", transform.position, Quaternion.identity);
                    enemy.GetComponent<DefaultEnemyAnimations>().enemyType = "Stab";
                }
                spawnManager.numEnemies += 1;
                spawnManager.bankValue -= 1;
            }
        }
    }
}
