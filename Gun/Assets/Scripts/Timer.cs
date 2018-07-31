using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Timer : MonoBehaviour {

    // variables of the class
    public Text timerText;
    private float startTime;
    private float t = 0;

	// Use this for initialization
	void Start () {
        // Initialize the timer
        startTime = Time.time;		
	}
	
	// Update is called once per frame
	void Update () {
        if (t < 59.99)
        {
            // Timer until is displayed
             t = Time.time - startTime;
            // Calcute the time
            string minutes = ((int)t / 60).ToString();
            string seconds = (t % 60).ToString("f2");
            // Display the time
            timerText.text = minutes + ":" + seconds;
            if (t > 44.99 && t < 59.99) {
            timerText.color = Color.yellow;
            //return;
            } 
        } else {
            timerText.color = Color.red;
            return;
        }
	}
}
