using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundController : MonoBehaviour {

    // Gun shoot
    public AudioClip clipGun;
    // Audio Source
    public AudioSource audioSource;

    public static SoundController sharedInstance;

    // Use this for initialization
    void Start () {
        sharedInstance = this;
        audioSource = GetComponent<AudioSource>(); // Initialize the AudioSource
        audioSource.clip = clipGun; // Save the clip in the Audio source variable
    }
	
}
