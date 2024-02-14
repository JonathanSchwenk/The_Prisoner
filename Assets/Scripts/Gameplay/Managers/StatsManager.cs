using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatsManager : MonoBehaviour, IStatsManager
{
    [SerializeField] float enemySpeedLocal;
    [SerializeField] float playerSpeedLocal;
    [SerializeField] float enemyAttackRangeLocal;


    public float enemySpeed {get; set;}
    public float playerSpeed {get; set;}
    public float enemyAttackRange {get; set;}


    // Start is called before the first frame update
    void Start()
    {
        enemySpeed = enemySpeedLocal;
        playerSpeed = playerSpeedLocal;
        enemyAttackRange = enemyAttackRangeLocal;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
