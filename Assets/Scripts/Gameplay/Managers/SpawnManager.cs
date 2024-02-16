using System.Collections;
using System.Collections.Generic;
using Dorkbots.ServiceLocatorTools;
using UnityEngine;

public class SpawnManager : MonoBehaviour, ISpawnManager
{
    public string enemyToSpawn {get; set;} // This gets set by doors
    public int numEnemies {get; set;}
    public int bankValue {get; set;}
    public bool canSpawn {get; set;}

    private int bankCap = 20; // Max enemies for a level 
    private int mutliplier = 2;
    private bool roundUpdated = false;

    private IGameManager gameManager;

    void Start() {
        gameManager = ServiceLocator.Resolve<IGameManager>();

        // Subscribes to gamemanagers actions
        if (gameManager != null) {
            gameManager.OnRoundChanged += GameManagerOnRoundNumChanged;
            gameManager.OnGameStateChanged += GameManagerOnGameStateChanged;

        }

        // enemyToSpawn = "UndeadDoor";

        numEnemies = 0;
        bankValue = gameManager.RoundNum * mutliplier;
    }

    void OnDestroy() {
        gameManager.OnRoundChanged -= GameManagerOnRoundNumChanged;
        gameManager.OnGameStateChanged -= GameManagerOnGameStateChanged;
    }

    
    private void GameManagerOnRoundNumChanged(int newRoundNum) {
        bankValue = gameManager.RoundNum * mutliplier;

        if (bankValue > bankCap) {
            bankValue = bankCap;
        }
        roundUpdated = false;
    }

    private void GameManagerOnGameStateChanged(GameState state) { 
        if (state == GameState.Playing) {
            canSpawn = true;
        } else {
            canSpawn = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (gameManager.State == GameState.Playing) {
            canSpawn = true;
        } else {
            canSpawn = false;
        }

        print("bankValue: " + bankValue + " numEnemies: " + numEnemies);
        if (bankValue == 0 && numEnemies == 0) {
            if (!roundUpdated) {
                roundUpdated = true;
                StartCoroutine(ChangeState(5.0f));
            }
        }
    }

    IEnumerator ChangeState(float time) {
        yield return new WaitForSeconds(time);
        gameManager.UpdateGameState(GameState.Doors);
        gameManager.UpdateRound();
        gameManager.player.GetComponent<Player>().health = gameManager.player.GetComponent<Player>().maxHealth;
    }
}
