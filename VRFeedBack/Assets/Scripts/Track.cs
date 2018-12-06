using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using Kinect = Windows.Kinect;

public class Track : MonoBehaviour
{

    Dictionary<Kinect.JointType, HumanBodyBones> kinectJointTypeToHumanBodyBone = new Dictionary<Windows.Kinect.JointType, HumanBodyBones>()
    {
        {Windows.Kinect.JointType.SpineBase, HumanBodyBones.Hips},
        {Windows.Kinect.JointType.SpineMid, HumanBodyBones.Spine},
        {Windows.Kinect.JointType.SpineShoulder, HumanBodyBones.Chest},
        {Windows.Kinect.JointType.Neck, HumanBodyBones.Neck},
        {Windows.Kinect.JointType.Head, HumanBodyBones.Head}, //TODO: Need facial tracking or Oculus for head orientation

		{Windows.Kinect.JointType.ShoulderRight, HumanBodyBones.RightShoulder},
        {Windows.Kinect.JointType.ElbowRight, HumanBodyBones.RightUpperArm},
        {Windows.Kinect.JointType.WristRight, HumanBodyBones.RightLowerArm},
        {Windows.Kinect.JointType.HandRight, HumanBodyBones.RightHand},
		//{Windows.Kinect.JointType.HandTipRight, HumanBodyBones.RightMiddleProximal},
		{Windows.Kinect.JointType.ShoulderLeft, HumanBodyBones.LeftShoulder},
        {Windows.Kinect.JointType.ElbowLeft, HumanBodyBones.LeftUpperArm},
        {Windows.Kinect.JointType.WristLeft, HumanBodyBones.LeftLowerArm},
        {Windows.Kinect.JointType.HandLeft, HumanBodyBones.LeftHand},
		//{Windows.Kinect.JointType.HandTipLeft, HumanBodyBones.LeftMiddleProximal},

		//{Windows.Kinect.JointType.HipRight, }, // No HumanBodyBones analog
		{Windows.Kinect.JointType.KneeRight, HumanBodyBones.RightUpperLeg},
        {Windows.Kinect.JointType.AnkleRight, HumanBodyBones.RightLowerLeg},
        {Windows.Kinect.JointType.FootRight, HumanBodyBones.RightFoot}, 

		//{Windows.Kinect.JointType.HipLeft, }, // No HumanBodyBones analog
		{Windows.Kinect.JointType.KneeLeft, HumanBodyBones.LeftUpperLeg},
        {Windows.Kinect.JointType.AnkleLeft, HumanBodyBones.LeftLowerLeg},
        {Windows.Kinect.JointType.FootLeft, HumanBodyBones.LeftFoot},
    };

    // Assign in editor
    public BodySourceManager bodySourceManager;
    //Windows.Kinect.Body[] bodies;
    Quaternion[] jointOrientations;
    Transform[] avatarBones;
    int numJointsTracked = 25;
    Animator animator;
    private Dictionary<Windows.Kinect.JointType, JointManipulation> jointManipulations;

    private AnglesCalculation _anglesCalculation;

    public static Track sharedInstance;

    // Vectors for the angles
    Vector3 leftHand;
    Vector3 leftElbow;
    Vector3 leftShoulder;
    Vector3 leftHip;

    // Right
    Vector3 rightHand;
    Vector3 rightElbow;
    Vector3 rightShoulder;
    Vector3 rightHip;

    // Variables used to hold the value of the angles
    float _leftElbowAngle = 0.0f;
    float _leftShoulderAngle = 0.0f;
    float _rightElbowAngle = 0.0f;
    float _rightShoulderAngle = 0.0f;

    // References for the canvas 
    public Text LeftElbowText;
    public Text LeftShoulderText;
 
    public Text RightElbowText;
    public Text RightShoulderText;

