using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO.Ports;

public class BluetoothController : MonoBehaviour
{

    SerialPort myData = new SerialPort("COM4", 115200);

    int currentStateLeftElbow = 5;
    int previousStateLeftElbow = 5;

    int currentStateLeftShoulder = 5;
    int previousStateLeftShoulder = 5;

    int currentStateRightElbow = 5;
    int previousStateRightElbow = 5;

    int currentStateRightShoulder = 5;
    int previousStateRightShoulder = 5;

    // Use this for initialization
    void Start()
    {
        // This will just print the devices connected in the port 
        foreach (string str in SerialPort.GetPortNames())
        {
            Debug.Log(string.Format("port : {0}", str));
        }

        myData.Open();

    }


    private void OnApplicationQuit()
    {
        myData.Close();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (myData.IsOpen)
        {
            currentStateLeftElbow = UpAngles.sharedInstance.lE;
            currentStateLeftShoulder = UpAngles.sharedInstance.lS;
            currentStateRightElbow = UpAngles.sharedInstance.rE;
            currentStateRightShoulder = UpAngles.sharedInstance.rS;

            if (currentStateLeftElbow == 1 && currentStateLeftElbow != previousStateLeftElbow)
            {         
                myData.WriteLine("1");
                //Debug.Log("1");
            } else if(currentStateLeftElbow != previousStateLeftElbow) {
                myData.WriteLine("0");
                //Debug.Log("0");
            }

            if (currentStateLeftShoulder == 3 && currentStateLeftShoulder != previousStateLeftShoulder)
            {
                myData.WriteLine("3");
                //Debug.Log("3");
            }
            else if (currentStateLeftShoulder != previousStateLeftShoulder) {
                myData.WriteLine("2");
                //Debug.Log("2");
            }

            if (currentStateRightElbow == 5 && currentStateRightElbow != previousStateRightElbow)
            {
                myData.WriteLine("5");
                //Debug.Log("5");
            }
            else if (currentStateRightElbow != previousStateRightElbow)
            {
                myData.WriteLine("4");
                //Debug.Log("4");
            }

            if (currentStateRightShoulder == 7 && currentStateRightShoulder != previousStateRightShoulder)
            {
                myData.WriteLine("7");
                //Debug.Log("7");
            }
            else if (currentStateRightShoulder != previousStateRightShoulder)
            {
                myData.WriteLine("6");
                //Debug.Log("6");
            }

            previousStateLeftElbow = currentStateLeftElbow;
            previousStateLeftShoulder = currentStateLeftShoulder;
            previousStateRightElbow = currentStateRightElbow;
            previousStateRightShoulder = currentStateRightShoulder;

        }
    }
}
