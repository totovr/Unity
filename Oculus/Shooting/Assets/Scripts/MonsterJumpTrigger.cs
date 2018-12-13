using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterJumpTrigger : MonoBehaviour {

    public float userInRange = 2.0f;
    public static MonsterJumpTrigger sharedInstance;

	// Use this for initialization
	void Start () {
        sharedInstance = this;
	}

    public void Jump()
    {

        // Shoot a ray from the position of the enemy
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;

        if (Physics.SphereCast(ray, 0.75f, out hit))
        {
            if (hit.distance < userInRange && hit.collider.gameObject.CompareTag("Player"))
            {
                EnemyMovement.sharedInstance.speed = 6.0f;
            }
            else
            {
                EnemyMovement.sharedInstance.speed = 3.0f;
            }
        }

    }
	
}
