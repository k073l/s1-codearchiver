using UnityEngine;

namespace ScheduleOne.Core.Avatar;
public class SkinnedAvatarAttachment : AvatarAttachment
{
    [SerializeField]
    protected SkinnedMeshRenderer[] _skinnedMeshes;
    [SerializeField]
    protected SkinnedMeshRenderer[] _shapeKeySkinnedMeshes;
    public override void Initialize(AvatarObject parent, IAttachmentAnchorProvider anchorProvider);
    public override void ApplyGender(float gender);
    public override void ApplyWeight(float weight);
}