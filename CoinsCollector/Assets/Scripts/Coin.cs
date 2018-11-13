using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour {

    // Static mean that it will be shared by all the instances of the class
    public static int cointsCount = 0;

	// Execute when the instance of this class is created
	void Start ()
    {
        // When the coin is instantiate will aument 1 in the counter
        Debug.Log("A coin was created");
        cointsCount++;
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    // An other collider has interact with this object
    void OnTriggerEnter(Collider collider)
    {
        if (collider.CompareTag("Player"))
        {
            // Destroy the game object that has the script, in this case the coin
            Destroy(gameObject);
        }
        
    }

    // OnDestroy works evertime that the gameobject was destroyed
    void OnDestroy()
    {
        cointsCount--;

        if(cointsCount <= 0)
        {
            // Find the timer and store it in a new object 
            GameObject timer = GameObject.Find("GameTimer");
            Destroy(timer);

            // Create an array to store object of fireworks
            GameObject[] fireworks = GameObject.FindGameObjectsWithTag("Firework");
            foreach(GameObject firework in fireworks)
            {
                firework.GetComponent<ParticleSystem>().Play();
            }
        }
    }
}
