using ScheduleOne.Core.Avatar;
using UnityEngine;

namespace ScheduleOne.Avatar;
public class AttachmentAnchorProviderComponent : MonoBehaviour, IAttachmentAnchorProvider
{
    [SerializeField]
    private SkinnedMeshRenderer _bonesProvider;
    [field: SerializeField]
    public Transform Hips { get; private set; }

    [field: SerializeField]
    public Transform LowerSpine { get; private set; }

    [field: SerializeField]
    public Transform MiddleSpine { get; private set; }

    [field: SerializeField]
    public Transform UpperSpine { get; private set; }

    [field: SerializeField]
    public Transform Neck { get; private set; }

    [field: SerializeField]
    public Transform Head { get; private set; }

    [field: SerializeField]
    public Transform RightShoulder { get; private set; }

    [field: SerializeField]
    public Transform RightUpperArm { get; private set; }

    [field: SerializeField]
    public Transform RightLowerArm { get; private set; }

    [field: SerializeField]
    public Transform RightHand { get; private set; }

    [field: SerializeField]
    public Transform LeftShoulder { get; private set; }

    [field: SerializeField]
    public Transform LeftUpperArm { get; private set; }

    [field: SerializeField]
    public Transform LeftLowerArm { get; private set; }

    [field: SerializeField]
    public Transform LeftHand { get; private set; }

    [field: SerializeField]
    public Transform RightUpperLeg { get; private set; }

    [field: SerializeField]
    public Transform RightLowerLeg { get; private set; }

    [field: SerializeField]
    public Transform RightFoot { get; private set; }

    [field: SerializeField]
    public Transform LeftUpperLeg { get; private set; }

    [field: SerializeField]
    public Transform LeftLowerLeg { get; private set; }

    [field: SerializeField]
    public Transform LeftFoot { get; private set; }

    public Transform[] GetBones();
}