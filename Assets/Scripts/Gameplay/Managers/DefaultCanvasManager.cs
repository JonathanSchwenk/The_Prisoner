using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Dorkbots.ServiceLocatorTools;
using TMPro;

public class DefaultCanvasManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI currentRound;

    private IGameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = ServiceLocator.Resolve<IGameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        currentRound.text = gameManager.RoundNum.ToString();
    }
}
