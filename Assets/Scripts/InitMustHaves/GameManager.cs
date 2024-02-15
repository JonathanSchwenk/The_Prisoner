using UnityEngine;
using System;
using Dorkbots.ServiceLocatorTools;
using System.Collections.Generic;

public class GameManager : MonoBehaviour, IGameManager
{
    public GameState State {get; set;}
    public Action<GameState> OnGameStateChanged {get; set;}
    public Action<int> OnRoundChanged {get; set;}
    public GameObject player {get; set;}
    public int RoundNum {get; set;}

    [SerializeField] GameObject playerLocal;


    private ISaveManager saveManager;
    private IAudioManager audioManager;


    void OnDestroy() {
        OnGameStateChanged = null;
    }

    // Sets the state to ready when the game starts 
    void Awake() {
        saveManager = ServiceLocator.Resolve<ISaveManager>();
        audioManager = ServiceLocator.Resolve<IAudioManager>();

        player = playerLocal;

        UpdateGameState(GameState.Playing);

        RoundNum = 0; // 0 for survival
        UpdateRound();
    }

    // For next game, control more with this game managers state machine to keep everything in one spot
    // Update game state function
    public void UpdateGameState(GameState newState) {
        State = newState;

        // Swtich statement that deals with each possible state 
        switch(newState) {
            case GameState.Tutorial:

                break;
            case GameState.Idle:
                
                break;
            case GameState.Playing:
                
                break;
            case GameState.GameOver:

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
    Tutorial,
    Idle,
    Playing,
    GameOver
}


