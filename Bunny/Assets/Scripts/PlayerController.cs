﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float jumpForce = 30.0f;
    public float runningSpeed = 3.0f;
    private Rigidbody2D rigidBody;
    // Access to the ground component of the game 
    public LayerMask groundLayerMask;
    public Animator animator;

    // Create a singleton for the player
    public static PlayerController sharedInstance;

    // To reset the position of the user
    private Vector3 startPosition;

    void Awake()
    {
    
        // Singleton
        sharedInstance = this;
        // Use this component to add speed to the user 
        rigidBody = GetComponent<Rigidbody2D>();
        // This will save the original position of the player 
        startPosition = this.transform.position;
        // Change the animation of the bunny 
        animator.SetBool("isAlive", true);

    }

	// Use this for initialization
	public void StartGame () {
        animator.SetBool("isAlive", true);
        this.transform.position = startPosition;
        rigidBody.velocity = new Vector2(0, 0); 
	}
	
	// Update is called once per frame
	void Update () {
        if (GameManager.sharedInstance.currentGameState == GameState.inTheGame)
        {
            if (Input.GetMouseButtonDown(0))
            {
                Debug.Log("Left buttom pressed");
                Jump();
            }

            animator.SetBool("isGrounded", IsOnTheFloor());
        }
	}

    void FixedUpdate()
    {
        if (GameManager.sharedInstance.currentGameState == GameState.inTheGame)
        {
            if (rigidBody.velocity.x < runningSpeed)
            {
                rigidBody.velocity = new Vector2(runningSpeed, rigidBody.velocity.y);
            }
        }

    }

    void Jump()
    {
        if (IsOnTheFloor()) {
            // Vector2.up return an unitary vector, the second statment is the mode of the force  
            rigidBody.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }
    }

    // Check if the player is close to the ground
    bool IsOnTheFloor()
    {   
        // The ray cast is to "send" one vector to the ground to know the distance of the object to another one to trigger something
        if (Physics2D.Raycast(this.transform.position, Vector2.down, 0.1f, groundLayerMask.value))
        {
            return true;
        } else
        {
            return false;
        }

    }

    public void KillPlayer()
    {
        GameManager.sharedInstance.GameOver();
        animator.SetBool("isAlive", false);
    }
}
