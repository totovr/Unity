using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour
{

    bool isCollected = false;

    void ShowCoin()
    {
        GetComponent<SpriteRenderer>().enabled = true;
        GetComponent<Collider2D>().enabled = true;
        isCollected = false;
    }

    void HideCoin()
    {
        GetComponent<SpriteRenderer>().enabled = false;
        GetComponent<Collider2D>().enabled = false;
    }

    void CollectCoin()
    {   isCollected = true;
        HideCoin();

        // Notify to manage that we have catch a coin
        GameManager.sharedInstance.CollectCoin();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            CollectCoin();
        }
    }

}
