using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoSomething : MonoBehaviour
{

    public SerialHandler serialHandler;

    void Start()
    {
        serialHandler.OnDataReceived += OnDataReceived;
    }

    void Updata()
    {
        // serialHandler.Write("hogehoge");
    }

    void OnDataReceived(string message)
    {
        var data = message.Split(
                new string[] { "\t" }, System.StringSplitOptions.None);
        if (data.Length < 2) return;

        try
        {
            Debug.Log(data);
        }
        catch (System.Exception e)
        {
            Debug.LogWarning(e.Message);
        }
    }
}
