using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BehaviourTraining : MonoBehaviour {

    // Use this prior to initialization
    void Awake () {
        Debug.Log("The class is going to start");
    }

	// Use this for initialization
	void Start () {
        Debug.Log("The class start");
    }
	
	// Update is called once per frame
	void Update () {
        // Print the actual time
        Debug.Log(Time.time);
    }
}

