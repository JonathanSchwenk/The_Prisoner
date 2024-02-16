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
            if (spawnManager.enemyToSpawn == "Goblin_OneHanded") {
                int enemyToSpawn = Random.Range(0, 2);
                if (enemyToSpawn == 0) {
                    enemy = objectPooler.SpawnFromPool("Goblin_Male", transform.position, Quaternion.identity);
                } else {
                    enemy = objectPooler.SpawnFromPool("Goblin_Warrior", transform.position, Quaternion.identity);
                }
                enemy.GetComponent<DefaultEnemyAnimations>().enemyType = "One Handed";
            } else if (spawnManager.enemyToSpawn == "Goblin_TwoHanded") {
                int enemyToSpawn = Random.Range(0, 2);
                if (enemyToSpawn == 0) {
                    enemy = objectPooler.SpawnFromPool("Goblin_King", transform.position, Quaternion.identity);
                } else {
                    enemy = objectPooler.SpawnFromPool("Goblin_WitchDoctor", transform.position, Quaternion.identity);
                }
                enemy.GetComponent<DefaultEnemyAnimations>().enemyType = "Two Handed";
            } else if (spawnManager.enemyToSpawn == "Goblin_Stab") {
                int enemyToSpawn = Random.Range(0, 2);
                if (enemyToSpawn == 0) {
                    enemy = objectPooler.SpawnFromPool("Goblin_Female", transform.position, Quaternion.identity);
                } else {
                    enemy = objectPooler.SpawnFromPool("Goblin_Hunter", transform.position, Quaternion.identity);
                }
                enemy.GetComponent<DefaultEnemyAnimations>().enemyType = "Stab";
            }
        }

        //Human
        if (gameObject.tag == "Human_Spawner") {
            if (spawnManager.enemyToSpawn == "Human_OneHanded") {
                int enemyToSpawn = Random.Range(0, 2);
                if (enemyToSpawn == 0) {
                    enemy = objectPooler.SpawnFromPool("Human_Knight_Dark", transform.position, Quaternion.identity);
                } else {
                    enemy = objectPooler.SpawnFromPool("Human_Knight_Tin", transform.position, Quaternion.identity);
                }
                enemy.GetComponent<DefaultEnemyAnimations>().enemyType = "One Handed";
            } else if (spawnManager.enemyToSpawn == "Human_TwoHanded") {
                int enemyToSpawn = Random.Range(0, 2);
                if (enemyToSpawn == 0) {
                    enemy = objectPooler.SpawnFromPool("Human_Knight_Heavy_1", transform.position, Quaternion.identity);
                } else {
                    enemy = objectPooler.SpawnFromPool("Human_Knight_Heavy_2", transform.position, Quaternion.identity);
                }
                enemy.GetComponent<DefaultEnemyAnimations>().enemyType = "Two Handed";
            } else if (spawnManager.enemyToSpawn == "Human_Stab") {
                int enemyToSpawn = Random.Range(0, 2);
                if (enemyToSpawn == 0) {
                    enemy = objectPooler.SpawnFromPool("Human_Knight_1", transform.position, Quaternion.identity);
                } else {
                    enemy = objectPooler.SpawnFromPool("Human_Knight_2", transform.position, Quaternion.identity);
                }
                enemy.GetComponent<DefaultEnemyAnimations>().enemyType = "Stab";
            }
        }

        // Elf
        if (gameObject.tag == "Elf_Spawner") {
            if (spawnManager.enemyToSpawn == "Elf_OneHanded") {
                int enemyToSpawn = Random.Range(0, 2);
                if (enemyToSpawn == 0) {
                    enemy = objectPooler.SpawnFromPool("Elf_Male", transform.position, Quaternion.identity);
                } else {
                    enemy = objectPooler.SpawnFromPool("Elf_Female", transform.position, Quaternion.identity);
                }
                enemy.GetComponent<DefaultEnemyAnimations>().enemyType = "One Handed";
            } else if (spawnManager.enemyToSpawn == "Elf_TwoHanded") {
                int enemyToSpawn = Random.Range(0, 2);
                if (enemyToSpawn == 0) {
                    enemy = objectPooler.SpawnFromPool("Elf_King", transform.position, Quaternion.identity);
                } else {
                    enemy = objectPooler.SpawnFromPool("Elf_Knight", transform.position, Quaternion.identity);
                }
                enemy.GetComponent<DefaultEnemyAnimations>().enemyType = "Two Handed";
            } else if (spawnManager.enemyToSpawn == "Elf_Stab") {
                enemy = objectPooler.SpawnFromPool("Elf_Assassin", transform.position, Quaternion.identity);
                enemy.GetComponent<DefaultEnemyAnimations>().enemyType = "Stab";
            }
        }

        // Undead
        if (gameObject.tag == "Undead_Spawner") {
            if (spawnManager.enemyToSpawn == "Undead_OneHanded") {
                int enemyToSpawn = Random.Range(0, 2);
                if (enemyToSpawn == 0) {
                    enemy = objectPooler.SpawnFromPool("Undead_King", transform.position, Quaternion.identity);
                } else {
                    enemy = objectPooler.SpawnFromPool("Undead_Footman_02", transform.position, Quaternion.identity);
                }
                enemy.GetComponent<DefaultEnemyAnimations>().enemyType = "One Handed";
            } else if (spawnManager.enemyToSpawn == "Undead_TwoHanded") {
                int enemyToSpawn = Random.Range(0, 2);
                if (enemyToSpawn == 0) {
                    enemy = objectPooler.SpawnFromPool("Undead_Heavy", transform.position, Quaternion.identity);
                } else {
                    enemy = objectPooler.SpawnFromPool("Undead_Footman_01", transform.position, Quaternion.identity);
                }
                enemy.GetComponent<DefaultEnemyAnimations>().enemyType = "Two Handed";
            } else if (spawnManager.enemyToSpawn == "Undead_Stab") {
                int enemyToSpawn = Random.Range(0, 2);
                if (enemyToSpawn == 0) {
                    enemy = objectPooler.SpawnFromPool("Undead_Skeleton", transform.position, Quaternion.identity);
                } else {
                    enemy = objectPooler.SpawnFromPool("Undead_Rogue", transform.position, Quaternion.identity);
                }
                enemy.GetComponent<DefaultEnemyAnimations>().enemyType = "Stab";
            }
        }

        spawnManager.numEnemies += 1;
        spawnManager.bankValue -= 1;
    }
}