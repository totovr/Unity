using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputController : MonoBehaviour {

    public AudioClip clip;
    public AudioSource audioSource;

    public Transform gunBarrelTransform;

	// Use this for initialization
	void Start () {
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = clip;
	}
	
	// Update is called once per frame
	void Update () {
		if(OVRInput.Get(OVRInput.Button.PrimaryIndexTrigger))
        {
            audioSource.Play();
            RayCastGun();
        }
	}

    void RayCastGun()
    {
        // Check the distance bettwen the object and the user
        RaycastHit hit;
        
        if(Physics.Raycast(gunBarrelTransform.position, gunBarrelTransform.forward, out hit))
        { 
            if (hit.collider.gameObject.CompareTag("Enemy"))
            {
                Destroy(hit.collider.gameObject);
            }
        }
    }
}
