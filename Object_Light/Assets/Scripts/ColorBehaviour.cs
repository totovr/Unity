using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorBehaviour : MonoBehaviour {

    public Color myColor = Color.red;
    MeshRenderer myRender;

	// Use this for initialization
	void Start () {

        myRender = GetComponent<MeshRenderer>();
        myRender.material.color = myColor;

	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
