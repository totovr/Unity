using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillPlayer : MonoBehaviour {

    // Destroy everything that enters the trigger
    void OnTriggerEnter(Collider other)
    {
        // Here go the code to send to the jacket 
        Destroy(other.gameObject);
        GameManager.sharedInstance.GameOver();
    }

}
