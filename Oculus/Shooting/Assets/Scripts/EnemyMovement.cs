using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour {

    public float speed = 4.5f;
    public float obstacleRange = 3.0f;
    
    public bool alive = false;

    public static EnemyMovement sharedInstance;

    void Start()
    {
        sharedInstance = this;
    }
	
	// Update is called once per frame
	void Update () {

        if (alive)
        {
            transform.Translate(0, 0, speed * Time.deltaTime);
        }

        // Check the distance of the wall to rotate
        RayCastCheck();
        // Check if is necessary to jump
        MonsterJumpTrigger.sharedInstance.Jump();
    }

    public void RayCastCheck()
    {
        // Shoot a ray from the position of the enemy
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;

        /*
         * public static bool SphereCast(Vector3 origin, float radius, Vector3 direction, out RaycastHit hitInfo, 
         * float maxDistance = Mathf.Infinity, int layerMask = DefaultRaycastLayers, QueryTriggerInteraction 
         * queryTriggerInteraction = QueryTriggerInteraction.UseGlobal);
         */

        if (Physics.SphereCast(ray, 0.75f, out hit))
        {
            if (hit.distance < obstacleRange && hit.collider.gameObject.CompareTag("Wall"))
            {
                float angle = Random.Range(-100, 110);
                transform.Rotate(0, angle, 0);
            }
        }

    }

}
