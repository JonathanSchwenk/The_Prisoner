using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public interface IGameManager {
    GameState State {get; set;}
    Action<GameState> OnGameStateChanged {get; set;}
    Action<int> OnRoundChanged {get; set;}
    void UpdateGameState(GameState state);
    GameObject player {get; set;}
    int RoundNum {get; set;}
}

public interface IObjectPooler {
    List<Pool> Pools {get; set;}
    Dictionary<string, Queue<GameObject>> poolDictionary {get; set;}

    GameObject SpawnFromPool(string tag, Vector3 position, Quaternion rotation);
}

public interface ISaveManager {
    SaveData saveData {get; set;}
    Action<int>OnSave {get; set;}

    void Save();
    void Load();
    void DeleteSavedData();
}

public interface IAudioManager {
    void PlaySFX(string name);
    void StopSFX(string name);
    void PlayMusic(string name);
    void StopMusic(string name);
}


public interface IAdManager {
    void LoadRewardedAd();
}

public interface IStatsManager {
    float enemySpeed {get; set;}
    float playerSpeed {get; set;}
    float enemyAttackRange {get; set;}
}

public interface ISpawnManager {
    string enemyToSpawn {get; set;}
    int numEnemies {get; set;}
    int bankValue {get; set;}
    bool canSpawn {get; set;}
}

public interface IDoorManager {
    GameObject selectedDoor {get; set;}
    string enemyToSpawn {get; set;}
}
