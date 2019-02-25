using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ViewInGame : MonoBehaviour
{
    public Text coinsLabel;
    public Text scoreLabel;
    public Text highScoreLabel;

    public static ViewInGame sharedInstance;

    private void Awake()
    {
        sharedInstance = this;
    }


    // Update is called once per frame
    void Update()
    {
        if (GameManager.sharedInstance.currentGameState == GameState.inTheGame)
        {
            scoreLabel.text = PlayerController.sharedInstance.GetDistance().ToString("f0"); // Parse the float to return 0 decimal
        }
    }

    public void UpdateHighScoreLabel()
    {
        if (GameManager.sharedInstance.currentGameState == GameState.inTheGame)
        {
            highScoreLabel.text = PlayerPrefs.GetFloat("highscore", 0).ToString("f0");
        }
    }

    public void UpdateCoinsLabel()
    {
        if (GameManager.sharedInstance.currentGameState == GameState.inTheGame)
        {
            coinsLabel.text = GameManager.sharedInstance.collectedCoins.ToString();
        }
    }


}
