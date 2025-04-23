using solarxr_protocol.datatypes;
using solarxr_protocol.datatypes.math;
using System.Collections.Generic;
using UnityEngine;

public class Skeleton : MonoBehaviour
{
    public GameObject Networking;
    public bool HideHead = false;
    public Material BoneMaterial;

    private const float BoneRadius = 0.025f;

    private readonly Dictionary<BodyPart, GameObject> boneObjects = new();

    void Update()
    {
        if (!Networking.TryGetComponent<SlimeVRClient>(out var slimeVRClient))
        {
            return;
        }

        var maybeSkeleton = slimeVRClient.Skeleton;
        if (!maybeSkeleton.HasValue)
        {
            return;
        }

        var skeletonToCameraTransform = slimeVRClient.SkeletonToCameraTransform;
        if (skeletonToCameraTransform == null)
        {
            return;
        }

        var skeleton = maybeSkeleton.Value;

        for (var i = 0; i < skeleton.BonesLength; ++i)
        {
            var optionalBone = skeleton.Bones(i);
            if (!optionalBone.HasValue)
            {
                continue;
            }

            var bone = optionalBone.Value;

            if (bone.BodyPart == BodyPart.NONE ||
                (HideHead && bone.BodyPart == BodyPart.HEAD))
            {
                continue;
            }


            var bodyPart = bone.BodyPart.ToString();
            if (bodyPart.EndsWith("METACARPAL") ||
                bodyPart.EndsWith("PROXIMAL") ||
                bodyPart.EndsWith("DISTAL") ||
                bodyPart.EndsWith("INTERMEDIATE"))
            {
                continue;
            }

            if (!boneObjects.TryGetValue(bone.BodyPart, out var boneObject))
            {
                boneObject = new GameObject();
                boneObject.name = "BONE_" + bone.BodyPart.ToString();
                boneObject.transform.parent = transform;

                var cylinderObject = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
                cylinderObject.transform.parent = boneObject.transform;
                cylinderObject.GetComponent<Renderer>().material = BoneMaterial;

                boneObjects.Add(bone.BodyPart, boneObject);
            }

            if (bone.HeadPositionG.HasValue && bone.RotationG.HasValue)
            {
                boneObject.transform.SetLocalPositionAndRotation(
                    RHSToLHSVector3(bone.HeadPositionG.Value)
                        - (bone.BoneLength * 0.5f) * (RHSToLHSQuaternion(bone.RotationG.Value) * Vector3.up)
                        - skeletonToCameraTransform.Translation,
                    RHSToLHSQuaternion(bone.RotationG.Value));

                var cylinderTransform = boneObject.transform.GetChild(0);
                cylinderTransform.localScale = new Vector3(BoneRadius, bone.BoneLength * 0.5f, BoneRadius);

                boneObject.SetActive(true);
            }
            else
            {
                boneObject.SetActive(false);
            }
        }

        for (int i = 0; i < skeleton.DevicesLength; i++)
        {
            var optionalDevice = skeleton.Devices(i);
            if (!optionalDevice.HasValue)
            {
                continue;
            }

            var device = optionalDevice.Value;
            for (int j = 0; j < device.TrackersLength; ++j)
            {
                var optionalTracker = device.Trackers(j);
                if (!optionalTracker.HasValue)
                {
                    continue;
                }

                var tracker = optionalTracker.Value;
                if (tracker.Status != TrackerStatus.OK || !tracker.Info.HasValue)
                {
                    continue;
                }

                var trackerBodyPart = tracker.Info.Value.BodyPart;
                if (trackerBodyPart == BodyPart.NONE ||
                    (HideHead && trackerBodyPart == BodyPart.HEAD))
                {
                    continue;
                }
            }
        }

        for (int i = 0; i < skeleton.SyntheticTrackersLength; i++)
        {
            var optionalTracker = skeleton.SyntheticTrackers(i);
            if (!optionalTracker.HasValue)
            {
                continue;
            }

            var tracker = optionalTracker.Value;
            if (tracker.Status != TrackerStatus.OK || !tracker.Info.HasValue)
            {
                continue;
            }

            var trackerBodyPart = tracker.Info.Value.BodyPart;
            if (trackerBodyPart == BodyPart.NONE ||
                (HideHead && trackerBodyPart == BodyPart.HEAD))
            {
                continue;
            }
        }
    }

    private static Vector3 RHSToLHSVector3(Vec3f v)
    {
        return new Vector3(v.X, v.Y, -v.Z);
    }

    private static Quaternion RHSToLHSQuaternion(Quat q)
    {
        return new Quaternion(q.X, q.Y, -q.Z, -q.W);
    }
}