    void Start()
    {
        jointOrientations = new Quaternion[numJointsTracked];
        avatarBones = new Transform[numJointsTracked];
        animator = GetComponent<Animator>();
        foreach (var joint in kinectJointTypeToHumanBodyBone.Keys)
        {
            avatarBones[(int)joint] = animator.GetBoneTransform(kinectJointTypeToHumanBodyBone[joint]);
        }
        InitializeJointManipulationData();

        sharedInstance = this;

        //Initialization
        leftHand = new Vector3(0.0f, 0.0f, 0.0f);
        leftElbow = new Vector3(0.0f, 0.0f, 0.0f);
        leftShoulder = new Vector3(0.0f, 0.0f, 0.0f);
        leftHip = new Vector3(0.0f, 0.0f, 0.0f);

        // Right
        rightHand = new Vector3(0.0f, 0.0f, 0.0f);
        rightElbow = new Vector3(0.0f, 0.0f, 0.0f);
        rightShoulder = new Vector3(0.0f, 0.0f, 0.0f);
        rightHip = new Vector3(0.0f, 0.0f, 0.0f);

        _anglesCalculation = gameObject.GetComponent<AnglesCalculation>(); // Initialize the AnglesCalculation class

    }

    void Update()
    {
        if (!bodySourceManager)
            return;

        var data = bodySourceManager.GetData();
        if (data == null)
        {
            return;
        }

        // Use the data of the first body 
        var body = data.FirstOrDefault(b => b.IsTracked);
        if (body == null)
        {
            return;
        }

        // Get the information of the angles
        ShowAngles(body);

        // Save the orientation data of each joint
        foreach (var joint in kinectJointTypeToHumanBodyBone.Keys)
        {
            var x = body.JointOrientations[joint].Orientation.X;
            var y = body.JointOrientations[joint].Orientation.Y;
            var z = body.JointOrientations[joint].Orientation.Z;
            var w = body.JointOrientations[joint].Orientation.W;
            var rawJointOrientation = new Quaternion(x, y, z, w);

            jointOrientations[(int)joint] = ManipulateKinectJointOrientation(rawJointOrientation, joint);
        }

        UpdateJoints();
    }

    void ShowAngles(Kinect.Body body)
    {

        // Left
        leftHand = new Vector3(body.Joints[Kinect.JointType.HandLeft].Position.X, body.Joints[Kinect.JointType.HandLeft].Position.Y, body.Joints[Kinect.JointType.HandLeft].Position.Z);
        leftElbow = new Vector3(body.Joints[Kinect.JointType.ElbowLeft].Position.X, body.Joints[Kinect.JointType.ElbowLeft].Position.Y, body.Joints[Kinect.JointType.ElbowLeft].Position.Z);
        leftShoulder = new Vector3(body.Joints[Kinect.JointType.ShoulderLeft].Position.X, body.Joints[Kinect.JointType.ShoulderLeft].Position.Y, body.Joints[Kinect.JointType.ShoulderLeft].Position.Z);
        leftHip = new Vector3(body.Joints[Kinect.JointType.HipLeft].Position.X, body.Joints[Kinect.JointType.HipLeft].Position.Y, body.Joints[Kinect.JointType.HipLeft].Position.Z);

        // Right
        rightHand = new Vector3(body.Joints[Kinect.JointType.HandRight].Position.X, body.Joints[Kinect.JointType.HandRight].Position.Y, body.Joints[Kinect.JointType.HandRight].Position.Z);
        rightElbow = new Vector3(body.Joints[Kinect.JointType.ElbowRight].Position.X, body.Joints[Kinect.JointType.ElbowRight].Position.Y, body.Joints[Kinect.JointType.ElbowRight].Position.Z);
        rightShoulder = new Vector3(body.Joints[Kinect.JointType.ShoulderRight].Position.X, body.Joints[Kinect.JointType.ShoulderRight].Position.Y, body.Joints[Kinect.JointType.ShoulderRight].Position.Z);
        rightHip = new Vector3(body.Joints[Kinect.JointType.HipRight].Position.X, body.Joints[Kinect.JointType.HipRight].Position.Y, body.Joints[Kinect.JointType.HipRight].Position.Z);

        // Calculation of the angles
        _leftElbowAngle = _anglesCalculation.AngleBetweenTwoVectors(leftElbow - leftShoulder, leftElbow - leftHand);
        _leftShoulderAngle = _anglesCalculation.AngleBetweenTwoVectors(leftShoulder - leftElbow, leftShoulder - leftHip);
        _rightElbowAngle = _anglesCalculation.AngleBetweenTwoVectors(rightElbow - rightShoulder, rightElbow - rightHand);
        _rightShoulderAngle = _anglesCalculation.AngleBetweenTwoVectors(rightShoulder - rightElbow, rightShoulder - rightHip);

        // Control Statements
        UpAngles.sharedInstance.Statements(_leftElbowAngle, _leftShoulderAngle, _rightElbowAngle, _rightShoulderAngle);

        // Show in the Canvas
        LeftElbowText.text = "The left elbow angle is: " + _leftElbowAngle.ToString();
        LeftShoulderText.text = "The left shoulder angle is: " + _leftShoulderAngle.ToString();
        RightElbowText.text = "The right elbow is: " + _rightElbowAngle.ToString();
        RightShoulderText.text = "The right shoulder angle is: " + _rightShoulderAngle.ToString();

    }

