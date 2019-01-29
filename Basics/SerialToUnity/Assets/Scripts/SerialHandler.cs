using UnityEngine;
using System.IO.Ports;
using System.Threading;

public class SerialHandler : MonoBehaviour
{
    public delegate void SerialDataReceivedEventHandler(string message);
    public event SerialDataReceivedEventHandler OnDataReceived;

    SerialPort myData = new SerialPort("COM5", 115200);
    private Thread thread_;
    private bool isRunning_ = false;

    private string message_;
    private bool isNewMessageReceived_ = false;

    void Awake()
    {
        OpenPort();
    }

    void Update()
    {
        if (isNewMessageReceived_)
        {
            OnDataReceived(message_);
        }
        isNewMessageReceived_ = false;
    }

    void OnDestroy()
    {
        myData.Close();
    }

    // Use this for initialization
    void OpenPort()
    {
        // This will just print the devices connected in the port 
        foreach (string str in SerialPort.GetPortNames())
        {
            Debug.Log(string.Format("port : {0}", str));
        }
        
        myData.Open();
        isRunning_ = true;

        thread_ = new Thread(Read);
        thread_.Start();

    }

    private void Close()
    {
        isNewMessageReceived_ = false;
        isRunning_ = false;

        if (thread_ != null && thread_.IsAlive)
        {
            thread_.Join();
        }

        if (myData != null && myData.IsOpen)
        {
            myData.Close();
            myData.Dispose();
        }
    }

    void Read()
    {
        while (isRunning_ && myData != null && myData.IsOpen)
        {
            try
            {
                message_ = myData.ReadLine();
                isNewMessageReceived_ = true;
                Debug.Log(message_);
            }
            catch (System.Exception e)
            {
                Debug.LogWarning(e.Message);
            }
        }
    }

    //public void Write(string message)
    //{
    //    try
    //    {
    //        myData.Write(message);
    //    }
    //    catch (System.Exception e)
    //    {
    //        Debug.LogWarning(e.Message);
    //    }
    //}

}

