using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootTrigger : MonoBehaviour {

    public Transform gunBarrelTransform;
    public static ShootTrigger sharedInstance;
    public static int monsterLife = 5;

    void Start()
    {
        sharedInstance = this;
    }

    public void RayCastGun()
    {
        // Check the distance bettwen the object and the user
        RaycastHit hit;

        if (Physics.Raycast(gunBarrelTransform.position, gunBarrelTransform.forward, out hit))
        {
            if (hit.collider.gameObject.CompareTag("Enemy"))
            {
                monsterLife--;
                if (monsterLife == 0)
                {
                    EnemyPositionGeneration.sharedInstance.movementMonster = false;
                    MonsterController.sharedInstance.animator.SetBool("isShooted", true);
                    Destroy(hit.collider.gameObject, MonsterController.sharedInstance.clips[1].length);
                }
            }
        }
    }
}
