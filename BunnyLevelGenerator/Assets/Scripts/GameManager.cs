using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GameState {
    menu, 
    inTheGame, 
    gameOver
}


public class GameManager : MonoBehaviour {

    // Actual GameState
    public GameState currentGameState = GameState.menu;

    // singleton
    public static GameManager sharedInstance;

    void Awake()
    {
        // Initialize the singleton and share all the GameManager fields and methods with it
        sharedInstance = this;
    }

    void Start()
    {
        currentGameState = GameState.menu;
    }

    void Update()
    {
        if (currentGameState != GameState.inTheGame)
        {
            if (Input.GetButtonDown("s"))
            {
                StartGame();
            }
        }

    }

	// Use this for start the game
	public void StartGame ()
    {
        PlayerController.sharedInstance.StartGame();
        ChangeGameState(GameState.inTheGame);
    }
	
    // Called when the player dies
    public void GameOver ()
    {
        ChangeGameState(GameState.gameOver);
    }

    // Call it when the user wants to finish and return to the main menu  
    public void BackToMainMenu()
    {
        ChangeGameState(GameState.menu);
    }

    // This method will manage the states of the game
    void ChangeGameState(GameState newGameState)
    {
        if(newGameState == GameState.menu)
        {
            // The logic of the principal menu
        } else if (newGameState == GameState.inTheGame)
        {
            // This is the current scene or level of the game
        } else if (newGameState == GameState.gameOver)
        {
            // Gameover
        }

        // This is the new state after the change 
        currentGameState = newGameState;

    }
}
