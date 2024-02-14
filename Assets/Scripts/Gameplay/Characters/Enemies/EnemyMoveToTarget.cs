using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Dorkbots.ServiceLocatorTools;

public class EnemyMoveToTarget : MonoBehaviour {

    [SerializeField] private NavMeshAgent agent;
    private GameObject target;


    private IGameManager gameManager;
    private IStatsManager statsManager;

    void Awake() {
        gameManager = ServiceLocator.Resolve<IGameManager>();
        statsManager = ServiceLocator.Resolve<IStatsManager>();
    }

    // Start is called before the first frame update
    void Start() {
        target = gameManager.player;
        agent.speed = statsManager.enemySpeed;
    }

    // Update is called once per frame
    void Update() {
        if (target) {
            agent.SetDestination(target.transform.position);
        }
    }
}
