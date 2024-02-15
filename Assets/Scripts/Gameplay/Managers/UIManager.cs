using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Dorkbots.ServiceLocatorTools;

public class UIManager : MonoBehaviour {

    [SerializeField] GameObject pauseCanvas;
    [SerializeField] GameObject gameOverCanvas;
    [SerializeField] GameObject gameplayCanvas;

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
        } else if (state == GameState.Idle) {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            
            Time.timeScale = 0;
            pauseCanvas.SetActive(true);
            gameOverCanvas.SetActive(false);
            gameplayCanvas.SetActive(false);
        } else if (state == GameState.GameOver) {
            Time.timeScale = 0;
            pauseCanvas.SetActive(false);
            gameOverCanvas.SetActive(true);
            gameplayCanvas.SetActive(false);

        }
    }
    // Start is called before the first frame update
    void Start() {

    }

    // Update is called once per frame
    void Update() {
        if (Input.GetKeyDown(KeyCode.Space)) {
            if (gameManager.State == GameState.Playing) {
                gameManager.UpdateGameState(GameState.Idle);
            } else if (gameManager.State == GameState.Idle) {
                gameManager.UpdateGameState(GameState.Playing);
            }
        }
    }
}
