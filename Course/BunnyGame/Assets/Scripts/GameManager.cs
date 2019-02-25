using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GameState
{
    menu,
    inTheGame,
    gameOver
}


public class GameManager : MonoBehaviour
{

    // Actual GameState
    public GameState currentGameState = GameState.menu;

    // singleton
    public static GameManager sharedInstance;

    public Canvas menuCanvas;
    public Canvas gameCanvas;
    public Canvas gameOverCanvas;

    public int collectedCoins = 0;

    void Awake()
    {
        // Initialize the singleton and share all the GameManager fields and methods with it
        sharedInstance = this;
    }

    void Start()
    {
        currentGameState = GameState.menu;
        menuCanvas.enabled = true;
        gameCanvas.enabled = false;
        gameOverCanvas.enabled = false;
    }

    void Update()
    {
        //if (currentGameState != GameState.inTheGame)
        //{
        //    if (Input.GetButtonDown("s"))
        //    {
        //        StartGame();
        //    }
        //}

    }

    // Use this for start the game
    public void StartGame()
    {
        PlayerController.sharedInstance.StartGame();
        LevelGenerator.sharedInstance.GenerateInitialBlocks();
        ChangeGameState(GameState.inTheGame);
        ViewInGame.sharedInstance.UpdateHighScoreLabel();
    }

    // Called when the player dies
    public void GameOver()
    {
        LevelGenerator.sharedInstance.RemoveAllTheBlocks();
        ChangeGameState(GameState.gameOver);
        ViewInGameOver.sharedInstance.UpdateUI();
    }

    // Call it when the user wants to finish and return to the main menu  
    public void BackToMainMenu()
    {
        ChangeGameState(GameState.menu);
    }

    // This method will manage the states of the game
    void ChangeGameState(GameState newGameState)
    {
        if (newGameState == GameState.menu)
        {
            // The logic of the principal menu
            menuCanvas.enabled = true;
            gameCanvas.enabled = false;
            gameOverCanvas.enabled = false;
        }
        else if (newGameState == GameState.inTheGame)
        {
            // This is the current scene or level of the game
            menuCanvas.enabled = false;
            gameCanvas.enabled = true;
            gameOverCanvas.enabled = false;
        }
        else if (newGameState == GameState.gameOver)
        {
            // Gameover
            menuCanvas.enabled = false;
            gameCanvas.enabled = false;
            gameOverCanvas.enabled = true;
        }

        // This is the new state after the change 
        currentGameState = newGameState;

    }

    public void CollectCoin()
    {
        collectedCoins++;
        ViewInGame.sharedInstance.UpdateCoinsLabel();
    }

}
