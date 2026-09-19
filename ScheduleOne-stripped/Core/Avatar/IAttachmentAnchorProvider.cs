using UnityEngine;

namespace ScheduleOne.Core.Avatar;
public interface IAttachmentAnchorProvider
{
    Transform Hips { get; }

    Transform LowerSpine { get; }

    Transform MiddleSpine { get; }

    Transform UpperSpine { get; }

    Transform Neck { get; }

    Transform Head { get; }

    Transform RightShoulder { get; }

    Transform RightUpperArm { get; }

    Transform RightLowerArm { get; }

    Transform RightHand { get; }

    Transform LeftShoulder { get; }

    Transform LeftUpperArm { get; }

    Transform LeftLowerArm { get; }

    Transform LeftHand { get; }

    Transform RightUpperLeg { get; }

    Transform RightLowerLeg { get; }

    Transform RightFoot { get; }

    Transform LeftUpperLeg { get; }

    Transform LeftLowerLeg { get; }

    Transform LeftFoot { get; }

    Transform[] GetBones();
    Transform GetAnchor(EAttachmentAnchor anchor);
}