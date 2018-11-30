using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float jumpForce = 30.0f;
    public float runningSpeed = 3.0f;
    private Rigidbody2D rigidBody;
    // Access to the ground component of the game 
    public LayerMask groundLayerMask;
    public Animator animator;

    void Awake()
    {
        rigidBody = GetComponent<Rigidbody2D>();
    }


	// Use this for initialization
	void Start () {
        animator.SetBool("isAlive", true);
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetMouseButtonDown(0))
        {
            Debug.Log("Left buttom pressed");
            Jump();
        }

        animator.SetBool("isGrounded", IsOnTheFloor());

	}

    void FixedUpdate()
    {
        if(rigidBody.velocity.x <runningSpeed)
        {
            rigidBody.velocity = new Vector2(runningSpeed, rigidBody.velocity.y);
        }
    }

    void Jump()
    {
        if (IsOnTheFloor()) {
            // Vector2.up return an unitary vector, the second statment is the mode of the force  
            rigidBody.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }
    }

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


}
