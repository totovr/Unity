using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour {

    public float MaxTime = 60.0f;

    private float countDown = 0.0f;

	// Use this for initialization
	void Start ()
    {
        countDown = MaxTime;
	}
	
	// Update is called once per frame
	void Update ()
    {
        // Time of rendering 
        countDown -= Time.deltaTime;

        if (countDown <= 0)
        {
            // Set the coins count to zero
            Coin.cointsCount = 0;
            // The game has end, load again the level
            SceneManager.LoadScene("Level_01");
            Debug.Log("Time is over");
        }
	}
}
