using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Dorkbots.ServiceLocatorTools;

public class EnemySpawner : MonoBehaviour
{

    private IObjectPooler objectPooler;
    private ISpawnManager spawnManager;

    private float spawnDelayMin = 2.0f;
    private float spawnDelayMax = 4.0f; 
    private float spawnDelayCounter;
    private float spawnDelayRate;

    private int maxEnemies = 20;

    // Start is called before the first frame update
    void Start()
    {
        objectPooler = ServiceLocator.Resolve<IObjectPooler>();
        spawnManager = ServiceLocator.Resolve<ISpawnManager>();

        spawnDelayCounter = 0;
    }

    // Update is called once per frame
    void Update()
    {
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
        print("Enemy spawned: " + spawnManager.enemyToSpawn);
        spawnManager.numEnemies += 1;
        spawnManager.bankValue -= 1;
    }
}
