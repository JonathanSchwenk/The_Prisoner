using UnityEngine;
using System;
using Dorkbots.ServiceLocatorTools;
using System.Collections.Generic;

public class GameManager : MonoBehaviour, IGameManager {
    public GameState State { get; set; }
    public Action<GameState> OnGameStateChanged { get; set; }
    public Action<int> OnRoundChanged { get; set; }
    public GameObject player { get; set; }
    public int RoundNum { get; set; }

    [SerializeField] GameObject playerLocal;
    [SerializeField] GameObject doors;


    private ISaveManager saveManager;
    private IAudioManager audioManager;
    private ISpawnManager spawnManager;


    void OnDestroy() {
        OnGameStateChanged = null;
    }

    // Sets the state to ready when the game starts 
    void Start() {
        saveManager = ServiceLocator.Resolve<ISaveManager>();
        audioManager = ServiceLocator.Resolve<IAudioManager>();
        spawnManager = ServiceLocator.Resolve<ISpawnManager>();

        player = playerLocal;

        UpdateGameState(GameState.Doors);

        RoundNum = 0; // 0 for survival
        UpdateRound();
    }

    // For next game, control more with this game managers state machine to keep everything in one spot
    // Update game state function
    public void UpdateGameState(GameState newState) {
        State = newState;

        // Swtich statement that deals with each possible state 
        switch (newState) {
            case GameState.Doors:
                player.SetActive(false);
                doors.SetActive(true);
                break;
            case GameState.Idle:
                player.SetActive(true);
                doors.SetActive(false);
                break;
            case GameState.Playing:
                player.SetActive(true);
                doors.SetActive(false);
                break;
            case GameState.GameOver:
                player.SetActive(true);
                doors.SetActive(false);

                spawnManager.numEnemies = 0;

                if (saveManager.saveData.bestRound < RoundNum) {
                    saveManager.saveData.bestRound = RoundNum;
                    saveManager.Save();
                }
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(newState), newState, null);
        }

        // Null checker then calls the action for anthing subscribed to it
        OnGameStateChanged?.Invoke(newState);
    }

    public void UpdateRound() {
        RoundNum += 1;
        OnRoundChanged?.Invoke(RoundNum);
    }


}




// GameState enum (basically a definition)
public enum GameState {
    Doors,
    Idle,
    Playing,
    GameOver
}


