using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Dorkbots.ServiceLocatorTools;
using TMPro;
using UnityEngine.UI;

public class PlayerHudCanvasManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI enemiesRemaining;
    [SerializeField] private Slider healthSlider;

    private IGameManager gameManager;
    private ISpawnManager spawnManager;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = ServiceLocator.Resolve<IGameManager>();
        spawnManager = ServiceLocator.Resolve<ISpawnManager>();
    }

    // Update is called once per frame
    void Update()
    {
        enemiesRemaining.text = (spawnManager.numEnemies + spawnManager.bankValue).ToString();
        healthSlider.value = gameManager.player.GetComponent<Player>().health;
    }
}
