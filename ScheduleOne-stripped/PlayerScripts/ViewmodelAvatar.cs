using System.Collections.Generic;
using ScheduleOne.AvatarFramework;
using ScheduleOne.Core.Avatar;
using ScheduleOne.DevUtilities;
using UnityEngine;
using UnityEngine.Rendering;

namespace ScheduleOne.PlayerScripts;
public class ViewmodelAvatar : Singleton<ViewmodelAvatar>
{
    private const float ViewmodelHeight;
    [SerializeField]
    private float ArmShift;
    public ScheduleOne.AvatarFramework.Avatar ParentAvatar;
    public Animator Animator;
    public ScheduleOne.AvatarFramework.Avatar Avatar;
    public Transform RightHandContainer;
    public bool IsVisible { get; private set; }

    protected override void Awake();
    public void SetVisibility(bool isVisible);
    private void LateUpdate();
    private void SetBoneTransforms();
    private void SetNakedAppearance(NakedAppearance appearance);
    private void SetOutfit(List<SerializedAvatarObject> outfit);
    private void ApplyViewmodelMeshSettings();
    public void SetAnimatorController(RuntimeAnimatorController controller);
    public void SetOffset(Vector3 offset);
    public void SetRotationOffset(Vector3 eulerAngles);
}