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

    // This are examples of arrays and how to declare them 
    public string[] enemys = new string[]{"Bad guy", "Cyclop", "Bat", "Rat"};
    public string[] players = new string[8];

    // Create one list
    //public List<string> enemys2;
    public List<string> enemys2 = new List<string>();

    // In one ArrayList we can save any kind of data 
    public ArrayList userInfo = new ArrayList();

    // This is one dictionary
    public Hashtable personalInfo = new Hashtable(); 

    // Use this prior to initialization
    void Awake()
    {

        //// Array para agregar objectos desde unity 
        //GameObject[] NewEnemies = GameObject.FindGameObjectsWithTag("enemy");
        //Debug.Log("The game has: " + NewEnemies.Length + " enemys");

        //// This is an example to add elements to one list 
        //enemys2.Add("Bad guy");
        //enemys2.Add("Cyclop");
        //enemys2.Add("Bat");
        //enemys2.Add("Rat");

        //// If we want to delate elements of one list 
        //enemys2.Remove("Bat");

        //// If we want to clear all the list 
        //enemys2.Clear();

        //// If we want to know if one elements is in the list 
        //enemys2.Contains("Bat");

        //// If we want to insert one element in the list
        //enemys2.Insert(3, "Goblin");

        //// If we want to convert one list to one array
        //string[] enemysListToArray = enemys2.ToArray();

        ////Debug.Log("The class is going to start");

        //Debug.Log("The total is: " + SumTwoNumbers(2, 4));

        //// How to access to one array
        //string firstEnemyA = enemys[0];

        //// How to access to one element of one list
        //string firstEnemyL = enemys2[0];

        //// How to know the lenght of one array
        //int arrayLength = enemys.Length;

        //// How to know the length of one list
        //int listLength = enemys2.Count;

        // Add elements to one ArrayList
        //userInfo.Add(10);
        //userInfo.Add("User");
        //userInfo.Add(GameObject.Find("Enemy")); // This add the element with using its name, NOT THE TAG
        //Debug.Log(userInfo[0] + " is type " + userInfo[0].GetType()); // GetType return the type of the variable or object 

        //// Add elements to one dictionary
        //personalInfo.Add("userLevel", 10);
        //personalInfo.Add("timePlayed", 3.5);
        //personalInfo.Add("userName", "Antonio");
        //personalInfo.Add("nickName", "Tono");
        //personalInfo.Add("bullshitFromScene", GameObject.Find("Enemy"));

        //// Access elements of one dictionary
        ////Debug.Log(personalInfo["nickName"]);

        //// Method foreach applied in a dictionary  
        //foreach(string key in personalInfo.Keys)
        //{
        //    Debug.Log("This is the key - " + key + " and this is the value - " + personalInfo[key]);
        //}

        //// Method foreach applied in an array
        //int i = 0;
        //foreach(string enemy in enemys)
        //{
        //    Debug.Log( i + "-" + enemy);
        //    i = 1 + i;
        //}

        //PairNumber(10);
        //if (PairNumber(10)) // if the number is true the if will execute
        //{
        //    Debug.Log("The number is pair");
        //}
        //else
        //{
        //    Debug.Log("The number is not");
        //}

        // Example of use a bucle to detect an impair number
        //for (int i = 1; i < 26; i++)
        //{
        //    if(PairNumber(i))
        //    {
        //        Debug.Log(i + " is pair");
        //    }
        //    else
        //    {
        //        Debug.Log(i + " is not pair");
        //    }
        //}

        // Is goo to give the number -1 if we dont know the position of the element
        int lastPosition = -1;
        // Find an element in the array
        for(int i = 0; i < enemys.Length; i++)
        {
            if(enemys[i] == "Batman")
            {
                Debug.Log("I found batman");
                lastPosition = i;
                break;
            }
        }

        if(lastPosition != -1)
        {
            Debug.Log("I found Batman in the position: " + lastPosition);
        }
        else
        {
            Debug.Log("I did not find nothing");
        }

    }

    // Use this for initialization
    void Start()
    {
        //Debug.Log("The class start");

        //if (willRain)
        //{
        //    Debug.Log("Yes, it will rain");
        //}
        //else
        //{
        //    Debug.Log("It will not rain");
        //}
        //// ! means no
        //if (!gender)
        //{
        //    Debug.Log("I am a men");
        //}
        //else
        //{
        //    Debug.Log("I am a woman");
        //}
        //// ! means no
        //if ((age > 18 && money >= 15) || cheat)
        //{
        //    Debug.Log("You can join");
        //}
        //else
        //{
        //    Debug.Log("You can not join");
        //}

    }

    // Update is called once per frame
    void Update()
    {
        // Print the actual time
        //Debug.Log(Time.time);
    }

    int SumTwoNumbers(int n1, int n2)
    {
        int total = n1 + n2;
        return total;
    }
    bool PairNumber(int number) // If the number is pair will return a true 
    {
        if (number % 2 == 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}

