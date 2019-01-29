using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class textControl : MonoBehaviour {

    public Text Message;
    BluetoothSerialReceiver bluetoothController;
    string stringMessage;

    void Start()
    {
        bluetoothController = GetComponent<BluetoothSerialReceiver>();
    }

    void Update()
    {
        stringMessage = bluetoothController.readData;
        Message.text = "This is the message " + stringMessage.ToString();
    }

}
