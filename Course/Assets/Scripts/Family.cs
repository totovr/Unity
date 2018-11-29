using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Family : MonoBehaviour {

    public Person father;
    public Person mother;
    public Person son;

	// Use this for initialization
	void Start () {

        father = new Person();
        father.name = "Antonio";
        father.lastname = "Vega";
        father.age = 55;
        father.isMan = true;
        father.isMarried = true;

        mother = new Person();
        mother.name = "Rocio";
        mother.lastname = "Ramirez";
        mother.age = 52;
        mother.isMan = false;
        mother.isMarried = true;

        mother = new Person();
        mother.name = "Rocio";
        mother.lastname = "Ramirez";
        mother.age = 52;
        mother.isMan = false;
        mother.isMarried = true;

        son = new Person();
        son.name = father.name;
        son.lastname = father.lastname;
        son.age = 26;
        son.isMan = true;
        son.isMarried = false;

        // Debug.Log(father.name + " and " + mother.name + " have a son called " + son.name);

        // married is an object of the Person class so it will contain all the variables of the mother and father
        father.married = mother;
        mother.married = father;

        if (father.married == mother)
        {
            Debug.Log(father.name + " and " + mother.name + " are married");
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
