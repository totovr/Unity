using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RigControl3 : MonoBehaviour {

    public GameObject humanoid;
    public Vector3 bodyRotation = new Vector3(0, 0, 0);
    public Bone bone = Bone.LeftUpperArm;
    public float angle = 0;
    public float axisX = 0.0f;
    public float axisY = 1.0f;
    public float axisZ = 0.0f;
    Dictionary<Bone, RigBone> rigBones;

    // Variables for each joint
    public enum Bone
    {
        Hips,
        Spine,
        Chest,        // optional
        UpperChest,   // optional
        Neck,         // optional
        Head,
        LeftShoulder, // optional
        LeftUpperArm,
        LeftLowerArm,
        LeftHand,
        LeftUpperLeg,
        LeftLowerLeg,
        LeftFoot,
        RightShoulder, // optional
        RightUpperArm,
        RightLowerArm,
        RightHand,
        RightUpperLeg,
        RightLowerLeg,
        RightFoot
    }

    private Dictionary<Bone, HumanBodyBones> bodyBones = new Dictionary<Bone, HumanBodyBones>() {
    { Bone.Hips, HumanBodyBones.Hips },
    { Bone.Spine, HumanBodyBones.Spine },
    { Bone.Chest, HumanBodyBones.Chest },
    { Bone.UpperChest, HumanBodyBones.UpperChest },
    { Bone.Neck, HumanBodyBones.Neck },
    { Bone.Head, HumanBodyBones.Head },
    { Bone.LeftShoulder, HumanBodyBones.LeftShoulder },
    { Bone.LeftUpperArm, HumanBodyBones.LeftUpperArm },
    { Bone.LeftLowerArm, HumanBodyBones.LeftLowerArm },
    { Bone.LeftHand, HumanBodyBones.LeftHand },
    { Bone.LeftUpperLeg, HumanBodyBones.LeftUpperLeg },
    { Bone.LeftLowerLeg, HumanBodyBones.LeftLowerLeg },
    { Bone.LeftFoot, HumanBodyBones.LeftFoot },
    { Bone.RightShoulder, HumanBodyBones.RightShoulder },
    { Bone.RightUpperArm, HumanBodyBones.RightUpperArm },
    { Bone.RightLowerArm, HumanBodyBones.RightLowerArm },
    { Bone.RightHand, HumanBodyBones.RightHand },
    { Bone.RightUpperLeg, HumanBodyBones.RightUpperLeg },
    { Bone.RightLowerLeg, HumanBodyBones.RightLowerLeg },
    { Bone.RightFoot, HumanBodyBones.RightFoot }
  };

    // Use this for initialization
    void Start () {

        rigBones = new Dictionary<Bone, RigBone>();

        foreach (Bone b in Enum.GetValues(typeof(Bone)))
        {
            rigBones.Add(b, new RigBone(humanoid, bodyBones[b]));
        }

    }
	
	// Update is called once per frame
	void Update () {

        if (rigBones[bone].isValid == false) return;

        rigBones[bone].offset(angle, axisX, axisY, axisZ);

        humanoid.transform.rotation
          = Quaternion.AngleAxis(bodyRotation.z, new Vector3(0, 0, 1))
          * Quaternion.AngleAxis(bodyRotation.x, new Vector3(1, 0, 0))
          * Quaternion.AngleAxis(bodyRotation.y, new Vector3(0, 1, 0));

    }
}
