using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour {

    // Static mean that it will be shared by all the instances of the class
    public static int cointsCount = 0;

	// Execute when the instance of this class is created
	void Start ()
    {
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
            // Destroy the game object 
            Destroy(gameObject);
        }
        
    }

    // OnDestroy works evertime that the gameobject was destroyed
    void OnDestroy()
    {
        cointsCount--;

        if(cointsCount <= 0)
        {
            Debug.Log("You have won the game");
        }
    }

}
