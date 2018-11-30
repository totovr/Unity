using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Person {

    public string name = "";
    public string lastname = "";
    public int age = 0;
    public string address = "";
    public bool isMan = false;
    public bool isMarried = false;

    public Person married;

    public Person()
    {
        // Empty constructor by defect
    }

    public Person(string _name)
    {
        this.name = _name;
    }

    public Person(string _name, string _lastname)
    {
        this.name = _name;
        this.lastname = _lastname;
    }

    public Person(string _name, string _lastname, int _age)
    {
        this.name = _name;
        this.lastname = _lastname;
        this.age = _age;
    }


    public bool IsMarriedWith(Person person)
    {
        if (person != null)
        {
            // we use .this to reference the own object variables or objects
            if (person == this.married)
            {
                return true;
            }
            else
            {
                return false;
            }
        } else
        {
            return false;
        }

    }

}
