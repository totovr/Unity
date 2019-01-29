using UnityEngine;
using System.IO.Ports;

public class BluetoothController : MonoBehaviour
{

    SerialPort myData = new SerialPort("COM4", 115200);
    public string readData;

    // Use this for initialization
    void Start()
    {
        // This will just print the devices connected in the port 
        foreach (string str in SerialPort.GetPortNames())
        {
            Debug.Log(string.Format("port : {0}", str));
        }
        myData.ReadTimeout = 50;
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
            readData = myData.ReadLine();
        }
    }

}

