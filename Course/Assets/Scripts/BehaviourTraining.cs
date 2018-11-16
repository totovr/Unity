using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BehaviourTraining : MonoBehaviour
{

    public bool willRain = true;
    public bool gender = false;
    public int age = 26;
    public int money = 20;
    public bool cheat = false;
    private bool imRich = true;
    private bool iHaveToStudy; // By default is private

    // Use this prior to initialization
    void Awake()
    {
        Debug.Log("The class is going to start");

        PairNumber(10);

        SumTwoNumbers(2, 4);
    }

    // Use this for initialization
    void Start()
    {
        //Debug.Log("The class start");

        if (willRain)
        {
            Debug.Log("Yes, it will rain");
        }
        else
        {
            Debug.Log("It will not rain");
        }
        // ! means no
        if (!gender)
        {
            Debug.Log("I am a men");
        }
        else
        {
            Debug.Log("I am a woman");
        }
        // ! means no
        if ((age > 18 && money >= 15) || cheat)
        {
            Debug.Log("You can join");
        }
        else
        {
            Debug.Log("You can not join");
        }

    }

    // Update is called once per frame
    void Update()
    {
        // Print the actual time
        //Debug.Log(Time.time);
    }

    void SumTwoNumbers(int n1, int n2)
    {
        int total = n1 + n2;
        Debug.Log(total);
    }
    void PairNumber(int number)
    {
        if (number % 2 == 0)
        {
            Debug.Log("This is a pair number");
        }
        else
        {
            Debug.Log("This number is not a pair number");
        }
    }
}

