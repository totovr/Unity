using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    public string PlayerName = "Tono";
    public float Life = 100f;
    public int Mana = 0;

    private bool hit = false;

    // Use this for initialization
    void Start () {
		
	}

    // Update is called once per frame
    void Update()
    {

        TriggerShoot();

        LoadMana();

        MovementPlayer();

        Shoot();

    }

    void MovementPlayer()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            Debug.Log("Walk front");
        }
        else if (Input.GetKeyDown(KeyCode.A))
        {
            Debug.Log("Walk left");
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            Debug.Log("Walk right");
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            Debug.Log("Walk behind");
        }
    }

    void TriggerShoot()
    {
        if (Life < 0)
        {
            Debug.Log("You lose");
        }
    }

    void LoadMana()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            Debug.Log("Loading Mana");
            Mana += 10;
        }
    }

    void Shoot()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            Debug.Log("Shooted");
        }

        if (Input.GetKeyDown(KeyCode.N) && Mana > 50)
        {
            Debug.Log("Magic Shooted");
            Mana -= 50;
        }
    }
}
