using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyFirstScript : MonoBehaviour {

    public string playerName = "Unkown";
    public int playerScore = 0;
    public int playerAge = 0;

    private int maxScore = 120;

	// Use this for initialization
	void Start () {
        Debug.Log(playerScore + 12);
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyUp(KeyCode.B))
        {
            BirthDay();
        }
	}

    void BirthDay()
    {
        Debug.Log(playerAge + 1);
    }
}
