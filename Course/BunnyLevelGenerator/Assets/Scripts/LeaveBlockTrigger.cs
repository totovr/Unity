using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeaveBlockTrigger : MonoBehaviour {

    void OnTriggerEnter2D(Collider2D collider)
    {
        LevelGenerator.sharedInstance.AddNewBlock(); // Add a new block 
        LevelGenerator.sharedInstance.RemoveOldBlock(); // Remove the old one
    }

}
