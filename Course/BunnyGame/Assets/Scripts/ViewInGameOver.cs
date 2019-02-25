using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ViewInGameOver : MonoBehaviour
{

    public Text coinsLabel;
    public Text scoreLabel;

    public static ViewInGameOver sharedInstance;

    void Awake()
    {
        sharedInstance = this;
    }

    public void UpdateUI()
    {
        if (GameManager.sharedInstance.currentGameState == GameState.gameOver)
        {
            coinsLabel.text = GameManager.sharedInstance.collectedCoins.ToString();
            scoreLabel.text = PlayerController.sharedInstance.GetDistance().ToString("f0");
        }
    }

}