    void UpdateJoints()
    {
        // For each Kinect Joint...
        foreach (var joint in kinectJointTypeToHumanBodyBone.Keys)
        {
            avatarBones[(int)joint].rotation = jointOrientations[(int)joint];
        }
    }

    // Manipulate the kinect quaternions on a per-joint basis to unite the orientation data under a common coordinate system.
    private Quaternion ManipulateKinectJointOrientation(Quaternion kinectQuaternion, Windows.Kinect.JointType jointType)
    {
        var euler = kinectQuaternion.eulerAngles;
        if (jointManipulations.ContainsKey(jointType))
        {
            var jointManipulation = jointManipulations[jointType];
            euler = new Vector3(euler.x * jointManipulation.Sign.x + jointManipulation.Offset.x,
                euler.y * jointManipulation.Sign.y + jointManipulation.Offset.y,
                euler.z * jointManipulation.Sign.z + jointManipulation.Offset.z);
            if (jointManipulation.SwapXAndZ)
            {
                euler = new Vector3(euler.z, euler.y, euler.x);
            }
        }

        return Quaternion.Euler(euler);
    }

    // Find the pattern and you win a prize.
    private void InitializeJointManipulationData()
    {
        jointManipulations = new Dictionary<Windows.Kinect.JointType, JointManipulation>();
        var jointManipulation = new JointManipulation();

        jointManipulation.Offset = new Vector3(0, 180, 90);
        jointManipulation.Sign = new Vector3(1, -1, -1);
        jointManipulation.SwapXAndZ = false;
        jointManipulations.Add(Windows.Kinect.JointType.WristRight, jointManipulation);

        jointManipulation.Offset = new Vector3(0, 180, -90);
        jointManipulation.Sign = new Vector3(1, -1, -1);
        jointManipulation.SwapXAndZ = false;
        jointManipulations.Add(Windows.Kinect.JointType.WristLeft, jointManipulation);

        jointManipulation.Offset = new Vector3(0, 180, 90);
        jointManipulation.Sign = new Vector3(1, -1, -1);
        jointManipulation.SwapXAndZ = false;
        jointManipulations.Add(Windows.Kinect.JointType.HandRight, jointManipulation);

        jointManipulation.Offset = new Vector3(180, 0, 90);
        jointManipulation.Sign = new Vector3(-1, -1, -1);
        jointManipulation.SwapXAndZ = false;
        jointManipulations.Add(Windows.Kinect.JointType.HandLeft, jointManipulation);

        jointManipulation.Offset = new Vector3(0, 0, 90);
        jointManipulation.Sign = new Vector3(-1, -1, 1);
        jointManipulation.SwapXAndZ = false;
        jointManipulations.Add(Windows.Kinect.JointType.ElbowRight, jointManipulation);

        jointManipulation.Offset = new Vector3(0, 0, -90);
        jointManipulation.Sign = new Vector3(-1, -1, 1);
        jointManipulation.SwapXAndZ = false;
        jointManipulations.Add(Windows.Kinect.JointType.ElbowLeft, jointManipulation);

        jointManipulation.Offset = new Vector3(180, 0, -90);
        jointManipulation.Sign = new Vector3(-1, -1, -1);
        jointManipulation.SwapXAndZ = false;
        jointManipulations.Add(Windows.Kinect.JointType.ShoulderRight, jointManipulation);

        jointManipulation.Offset = new Vector3(0, 180, -90);
        jointManipulation.Sign = new Vector3(1, -1, -1);
        jointManipulation.SwapXAndZ = false;
        jointManipulations.Add(Windows.Kinect.JointType.ShoulderLeft, jointManipulation);

        jointManipulation.Offset = new Vector3(0, 180, 0);
        jointManipulation.Sign = new Vector3(1, -1, -1);
        jointManipulation.SwapXAndZ = false;
        jointManipulations.Add(Windows.Kinect.JointType.SpineShoulder, jointManipulation);

        jointManipulation.Offset = new Vector3(0, 180, 0);
        jointManipulation.Sign = new Vector3(1, -1, -1);
        jointManipulation.SwapXAndZ = false;
        jointManipulations.Add(Windows.Kinect.JointType.SpineMid, jointManipulation);

        jointManipulation.Offset = new Vector3(0, 180, 0);
        jointManipulation.Sign = new Vector3(1, -1, -1);
        jointManipulation.SwapXAndZ = false;
        jointManipulations.Add(Windows.Kinect.JointType.Neck, jointManipulation);

        jointManipulation.Offset = new Vector3(0, -180, 0);
        jointManipulation.Sign = new Vector3(1, -1, -1);
        jointManipulation.SwapXAndZ = false;
        jointManipulations.Add(Windows.Kinect.JointType.SpineBase, jointManipulation);

        jointManipulation.Offset = new Vector3(0, 180, 90);
        jointManipulation.Sign = new Vector3(1, -1, -1);
        jointManipulation.SwapXAndZ = false;
        jointManipulations.Add(Windows.Kinect.JointType.HipRight, jointManipulation);

        jointManipulation.Offset = new Vector3(0, 180, -90);
        jointManipulation.Sign = new Vector3(1, -1, -1);
        jointManipulation.SwapXAndZ = false;
        jointManipulations.Add(Windows.Kinect.JointType.HipLeft, jointManipulation);

        jointManipulation.Offset = new Vector3(0, 90, 180);
        jointManipulation.Sign = new Vector3(-1, -1, -1);
        jointManipulation.SwapXAndZ = true;
        jointManipulations.Add(Windows.Kinect.JointType.KneeRight, jointManipulation);

        jointManipulation.Offset = new Vector3(180, 90, 0);
        jointManipulation.Sign = new Vector3(1, -1, -1);
        jointManipulation.SwapXAndZ = true;
        jointManipulations.Add(Windows.Kinect.JointType.KneeLeft, jointManipulation);

        jointManipulation.Offset = new Vector3(180, -90, 0);
        jointManipulation.Sign = new Vector3(-1, -1, 1);
        jointManipulation.SwapXAndZ = true;
        jointManipulations.Add(Windows.Kinect.JointType.AnkleRight, jointManipulation);

        jointManipulation.Offset = new Vector3(0, -90, 180);
        jointManipulation.Sign = new Vector3(1, -1, 1);
        jointManipulation.SwapXAndZ = true;
        jointManipulations.Add(Windows.Kinect.JointType.AnkleLeft, jointManipulation);
    }

    // Used to unite the kinect joint orientations under a common coordinate system.
    private struct JointManipulation
    {
        public Vector3 Offset;
        public Vector3 Sign;
        public bool SwapXAndZ;
    };
}
