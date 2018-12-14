using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillPlayer : MonoBehaviour {

    public static int counterTouch = 0;

    // Destroy everything that enters the trigger
    void OnTriggerEnter(Collider other)
    {
        // Here go the code to send to the jacket 
        counterTouch++;

        if(counterTouch > 5)
        {
            Destroy(other.gameObject);
            GameManager.sharedInstance.GameOver();
        }
    }

}
