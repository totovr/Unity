using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalBehaviour : MonoBehaviour {

    public string animalSound = null;
	
	// Update is called once per frame
	void Update ()
    {

        // Call the function that show display the animal sound
        if (Input.GetKeyUp(KeyCode.B))
        {
            Sound();
        }
	}

    void Sound()
    {
        Debug.Log(animalSound);
    }
}
