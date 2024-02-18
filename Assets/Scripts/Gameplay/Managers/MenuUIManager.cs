using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuUIManager : MonoBehaviour
{
    [SerializeField] private GameObject mainMenuCanvas;
    [SerializeField] private GameObject instructionsCanvas;

    private bool isInstructions = false;

    public void StartGame() {
        SceneManager.LoadScene("Gameplay");
    }

    public void QuitGame() {
        Application.Quit();
    }

    public void Instructions() {
        if (isInstructions) {
            mainMenuCanvas.SetActive(true);
            instructionsCanvas.SetActive(false);
            isInstructions = false;
        } else {
            mainMenuCanvas.SetActive(false);
            instructionsCanvas.SetActive(true);
            isInstructions = true;
        }
    }


}
