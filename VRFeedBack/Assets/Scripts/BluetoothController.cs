using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO.Ports;

public class BluetoothController : MonoBehaviour
{

    SerialPort myData = new SerialPort("COM4", 115200);

    int currentStateLeftElbow = 0;
    int previousStateLeftElbow = 0;

    int currentStateLeftShoulder = 0;
    int previousStateLeftShoulder = 0;

    int currentStateRightElbow = 0;
    int previousStateRightElbow = 0;

    int currentStateRightShoulder = 0;
    int previousStateRightShoulder = 0;

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
            currentStateLeftElbow = UpAngles.sharedInstance.le;
            currentStateLeftShoulder = UpAngles.sharedInstance.ls;
            currentStateRightElbow = UpAngles.sharedInstance.re;
            currentStateRightShoulder = UpAngles.sharedInstance.rs;

            if (currentStateLeftElbow == 1 && currentStateLeftElbow != previousStateLeftElbow)
            {         
                myData.WriteLine("1");
            } else if(currentStateLeftElbow == 0 && currentStateLeftElbow != previousStateLeftElbow) {
                myData.WriteLine("0");
            }

            if (currentStateLeftShoulder == 3 && currentStateLeftShoulder != previousStateLeftShoulder)
            {
                myData.WriteLine("3");
            }
            else if (currentStateLeftShoulder == 2 && currentStateLeftShoulder != previousStateLeftShoulder) {
                myData.WriteLine("2");
            }

            if (currentStateRightElbow == 5 && currentStateLeftShoulder != previousStateRightElbow)
            {
                myData.WriteLine("5");
            }
            else if (currentStateRightElbow == 4 && currentStateLeftShoulder != previousStateRightElbow)
            {
                myData.WriteLine("4");
            }

            if (currentStateRightShoulder == 7 && currentStateLeftShoulder != previousStateRightShoulder)
            {
                myData.WriteLine("7");
            }
            else if (currentStateRightShoulder == 7 && currentStateLeftShoulder != previousStateRightShoulder)
            {
                myData.WriteLine("7");
            }

            previousStateLeftElbow = currentStateLeftElbow;
            previousStateLeftShoulder = currentStateLeftShoulder;
            previousStateRightElbow = currentStateRightElbow;
            previousStateRightShoulder = currentStateRightShoulder;

        }
    }
}
