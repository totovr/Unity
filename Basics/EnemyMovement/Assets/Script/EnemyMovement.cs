using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour {

    public float speed = 3.0f;
    public float obstacleRange = 5.0f;

    private bool alive;

	// Use this for initialization
	void Start () {
        alive = true;
	}
	
	// Update is called once per frame
	void Update () {

        if (alive)
        {
            transform.Translate(0, 0, speed * Time.deltaTime);
        }

        RayCastCheck();

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
            // hit.collider.gameObject.CompareTag("Enemy")
            if (hit.distance < obstacleRange && hit.collider.gameObject.CompareTag("Wall"))
            {
                float angle = Random.Range(-100, 110);
                transform.Rotate(0, angle, 0);
            }

        }

    }

    public void SetAlive(bool _alive)
    {
        alive = _alive;
    }

}
