using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class textControl : MonoBehaviour {

    public Text Message;
    BluetoothController bluetoothController;
    string stringMessage;

    void Start()
    {
        bluetoothController = GetComponent<BluetoothController>();
    }

    void Update()
    {
        stringMessage = bluetoothController.readData;
        Debug.Log(stringMessage);
        Message.text = "This is the message " + stringMessage.ToString();
    }

}
