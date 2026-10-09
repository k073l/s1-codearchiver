using UnityEngine;

namespace ScheduleOne.Core.Avatar;
public class AvatarAttachment : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField]
    protected EAttachmentAnchor _anchor;
    [SerializeField]
    protected Transform _alignmentPoint;
    private AvatarObject _avatarObject;
    public EAttachmentAnchor Anchor => _anchor;
    public AvatarObject Parent => _avatarObject;

    public virtual void Initialize(AvatarObject parent, IAttachmentAnchorProvider anchorProvider);
    public virtual void SetEnabled(bool enabled);
    public virtual void Destroy();
    public virtual void ApplyGender(float gender);
    public virtual void ApplyWeight(float weight);
    private void AnchorAndAlignTo(IAttachmentAnchorProvider anchorProvider);
    [Button("CreateAlignmentPoint", "!_alignmentPoint")]
    public void CreateAlignmentPoint();
}