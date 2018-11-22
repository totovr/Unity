using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour {

    public float maxSpeed = 6.0f;
    public float moveDirection;
    public bool facingRight = true;
    private Rigidbody rigidbody;
    private Animator anim;

	// Use this for initialization
	void Start () {
        rigidbody = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
        // A and D keys by default
        moveDirection = Input.GetAxis("Horizontal");
	}

    // FixUpdate method is used with rigidbody
    private void FixedUpdate()
    {
        // Calculate the movement of the user in 2 dimensions
        rigidbody.velocity = new Vector2(moveDirection * maxSpeed, rigidbody.velocity.y);

        // Change the direction of the flip if is looking to the left 
        if(moveDirection > 0.0f && !facingRight)
        {
            Flip();
        } else if (moveDirection < 0.0f && facingRight) // Change the direction of the flip if is looking to the right
        {
            Flip();
        }

        // The string was declarated in 
        anim.SetFloat("Speed", Mathf.Abs(moveDirection));

    }

    // Method to flip the character
    void Flip() {
        facingRight = !facingRight;
        // Rotate(Vector3 axis, float angle, Space relativeTo = Space.Self);
        // Rotate around Y
        transform.Rotate(Vector3.up, 180.0f, Space.World);
    }

}
