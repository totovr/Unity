using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmoothFollow : MonoBehaviour {

    public float xMargin = 1.0f;
    public float yMargin = 1.0f;

    public float xSmooth = 10.0f;
    public float ySmooth = 10.0f;

    public Vector2 maxXandY;
    public Vector2 minXandY;

    public Transform cameraTarget;

    private void Awake()
    {
        // Find the camera target
        cameraTarget = GameObject.FindGameObjectWithTag("CameraTarget").transform;
    }

    bool CheckXMargin() 
    {
        return Mathf.Abs(transform.position.x - cameraTarget.position.x) > xMargin;
    }

    bool CheckYMargin()
    {
        return Mathf.Abs(transform.position.y - cameraTarget.position.y) > yMargin;
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void FixedUpdate()
    {
        TrackPlayer();
    }

    void TrackPlayer()
    {
        float _targetX = transform.position.x;
        float _targetY = transform.position.y;

        // Compare the margin value
        if(CheckXMargin()) 
        {
            // Do an interpolation for the x position
            _targetX = Mathf.Lerp(transform.position.x, cameraTarget.position.x, xSmooth * Time.deltaTime);
        }

        // Compare the margin value
        if (CheckYMargin())
        {
            // Do an interpolation for the y position
            _targetY = Mathf.Lerp(transform.position.y, cameraTarget.position.y, ySmooth * Time.deltaTime);
        }

        // Clamp the targets
        _targetX = Mathf.Clamp(_targetX, minXandY.x, maxXandY.x);
        _targetY = Mathf.Clamp(_targetY, minXandY.y, maxXandY.y);

        transform.position = new Vector3(_targetX, _targetY, transform.position.z);

    }
}
