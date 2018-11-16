using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car : MonoBehaviour
{

    public string brand = "Mazda";
    public string model = "Riata";
    public Color color = Color.red;
    public int hp = 160;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.A))
        {
            StartCar();
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            Stop();
        }

    }

    void StartCar()
    {
        Debug.Log("Engine ON");
    }

    void Stop()
    {
        Debug.Log("The engine stop");
    }
}
