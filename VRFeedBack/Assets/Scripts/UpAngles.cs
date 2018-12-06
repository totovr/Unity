using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpAngles : MonoBehaviour {

    public static UpAngles sharedInstance;

    public int le = 0;
    public int ls = 2;

    public int re = 4;
    public int rs = 6;

    void Start()
    {
        sharedInstance = this;
    }

    public void Statements(float _leftElbow, float _leftShoulder, float _rightElbow, float _rightShoulder)
    {
        if (_leftElbow <= 110)
        {
            le = 1;
        }
        else
        {
            le = 0;
        }

        if (_leftShoulder <= 110)
        {
            le = 3;
        }
        else
        {
            le = 2;
        }

        if (_rightElbow <= 110)
        {
            le = 5;
        }
        else
        {
            le = 4;
        }

        if (_rightShoulder <= 110)
        {
            le = 7;
        }
        else
        {
            le = 6;
        }
    }
}
