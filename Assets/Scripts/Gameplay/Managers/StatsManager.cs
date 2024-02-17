using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class StatsManager : MonoBehaviour, IStatsManager {
    [SerializeField] float enemySpeedLocal;
    [SerializeField] float playerSpeedLocal;
    [SerializeField] float enemyAttackRangeLocal;
    [SerializeField] float enemyAttackDamageLocal;
    [SerializeField] int bankCapLocal;
    [SerializeField] int maxEnemiesLocal;
    [SerializeField] int enemyHealthLocal;


    public float enemySpeed { get; set; }
    public float playerSpeed { get; set; }
    public float enemyAttackRange { get; set; }
    public float enemyAttackDamage { get; set; }
    public int bankCap { get; set; }
    public int maxEnemies { get; set; }
    public int enemyHealth { get; set; }
    public Dictionary<string, Weapon> playerUnlockedWeapons { get; set; }

    // enemy health for each enemy type


    // Start is called before the first frame update
    void Start() {
        enemySpeed = enemySpeedLocal;
        playerSpeed = playerSpeedLocal;
        enemyAttackRange = enemyAttackRangeLocal;
        enemyAttackDamage = enemyAttackDamageLocal;
        bankCap = bankCapLocal;
        maxEnemies = maxEnemiesLocal;
        enemyHealth = enemyHealthLocal;

        playerUnlockedWeapons = new Dictionary<string, Weapon> {
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
    }

    // Update is called once per frame
    void Update() {

    }
}
