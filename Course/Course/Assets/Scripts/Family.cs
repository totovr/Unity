using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Family : MonoBehaviour {

    public Person father;
    public Person mother;
    public Person son;

	// Use this for initialization
	void Start () {

        father = new Person("Antonio", "Vega", 55);
        father.isMan = true;
        father.isMarried = true;

        mother = new Person("Rocio", "Ramirez", 52);
        mother.isMan = false;
        mother.isMarried = true;

        son = new Person(father.name, father.lastname, 26);
        son.isMan = true;
        son.isMarried = false;

        // Debug.Log(father.name + " and " + mother.name + " have a son called " + son.name);

        // married is an object of the Person class so it will contain all the variables of the mother and father
        father.married = mother;
        mother.married = father;

        if (father.IsMarriedWith(mother)) // if there is not object we use the null object 
        {
            Debug.Log(father.name + " and " + mother.name + " are married");
        } else
        {
            Debug.Log(father.name + " and " + mother.name + " are not married");
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
