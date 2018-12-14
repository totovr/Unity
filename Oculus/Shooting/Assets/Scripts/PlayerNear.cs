using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerNear : MonoBehaviour {

    // Gun shoot
    public AudioClip clipMonsterSound;
    // Audio Source
    public AudioSource audioSource;

    // Use this for initialization
    void Start()
    {
        audioSource = GetComponent<AudioSource>(); // Initialize the AudioSource
        //audioSource.clip = clipMonsterSound; // Save the clip in the Audio source variable
    }

    void OnTriggerEnter(Collider collider)
    {
        if(collider.gameObject.CompareTag("Player"))
        {
            audioSource.PlayOneShot(clipMonsterSound);
        }
    }

    //void OnTriggerExit(Collider collider)
    //{
    //    if (collider.gameObject.CompareTag("Player"))
    //    {
    //        audioSource.PlayOneShot(clipMonsterSound);
    //    }
    //}
}
