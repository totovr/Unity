using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputController : MonoBehaviour {

	// Update is called once per frame
	void Update () {

            if (OVRInput.GetUp(OVRInput.Button.PrimaryIndexTrigger))
            {
                SoundController.sharedInstance.audioSource.Play();
                ShootTrigger.sharedInstance.RayCastGun();
            }
  
	}

}
