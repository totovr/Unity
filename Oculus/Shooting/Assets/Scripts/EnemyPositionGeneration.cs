using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPositionGeneration : MonoBehaviour {

    public GameObject enemyPrefab;
    private GameObject enemy;

    public bool movementMonster = true;

    public static EnemyPositionGeneration sharedInstance;

    void Start()
    {
        sharedInstance = this;
    }

	// Update is called once per frame
	public void GenerateMonster() {
		if(enemy == null && movementMonster == true)
        {
                enemy = Instantiate(enemyPrefab) as GameObject;
                enemy.transform.position = new Vector3(0, 0, 0);
                float angle = Random.Range(0, 360);
                enemy.transform.Rotate(0, angle, 0);
        }
	}
}
