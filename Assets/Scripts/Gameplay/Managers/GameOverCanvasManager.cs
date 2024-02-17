using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Dorkbots.ServiceLocatorTools;
using TMPro;

public class GameOverCanvasManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI currentRoundText;
    [SerializeField] private TextMeshProUGUI bestRoundText;


    private ISaveManager saveManager;
    private IGameManager gameManager;
    private IStatsManager statsManager;
    private IAudioManager audioManager;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = ServiceLocator.Resolve<IGameManager>();
        saveManager = ServiceLocator.Resolve<ISaveManager>();
        statsManager = ServiceLocator.Resolve<IStatsManager>();
        audioManager = ServiceLocator.Resolve<IAudioManager>();
    }

    // Update is called once per frame
    void Update()
    {
        currentRoundText.text = gameManager.RoundNum.ToString();
        bestRoundText.text = saveManager.saveData.bestRound.ToString();
    }

    public void RestartGame() {
        gameManager.UpdateGameState(GameState.Doors);
        audioManager.PlaySFX("ButtonClick");

        gameManager.RoundNum = 0;
        gameManager.UpdateRound();

        statsManager.playerUnlockedWeapons = new Dictionary<string, Weapon> {
            {
                "Long Sword",
                new Weapon {
                    name = "Long Sword",
                    damage = 2.5f,
                    attackRange = 1.5f,
                    weaponType = "One Handed",
                }
            }
        };

        gameManager.player.GetComponent<Player>().activeWeapon = statsManager.playerUnlockedWeapons["Long Sword"];
        gameManager.player.GetComponent<Player>().health = gameManager.player.GetComponent<Player>().maxHealth;
    }
}
