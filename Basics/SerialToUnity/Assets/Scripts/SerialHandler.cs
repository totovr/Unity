using UnityEngine;
using System.IO.Ports;
using System.Threading;

public enum SerialPortConnection
{
    COM3,
    COM4,
    COM5,
    COM6
}

public class SerialHandler : MonoBehaviour
{
    public delegate void SerialDataReceivedEventHandler(string message);
    public event SerialDataReceivedEventHandler OnDataReceived;

    // SerialPort myData = new SerialPort("COM5", 115200);
    // public string portName = "COM5"; // We will check this
    
    // Actual SerialPort
    public SerialPortConnection portName = SerialPortConnection.COM5;
    public int baudRate = 115200;
    private string _portName; // Este tampoco es necesario 

    private SerialPort myData;
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
        for (int i = 0; i < 10; i++)
        {
            Debug.Log("1");
            myData.Write("1");
        }
        myData.Close();
    }

    string ChoosePort(SerialPortConnection port)
    {
        //string _portName;

        if (port == SerialPortConnection.COM3)
        {
            _portName = "COM3";
        }
        else if (port == SerialPortConnection.COM4)
        {
            _portName = "COM4";
        }
        else if (port == SerialPortConnection.COM5)
        {
            _portName = "COM5";
        }

        return _portName;

    }

    // Use this for initialization
    void OpenPort()
    {
        // This will just print the devices connected in the port 
        foreach (string str in SerialPort.GetPortNames())
        {
            Debug.Log(string.Format("port : {0}", str));
        }

        myData = new SerialPort(ChoosePort(portName), baudRate, Parity.None, 8, StopBits.One);

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

    public void Write(string message)
    {
        try
        {
            myData.Write(message);
        }
        catch (System.Exception e)
        {
            Debug.LogWarning(e.Message);
        }
    }

}

