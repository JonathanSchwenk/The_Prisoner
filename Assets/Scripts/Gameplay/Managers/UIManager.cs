using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Dorkbots.ServiceLocatorTools;

public class UIManager : MonoBehaviour {

    [SerializeField] private GameObject pauseCanvas;
    [SerializeField] private GameObject gameOverCanvas;
    [SerializeField] private GameObject gameplayCanvas;
    [SerializeField] private GameObject doorCanvas;
    [SerializeField] private GameObject instructionsCanvas;

    private IGameManager gameManager; // GameManager and ServiceManager must be executed first

    void Awake() {
        gameManager = ServiceLocator.Resolve<IGameManager>();

        // Subscribes to gamemanagers actions
        if (gameManager != null) {
            gameManager.OnGameStateChanged += GameManagerOnGameStateChanged;

        }
    }

    void OnDestroy() {
        gameManager.OnGameStateChanged -= GameManagerOnGameStateChanged;
    }


    private void GameManagerOnGameStateChanged(GameState state) {
        if (state == GameState.Playing) {
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;

            Time.timeScale = 1;
            pauseCanvas.SetActive(false);
            gameOverCanvas.SetActive(false);
            gameplayCanvas.SetActive(true);
            doorCanvas.SetActive(false);
        } else if (state == GameState.Idle) {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            
            Time.timeScale = 0;
            pauseCanvas.SetActive(true);
            gameOverCanvas.SetActive(false);
            gameplayCanvas.SetActive(false);
            doorCanvas.SetActive(false);
        } else if (state == GameState.GameOver) {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;

            Time.timeScale = 0;
            pauseCanvas.SetActive(false);
            gameOverCanvas.SetActive(true);
            gameplayCanvas.SetActive(false);
            doorCanvas.SetActive(false);
        } else if (state == GameState.Doors) {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;

            Time.timeScale = 1;
            pauseCanvas.SetActive(false);
            gameOverCanvas.SetActive(false);
            gameplayCanvas.SetActive(false);
            doorCanvas.SetActive(true);
        } 
    }
    // Start is called before the first frame update
    void Start() {

    }

    // Update is called once per frame
    void Update() {
        if (Input.GetKeyDown(KeyCode.Space)) {
            if (gameManager.State == GameState.Playing && gameManager.State != GameState.Doors || gameManager.State == GameState.GameOver) {
                gameManager.UpdateGameState(GameState.Idle);
            } else if (gameManager.State == GameState.Idle && gameManager.State != GameState.Doors || gameManager.State == GameState.GameOver) {
                gameManager.UpdateGameState(GameState.Playing);
            }
        }

        if (Input.GetKeyDown(KeyCode.I)) {
            if (gameManager.State == GameState.Idle) {
                if (instructionsCanvas.activeSelf) {
                    instructionsCanvas.SetActive(false);
                    pauseCanvas.SetActive(true);
                } else {
                    instructionsCanvas.SetActive(true);
                    pauseCanvas.SetActive(false);
                }
            } else if (gameManager.State == GameState.GameOver) {
                if (instructionsCanvas.activeSelf) {
                    instructionsCanvas.SetActive(false);
                    gameOverCanvas.SetActive(true);
                } else {
                    instructionsCanvas.SetActive(true);
                    gameOverCanvas.SetActive(false);
                }
            } else {
                if (instructionsCanvas.activeSelf) {
                    instructionsCanvas.SetActive(false);
                } else {
                    instructionsCanvas.SetActive(true);
                }
            }
        }
    }
}
