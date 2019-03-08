using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinRotation : MonoBehaviour
{
    private Transform coinTransform;
    float rotationSpeed = 50.0f;

    // Start is called before the first frame update
    void Start()
    {
        coinTransform = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        coinTransform.Rotate(Vector3.left, rotationSpeed * Time.deltaTime);
    }
}
