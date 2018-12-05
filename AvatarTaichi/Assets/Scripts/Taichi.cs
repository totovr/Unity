using UnityEngine;
using System.Collections;
using Windows.Kinect;
using System.Collections.Generic;
using System.Linq;

public class Taichi : MonoBehaviour
{

    public bool IsMirror = true;

    public BodySourceManager _BodyManager;
    public GameObject _Avatar;

    public GameObject Ref;
    public GameObject Hips;
    public GameObject LeftUpLeg;
    public GameObject LeftLeg;
    public GameObject RightUpLeg;
    public GameObject RightLeg;
    public GameObject Spine1;
    public GameObject Spine2;
    public GameObject LeftShoulder;
    public GameObject LeftArm;
    public GameObject LeftForeArm;
    public GameObject LeftHand;
    public GameObject RightShoulder;
    public GameObject RightArm;
    public GameObject RightForeArm;
    public GameObject RightHand;
    public GameObject Neck;
    public GameObject Head;


    // Use this for initialization
    void Start()
    {
        Ref = _Avatar.transform.Find("PelvisRoot").gameObject;

        Hips = Ref.gameObject.transform.Find("Hips").gameObject;
        LeftUpLeg = Hips.transform.Find("LeftUpLeg").gameObject;
        LeftLeg = LeftUpLeg.transform.Find("LeftLeg").gameObject;
        RightUpLeg = Hips.transform.Find("RightUpLeg").gameObject;
        RightLeg = RightUpLeg.transform.Find("RightLeg").gameObject;
        Spine1 = Hips.transform.Find("Spine").gameObject.transform.Find("Spine1").gameObject;
        Spine2 = Spine1.transform.Find("Spine2").gameObject;
        LeftShoulder = Spine2.transform.Find("Spine3").gameObject.transform.Find("LeftShoulder").gameObject;
        LeftArm = LeftShoulder.transform.Find("LeftArm").gameObject;
        LeftForeArm = LeftArm.transform.Find("LeftArmRoll").gameObject.transform.Find("LeftForeArm").gameObject;
        LeftHand = LeftForeArm.transform.Find("LeftForeArmRoll").gameObject.transform.Find("LeftHand").gameObject;
        RightShoulder = Spine2.transform.Find("Spine3").gameObject.transform.Find("RightShoulder").gameObject;
        RightArm = RightShoulder.transform.Find("RightArm").gameObject;
        RightForeArm = RightArm.transform.Find("RightArmRoll").gameObject.transform.Find("RightForeArm").gameObject;
        RightHand = RightForeArm.transform.Find("RightForeArmRoll").gameObject.transform.Find("RightHand").gameObject;
        Neck = Spine2.transform.Find("Spine3").gameObject.transform.Find("Neck").gameObject;
        Head = Neck.transform.Find("Head").gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if (_BodyManager == null)
        {
            Debug.Log("_BodyManager == null");
            return;
        }

        //  Track the user 
        var data = _BodyManager.GetData();

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

        // Obtein the plane 
        var floorPlane = _BodyManager.FloorClipPlane;
        var comp = Quaternion.FromToRotation(new Vector3(floorPlane.X, floorPlane.Y, floorPlane.Z), Vector3.up);

        // Hold the data of the orientation of the body joints 
        var joints = body.JointOrientations;

        Quaternion SpineBase;
        Quaternion SpineMid;
        Quaternion SpineShoulder;
        Quaternion ShoulderLeft;
        Quaternion ShoulderRight;
        Quaternion ElbowLeft;
        Quaternion WristLeft;
        Quaternion HandLeft;
        Quaternion ElbowRight;
        Quaternion WristRight;
        Quaternion HandRight;
        Quaternion KneeLeft;
        Quaternion AnkleLeft;
        Quaternion KneeRight;
        Quaternion AnkleRight;

        // Check if the mirror is activated 
        if (IsMirror)
        {
            SpineBase = joints[JointType.SpineBase].Orientation.ToMirror().ToQuaternion(comp);
            SpineMid = joints[JointType.SpineMid].Orientation.ToMirror().ToQuaternion(comp);
            SpineShoulder = joints[JointType.SpineShoulder].Orientation.ToMirror().ToQuaternion(comp);
            ShoulderLeft = joints[JointType.ShoulderRight].Orientation.ToMirror().ToQuaternion(comp);
            ShoulderRight = joints[JointType.ShoulderLeft].Orientation.ToMirror().ToQuaternion(comp);
            ElbowLeft = joints[JointType.ElbowRight].Orientation.ToMirror().ToQuaternion(comp);
            WristLeft = joints[JointType.WristRight].Orientation.ToMirror().ToQuaternion(comp);
            HandLeft = joints[JointType.HandRight].Orientation.ToMirror().ToQuaternion(comp);
            ElbowRight = joints[JointType.ElbowLeft].Orientation.ToMirror().ToQuaternion(comp);
            WristRight = joints[JointType.WristLeft].Orientation.ToMirror().ToQuaternion(comp);
            HandRight = joints[JointType.HandLeft].Orientation.ToMirror().ToQuaternion(comp);
            KneeLeft = joints[JointType.KneeRight].Orientation.ToMirror().ToQuaternion(comp);
            AnkleLeft = joints[JointType.AnkleRight].Orientation.ToMirror().ToQuaternion(comp);
            KneeRight = joints[JointType.KneeLeft].Orientation.ToMirror().ToQuaternion(comp);
            AnkleRight = joints[JointType.AnkleLeft].Orientation.ToMirror().ToQuaternion(comp);
        }
        // If not
        else
        {
            SpineBase = joints[JointType.SpineBase].Orientation.ToQuaternion(comp);
            SpineMid = joints[JointType.SpineMid].Orientation.ToQuaternion(comp);
            SpineShoulder = joints[JointType.SpineShoulder].Orientation.ToQuaternion(comp);
            ShoulderLeft = joints[JointType.ShoulderLeft].Orientation.ToQuaternion(comp);
            ShoulderRight = joints[JointType.ShoulderRight].Orientation.ToQuaternion(comp);
            ElbowLeft = joints[JointType.ElbowLeft].Orientation.ToQuaternion(comp);
            WristLeft = joints[JointType.WristLeft].Orientation.ToQuaternion(comp);
            HandLeft = joints[JointType.HandLeft].Orientation.ToQuaternion(comp);
            ElbowRight = joints[JointType.ElbowRight].Orientation.ToQuaternion(comp);
            WristRight = joints[JointType.WristRight].Orientation.ToQuaternion(comp);
            HandRight = joints[JointType.HandRight].Orientation.ToQuaternion(comp);
            KneeLeft = joints[JointType.KneeLeft].Orientation.ToQuaternion(comp);
            AnkleLeft = joints[JointType.AnkleLeft].Orientation.ToQuaternion(comp);
            KneeRight = joints[JointType.KneeRight].Orientation.ToQuaternion(comp);
            AnkleRight = joints[JointType.AnkleRight].Orientation.ToQuaternion(comp);
        }

        // Calculate the rotation of the joints 
        var q = transform.rotation;
        transform.rotation = Quaternion.identity;

        var comp2 = Quaternion.AngleAxis(90, new Vector3(0, 1, 0)) *
                    Quaternion.AngleAxis(-90, new Vector3(0, 0, 1));

        Spine1.transform.rotation = SpineMid * comp2;

        RightArm.transform.rotation = ElbowRight * comp2;
        RightForeArm.transform.rotation = WristRight * comp2;
        RightHand.transform.rotation = HandRight * comp2;

        LeftArm.transform.rotation = ElbowLeft * comp2;
        LeftForeArm.transform.rotation = WristLeft * comp2;
        LeftHand.transform.rotation = HandLeft * comp2;

        RightUpLeg.transform.rotation = KneeRight * comp2;
        RightLeg.transform.rotation = AnkleRight * comp2;

        LeftUpLeg.transform.rotation = KneeLeft * Quaternion.AngleAxis(-90, new Vector3(0, 0, 1));
        LeftLeg.transform.rotation = AnkleLeft * Quaternion.AngleAxis(-90, new Vector3(0, 0, 1));

        // Set the rotation of the model 
        transform.rotation = q;

        // Move the position of the joints 
        var pos = body.Joints[JointType.SpineMid].Position;
        Ref.transform.position = new Vector3(-pos.X, pos.Y, -pos.Z);
    }
}
