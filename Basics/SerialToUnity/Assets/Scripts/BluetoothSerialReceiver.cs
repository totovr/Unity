using UnityEngine;
using System.IO.Ports;
using System.Collections;
using System;

public class BluetoothSerialReceiver : MonoBehaviour
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
            // Start the coroutine every frame
            StartCoroutine
            (
                ReadSerial
                ((readData) => Debug.Log(readData),     // Callback
                () => Debug.LogError("Error!"), // Error callback
                5000f                          // Timeout (milliseconds)
                )
             );
        }
    }

    public IEnumerator ReadSerial(Action<string> callback, Action fail = null, float timeout = float.PositiveInfinity)
    {
        DateTime initialTime = DateTime.Now;
        DateTime nowTime;
        TimeSpan diff = default(TimeSpan);

        string dataString = null;

        do
        {
            try
            {
                dataString = myData.ReadLine();
            }
            catch (TimeoutException)
            {
                dataString = null;
            }

            if (dataString != null)
            {
                callback(dataString);
                yield break; // Terminates the Coroutine
            }
            else
            {
                yield return null; // Wait for next frame
            }
            nowTime = DateTime.Now;
            diff = nowTime - initialTime;

        } while (diff.Milliseconds < timeout);

        if (fail != null)
        {
            fail();
        }
        yield return null;
    }
}


