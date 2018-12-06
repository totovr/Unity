using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpAngles : MonoBehaviour {

    public static UpAngles sharedInstance;

    public int lE = 0;
    public int lS = 2;

    public int rE = 4;
    public int rS = 6;

    void Start()
    {
        sharedInstance = this;
    }

    public void Statements(float _leftElbow, float _leftShoulder, float _rightElbow, float _rightShoulder)
    {
        //Debug.Log(_leftElbow + " " + _leftShoulder + " " + _rightElbow + " " + _rightElbow);

        if (_leftElbow <= 110.0f)
        {
            lE = 1;
        }
        else
        {
            lE = 0;
        }

        if (_leftShoulder <= 50.0f)
        {
            lS = 3;
        }
        else
        {
            lS = 2;
        }

        if (_rightElbow <= 110.0f)
        {
            rE = 5;
        }
        else
        {
            rE = 4;
        }

        if (_rightShoulder <= 50.0f)
        {
            rS = 7;
        }
        else
        {
            rS = 6;
        }
    }
}
