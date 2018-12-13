using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTrigger : MonoBehaviour {

    public static PlayerTrigger sharedInstance;

    void start()
    {
        sharedInstance = this;
    }

}
